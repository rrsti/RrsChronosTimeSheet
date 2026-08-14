using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;
using RrsChronosTimeSheet.Core.Application.Dto;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TipoProjeto.Command
{
    public class CriarTipoProjetoCommand : ICommand, IRequest<Guid>
    {
        public TipoProjetoDto Tipo {  get; set; }
    }
}
