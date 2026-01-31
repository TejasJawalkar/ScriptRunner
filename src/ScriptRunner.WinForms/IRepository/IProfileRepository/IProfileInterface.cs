using ScriptRunner.WinForms.DTO;
using ScriptRunner.WinForms.Models;

namespace ScriptRunner.WinForms.IRepository.IProfileRepository
{
    public interface IProfileService
    {
        public Task<List<Tuple<ConnectionProfileDTO, ConnectionsDTO>>> GetAllProfiles();
        public Task<Int32> SaveProfiles(SavingPRofileDatabase savingProfile);
        public Task<ConnectionProfileDTO> GetProfileByID(Int64 ProfileID);
        public Task<ConnectionsDTO> GetDatabaseByID(Int64 ProfileID);
        public Task<OutputList> GetDataBases(Int64 ProfileID);
    }
}
