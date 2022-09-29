namespace Core.EntityChangeLog.Domain;

public class TableColumnChangeDetail : IEntityChangeLog
{
  public int Id { get; set; }
  public int TableColumnId { get; set; }
  public int EntityId { get; set; }
  public string? OldValue { get; set; }
  public string? NewValue { get; set; }
  public int UserId { get; set; }
  public int EntityState { get; set; }
  public DateTime ChangeDate { get; set; }
  public TableColumn? TableColumn { get; set; }
}
