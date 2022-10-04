using Core.CrossCuttingConcerns.Logging.EntityChangeLogs;
using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Context
{
  public class BaseDbContext : DbContext
  {
    public BaseDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
      ChangeTracker.StateChanged += ChangeTracker_StateChanged;
    }



    private void ChangeTracker_StateChanged(object? sender, EntityStateChangedEventArgs e)
    {
      if (sender != null)
      {
        LoggingProcess((ChangeTracker)sender, e);
      }
    }

    private void LoggingProcess(ChangeTracker changeTracker, EntityStateChangedEventArgs e)
    {
      Dictionary<string, HashSet<string>> logConfs = GetLoggedFields();
      if (logConfs.Count == 0)
        return;
      IEnumerable<LogObjectDto> logs = CollectChangesAndSaveChanges(logConfs, changeTracker, e).ToList();
    }

    private IEnumerable<LogObjectDto> CollectChangesAndSaveChanges(Dictionary<string, HashSet<string>> logConfs, ChangeTracker changeTracker, EntityStateChangedEventArgs e)
    {
      var timestamp = DateTime.UtcNow;
      //string userId;
      //string userName;
      //try
      //{
      //    //userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
      //    //userName = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
      //}
      //catch (Exception)
      //{
      //    userId = null;
      //    userName = null;
      //}
      var modifiedEntities = changeTracker.Entries();


      foreach (var change in modifiedEntities)
      {
        var tableName = change.Metadata.Name;
        if (!logConfs.ContainsKey(tableName))
          continue;
        var watchedColumns = logConfs[tableName];


        foreach (var item in change.Properties.Where(x => x.IsModified))
        {
          var columnName = item.Metadata.Name;
          if (!watchedColumns.Contains(columnName))
            continue;

          var oldValue = item.OriginalValue == null ? "" : item.OriginalValue.ToString();
          var newValue = item.CurrentValue == null ? "" : item.CurrentValue.ToString();
          if (oldValue != newValue)
          {
            yield return new LogObjectDto(1, tableName, 0, columnName, timestamp)
            {
              OldValue = oldValue,
              NewValue = newValue,
            };
          }
        }
      }
    }

    private Dictionary<string, HashSet<string>> GetLoggedFields()
    {
      var logConfs = new Dictionary<string, HashSet<string>>();
      logConfs.Add("Domain.Entities.SomeFeatureEntity", new HashSet<string> { "Id", "Name" });
      return logConfs;
    }

    
  }
}
