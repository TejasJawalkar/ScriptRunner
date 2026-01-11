using ScriptRunner.WinForms.Models;

namespace ScriptRunner.WinForms.IRepository.IScriptRepository
{
    public interface IEScriptServices
    {
        public Task<Int32> saveScripts(ExecutedScriptsDTO executedScripts);
    }
}
