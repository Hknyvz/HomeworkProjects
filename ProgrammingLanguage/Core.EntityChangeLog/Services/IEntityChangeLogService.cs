using Core.EntityChangeLog.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Core.EntityChangeLog.Services
{
  public interface IEntityChangeLogService
  {
    Task AddChange(EntityChangeLogDto entityChangeLogDto);
    Task AddTableAndColumn<TDbContext>() where TDbContext : DbContext;
  }
}
