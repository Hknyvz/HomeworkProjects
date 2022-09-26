using Core.Security.Features.OperationClaims.Dtos;
using MediatR;

namespace Core.Security.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>
    {
        public string Name { get; set; }
        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
        {

            public Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
