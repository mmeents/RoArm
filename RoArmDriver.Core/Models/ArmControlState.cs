using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoArmDriver.Core.Models
{
  public class ArmControlState {
    public JointState TargetJoints { get; private set; }
    public CartesianState TargetCartesian { get; private set; }
    public ArmState CurrentState { get; private set; }

    public ArmControlState() {
      TargetJoints = new JointState(0, 0, 0, 0, 0, 0);
      TargetCartesian = new CartesianState(235, 0, 234, 0);
      CurrentState = new ArmState(TargetJoints, TargetCartesian, new TorqueState(0, 0, 0, 0, 0));
    }

    public void UpdateTargetJoint(Joint joint, double radians) {
      TargetJoints = joint switch {
        Joint.Base => TargetJoints with { Base = radians },
        Joint.Shoulder => TargetJoints with { Shoulder = radians },
        Joint.Elbow => TargetJoints with { Elbow = radians },
        Joint.Wrist => TargetJoints with { Wrist = radians },
        Joint.Roll => TargetJoints with { Roll = radians },
        Joint.Hand => TargetJoints with { Hand = radians },
        _ => TargetJoints
      };
    }

    public void UpdateTargetCartesian(double? x = null, double? y = null, double? z = null, double? tilt = null) {
      TargetCartesian = new CartesianState(
          x ?? TargetCartesian.X,
          y ?? TargetCartesian.Y,
          z ?? TargetCartesian.Z,
          tilt ?? TargetCartesian.Tilt
      );
    }

    public void UpdateCurrentState(ArmState state) {
      CurrentState = state;
    }

    public bool IsAtJointsTarget(double tolerance = 0.01) {
      return Math.Abs(CurrentState.Joints.Base - TargetJoints.Base) < tolerance &&
             Math.Abs(CurrentState.Joints.Shoulder - TargetJoints.Shoulder) < tolerance &&
             Math.Abs(CurrentState.Joints.Elbow - TargetJoints.Elbow) < tolerance &&
             Math.Abs(CurrentState.Joints.Wrist - TargetJoints.Wrist) < tolerance &&
             Math.Abs(CurrentState.Joints.Roll - TargetJoints.Roll) < tolerance &&
             Math.Abs(CurrentState.Joints.Hand - TargetJoints.Hand) < tolerance;
    }

    public bool IsAtTarget(double tolerance = 0.01) {
      return Math.Abs(CurrentState.Cartesian.X - TargetCartesian.X) < tolerance &&
             Math.Abs(CurrentState.Cartesian.Y - TargetCartesian.Y) < tolerance &&
             Math.Abs(CurrentState.Cartesian.Z - TargetCartesian.Z) < tolerance &&
             Math.Abs(CurrentState.Cartesian.Tilt - TargetCartesian.Tilt) < tolerance;
    }
  }
}
