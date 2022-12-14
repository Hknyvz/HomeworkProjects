using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommand : IRequest<UpdateProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdateProgrammingLanguageDto>
        {
            private IProgrammingLanguageRepository languageRepository { get; }
            private IMapper mapper { get; }
            private ProgrammingLanguageBusinessRules languageBusinessRules { get; }

            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository languageRepository, IMapper mapper, ProgrammingLanguageBusinessRules languageBusinessRules)
            {
                this.languageRepository = languageRepository;
                this.mapper = mapper;
                this.languageBusinessRules = languageBusinessRules;
            }

            public async Task<UpdateProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await languageBusinessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgrammingLanguage language = mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage createLanguage = await languageRepository.UpdateAsync(language);
                return mapper.Map<UpdateProgrammingLanguageDto>(createLanguage);
            }
        }
    }
}
