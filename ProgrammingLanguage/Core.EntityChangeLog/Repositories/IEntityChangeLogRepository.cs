using Core.EntityChangeLog.Domain;
using Core.EntityChangeLog.Dtos;

namespace Core.EntityChangeLog.Services
{
  public interface IEntityChangeLogRepository
  {
    Task<int> AddTableAsync(Table table);
    Task<int> AddColumnAsync(TableColumn tableColumn);
    Task AddChangeAsync(TableColumnChangeDetail tableColumnChangeDetail);
    Task<int> GetTableIdAsync(string tableName);
    Task<int> GetColumnIdAsync(int tableId, string columnName);
  }
}
