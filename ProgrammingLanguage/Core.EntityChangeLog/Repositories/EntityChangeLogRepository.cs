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

    public async Task<int> AddColumnAsync(TableColumn tableColumn)
    {
      if (context.TableColumn != null && !context.TableColumn.Any(p => p.ColumnName == tableColumn.ColumnName && p.TableId == tableColumn.TableId))
      {
        await context.TableColumn.AddAsync(tableColumn);
        await context.SaveChangesAsync();
      }
      return tableColumn.Id;
    }

    public async Task<int> AddTableAsync(Table table)
    {
      Table foundedTable = context.Table.SingleOrDefault(p => p.TableName == table.TableName);
      if (foundedTable == null)
      {
        await context.Table.AddAsync(table);
        await context.SaveChangesAsync();
        return table.Id;
      }
      else
      {
        return foundedTable.Id;
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
