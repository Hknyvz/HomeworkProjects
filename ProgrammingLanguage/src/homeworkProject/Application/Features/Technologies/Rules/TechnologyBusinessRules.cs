using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private ITechnologyRepository technologyRepository { get; }

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
        {
            this.technologyRepository = technologyRepository;
        }

        public async Task TechnologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Technology> result = await technologyRepository.GetListAsync(p => p.Name == name);

            if (result.Items.Any())
            {
                throw new BusinessException("Technology name exists.");
            }
        }

        public void TechnologyShouldExistWhenRequested(Technology technology)
        {
            if (technology == null) throw new BusinessException("Requested technology does not exist");
        }
    }
}
