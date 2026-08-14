using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;
using RrsChronosTimeSheet.Core.Application.Dto;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.StatusTarefa.Command
{
    public class AlterarStatusTarefaCommand : ICommand, IRequest<Guid>
    {
        public StatusTarefaDto Status { get; set; }
    }
}
