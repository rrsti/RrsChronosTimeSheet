using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Clientes.Queries
{
    public class GetClienteByIdUFQuery : IRequest<IEnumerable<Cliente>>
    {
        public Guid IdUnidadeFederativa { get; set; }
    }
}
