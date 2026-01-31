namespace ScriptRunner.Core.DTOS
{
    public class ScriptRunnerInputs
    {
        public string? scriptText { get; set; }
        public string? EncryptedConnectionString { get; set; }
        public string? Provider { get; set; }
        public CancellationToken ct { get; set; }
    }
}
