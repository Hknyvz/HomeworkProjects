using Core.EntityChangeLog.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EntityChangeLog
{
  public class EntityChangeLogDbContext:DbContext
  {
    public EntityChangeLogDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
    {
    }

    public DbSet<Table> Table { get; set; }
    public DbSet<TableColumn> TableColumn { get; set; }
    public DbSet<TableColumnChangeDetail> TableColumnChangeDetails { get; set; }
  }
}
