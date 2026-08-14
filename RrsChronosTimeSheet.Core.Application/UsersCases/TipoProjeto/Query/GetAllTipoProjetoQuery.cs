using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TipoProjeto.Query
{
    public class GetAllTipoProjetoQuery : IRequest<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.TipoProjeto>>;
}
