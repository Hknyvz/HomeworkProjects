using Application.Features.Technologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Technologies.Queries.GetListTechnology;

public class GetListTechnologyQuery : IRequest<TechnologyListModel>
{
    public PageRequest PageRequest { get; set; }
    public class GetListTechnologyQueryHandler : IRequestHandler<GetListTechnologyQuery, TechnologyListModel>
    {
        private ITechnologyRepository technologyRepository { get; }
        private IMapper mapper { get; }

        public GetListTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            this.technologyRepository = technologyRepository;
            this.mapper = mapper;
        }

        public async Task<TechnologyListModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Technology> technology = await technologyRepository.GetListAsync(size: request.PageRequest.PageSize, index: request.PageRequest.Page, include:p=>p.Include(p=>p.ProgrammingLanguage));
            return mapper.Map<TechnologyListModel>(technology);
        }
    }
}
