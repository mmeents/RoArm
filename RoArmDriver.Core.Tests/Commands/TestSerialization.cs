
using RoArmDriver.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

namespace RoArmDriver.Core.Tests.Commands {

  [TestClass]
  public class CommandSerializationTests {

    private JsonSerializerOptions _jsonOptions;

    [TestInitialize]
    public void Setup() {     
    }

    [TestMethod]
    public void SerializeAndDeserialize_SetLampCommand() {
      // Arrange
      var command = new SetLamp(1, 255);

      // Act
      var json = command.ToJson();
      var deserialized = JsonSerializer.Deserialize<SetLamp>(json);

      // Assert
      Assert.IsNotNull(deserialized);
      Assert.AreEqual(command.CommandType, deserialized.CommandType);
      Assert.AreEqual(command.Led, deserialized.Led);
    }

    [TestMethod]
    public void SerializeAndDeserialize_JointCommand() {
      // Arrange
      var command = new JointCommand(1, Joint.Elbow, 1.57, 0.5, 0.2);

      // Act
      var json = command.ToJson();
      var deserialized = JsonSerializer.Deserialize<JointCommand>(json);

      // Assert
      Assert.IsNotNull(deserialized);
      Assert.AreEqual(command.CommandType, deserialized.CommandType);
      Assert.AreEqual(command.Joint, deserialized.Joint);
      Assert.AreEqual(command.Radians, deserialized.Radians);
      Assert.AreEqual(command.Speed, deserialized.Speed);
      Assert.AreEqual(command.Acceleration, deserialized.Acceleration);
    }

    [TestMethod]
    public void SerializeAndDeserialize_JointsCommand() {
      // Arrange
      var command = new JointsCommand(1, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8);

      // Act
      var json = command.ToJson();
      var deserialized = JsonSerializer.Deserialize<JointsCommand>(json);

      // Assert
      Assert.IsNotNull(deserialized);
      Assert.AreEqual(command.CommandType, deserialized.CommandType);
      Assert.AreEqual(command.Base, deserialized.Base);
      Assert.AreEqual(command.Shoulder, deserialized.Shoulder);
      Assert.AreEqual(command.Elbow, deserialized.Elbow);
      Assert.AreEqual(command.Wrist, deserialized.Wrist);
      Assert.AreEqual(command.Roll, deserialized.Roll);
      Assert.AreEqual(command.Hand, deserialized.Hand);
      Assert.AreEqual(command.Speed, deserialized.Speed);
      Assert.AreEqual(command.Acceleration, deserialized.Acceleration);
    }

    [TestMethod]
    public void SerializeAndDeserialize_CartesianCommand() {
      // Arrange
      var command = new CartesianCommand(1, 10.0, 20.0, 30.0, 0.5, 0.6, 0.7, 0.8);

      // Act
      var json = command.ToJson();
      var deserialized = JsonSerializer.Deserialize<CartesianCommand>(json);

      // Assert
      Assert.IsNotNull(deserialized);
      Assert.AreEqual(command.CommandType, deserialized.CommandType);
      Assert.AreEqual(command.X, deserialized.X);
      Assert.AreEqual(command.Y, deserialized.Y);
      Assert.AreEqual(command.Z, deserialized.Z);
      Assert.AreEqual(command.Tilt, deserialized.Tilt);
      Assert.AreEqual(command.Roll, deserialized.Roll);
      Assert.AreEqual(command.Gripper, deserialized.Gripper);
      Assert.AreEqual(command.Speed, deserialized.Speed);
    }

    [TestMethod]
    public void SerializeAndDeserialize_JogCommand() {
      // Arrange
      var command = new JogCommand(1, MovementMode.Cartesian, 2, 1, 0.5);

      // Act
      var json = command.ToJson();
      var deserialized = JsonSerializer.Deserialize<JogCommand>(json);

      // Assert
      Assert.IsNotNull(deserialized);
      Assert.AreEqual(command.CommandType, deserialized.CommandType);
      Assert.AreEqual(command.Mode, deserialized.Mode);
      Assert.AreEqual(command.Axis, deserialized.Axis);
      Assert.AreEqual(command.Direction, deserialized.Direction);
      Assert.AreEqual(command.Speed, deserialized.Speed);
    }

    [TestMethod]
    public void SerializeAndDeserialize_TorqueCommand() {
      // Arrange
      var command = new TorqueCommand(1, true);

      // Act
      var json = command.ToJson();
      var deserialized = JsonSerializer.Deserialize<TorqueCommand>(json);

      // Assert
      Assert.IsNotNull(deserialized);
      Assert.AreEqual(command.CommandType, deserialized.CommandType);
      Assert.AreEqual(command.Enable, deserialized.Enable);
    }

    [TestMethod]
    public void SerializeAndDeserialize_InitCommand() {
      // Arrange
      var command = new InitializeCommand();

      // Act
      var json = command.ToJson();
      var deserialized = JsonSerializer.Deserialize<InitializeCommand>(json);

      // Assert
      Assert.IsNotNull(deserialized);
      Assert.AreEqual(command.CommandType, deserialized.CommandType);
    }
  }
}
