using Application.Services.Repositories;
using Core.EntityChangeLog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
  public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<ProgrammingLanguageDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ProgrammingLanguage")));
    services.AddDbContext<EntityChangeDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("EntityChangeLog")));
    services.AddScoped<EntityChangeLogDbContext, EntityChangeDbContext>();
    services.AddEntityChangeLogService<ProgrammingLanguageDbContext>();
    services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();
    services.AddScoped<ITechnologyRepository, TechnologyRepository>();
    return services;
  }
}
