using Core.EntityChangeLog.Domain;
using Core.EntityChangeLog.Dtos;

namespace Core.EntityChangeLog.Services
{
  public interface IEntityChangeLogRepository
  {
    Task AddTableAsync(Table table);
    Task AddColumnAsync(TableColumn tableColumn);
    Task AddChangeAsync(TableColumnChangeDetail tableColumnChangeDetail);
    Task<int> GetTableIdAsync(string tableName);
    Task<int> GetColumnIdAsync(int tableId, string columnName);
  }
}
