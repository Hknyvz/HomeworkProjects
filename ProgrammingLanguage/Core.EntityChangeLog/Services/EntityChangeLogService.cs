using AutoMapper;
using Core.EntityChangeLog.Domain;
using Core.EntityChangeLog.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Core.EntityChangeLog.Services
{
  public class EntityChangeLogService : IEntityChangeLogService
  {
    public EntityChangeLogService(IEntityChangeLogRepository entityChangeLogRepository, IMapper mapper)
    {
      this.entityChangeLogRepository = entityChangeLogRepository;
      this.mapper = mapper;
    }
    private IMapper mapper { get; }
    private IEntityChangeLogRepository entityChangeLogRepository { get; }

    public async Task AddChange(EntityChangeLogDto entityChangeLogDto)
    {
      TableColumnChangeDetail tableColumnChangeDetail = mapper.Map<TableColumnChangeDetail>(entityChangeLogDto);
      int tableId = await entityChangeLogRepository.GetTableIdAsync(entityChangeLogDto.TableName);
      tableColumnChangeDetail.TableColumnId = await entityChangeLogRepository.GetColumnIdAsync(tableId, entityChangeLogDto.ColumnName);
      await entityChangeLogRepository.AddChangeAsync(tableColumnChangeDetail);
    }

    public async Task AddTableAndColumn<TDbContext>() where TDbContext : DbContext
    {
      Type type = typeof(TDbContext);
      PropertyInfo[] tables = type.GetProperties().Where(p => p?.GetMethod?.ReturnType.Name == typeof(DbSet<string>).Name).ToArray();
      foreach (PropertyInfo table in tables)
      {
        int tableId = await entityChangeLogRepository.AddTableAsync(
              new Table
              {
                TableName = table.Name
              });
        foreach (PropertyInfo property in table.PropertyType.GenericTypeArguments[0].GetProperties())
        {
          MethodInfo? methodInfo = property.GetGetMethod();
          if (methodInfo != null && !methodInfo.IsVirtual)
          {
            await entityChangeLogRepository.AddColumnAsync(new TableColumn
            {
              TableId = tableId,
              ColumnName = property.Name
            });
          }
        }
      }
    }
  }
}
