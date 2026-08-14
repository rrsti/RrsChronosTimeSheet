using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.ComentariosTarefa.Command
{
    public class DeleteComentarioTarefaCommand : ICommand, IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
