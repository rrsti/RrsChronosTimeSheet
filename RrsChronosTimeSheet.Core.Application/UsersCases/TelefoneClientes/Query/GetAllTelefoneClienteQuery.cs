using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneClientes.Query
{
    public class GetAllTelefoneClienteQuery : IRequest<IEnumerable<TelefoneCliente>>;
}
