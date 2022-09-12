using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, int>
        {
            private ITechnologyRepository technologyRepository { get; }
            private IMapper mapper { get; }

            public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
            {
                this.technologyRepository = technologyRepository;
                this.mapper = mapper;
            }

            public async Task<int> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology technology = mapper.Map<Technology>(request);
                Technology createTechnology = await technologyRepository.DeleteAsync(technology);
                return createTechnology.Id;
            }
        }
    }
}
