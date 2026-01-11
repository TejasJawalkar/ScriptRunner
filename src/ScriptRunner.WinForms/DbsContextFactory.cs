using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ScriptRunner.Data;

namespace ScriptRunner.WinForms
{
    public class DbsContextFactory : IDesignTimeDbContextFactory<ContextDB>
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public ContextDB CreateDbContext(string[] args)
        {

            var options = new DbContextOptionsBuilder<ContextDB>()
                .UseSqlServer(
                  connectionString,
                    b => b.MigrationsAssembly("ScriptRunner.WinForms"))
            .Options;

            return new ContextDB(options);
        }

    }
}
