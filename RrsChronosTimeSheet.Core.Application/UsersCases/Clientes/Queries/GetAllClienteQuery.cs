using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Clientes.Queries
{
    public class GetAllClienteQuery : IRequest<IEnumerable<Cliente>>
    {
    }
}
