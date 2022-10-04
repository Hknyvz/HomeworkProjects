using Core.EntityChangeLog.Domain;
using Core.EntityChangeLog.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.EntityChangeLog.Services
{
  public class EntityChangeLogService : IEntityChangeLogService
  {
    public EntityChangeLogService(IEntityChangeLogRepository entityChangeLogRepository)
    {
      this.entityChangeLogRepository = entityChangeLogRepository;
    }

    private IEntityChangeLogRepository entityChangeLogRepository { get; }

    public async Task AddChange(EntityChangeLogDto entityChangeLogDto)
    {
    }

    public async Task AddTableAndColumn<TDbContext>() where TDbContext : DbContext
    {
      Type type = typeof(TDbContext);
      PropertyInfo[] tables = type.GetProperties().Where(p => p?.GetMethod?.ReturnType.Name == typeof(DbSet<string>).Name).ToArray();
      foreach (PropertyInfo table in tables)
      {
        string tableName = table.Name;
        PropertyInfo[] properties = table.PropertyType.GenericTypeArguments[0].GetProperties().Where(p => !p.GetGetMethod().IsVirtual).ToArray();
        foreach (PropertyInfo property in properties)
        {
          await entityChangeLogRepository.AddTableAsync(
            new Table
            {
              TableName = tableName,
            });
        }
      }
    }
  }
}
