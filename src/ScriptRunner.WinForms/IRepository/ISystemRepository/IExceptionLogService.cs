using ScriptRunner.WinForms.DTO;

namespace ScriptRunner.WinForms.IRepository.ISystemRepository
{
    public interface IExceptionLogService
    {
        public Task<Int32> SaveExceptionLog(SystemExceptions exceptions);
    }
}
