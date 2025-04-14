using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoArmDriver.Core.Models
{
    class ValueTracker
    {
      public int Id { get; set; } = 0;
      public string Name { get; set; } = "";
      public string Unit { get; set; } = "Radians";
      public double Min { get; set; } = -Math.PI / 2;
      public double Max { get; set; } = Math.PI / 2;
      public double Current { get; set; } = 0.0;
      public double Target { get; set; } = 0.0;
      public double TargetZoneOffset { get; set; } = 0.05;

      public bool IsInTargetZone() {
        return Math.Abs(Current - Target) < TargetZoneOffset;
      }

  }

}
