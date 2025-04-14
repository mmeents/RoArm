using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoArmDriver.Core.Models
{
  public enum Joint { 
    Base=1, 
    Shoulder=2, 
    Elbow=3, 
    Wrist=4, 
    Roll=5, 
    Hand=6 }
  public enum Axis { 
    X =1, 
    Y=2, 
    Z=3, 
    Tilt=4, 
    Roll=5, 
    Gripper=6 }
  public enum MovementMode { Joint=0, Cartesian=1 }

  public record JointState(double Base, double Shoulder, double Elbow, double Wrist, double Roll, double Hand); // Radians
  public record CartesianState(double X, double Y, double Z, double Tilt); // mm, radians
  public record TorqueState(int Base, int Shoulder, int Elbow, int Wrist, int Roll); // Torque values
  public record ArmState(JointState Joints, CartesianState Cartesian, TorqueState Torque);

  // Calibration commands
  //public record SetServoIdCommand(int T, int RawId, int NewId) : Command(T);
  //public record SetServoMiddleCommand(int T, int Id) : Command(T);
  //public record SetServoPidCommand(int T, int Id, double P) : Command(T);
  //public record SetJointPidCommand(int T, Joint Joint, double P, double I) : Command(T);
  //public record ResetPidCommand(int T) : Command(T);

 // public abstract record Command(int T);
 // public record SetLamp(int T, int led) : Command(T);
 // public record JointCommand(int T, Joint joint, double rad, double spd, double acc) : Command(T);
 // public record JointsCommand(int T, double Base, double Shoulder, double Elbow, double Wrist, double Roll, double Hand, double spd, double acc) : Command(T);
 // public record CartesianCommand(int T, double x, double y, double z, double t, double r, double g, double spd) : Command(T);
 // public record JogCommand(int T, MovementMode Mode, int Axis, int Direction, double Speed) : Command(T);
  //public record TorqueCommand(int T, bool Enable) : Command(T);
  //public record InitCommand(int T) : Command(T);

  public static class Exts {
    public static int ToDegrees(this double radians) => Convert.ToInt32( radians * 180 / Math.PI);
    public static double ToRadians(this int degrees) => degrees * Math.PI / 180;

    public static double ToDouble(this int value) => Convert.ToDouble(value);
    public static int ToInt(this double value) => Convert.ToInt32(value);

    public static string ToQuotedString(this string value) => $"\"{value}\"";
  }

}
