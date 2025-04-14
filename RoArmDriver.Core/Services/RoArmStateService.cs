using RoArmDriver.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using RoArmDriver.Core.Models;

namespace RoArmDriver.Core.Services
{
   public class RoArmStateService : IDisposable {
     private readonly HttpClient _client;
     private readonly string _baseUrl;
     private readonly CancellationTokenSource _cts = new();
     private ArmState _lastState;
     private bool _isMoving;
     private readonly TimeSpan _pollInterval = TimeSpan.FromMilliseconds(200);
     private readonly ISupportFeedback _feedback; // Feedback interface for logging

     public event EventHandler<ArmState> StateUpdated;
     public event EventHandler<bool> MovementStatusChanged;

     public bool IsMoving {
       get => _isMoving;
       private set {
         if (_isMoving != value) {
           _isMoving = value;
           MovementStatusChanged?.Invoke(this, value);
         }
       }
     }

     public ArmState LastState => _lastState; // Expose for calibration checks

     public RoArmStateService(string baseUrl, HttpClient client, ISupportFeedback feedback) {
       _baseUrl = baseUrl;
       _feedback = feedback;
       _client = client ?? throw new ArgumentNullException(nameof(client));
       Task.Run(PollStateAsync);      
     }

    private async Task PollStateAsync() {
      var lastPositions = new List<ArmState>(3); // Debounce over 3 polls (600ms)
      while (!_cts.Token.IsCancellationRequested) {
        try {
          var json = @"{""T"":105}";
          var url = $"{_baseUrl}/js?json={Uri.EscapeDataString(json)}";
          var response = await _client.GetStringAsync(url);
          var state = ParseState(response); // Parse {"b":0.0,"s":0.0,"x":235.0,...}
          lastPositions.Add(state);
          if (lastPositions.Count > 3) lastPositions.RemoveAt(0);

          _lastState = state;        

          // Debounce: Check if state is stable (no change over 600ms)
          IsMoving = lastPositions.Count < 3 || lastPositions.Any(p => !StatesEqual(p, lastPositions.Last()));
         // _feedback?.LogMsg($"State: Base={state.Joints.Base:F2}, Elbow={state.Joints.Elbow:F2}, IsMoving={_isMoving}");
          StateUpdated?.Invoke(this, state);

        } catch (Exception ex) {
          IsMoving = false; // Assume stopped on error
          _feedback?.LogMsg($"State error: {ex.Message}");
        }
        await Task.Delay(_pollInterval, _cts.Token);
      }
    }


    private ArmState ParseState(string json) {
      using var doc = System.Text.Json.JsonDocument.Parse(json);
      var root = doc.RootElement;

      // Extract joint angles (radians)
      var joints = new JointState(
          Base: root.GetProperty("b").GetDouble(),
          Shoulder: root.GetProperty("s").GetDouble(),
          Elbow: root.GetProperty("e").GetDouble(),
          Wrist: root.GetProperty("t").GetDouble(),
          Roll: root.GetProperty("r").GetDouble(),
          Hand: root.GetProperty("g").GetDouble()
      );

      // Extract Cartesian coordinates (mm, radians for tilt)
      var cartesian = new CartesianState(
          X: root.GetProperty("x").GetDouble(),
          Y: root.GetProperty("y").GetDouble(),
          Z: root.GetProperty("z").GetDouble(),
          Tilt: root.GetProperty("tit").GetDouble()
      );

      // Extract torque values
      var torque = new TorqueState(
          Base: root.GetProperty("tB").GetInt32(),
          Shoulder: root.GetProperty("tS").GetInt32(),
          Elbow: root.GetProperty("tE").GetInt32(),
          Wrist: root.GetProperty("tT").GetInt32(),
          Roll: root.GetProperty("tR").GetInt32()
      );

      return new ArmState(joints, cartesian, torque);
    }

      private bool StatesEqual(ArmState a, ArmState b, double tolerance = 0.001) {
      return Math.Abs(a.Joints.Base - b.Joints.Base) < tolerance &&
             Math.Abs(a.Joints.Shoulder - b.Joints.Shoulder) < tolerance &&
             Math.Abs(a.Joints.Elbow - b.Joints.Elbow) < tolerance &&
             Math.Abs(a.Joints.Wrist - b.Joints.Wrist) < tolerance &&
             Math.Abs(a.Joints.Roll - b.Joints.Roll) < tolerance &&
             Math.Abs(a.Joints.Hand - b.Joints.Hand) < tolerance &&
             Math.Abs(a.Cartesian.X - b.Cartesian.X) < tolerance &&
             Math.Abs(a.Cartesian.Y - b.Cartesian.Y) < tolerance &&
             Math.Abs(a.Cartesian.Z - b.Cartesian.Z) < tolerance &&
             Math.Abs(a.Cartesian.Tilt - b.Cartesian.Tilt) < tolerance;
    }
    public void Dispose() {
      _cts.Cancel();
      _client.Dispose();
    }

  }
}
