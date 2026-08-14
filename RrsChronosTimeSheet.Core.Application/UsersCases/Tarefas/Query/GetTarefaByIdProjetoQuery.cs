using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Tarefas.Query
{
    public class GetTarefaByIdProjetoQuery : IRequest<IEnumerable<Domain.Entities.Tarefas>>
    {
        public Guid IdProjeto { get; set; }
    }
}
