using Microsoft.Extensions.DependencyInjection;
using ScriptRunner.Core.Adapters;
using ScriptRunner.Core.Contracts;
using ScriptRunner.Core.Mapper;
using ScriptRunner.WinForms.IRepository.IProfileRepository;
using ScriptRunner.WinForms.IRepository.IScriptRepository;
using ScriptRunner.WinForms.IRepository.ISystemRepository;

namespace ScriptRunner.WinForms.DInjection
{
    public class AddServicesCollection
    {
        public void InjectServices(IServiceCollection services)
        {
            services.AddSingleton<ScriptRunner.Core.ScriptRunner>();
            services.AddTransient<MainForm>();
            services.AddTransient<ProfileEditorForm>();

            services.AddSingleton<IProviderAdapter, SqlServerAdapter>();
            services.AddTransient<IProfileService, ProfileServices>();
            services.AddTransient<IEScriptServices, EScriptServices>();
            services.AddSingleton<IExceptionLogService, ExceptionLogServices>();
            services.AddSingleton<IMapper, Mapper>();
        }
    }
}
