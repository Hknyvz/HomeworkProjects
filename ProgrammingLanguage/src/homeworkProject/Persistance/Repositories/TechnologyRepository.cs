using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    internal class TechnologyRepository : EfRepositoryBase<Technology, ProgrammingLanguageDbContext>, ITechnologyRepository
    {
        public TechnologyRepository(ProgrammingLanguageDbContext context) : base(context)
        {

        }
    }
}
