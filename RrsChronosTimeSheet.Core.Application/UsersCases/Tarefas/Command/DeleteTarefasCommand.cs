using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Tarefas.Command
{
    public class DeleteTarefasCommand : ICommand, IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
