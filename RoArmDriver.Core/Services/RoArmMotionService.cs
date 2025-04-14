using RoArmDriver.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoArmDriver.Core.Services
{
    public class RoArmMotionService : IDisposable
    {

      private readonly CommandQueue _queue;
      private readonly RoArmStateService _stateService;
      private readonly ISupportFeedback _feedback;

      public bool IsMoving => _stateService.IsMoving;
      public ArmState CurrentState => _stateService.LastState; // Expose for calibration checks

      public event EventHandler<ArmState> StateUpdated {
        add => _stateService.StateUpdated += value;
        remove => _stateService.StateUpdated -= value;
      }

      public RoArmMotionService(string baseUrl, RoArmStateService stateService, HttpClient client, ISupportFeedback feedback) {
        _queue = new CommandQueue(baseUrl, client, feedback);
        _stateService = stateService;
        _feedback = feedback;
      }

      // Existing movement methods (unchanged)
      public async Task InitializeAsync() => await _queue.EnqueueAsync(new InitializeCommand());
      
      public async Task MoveJointAsync(Joint joint, double radians, double speed = 0, double acceleration = 10) {
        _feedback?.LogMsg($"Queueing MoveJoint: Joint={joint}, Radians={radians:F1}, Speed={speed:F2} rad/s, Acceleration={acceleration:F2} rad/s²");
        await _queue.EnqueueAsync(new JointCommand(101, joint, radians, speed, acceleration));
      }

      public async Task MoveJointsAsync(double baseRad, double shoulderRad, double elbowRad, double wristRad, double rollRad, double handRad, double speed = 0, double acceleration = 10) { 
        _feedback?.LogMsg($"Queueing MoveJoints: Base={baseRad:F1}, Shoulder={shoulderRad:F1}, Elbow={elbowRad:F1}, Wrist={wristRad:F1}, Roll={rollRad:F1}, Hand={handRad:F1}, Speed={speed:F2} rad/s, Acceleration={acceleration:F2} rad/s²");
        await _queue.EnqueueAsync(new JointsCommand(102, baseRad, shoulderRad, elbowRad, wristRad, rollRad, handRad, speed, acceleration));
      }

      public async Task MoveCartesianAsync(double x, double y, double z, double tilt, double roll, double gripper, double speed = 0.25) {
        _feedback?.LogMsg($"Queueing MoveCartesian: X={x:F1}, Y={y:F1}, Z={z:F1}, Tilt={tilt:F2} rad, Gripper={gripper:F2}, Speed={speed:F2}");
        await _queue.EnqueueAsync(new CartesianCommand(104, x, y, z, tilt, roll, gripper, speed));
      }

      public async Task JogAsync(MovementMode mode, int axis, int direction, double speed = 3) {
        _feedback?.LogMsg($"Queueing Jog: Mode={mode}, Axis={axis}, Direction={direction}, Speed={speed:F2}");
        await _queue.EnqueueAsync(new JogCommand(123, mode, axis, direction, speed));
      }

      public async Task SetGripperAsync(double angle, double speed = 0, double acceleration = 0) =>
          await _queue.EnqueueAsync(new JointCommand(106, Joint.Hand, angle, speed, acceleration));
      public async Task SetTorqueAsync(bool enable) {
        _feedback?.LogMsg($"Queueing SetTorque: Enable={enable}");
        await _queue.EnqueueAsync(new TorqueCommand(210, enable));
      }

      // Calibration methods
      public async Task SetServoIdAsync(int rawId, int newId) =>
          await _queue.EnqueueAsync(new SetServoIdCommand(501, rawId, newId));

      public async Task SetServoMiddleAsync(int servoId) =>
          await _queue.EnqueueAsync(new SetServoMiddleCommand(502, servoId));

      public async Task SetServoPidAsync(int servoId, double p) =>
          await _queue.EnqueueAsync(new SetServoPidCommand(503, servoId, p));

      public async Task SetJointPidAsync(Joint joint, double p, double i = 0) =>
          await _queue.EnqueueAsync(new SetJointPidCommand(108, joint, p, i));

      public async Task ResetPidAsync() =>
          await _queue.EnqueueAsync(new ResetPidCommand(109));
      public async Task SetLampAsync(int led) =>
        await _queue.EnqueueAsync(new SetLamp(114, led));

    public void Dispose() {
        _stateService.Dispose();
        _queue.Dispose();
      }

  }
}
