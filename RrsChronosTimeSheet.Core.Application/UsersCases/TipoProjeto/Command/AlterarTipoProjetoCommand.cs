using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;
using RrsChronosTimeSheet.Core.Application.Dto;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TipoProjeto.Command
{
    public class AlterarTipoProjetoCommand : ICommand, IRequest<Guid>
    {
        public TipoProjetoDto Tipo { get; set; }
    }
}
