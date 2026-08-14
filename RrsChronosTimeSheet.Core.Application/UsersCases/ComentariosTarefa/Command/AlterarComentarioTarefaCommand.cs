using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;
using RrsChronosTimeSheet.Core.Application.Dto;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.ComentariosTarefa.Command
{
    public class AlterarComentarioTarefaCommand : ICommand, IRequest<Guid>
    {
        public ComentarioTarefaDto ComentarioTarefa { get; set; }
    }
}
