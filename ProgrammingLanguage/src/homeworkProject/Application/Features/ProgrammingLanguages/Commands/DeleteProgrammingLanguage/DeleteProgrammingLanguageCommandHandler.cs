using Application.Features.ProgrammingLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;

public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeleteProgrammingLanguageDto>
{
    private IProgrammingLanguageRepository languageRepository { get; }
    private IMapper mapper { get; }

    public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository languageRepository, IMapper mapper)
    {
        this.languageRepository = languageRepository;
        this.mapper = mapper;
    }

    public async Task<DeleteProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
    {
        ProgrammingLanguage language = mapper.Map<ProgrammingLanguage>(request);
        ProgrammingLanguage createLanguage = await languageRepository.DeleteAsync(language);
        return mapper.Map<DeleteProgrammingLanguageDto>(createLanguage);
    }
}
