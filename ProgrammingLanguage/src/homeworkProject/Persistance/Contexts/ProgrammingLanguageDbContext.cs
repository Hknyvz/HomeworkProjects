using Core.EntityChangeLog.Dtos;
using Core.EntityChangeLog.Services;
using Core.Security.Entities;
using Core.Security.EntityDbMappings;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Persistence.EntityDbMappings;

namespace Persistence.Contexts
{
  public class ProgrammingLanguageDbContext : DbContext
  {
    public ProgrammingLanguageDbContext(DbContextOptions<ProgrammingLanguageDbContext> dbContextOptions, IConfiguration configuration, IEntityChangeLogService entityChangeLogService) : base(dbContextOptions)
    {
      Configuration = configuration;
      this.entityChangeLogService = entityChangeLogService;
      ChangeTracker.AutoDetectChangesEnabled = true;
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      try
      {
        LoggingProcess(ChangeTracker);
      }
      catch{}
      return base.SaveChangesAsync(cancellationToken);
    }

    //private void ChangeTracker_StateChanged(object sender, EntityStateChangedEventArgs e)
    //{
    //  if (sender != null)
    //  {
    //    LoggingProcess((ChangeTracker)sender, e);
    //  }
    //}

    private void LoggingProcess(ChangeTracker changeTracker)
    {
      var changeEnties = changeTracker.Entries();
      foreach (var changeEntity in changeEnties)
      {
        string tableName = changeEntity.Metadata.ClrType.Name;
        var properties = changeEntity.Properties;
      }
    }

    //private IEnumerable<EntityChangeLogDto> CollectChangesAndSaveChanges(Dictionary<string, HashSet<string>> logConfs, ChangeTracker changeTracker, EntityStateChangedEventArgs e)
    //{
    //  var timestamp = DateTime.UtcNow;
    //  var modifiedEntities = changeTracker.Entries();

    //  //foreach (var change in modifiedEntities)
    //  //{
    //  //  var tableName = change.Metadata.Name;
    //  //  if (!logConfs.ContainsKey(tableName))
    //  //    continue;
    //  //  var watchedColumns = logConfs[tableName];


    //  //  foreach (var item in change.Properties.Where(x => x.IsModified))
    //  //  {
    //  //    var columnName = item.Metadata.Name;
    //  //    if (!watchedColumns.Contains(columnName))
    //  //      continue;

    //  //    var oldValue = item.OriginalValue == null ? "" : item.OriginalValue.ToString();
    //  //    var newValue = item.CurrentValue == null ? "" : item.CurrentValue.ToString();
    //  //    if (oldValue != newValue)
    //  //    {
    //  //      yield return new EntityChangeLogDto(tableName, columnName, modifiedEntities. timestamp)
    //  //      {
    //  //        OldValue = oldValue,
    //  //        NewValue = newValue,
    //  //      };
    //  //    }
    //  //  }
    //  //}
    //}

    protected IConfiguration Configuration { get; set; }
    private IEntityChangeLogService entityChangeLogService { get; }
    public DbSet<ProgrammingLanguage> ProgrammingLanguage { get; set; }
    public DbSet<Technology> Technology { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaim { get; set; }
    public DbSet<OperationClaim> OperationClaim { get; set; }
    public DbSet<RefreshToken> RefreshToken { get; set; }

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
