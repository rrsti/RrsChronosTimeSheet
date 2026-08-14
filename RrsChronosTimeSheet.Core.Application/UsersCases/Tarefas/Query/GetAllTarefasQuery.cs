using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Tarefas.Query
{
    public class GetAllTarefasQuery : IRequest<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.Tarefas>>;
}
