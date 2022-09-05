using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage
{
    public class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery, ProgrammingLanguageGetByIdDto>
    {

        private IProgrammingLanguageRepository programmingLanguageRepository { get; }
        private IMapper mapper { get; }
        private ProgrammingLanguageBusinessRules programmingLanguageBusinessRules { get; }

        public GetByIdProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            this.programmingLanguageRepository = programmingLanguageRepository;
            this.mapper = mapper;
            this.programmingLanguageBusinessRules = programmingLanguageBusinessRules;
        }

        public async Task<ProgrammingLanguageGetByIdDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage programminLanguage = await programmingLanguageRepository.GetAsync(b => b.Id == request.Id);

            programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(programminLanguage);

            ProgrammingLanguageGetByIdDto programminLanguageGetByIdDto = mapper.Map<ProgrammingLanguageGetByIdDto>(programminLanguage);
            return programminLanguageGetByIdDto;
        }
    }
}
