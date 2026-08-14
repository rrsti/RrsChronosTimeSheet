using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.StatusTarefa.Command
{
    public class DeleteStatusTarefaCommand : ICommand, IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
