using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.ComentariosTarefa.Query
{
    public class GetComentarioTarefaByIdQuery : IRequest<ComentarioTarefa>
    {
        public Guid Id { get; set; }
    }
}
