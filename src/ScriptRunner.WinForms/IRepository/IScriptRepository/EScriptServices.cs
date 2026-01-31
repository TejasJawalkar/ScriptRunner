using ScriptRunner.Core.Contracts;
using ScriptRunner.Core.Models;
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
        private readonly IMapper _mapper;
        SystemExceptions exceptions = null;

        public EScriptServices(ContextDB contextDB, IExceptionLogService exceptionLogService, IMapper mapper)
        {
            _contextDB = contextDB;
            _exceptionLogService = exceptionLogService;
            _mapper = mapper;
        }
        public async Task<Int32> saveScripts(ExecutedScriptsDTO executedScripts)
        {
            try
            {
                var scriptinput = _mapper.MappingToDestination<ExecutedScriptsDTO, ExecutedScripts>(executedScripts);

                await _contextDB.TSYScripts.AddAsync(scriptinput);
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
