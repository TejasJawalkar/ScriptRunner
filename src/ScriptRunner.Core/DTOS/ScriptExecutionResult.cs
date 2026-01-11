namespace ScriptRunner.Core.DTOS
{
    public class ScriptExecutionResult
    {
        public bool Success { get; init; }
        public string Output { get; init; } = string.Empty;
        public Exception? Error { get; init; }
    }
}
