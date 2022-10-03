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
    public static IServiceCollection AddEntityChangeLogService(this IServiceCollection services, Type dbContextType)
    {
      services.AddScoped<IEntityChangeLogRepository, EntityChangeLogRepository>();
      services.AddScoped<IEntityChangeLogService, EntityChangeLogService>();
      var entityChangeLogRepository = (EntityChangeLogRepository)services.BuildServiceProvider().GetService(typeof(EntityChangeLogRepository));
      

      
      return services;
    }
  }
}
