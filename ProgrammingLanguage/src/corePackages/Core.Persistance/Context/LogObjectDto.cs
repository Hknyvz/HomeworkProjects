namespace Core.Persistence.Context
{
    internal class LogObjectDto
    {
        public LogObjectDto(int userId, string tableName, int entityId, string columnName, DateTime timestamp)
        {
            UserId = userId;
            TableName = tableName;
            EntityId = entityId;
            ColumnName = columnName;
            Timestamp = timestamp;
        }

        public int UserId { get; set; }
        public string TableName { get; set; }
        public int EntityId { get; set; }
        public string ColumnName { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public DateTime Timestamp { get; set; }
    }
}