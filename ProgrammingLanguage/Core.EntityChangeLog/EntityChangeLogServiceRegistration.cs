using Core.EntityChangeLog.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EntityChangeLog
{
  public static class EntityChangeLogServiceRegistration
  {
    public static IServiceCollection AddEntityChangeLogService<TDbContext>(this IServiceCollection services) where TDbContext : DbContext
    {
      services.AddScoped<IEntityChangeLogRepository, EntityChangeLogRepository>();
      services.AddScoped<IEntityChangeLogService, EntityChangeLogService>();
      var entityChangeLogService = (EntityChangeLogService)services.BuildServiceProvider().GetService(typeof(IEntityChangeLogService));
      entityChangeLogService.AddTableAndColumn<TDbContext>().GetAwaiter();
      return services;
    }
  }
}
