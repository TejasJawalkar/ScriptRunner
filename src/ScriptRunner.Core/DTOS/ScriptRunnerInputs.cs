using ScriptRunner.Core.Models;

namespace ScriptRunner.Core.DTOS
{
    public class ScriptRunnerInputs
    {
        public string? scriptText { get; set; }
        public ConnectionProfile? profile { get; set; }
        public CancellationToken ct { get; set; }


    }
}
