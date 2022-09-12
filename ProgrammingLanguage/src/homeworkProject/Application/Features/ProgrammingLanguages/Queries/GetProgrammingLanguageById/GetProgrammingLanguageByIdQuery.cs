using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Queries.GetProgrammingLanguageById
{
    public class GetProgrammingLanguageByIdQuery : IRequest<GetProgrammingLanguageByIdDto>
    {
        public int Id { get; set; }
        public class GetProgrammingLanguageQueryByIdHandler : IRequestHandler<GetProgrammingLanguageByIdQuery, GetProgrammingLanguageByIdDto>
        {

            private IProgrammingLanguageRepository programmingLanguageRepository { get; }
            private IMapper mapper { get; }
            private ProgrammingLanguageBusinessRules programmingLanguageBusinessRules { get; }

            public GetProgrammingLanguageQueryByIdHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                this.programmingLanguageRepository = programmingLanguageRepository;
                this.mapper = mapper;
                this.programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<GetProgrammingLanguageByIdDto> Handle(GetProgrammingLanguageByIdQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage programminLanguage = await programmingLanguageRepository.GetAsync(b => b.Id == request.Id);

                programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(programminLanguage);

                GetProgrammingLanguageByIdDto programminLanguageGetByIdDto = mapper.Map<GetProgrammingLanguageByIdDto>(programminLanguage);
                return programminLanguageGetByIdDto;
            }
        }
    }
}
