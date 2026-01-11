using ScriptRunner.WinForms.DTO;
using ScriptRunner.WinForms.Models;

namespace ScriptRunner.WinForms.IRepository.IProfileRepository
{
    public interface IProfileService
    {
        public Task<OutputList> GetAllProfiles();
        public Task<Int32> SaveProfiles(ConnectionProfileDTO connectionProfile);
        public Task<ConnectionProfileDTO> GetProfileByID(Int64 ProfileID);
    }
}
