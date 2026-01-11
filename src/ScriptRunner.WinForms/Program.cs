using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScriptRunner.Data;

namespace ScriptRunner.WinForms;

internal static class Program
{
    public static IServiceProvider Services { get; private set; } = null!;

    [STAThread]
    static void Main()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        Services = services.BuildServiceProvider();

        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(Services.GetRequiredService<MainForm>());
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging();
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        services.AddDbContext<ContextDB>(op => op.UseSqlServer(connectionString, b => b.MigrationsAssembly("ScriptRunner.WinForms")));
        var injector = new DInjection.AddServicesCollection();
        injector.InjectServices(services);
    }
}
