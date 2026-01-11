using Microsoft.EntityFrameworkCore;
using ScriptRunner.Core.Models;
using ScriptRunner.Data;
using ScriptRunner.WinForms.DTO;
using ScriptRunner.WinForms.IRepository.ISystemRepository;
using ScriptRunner.WinForms.Models;

namespace ScriptRunner.WinForms.IRepository.IProfileRepository
{
    public class ProfileServices : IProfileService
    {
        ContextDB _contextDB;
        IExceptionLogService _exceptionLogService;


        public ProfileServices(ContextDB contextDB, IExceptionLogService exceptionLogService)
        {
            _contextDB = contextDB;
            _exceptionLogService = exceptionLogService;
        }

        public async Task<OutputList> GetAllProfiles()
        {
            OutputList outputList = new OutputList();
            try
            {
                outputList.connectionProfiles = new List<ConnectionProfileDTO>();
                outputList.connectionProfiles = await _contextDB.TSYProfiles.Select(p => new ConnectionProfileDTO
                {
                    ProfileId = p.ProfileId,
                    ConnectionName = p.ConnectionName,
                    Provider = p.Provider,
                    EncryptedConnectionString = p.EncryptedConnectionString,
                    ConnectionSource = p.ConnectionSource
                }).ToListAsync();
                return outputList;
            }
            catch (Exception ex)
            {
                SystemExceptions systemExceptions = new SystemExceptions
                {
                    ErrorMessage = ex.Message,
                    GeneratedDateTime = System.DateTime.UtcNow
                };
                await _exceptionLogService.SaveExceptionLog(systemExceptions);
                return null;
            }
        }

        public async Task<ConnectionProfileDTO> GetProfileByID(Int64 ProfileID)
        {
            ConnectionProfileDTO? connectionProfile = new ConnectionProfileDTO();
            try
            {
                connectionProfile = await _contextDB.TSYProfiles.Where((x) => x.ProfileId == ProfileID).Select(p => new ConnectionProfileDTO
                {
                    ProfileId = p.ProfileId,
                    ConnectionName = p.ConnectionName,
                    Provider = p.Provider,
                    EncryptedConnectionString = p.EncryptedConnectionString,
                    ConnectionSource = p.ConnectionSource
                }).FirstOrDefaultAsync();
                return connectionProfile;
            }
            catch (Exception ex)
            {
                SystemExceptions systemExceptions = new SystemExceptions
                {
                    ErrorMessage = ex.Message,
                    GeneratedDateTime = System.DateTime.UtcNow
                };
                await _exceptionLogService.SaveExceptionLog(systemExceptions);
                return null;
            }
        }

        public async Task<Int32> SaveProfiles(ConnectionProfileDTO profiles)
        {
            try
            {
                if (profiles != null)
                {
                    var connectionProfile = new ConnectionProfile
                    {
                        ConnectionName = profiles.ConnectionName,
                        Provider = profiles.Provider,
                        ConnectionSource = profiles.ConnectionSource,
                        EncryptedConnectionString = profiles.EncryptedConnectionString
                    };
                    await _contextDB.TSYProfiles.AddAsync(connectionProfile);
                    await _contextDB.SaveChangesAsync();
                }

                return 1;
            }
            catch (Exception ex)
            {
                SystemExceptions systemExceptions = new SystemExceptions
                {
                    ErrorMessage = ex.Message,
                    GeneratedDateTime = System.DateTime.UtcNow
                };
                await _exceptionLogService.SaveExceptionLog(systemExceptions);
                return 0;
            }
        }
    }
}
