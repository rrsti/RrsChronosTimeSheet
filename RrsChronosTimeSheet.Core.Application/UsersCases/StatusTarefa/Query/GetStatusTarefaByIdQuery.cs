using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.StatusTarefa.Query
{
    public class GetStatusTarefaByIdQuery : IRequest<Domain.Entities.StatusTarefa>
    {
        public Guid Id { get; set; }
    }
}
