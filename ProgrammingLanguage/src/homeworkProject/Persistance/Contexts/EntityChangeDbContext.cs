using Core.EntityChangeLog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
  public class EntityChangeDbContext : EntityChangeLogDbContext
  {
    public EntityChangeDbContext(DbContextOptions dbContextOptions) :base(dbContextOptions)
    {

    }
  }
}
