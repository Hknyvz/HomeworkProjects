using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.CreateTechnology;

public class CreateTechnologyCommand : IRequest<CreatedTechnologyDto>
{
    public string Name { get; set; }
    public int ProgrammingLanguageId { get; set; }
    public string Description { get; set; }
    public bool IsOpenSource { get; set; }

    public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
    {
        private ITechnologyRepository technologyRepository { get; }
        private IMapper mapper { get; }
        private TechnologyBusinessRules technologyBusinessRules { get; }

        public CreateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
        {
            this.technologyRepository = technologyRepository;
            this.mapper = mapper;
            this.technologyBusinessRules = technologyBusinessRules;
        }

        public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
        {
            await technologyBusinessRules.TechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);
            Technology technology = mapper.Map<Technology>(request);
            technologyBusinessRules.TechnologyShouldExistWhenRequested(technology);
            Technology createtechnology = await technologyRepository.AddAsync(technology);
            return mapper.Map<CreatedTechnologyDto>(createtechnology);
        }
    }
}

