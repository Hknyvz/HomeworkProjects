using Core.EntityChangeLog.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EntityChangeLog.Services
{
  public class EntityChangeLogService : IEntityChangeLogService
  {
    public EntityChangeLogService(IEntityChangeLogRepository entityChangeLogRepository)
    {
      this.entityChangeLogRepository = entityChangeLogRepository;
    }

    private IEntityChangeLogRepository entityChangeLogRepository { get; }

    public async Task AddChange(EntityChangeLogDto entityChangeLogDto)
    {
    }

    public async Task AddTableAndColumn(Type dbContextType)
    {

      await entityChangeLogRepository.AddTableAsync();
    }
  }
}
