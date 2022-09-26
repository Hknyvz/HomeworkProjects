using EntityChangeLog.Domain.Entities;

namespace Core.CrossCuttingConcerns.Logging.EntityChangeLogs;

public class Table: IEntityChangeLog
{
    public Table()
    {
        TableColumns = new HashSet<TableColumn>();
    }
    public int Id { get; set; }
    public string? TableName { get; set; }
    public virtual ICollection<TableColumn> TableColumns { get; set; }
}
