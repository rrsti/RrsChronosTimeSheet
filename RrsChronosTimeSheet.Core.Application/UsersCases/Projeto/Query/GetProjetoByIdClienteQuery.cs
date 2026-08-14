using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Projeto.Query
{
    public class GetProjetoByIdClienteQuery : IRequest<IEnumerable<Domain.Entities.Projeto>>
    {
        public Guid IdCliente { get; set; }
    }
}
