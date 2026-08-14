using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.EmailsClientes.Query
{
    public class GetAllEmailClienteQuery : IRequest<IQueryable<EmailCliente>>;
}
