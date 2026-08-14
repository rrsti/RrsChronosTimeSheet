using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.StatusProjeto.Query
{
    public class GetAllStatusProjetoQuery : IRequest<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.StatusProjeto>>;
}
