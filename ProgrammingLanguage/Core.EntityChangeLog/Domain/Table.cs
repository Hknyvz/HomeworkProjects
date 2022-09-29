namespace Core.EntityChangeLog.Domain;

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
