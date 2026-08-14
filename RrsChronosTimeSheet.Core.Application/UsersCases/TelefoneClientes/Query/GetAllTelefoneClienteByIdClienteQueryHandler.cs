using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneClientes.Query
{
    public class GetAllTelefoneClienteByIdClienteQueryHandler : IRequestHandler<GetAllTelefoneClienteByIdClienteQuery, IEnumerable<TelefoneCliente>>
    {
        private readonly IBaseQuerysRepository<TelefoneCliente> _querysRepository;

        public GetAllTelefoneClienteByIdClienteQueryHandler(IBaseQuerysRepository<TelefoneCliente> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<TelefoneCliente>> Handle(GetAllTelefoneClienteByIdClienteQuery request, CancellationToken cancellationToken)
        {
            var telefones = await _querysRepository.GetWhereAsync(
                filtro: t => t.Cliente .Id == request.IdCliente,
                cancellationToken: cancellationToken);

            return telefones;
        }
    }
}
