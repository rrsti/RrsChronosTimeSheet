using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Clientes.Queries
{
    public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, Cliente>
    {
        private readonly IBaseQuerysRepository<Cliente> _querysRepository;

        public GetClienteByIdQueryHandler(IBaseQuerysRepository<Cliente> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<Cliente> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _querysRepository.GetFirstAsync(
                filtro: c => c.Id == request.Id,
                orderBy: c => c.Id,
                cancellationToken: cancellationToken);

            return cliente ?? throw new KeyNotFoundException($"Cliente com id {request.Id} não encontrado.");
        }
    }
}
