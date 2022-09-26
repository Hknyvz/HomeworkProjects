using Core.Persistence.Context;
using Core.Security.Entities;
using Core.Security.EntityDbMappings;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.EntityDbMappings;

namespace Persistence.Contexts
{
    public class ProgrammingLanguageDbContext : BaseDbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguage { get; set; }
        public DbSet<Technology> Technology { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaim { get; set; }
        public DbSet<OperationClaim> OperationClaim { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }

        public ProgrammingLanguageDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProgrammingLanguageMapping());
            modelBuilder.ApplyConfiguration(new TechnologyMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new UserOperationClaimMapping());
            modelBuilder.ApplyConfiguration(new OperationClaimMapping());
            modelBuilder.ApplyConfiguration(new RefreshTokenMapping());

            ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C#"), new(2, "C++") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);
        }
    }
}
