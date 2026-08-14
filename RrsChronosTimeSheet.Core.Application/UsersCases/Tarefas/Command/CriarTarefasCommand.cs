using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;
using RrsChronosTimeSheet.Core.Application.Dto;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Tarefas.Command
{
    public class CriarTarefasCommand : ICommand, IRequest<Guid>
    {
        public TarefasDto Tarefa { get; set; }
    }
}
