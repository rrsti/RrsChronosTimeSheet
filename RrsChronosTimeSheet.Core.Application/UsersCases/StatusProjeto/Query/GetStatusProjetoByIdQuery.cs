using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.StatusProjeto.Query
{
    public class GetStatusProjetoByIdQuery : IRequest<Domain.Entities.StatusProjeto>
    {
        public Guid Id { get; set; }
    }
}
