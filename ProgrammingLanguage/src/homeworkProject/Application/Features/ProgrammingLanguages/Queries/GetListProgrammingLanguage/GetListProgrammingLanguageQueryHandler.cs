using Application.Features.ProgrammingLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery, ProgrammingLanguageListModel>
    {
        private IProgrammingLanguageRepository programmingLanguageRepository { get; }
        private IMapper mapper { get; }
        public GetListProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
        {
            this.programmingLanguageRepository = programmingLanguageRepository;
            this.mapper = mapper;
        }

        public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingLanguage> programmingLanguage = await programmingLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            ProgrammingLanguageListModel mappedProgrammingLanguageListModel = mapper.Map<ProgrammingLanguageListModel>(programmingLanguage);
            return mappedProgrammingLanguageListModel;
        }
    }
}
