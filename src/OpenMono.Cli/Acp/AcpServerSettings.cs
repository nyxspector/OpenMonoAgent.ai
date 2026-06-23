namespace OpenMono.Acp;

public sealed class AcpServerSettings
{











    public bool Enabled { get; set; } = false;
    public int Port { get; set; } = 7475;
    public bool BindAllInterfaces { get; set; } = false;
    // 0 (or negative) means sessions never expire — the default for workspace-level
    // resume, which keeps every session until the user explicitly deletes it.
    public int SessionTtlHours { get; set; } = 0;
    public int PendingUserResponseTimeoutMinutes { get; set; } = 10;







    public string SessionsDirectory { get; set; } = "/data/acp-sessions";

    public TimeSpan PendingUserResponseTimeout => TimeSpan.FromMinutes(PendingUserResponseTimeoutMinutes);
}







public sealed class PendingUserResponseException : Exception
{
    public string PauseId { get; }
    public PendingResponseKind Kind { get; }

    public PendingUserResponseException(string id, PendingResponseKind kind)
        : base($"Awaiting client {kind} response for pause id {id}")
    {
        PauseId = id;
        Kind = kind;
    }
}

public enum PendingResponseKind { Permission, UserInput }
