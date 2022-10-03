using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EntityChangeLog.Dtos
{
  public class EntityChangeLogDto
  {
    public EntityChangeLogDto([NotNull]string tableName, [NotNull]string columnName, int entityId, string? oldValue, string? newValue, int userId, int entityState, DateTime changeDate)
    {
      TableName = tableName;
      ColumnName = columnName;
      EntityId = entityId;
      OldValue = oldValue;
      NewValue = newValue;
      UserId = userId;
      EntityState = entityState;
      ChangeDate = changeDate;
    }

    public string TableName { get; set; }
    public string ColumnName { get; set; }
    public int EntityId { get; set; }
    public string? OldValue { get; set; }
    public string? NewValue { get; set; }
    public int UserId { get; set; }
    public int EntityState { get; set; }
    public DateTime ChangeDate { get; set; }
  }
}
