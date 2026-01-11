
using ScriptRunner.Core.Models;
using ScriptRunner.Data;
using ScriptRunner.WinForms.DTO;

namespace ScriptRunner.WinForms.IRepository.ISystemRepository
{
    public class ExceptionLogServices : IExceptionLogService
    {
        private readonly ContextDB _contextDB;

        public ExceptionLogServices(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public async Task<Int32> SaveExceptionLog(SystemExceptions exceptions)
        {
            try
            {
                if (exceptions != null)
                {
                    var exceptionsinput = new ExceptionLog
                    {
                        ErrorMessage = exceptions.ErrorMessage.ToString(),
                        GeneratedDateTime = DateTime.Now
                    };
                    await _contextDB.TSYExceptionLogs.AddAsync(exceptionsinput);
                    await _contextDB.SaveChangesAsync();
                    return 1;
                }
                else
                { return 0; }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
