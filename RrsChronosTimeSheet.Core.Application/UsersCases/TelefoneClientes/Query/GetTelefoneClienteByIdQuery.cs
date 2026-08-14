using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneClientes.Query
{
    public class GetTelefoneClienteByIdQuery : IRequest<TelefoneCliente>
    {
        public Guid Id { get; set; }
    }
}
