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

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
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
