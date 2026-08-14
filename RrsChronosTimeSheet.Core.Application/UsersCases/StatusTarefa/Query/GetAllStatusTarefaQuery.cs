using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.StatusTarefa.Query
{
    public class GetAllStatusTarefaQuery : IRequest<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.StatusTarefa>>;
}
