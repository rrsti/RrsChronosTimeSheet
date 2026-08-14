using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.ComentariosTarefa.Query
{
    public class GetComentarioTarefaByIdTarefaQuery : IRequest<IEnumerable<Domain.Entities.ComentarioTarefa>>
    {
        public Guid IdTarefa { get; set; }
    }
}
