using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Clientes.Queries
{
    public class GetClienteByIdQuery : IRequest<Cliente>
    {
        public Guid Id { get; set; }
    }
}
