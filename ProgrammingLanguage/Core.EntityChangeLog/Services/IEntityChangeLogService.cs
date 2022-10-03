using Core.EntityChangeLog.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EntityChangeLog.Services
{
  public interface IEntityChangeLogService
  {
    Task AddTableAndColumn(Type dbContextType);
    Task AddChange(EntityChangeLogDto entityChangeLogDto);  
  }
}
