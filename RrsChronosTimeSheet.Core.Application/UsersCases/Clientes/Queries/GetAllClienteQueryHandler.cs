using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Clientes.Queries
{
    public class GetAllClienteQueryHandler : IRequestHandler<GetAllClienteQuery, IEnumerable<Cliente>>
    {
        private readonly IBaseQuerysRepository<Cliente> _querysRepository;

        public GetAllClienteQueryHandler(IBaseQuerysRepository<Cliente> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<Cliente>> Handle(GetAllClienteQuery request, CancellationToken cancellationToken)
        {
            var clientes = await _querysRepository.GetWhereAsync(
                filtro: null,
                cancellationToken: cancellationToken);

            return clientes;
        }
    }
}
