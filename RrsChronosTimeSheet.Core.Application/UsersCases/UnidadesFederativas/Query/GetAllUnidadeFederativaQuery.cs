using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.UnidadesFederativas.Query
{
    public class GetAllUnidadeFederativaQuery: IRequest<IEnumerable<UnidadeFederativa>>;
}
