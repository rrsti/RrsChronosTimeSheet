using MediatR;
using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Application.Abstractions;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.UnidadesFederativas.Command
{
    public class AlterarUnidadeFederativaCommand : ICommand, IRequest<Guid>
    {
        public UnidadeFederativaDto UF { get; set; }
    }
}
