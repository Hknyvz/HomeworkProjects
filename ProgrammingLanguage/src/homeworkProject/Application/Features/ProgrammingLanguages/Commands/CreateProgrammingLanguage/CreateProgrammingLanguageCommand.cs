using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;

public class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDto>
{
    public string Name { get; set; }
    public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgrammingLanguageDto>
    {
        private IProgrammingLanguageRepository languageRepository { get; }
        private IMapper mapper { get; }
        private ProgrammingLanguageBusinessRules languageBusinessRules { get; }

        public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository languageRepository, IMapper mapper, ProgrammingLanguageBusinessRules languageBusinessRules)
        {
            this.languageRepository = languageRepository;
            this.mapper = mapper;
            this.languageBusinessRules = languageBusinessRules;
        }

        public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            await languageBusinessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

            ProgrammingLanguage language = mapper.Map<ProgrammingLanguage>(request);
            ProgrammingLanguage createLanguage = await languageRepository.AddAsync(language);
            return mapper.Map<CreatedProgrammingLanguageDto>(createLanguage);
        }

    }
}

