using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;
using RrsChronosTimeSheet.Core.Application.Dto;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.StatusTarefa.Command
{
    public class CriarStatusTarefaCommand : ICommand, IRequest<Guid>
    {
        public StatusTarefaDto Status { get; set; }
    }
}
