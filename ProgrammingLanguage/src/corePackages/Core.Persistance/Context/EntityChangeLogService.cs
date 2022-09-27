using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Context
{
  public static class EntityChangeLogService
  {
    public static IServiceCollection AddEntityChangeLogService(this IServiceCollection services, Type type)
    {
      var context = (BaseDbContext)services.BuildServiceProvider().GetService(type);
      if (context != null)
      {
        context.AddEntityChangeLogData(context);
        return services;
      }
      throw new InvalidOperationException($"'Cannot resolve scoped service {type.FullName} from root provider.'\r\n");
    }
  }
}
