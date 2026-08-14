using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.UnidadesFederativas.Query
{
    public class GetUnidadeFederativaByIdQuery : IRequest<UnidadeFederativa>
    {
        public Guid IdUnidadeFederativa { get; set; }
    }
}
