using ScriptRunner.Data;
using ScriptRunner.WinForms.DTO;
using ScriptRunner.WinForms.IRepository.ISystemRepository;
using ScriptRunner.WinForms.Models;

namespace ScriptRunner.WinForms.IRepository.IScriptRepository
{
    public class EScriptServices : IEScriptServices
    {
        private readonly ContextDB _contextDB;
        private readonly IExceptionLogService _exceptionLogService;
        SystemExceptions exceptions = null;

        public EScriptServices(ContextDB contextDB, IExceptionLogService exceptionLogService)
        {
            _contextDB = contextDB;
            _exceptionLogService = exceptionLogService;
        }
        public async Task<Int32> saveScripts(ExecutedScriptsDTO executedScripts)
        {
            try
            {
                await _contextDB.TSYScripts.AddAsync(new Core.Models.ExecutedScripts
                {
                    ProfileId = executedScripts.ProfileId,
                    ScriptText = executedScripts.ScriptText,
                    ExecutedOn = DateTime.Now,
                    Status = executedScripts.Status
                });
                await _contextDB.SaveChangesAsync();

                return 1;
            }
            catch (Exception ex)
            {
                exceptions = new SystemExceptions
                {
                    ErrorMessage = ex.Message
                };
                await _exceptionLogService.SaveExceptionLog(exceptions);
                return 0;
            }
        }
    }
}
