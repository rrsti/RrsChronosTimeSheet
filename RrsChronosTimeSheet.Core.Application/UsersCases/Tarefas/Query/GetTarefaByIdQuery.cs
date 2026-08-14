using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Tarefas.Query
{
    public class GetTarefaByIdQuery : IRequest<Domain.Entities.Tarefas>
    {
        public Guid Id { get; set; }
    }
}
