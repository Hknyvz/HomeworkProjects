using Application.Features.Technologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Technologies.Queries.GetListTechnologyByDynamic
{
    public class GetListTechnologyByDynamicQuery : IRequest<TechnologyListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListTechnologyByDynamicQueryHandler :
            IRequestHandler<GetListTechnologyByDynamicQuery, TechnologyListModel>
        {
            public GetListTechnologyByDynamicQueryHandler(IMapper mapper, ITechnologyRepository technologyRepository)
            {
                this.mapper = mapper;
                this.technologyRepository = technologyRepository;
            }

            private IMapper mapper { get; }
            private ITechnologyRepository technologyRepository { get; }
            public async Task<TechnologyListModel> Handle(GetListTechnologyByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Technology> technologies = await technologyRepository.GetListByDynamicAsync(request.Dynamic, include: p => p.Include(c => c.ProgrammingLanguage), index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                return mapper.Map<TechnologyListModel>(technologies);


            }
        }
    }
}
