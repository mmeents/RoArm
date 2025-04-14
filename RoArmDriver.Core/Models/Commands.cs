using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoArmDriver.Core.Models
{
  public class Command
  {
    [JsonPropertyName("T")]
    public int CommandType { get; set; }
    public Command(int type) {
      CommandType = type;
    }

    public virtual string ToJson() {
      return $"{{\"T\":{CommandType}}}";
    }
  }

  public class InitializeCommand : Command { 
    public InitializeCommand() : base(100) { }
    public InitializeCommand(int type = 100) : base(type) { } 

  }

  public class SetLamp : Command {
    [JsonPropertyName("led")]
    public int Led { get; set; }
    public SetLamp() : base(114) { }
    public SetLamp(int t, int led) : base(t) {
      Led = led;
    }
    public override string ToJson() {
      return $"{{\"T\":{CommandType}, \"led\":{Led}}}";
    }
  }

  public class JointCommand : Command {

    [JsonPropertyName("joint")]
    public Joint Joint { get; set; }
    [JsonPropertyName("rad")]
    public double Radians { get; set; }
    [JsonPropertyName("spd")]
    public double Speed { get; set; }
    [JsonPropertyName("acc")]
    public double Acceleration { get; set; }
    public JointCommand() : base(101) { }

    public JointCommand(int t, Joint joint, double rad, double spd, double acc) : base(t) {
      Joint = joint;
      Radians = rad;
      Speed = spd;
      Acceleration = acc;
    }
    public override string ToJson() {
      return $"{{\"T\":{CommandType}, \"joint\":{(int)Joint}, \"rad\":{Radians}, \"spd\":{Speed}, \"acc\":{Acceleration}}}";
    }
  }

  public class JointsCommand : Command {

    [JsonPropertyName("base")]
    public double Base { get; set; } =0.0;
    [JsonPropertyName("shoulder")]
    public double Shoulder { get; set; } = 0.0;
    [JsonPropertyName("elbow")]
    public double Elbow { get; set; } = 0.0;
    [JsonPropertyName("wrist")]
    public double Wrist { get; set; } = 0.0;
    [JsonPropertyName("roll")]
    public double Roll { get; set; } = 0.0;
    [JsonPropertyName("hand")]
    public double Hand { get; set; } = 0.0;
    [JsonPropertyName("spd")]
    public double Speed { get; set; } = 0.0;
    [JsonPropertyName("acc")]
    public double Acceleration { get; set; } = 0.0;
    public JointsCommand():base(102) { 
    }
    public JointsCommand(int t, 
      double baseRad, 
      double shoulderRad, 
      double elbowRad, 
      double wristRad, 
      double rollRad, 
      double handRad, 
      double spd, 
      double acc) : base(t) {
      Base = baseRad;
      Shoulder = shoulderRad;
      Elbow = elbowRad;
      Wrist = wristRad;
      Roll = rollRad;
      Hand = handRad;
      Speed = spd;
      Acceleration = acc;
    }

    public override string ToJson() {
      return $"{{\"T\":{CommandType}, \"base\":{Base}, \"shoulder\":{Shoulder}, \"elbow\":{Elbow}, \"wrist\":{Wrist}, \"roll\":{Roll}, \"hand\":{Hand}, \"spd\":{Speed}, \"acc\":{Acceleration}}}";
    }
  }

  public class CartesianCommand : Command {
    [JsonPropertyName("x")]
    public double X { get; set; }
    [JsonPropertyName("y")]
    public double Y { get; set; }
    [JsonPropertyName("z")]
    public double Z { get; set; }
    [JsonPropertyName("t")]
    public double Tilt { get; set; }
    [JsonPropertyName("r")]
    public double Roll { get; set; }
    [JsonPropertyName("g")]
    public double Gripper { get; set; }
    [JsonPropertyName("spd")]
    public double Speed { get; set; }
    public CartesianCommand() : base(104) { }
    public CartesianCommand(int t,
      double x,
      double y,
      double z,
      double tilt,
      double roll,
      double gripper,
      double spd) : base(t) {
      X = x;
      Y = y;
      Z = z;
      Tilt = tilt;
      Roll = roll;
      Gripper = gripper;
      Speed = spd;
    }
    public override string ToJson() {
      return $"{{\"T\":{CommandType}, \"x\":{X}, \"y\":{Y}, \"z\":{Z}, \"t\":{Tilt}, \"r\":{Roll}, \"g\":{Gripper}, \"spd\":{Speed}}}";
    }
  }

  public class JogCommand : Command {

    [JsonPropertyName("m")]
    public MovementMode Mode { get; set; }  // 0 = Joint, 1 = Cartesian

    [JsonPropertyName("axis")]
    public int Axis { get; set; }

    [JsonPropertyName("cmd")]
    public int Direction { get; set; }  // 0 = stop, 1 = +, 2 = - 

    [JsonPropertyName("spd")]
    public double Speed { get; set; }  // web set to 10

    public JogCommand() : base(123) { }
    public JogCommand(int t, MovementMode mode, int axis, int direction, double speed) : base(t) {
      Mode = mode;
      Axis = axis;
      Direction = direction;
      Speed = speed;
    }
    public override string ToJson() {
      return $"{{\"T\":{CommandType}, \"m\":{(int)Mode}, \"axis\":{Axis}, \"cmd\":{Direction}, \"spd\":{Speed}}}";
    }
  }

  public class TorqueCommand : Command {
    [JsonPropertyName("cmd")]
    public int Enable { get; set; } // 0 = disable, 1 = enable
    public TorqueCommand() : base(210) { }
    public TorqueCommand(int t, bool enable) : base(t) {
      Enable = enable ? 0 : 1;
    }
    public override string ToJson() {
      return $"{{\"T\":{CommandType}, \"cmd\":{Enable}}}";
    }
  }

  // Calibration commands

  public class SetServoIdCommand : Command {
    [JsonPropertyName("raw")]
    public int RawId { get; set; }
    [JsonPropertyName("new")]
    public int NewId { get; set; }
    public SetServoIdCommand() : base(200) { }
    public SetServoIdCommand(int t, int rawId, int newId) : base(t) {
      RawId = rawId;
      NewId = newId;
    }
    public override string ToJson() {
      return $"{{\"T\":{CommandType}, \"raw\":{RawId}, \"new\":{NewId}}}";
    }
  }

  public class SetServoMiddleCommand : Command {
    [JsonPropertyName("id")]
    public int Id { get; set; }
    public SetServoMiddleCommand() : base(201) { }
    public SetServoMiddleCommand(int t, int id) : base(t) {
      Id = id;
    }
    public override string ToJson() {
      return $"{{\"T\":{CommandType}, \"id\":{Id}}}";
    }
  }

  public class SetServoPidCommand : Command {
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("p")]
    public double P { get; set; }
    public SetServoPidCommand() : base(202) { }
    public SetServoPidCommand(int t, int id, double p) : base(t) {
      Id = id;
      P = p;
    }
    public override string ToJson() {
      return $"{{\"T\":{CommandType}, \"id\":{Id}, \"p\":{P}}}";
    }
  }

  public class SetJointPidCommand : Command {
    [JsonPropertyName("joint")]
    public Joint Joint { get; set; }
    [JsonPropertyName("p")]
    public double P { get; set; }
    [JsonPropertyName("i")]
    public double I { get; set; }
    public SetJointPidCommand() : base(108) { }
    public SetJointPidCommand(int t, Joint joint, double p, double i) : base(t) {
      Joint = joint;
      P = p;
      I = i;
    }
    public override string ToJson() {
      return $"{{\"T\":{CommandType}, \"joint\":{Joint}, \"p\":{P}, \"i\":{I}}}";
    }
  }

  public class ResetPidCommand : Command {
    public ResetPidCommand() : base(109) { }
    public ResetPidCommand(int t) : base(t) { }

  }
}
