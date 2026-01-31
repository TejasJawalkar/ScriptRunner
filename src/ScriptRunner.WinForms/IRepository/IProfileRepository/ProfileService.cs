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

        public async Task<List<Tuple<ConnectionProfileDTO, ConnectionsDTO>>> GetAllProfiles()
        {

            var Values = new List<Tuple<ConnectionProfileDTO, ConnectionsDTO>>();
            try
            {
                Values = await (from profile in _contextDB.TSYProfiles
                                join database in _contextDB.TSYDatabases
                                on profile.ProfileId equals database.ProfileId
                                select new Tuple<ConnectionProfileDTO, ConnectionsDTO>(
                                    new ConnectionProfileDTO
                                    {
                                        ProfileId = profile.ProfileId,
                                        ConnectionSource = profile.ConnectionSource
                                    },
                                    new ConnectionsDTO
                                    {
                                        ProfileId = database.ProfileId,
                                        ConnectionName = database.ConnectionName,
                                        Provider = database.Provider,
                                        EncryptedConnectionString = database.EncryptedConnectionString,
                                        DatabaseId = database.DatabaseId,
                                    }
                                )).ToListAsync();

                return Values;
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

        public async Task<OutputList> GetDataBases(Int64 ProfileID)
        {
            OutputList outputList = new OutputList();
            try
            {
                outputList.connections = new List<ConnectionsDTO>();
                outputList.connections = await _contextDB.TSYDatabases.Where((x) => x.ProfileId == ProfileID).Select(p => new ConnectionsDTO
                {
                    ProfileId = p.ProfileId,
                    ConnectionName = p.ConnectionName,
                    Provider = p.Provider,
                    EncryptedConnectionString = p.EncryptedConnectionString,
                    DatabaseId = p.DatabaseId,
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

        public async Task<Int32> SaveProfiles(SavingPRofileDatabase savingProfile)
        {
            try
            {
                var profile = new ConnectionProfile
                {
                    ConnectionSource = savingProfile.ConnectionSource
                };
                await _contextDB.TSYProfiles.AddAsync(profile);
                if (profile != null)
                {
                    await _contextDB.SaveChangesAsync();
                    SaveDatabase(savingProfile, profile);
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

        private async void SaveDatabase(SavingPRofileDatabase savingProfile, ConnectionProfile profile)
        {
            try
            {
                var database = new Databases
                {
                    ProfileId = profile.ProfileId,
                    ConnectionName = savingProfile.ConnectionName,
                    Provider = savingProfile.Provider,
                    EncryptedConnectionString = savingProfile.EncryptedConnectionString
                };

                await _contextDB.TSYDatabases.AddAsync(database);
                await _contextDB.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                SystemExceptions systemExceptions = new SystemExceptions
                {
                    ErrorMessage = ex.Message,
                    GeneratedDateTime = System.DateTime.UtcNow
                };
                await _exceptionLogService.SaveExceptionLog(systemExceptions);
            }
        }

        public async Task<ConnectionsDTO> GetDatabaseByID(Int64 ProfileID)
        {
            ConnectionsDTO? connectionProfile = new ConnectionsDTO();
            try
            {
                connectionProfile = await _contextDB.TSYDatabases.Where((x) => x.ProfileId == ProfileID).Select(p => new ConnectionsDTO
                {
                    ProfileId = p.ProfileId,
                    DatabaseId = p.DatabaseId,
                    ConnectionName = p.ConnectionName,
                    Provider = p.Provider,
                    EncryptedConnectionString = p.EncryptedConnectionString
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
    }
}
