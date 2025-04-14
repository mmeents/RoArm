using System;
using System.Xml.Linq;
using RoArmDriver.Core;
using RoArmDriver.Core.Models;
using RoArmDriver.Core.Services;

namespace RoArmDriver.App
{
  public partial class Form1 : Form, ISupportFeedback {
    private const string IpAddress = "10.0.0.65";
    private readonly ArmDriver _driver;
    private readonly ArmControlState _controlState;
    private readonly TrackBar[] _jointTrackBars;
    private readonly Label[] _jointStatusLabels;
    private readonly Dictionary<string, object> _pendingMoves;
    private int _currentJointIndex = 0;
    private double _currentJointRads = 0.0;
    private bool _inUpdate = false;

    public Form1()
    {
      InitializeComponent();
      _driver = new ArmDriver($"http://{IpAddress}", this);
      _controlState = new ArmControlState();
      _jointTrackBars = new TrackBar[] { tbBase, tbShoulder, tbElbow, tbWrist, tbRoll, tbHand, tbLamp, tbX, tbY, tbZ, tbTilt };
      _jointStatusLabels = new Label[] { lbBase, lbShoulder, lbElbow, lbWrist, lbRoll, lbHand, lbLamp, lbX, lbY, lbZ, lbTilt };
      _pendingMoves = new Dictionary<string, object>();
      foreach (var trackBar in _jointTrackBars) {
        trackBar.ValueChanged += JointTrackBar_ValueChange;
      }
      _driver.StateService.StateUpdated += (sender, state) => {
        _controlState.UpdateCurrentState(state);
        UpdateUI();
      };      
    }

    #region ISupportFeedback interface methods.
    delegate void SetLogMsgCallback(string msg);
    public void LogMsg(string msg) {
      if (this.edLog.InvokeRequired) {
        SetLogMsgCallback d = new SetLogMsgCallback(LogMsg);
        this.BeginInvoke(d, new object[] { msg });
      } else {
        if (!edLog.Visible) edLog.Visible = true;
        this.edLog.Text = msg + Environment.NewLine + edLog.Text;
      }
    }

    delegate void UpdateUICallback(string notUsed);
    public void UpdateUI(string notUsed = "") {
      if (this.edLog.InvokeRequired) {
        UpdateUICallback d = new UpdateUICallback(UpdateUI);
        this.BeginInvoke(d, new object[] { notUsed });
      } else {
        _inUpdate = true;
        var state = _controlState.CurrentState;
        var target = _controlState.TargetJoints;
        var targetCartesian = _controlState.TargetCartesian;
        var isMoving = _driver.StateService.IsMoving;
        var statusText = $"Status: {(isMoving ? "Moving" : "Stopped")} | At Target: {_controlState.IsAtTarget()}";

        // Update joint trackbars and labels
        var jointNames = new[] { "Base", "Shoulder", "Elbow", "Wrist", "Roll", "Hand" };
        var jointValues = new[] { state.Joints.Base, state.Joints.Shoulder, state.Joints.Elbow, state.Joints.Wrist, state.Joints.Roll, state.Joints.Hand };
        var targetValues = new[] { target.Base, target.Shoulder, target.Elbow, target.Wrist, target.Roll, target.Hand };        

        for (int i = 0; i < 6; i++) {
          if (!_jointTrackBars[i].Focused) _jointTrackBars[i].Value = Math.Clamp( jointValues[i].ToDegrees(), _jointTrackBars[i].Minimum, _jointTrackBars[i].Maximum);          
          _jointStatusLabels[i].Text = $"{jointNames[i]}: {jointValues[i].ToDegrees():F1}° (T: {targetValues[i].ToDegrees():F1}°) | Range: {_jointTrackBars[i].Minimum}° to {_jointTrackBars[i].Maximum}°";
          _jointStatusLabels[i].ForeColor = Math.Abs(jointValues[i] - targetValues[i]) > 0.1 && !isMoving ? Color.Red : Color.Black;
        }

        var cartesian = state.Cartesian;
        if (!_jointTrackBars[7].Focused) tbX.Value = (int)Math.Round(Math.Clamp(cartesian.X, tbX.Minimum, tbX.Maximum));
        if (!_jointTrackBars[8].Focused) tbY.Value = (int)Math.Round(Math.Clamp(cartesian.Y, tbY.Minimum, tbY.Maximum));
        if (!_jointTrackBars[9].Focused) tbZ.Value = (int)Math.Round(Math.Clamp(cartesian.Z, tbZ.Minimum, tbZ.Maximum));
        if (!_jointTrackBars[10].Focused) tbTilt.Value = Math.Clamp(cartesian.Tilt.ToDegrees(), tbTilt.Minimum, tbTilt.Maximum);

        lbX.Text = $"X: {cartesian.X:F1}mm (T: {targetCartesian.X:F1}mm) | Range: {tbX.Minimum} to {tbX.Maximum}mm";
        lbY.Text = $"Y: {cartesian.Y:F1}mm (T: {targetCartesian.Y:F1}mm) | Range: {tbY.Minimum} to {tbY.Maximum}mm";
        lbZ.Text = $"Z: {cartesian.Z:F1}mm (T: {targetCartesian.Z:F1}mm) | Range: {tbZ.Minimum} to {tbZ.Maximum}mm";
        lbTilt.Text = $"Tilt: {cartesian.Tilt.ToDegrees():F1}° (T: {targetCartesian.Tilt.ToDegrees():F1}°) | Range: {tbTilt.Minimum}° to {tbTilt.Maximum}°";


        lbStatus.Text = statusText;
        _inUpdate = false;
      }
    }
    #endregion

    private async void JointTrackBar_ValueChange(object sender, EventArgs e) {
      if (sender is TrackBar trackBar && !_inUpdate) {
        debounceTimer.Stop();
        var name = trackBar.Name;
        if (name == "tbLamp") // Light
        {
          _pendingMoves[name] = trackBar.Value;
        //  LogMsg($"TrackBar Light: {trackBar.Value}");
        } else if (name.StartsWith("tb") && Enum.TryParse<Joint>(name[2..], out var joint)) {
          var radians = trackBar.Value.ToRadians();
          _controlState.UpdateTargetJoint(joint, radians);
          _pendingMoves[name] = new JointCommand(101, joint, radians, 4, 5);
        //  LogMsg($"TrackBar {joint}: {trackBar.Value}° ({radians:F2} rad)");
        } else if (name is "tbX" or "tbY" or "tbZ" or "tbTilt") {
          var cartesian = _controlState.TargetCartesian;
          var newCartesian = name switch {
            "tbX" => cartesian with { X = trackBar.Value },
            "tbY" => cartesian with { Y = trackBar.Value },
            "tbZ" => cartesian with { Z = trackBar.Value },
            "tbTilt" => cartesian with { Tilt = trackBar.Value.ToRadians() },
            _ => cartesian
          };
          _controlState.UpdateTargetCartesian(newCartesian.X, newCartesian.Y, newCartesian.Z, newCartesian.Tilt);
          var roll = _controlState.CurrentState.Joints.Roll;
          _pendingMoves[name] = new CartesianCommand(104, newCartesian.X.ToInt(), newCartesian.Y.ToInt(), newCartesian.Z.ToInt(), newCartesian.Tilt, roll, 4, 3);
        //  LogMsg($"TrackBar {name[2..]}: {trackBar.Value}{(name == "tbTilt" ? "°" : "mm")}");
        }
        UpdateUI();   
        debounceTimer.Start();     
      }
    }

    private async void debounceTimer_Tick(object sender, EventArgs e) {
      debounceTimer.Stop();
      foreach (var (name, command) in _pendingMoves) {
        if (name == "tbLamp") {
          var brightness = (int)command;
          LogMsg($"Debounced: Setting Light to {brightness}");
          await _driver.MotionService.SetLampAsync(brightness); 
        } else if (command is JointCommand jc) {
          LogMsg($"Debounced: Moving {jc.Joint} to {jc.Radians:F2} rad");
          await _driver.MotionService.MoveJointAsync(jc.Joint, jc.Radians, jc.Speed, jc.Acceleration);
        } else if (command is CartesianCommand cc) {
          LogMsg($"Debounced: Moving to X={cc.X}, Y={cc.Y}, Z={cc.Z}, Tilt={cc.Tilt}, Roll={cc.Roll} rad, ");
          await _driver.MotionService.MoveCartesianAsync(cc.X, cc.Y, cc.Z, cc.Tilt, cc.Roll, cc.Speed, 3);
        }
      }

      _pendingMoves.Clear();
      UpdateUI();
    }

    

  }
}
