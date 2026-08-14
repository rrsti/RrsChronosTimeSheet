using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.ComentariosTarefa.Query
{
    public class GetAllComentarioTarefaQuery : IRequest<IEnumerable<ComentarioTarefa>>;
}
