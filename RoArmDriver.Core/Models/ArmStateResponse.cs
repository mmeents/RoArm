
using System.Text.Json.Serialization;

namespace RoArmDriver.Core.Models {
  public class ArmStateResponse {

    [JsonPropertyName("b")]
    public float BaseRadians { get; set; } // Base (radians)

    [JsonPropertyName("s")]
    public float ShoulderRadians { get; set; } // Shoulder

    [JsonPropertyName("e")]
    public float ElbowRadians { get; set; } // Elbow

    [JsonPropertyName("t")]
    public float WristRadians { get; set; } // Wrist

    [JsonPropertyName("r")]
    public float RollRadians { get; set; } // Roll

    [JsonPropertyName("g")]
    public float GripperRadians { get; set; } // Gripper

    [JsonPropertyName("x")]
    public float x { get; set; } // X (mm)

    [JsonPropertyName("y")]
    public float y { get; set; } // Y

    [JsonPropertyName("z")]
    public float z { get; set; } // Z


    [JsonPropertyName("tit")]
    public float tit { get; set; } // Tilt (radians)

  }
}
