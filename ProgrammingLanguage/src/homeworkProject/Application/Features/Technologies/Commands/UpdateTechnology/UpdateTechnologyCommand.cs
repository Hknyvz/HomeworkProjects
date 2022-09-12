using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommand : IRequest<UpdatedTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Description { get; set; }
        public bool IsOpenSource { get; set; }
        public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
        {
            private ITechnologyRepository technologyRepository { get; }
            private IMapper mapper { get; }
            private TechnologyBusinessRules technologyBusinessRules { get; }

            public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                this.technologyRepository = technologyRepository;
                this.mapper = mapper;
                this.technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
                await technologyBusinessRules.TechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);

                Technology technology = mapper.Map<Technology>(request);
                Technology createLanguage = await technologyRepository.UpdateAsync(technology);
                return mapper.Map<UpdatedTechnologyDto>(createLanguage);
            }
        }
    }
}

