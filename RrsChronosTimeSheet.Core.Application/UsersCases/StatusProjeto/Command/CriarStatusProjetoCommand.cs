using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;
using RrsChronosTimeSheet.Core.Application.Dto;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.StatusProjeto.Command
{
    public class CriarStatusProjetoCommand : ICommand, IRequest<Guid>
    {
        public StatusProjetoDto Status { get; set; }
    }
}
