namespace OpenMono.Acp;

/// <summary>
/// Informational firehose out of the LLM loop into the SSE stream. Each method maps to
/// a single SSE event name. Implementations never block the loop — pause-resume lives
/// on <see cref="IAcpUserInteraction"/>.
/// </summary>
public interface IAcpEventSink
{
    Task OnTextDeltaAsync(string content);
    Task OnThinkingDeltaAsync(string content);

    /// <summary>Agent is starting to execute a tool. Informational; the tool runs locally.</summary>
    Task OnToolStartAsync(string callId, string name, string summary);

    /// <summary>Agent finished executing a tool. <paramref name="ok"/> = no error / not cancelled.</summary>
    Task OnToolEndAsync(string callId, string name, bool ok, double durationMs);

    Task OnToolResultPreviewAsync(string callId, string preview, string? artifactId);
    Task OnCompactionAsync(int messagesCompressed, double durationSeconds, int checkpointIndex);
    Task OnUsageAsync(int inputTokens, int outputTokens, int totalTokens);
}
