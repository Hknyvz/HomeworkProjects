using EntityChangeLog.Domain.Entities;

namespace Core.CrossCuttingConcerns.Logging.EntityChangeLogs;

public class TableColumn : IEntityChangeLog
{
    public TableColumn()
    {
        TableColumnChangeDetails = new HashSet<TableColumnChangeDetail>();
    }
    public int Id { get; set; }
    public int EntityId { get; set; }
    public int TableId { get; set; }
    public string? ColumnName { get; set; }
    public virtual Table? Table { get; set; }
    public virtual ICollection<TableColumnChangeDetail> TableColumnChangeDetails { get; set; }
}
