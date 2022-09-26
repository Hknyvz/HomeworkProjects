using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProgrammingLanguageRepository : EfRepositoryBase<ProgrammingLanguage, ProgrammingLanguageDbContext>, IProgrammingLanguageRepository
{
    public ProgrammingLanguageRepository(ProgrammingLanguageDbContext context) : base(context)
    {
    }
}
