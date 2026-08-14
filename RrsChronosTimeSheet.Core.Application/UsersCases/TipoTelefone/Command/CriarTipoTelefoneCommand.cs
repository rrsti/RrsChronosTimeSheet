using MediatR;
using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Application.Abstractions;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TipoTelefone.Command
{
    public class CriarTipoTelefoneCommand : ICommand, IRequest<Guid>
    {
        public TipoTelefoneDto TipoTelefone { get; set; }
    }
}
