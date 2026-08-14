using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneClientes.Query
{
    public class GetAllTelefoneClienteQueryHandler : IRequestHandler<GetAllTelefoneClienteQuery, IEnumerable<TelefoneCliente>>
    {
        private readonly IBaseQuerysRepository<TelefoneCliente> _querysRepository;

        public GetAllTelefoneClienteQueryHandler(IBaseQuerysRepository<TelefoneCliente> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<TelefoneCliente>> Handle(GetAllTelefoneClienteQuery request, CancellationToken cancellationToken)
        {
            var telefones = await _querysRepository.GetWhereAsync(
                filtro: null,
                cancellationToken: cancellationToken);

            return telefones;
        }
    }
}
