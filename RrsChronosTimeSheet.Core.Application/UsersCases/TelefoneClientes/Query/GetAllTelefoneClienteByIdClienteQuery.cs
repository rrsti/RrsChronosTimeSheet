using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneClientes.Query
{
    public class GetAllTelefoneClienteByIdClienteQuery : IRequest<IEnumerable<TelefoneCliente>>
    {
        public Guid IdCliente { get; set; }
    }
}
