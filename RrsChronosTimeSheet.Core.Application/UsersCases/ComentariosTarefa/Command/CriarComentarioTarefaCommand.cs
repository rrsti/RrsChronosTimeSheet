using MediatR;
using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Application.Abstractions;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.ComentariosTarefa.Command
{
    public class CriarComentarioTarefaCommand : ICommand, IRequest<Guid>
    {
        public ComentarioTarefaDto ComentarioTarefa { get; set; }
    }
}
