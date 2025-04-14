using RoArmDriver.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoArmDriver.Core.Services;

namespace RoArmDriver.Core
{
    public class ArmDriver
    {
      public RoArmMotionService MotionService { get; }
      public RoArmStateService StateService { get; }

      public ArmDriver(string baseUrl, ISupportFeedback feedbackForm) {
        var httpClient = new HttpClient(); // Shared for efficiency        
        StateService = new RoArmStateService(baseUrl, httpClient, feedbackForm);
        MotionService = new RoArmMotionService(baseUrl, StateService, httpClient, feedbackForm);
      }

      public void Dispose() {
        MotionService.Dispose();
        StateService.Dispose();
      }
    }

  public interface ISupportFeedback {
    public void LogMsg(string msg);
    public void UpdateUI(string notUsed = "");

  }
}
