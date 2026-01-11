using Microsoft.EntityFrameworkCore;
using ScriptRunner.Core.Models;

namespace ScriptRunner.Data
{
    public class ContextDB : DbContext
    {
        #region Constructor
        public ContextDB(DbContextOptions<ContextDB> options) : base(options) { }
        #endregion


        #region DbSets
        public DbSet<ConnectionProfile> TSYProfiles { get; set; }
        public DbSet<ExecutedScripts> TSYScripts { get; set; }
        public DbSet<ExceptionLog> TSYExceptionLogs { get; set; }

        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ConnectionProfile>(entity =>
            {
                entity.HasKey(e => e.ProfileId);
                entity.HasIndex(e => e.ConnectionName).IsUnique();
                entity.HasMany(e => e.ExecutedScripts)
                      .WithOne(e => e.connectionProfiles)
                      .HasForeignKey(e => e.ProfileId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ExecutedScripts>(entity =>
             {
                 entity.HasKey(e => e.ScriptId);
             });

            modelBuilder.Entity<ExceptionLog>(entity =>
            {
                entity.HasKey(e => e.ExceptionId);
            });
        }
        #endregion


    }
}
