namespace OpenMono.Acp;

public interface IAcpEventSink
{
    Task OnTextDeltaAsync(string content);
    Task OnThinkingDeltaAsync(string content);
    Task OnCompactionAsync(int messagesCompressed, double durationSeconds, int checkpointIndex);
    Task OnUsageAsync(int inputTokens, int outputTokens, int totalTokens);
    Task OnToolResultPreviewAsync(string callId, string preview, string? artifactId);
}
