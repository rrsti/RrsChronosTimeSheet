using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TipoTelefone.Query
{
    public class GetAllTipoTelefoneQuery : IRequest<IEnumerable<Domain.Entities.TipoTelefone>>
    {
    }
}
