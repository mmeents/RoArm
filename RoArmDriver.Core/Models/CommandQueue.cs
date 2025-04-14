using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoArmDriver.Core.Models
{
  public class CommandQueue : IDisposable {
    private readonly Queue<(Command Command, TaskCompletionSource<bool> Tcs)> _queue = new();
    private readonly HttpClient _client;
    private readonly string _baseUrl;
    private readonly object _lock = new();
    private bool _isProcessing;
    private bool _isDisposed;
    private readonly JsonSerializerOptions _jsonOptions;
    private readonly ISupportFeedback _feedback;

    public CommandQueue(string baseUrl, HttpClient client, ISupportFeedback feedback) {
      _baseUrl = baseUrl;
      _client = client ?? throw new ArgumentNullException( nameof(client));
      _feedback = feedback;
    }

    public async Task<bool> EnqueueAsync(Command command) {
      var tcs = new TaskCompletionSource<bool>();
      _queue.Enqueue((command, tcs));
      if (!_isProcessing) _ = ProcessQueueAsync();
      return await tcs.Task;
    }

    private async Task ProcessQueueAsync() {
      _isProcessing = true;      
      while (_queue.Count > 0) {
        var (command, tcs) = _queue.Dequeue();
        try {
          var json = command.ToJson();
          var url = $"{_baseUrl}/js?json={Uri.EscapeDataString(json)}";
          _feedback?.LogMsg($"Sending: {json}");
          var response = await _client.GetAsync(url);
          response.EnsureSuccessStatusCode();
          tcs.SetResult(true);
        } catch (Exception ex) {
          tcs.SetException(ex);
        }
      }
      _isProcessing = false;
    }

    public void Dispose() {
      lock (_lock) {
        if (_isDisposed) return;
        _isDisposed = true;
        _client.Dispose();
      }
    }
  } 

}
