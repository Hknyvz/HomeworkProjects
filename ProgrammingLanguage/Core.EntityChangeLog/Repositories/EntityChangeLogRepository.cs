using Core.EntityChangeLog.Domain;
using Core.EntityChangeLog.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EntityChangeLog.Services
{
  public class EntityChangeLogRepository : IEntityChangeLogRepository
  {
    public EntityChangeLogRepository(EntityChangeLogDbContext context)
    {
      this.context = context;
    }

    private EntityChangeLogDbContext context { get; }

    public async Task AddChangeAsync(TableColumnChangeDetail tableColumnChangeDetail)
    {
      await context.TableColumnChangeDetails.AddAsync(tableColumnChangeDetail);
      await context.SaveChangesAsync();
    }

    public async Task AddColumnAsync(TableColumn tableColumn)
    {
      if (!context.TableColumn.Any(p => p.ColumnName == tableColumn.ColumnName && p.TableId == tableColumn.TableId))
      {
        await context.TableColumn.AddAsync(tableColumn);
        await context.SaveChangesAsync();
      }
    }

    public async Task AddTableAsync(Table table)
    {
      if (!context.Table.Any(p => p.TableName == table.TableName))
      {
        await context.Table.AddAsync(table);
        await context.SaveChangesAsync();
      }
    }

    public async Task<int> GetColumnIdAsync(int tableId, string columnName)
    {
      var result = await context.Set<TableColumn>().FirstOrDefaultAsync(p => p.TableId == tableId && p.ColumnName == columnName);
      if (result != null)
      {
        return result.Id;
      }
      else
      {
        return 0;
      }
    }

    public async Task<int> GetTableIdAsync(string tableName)
    {
      var result = await context.Set<Table>().FirstOrDefaultAsync(p => p.TableName == tableName);
      if (result != null)
      {
        return result.Id;
      }
      else
      {
        return 0;
      }
    }
  }
}
