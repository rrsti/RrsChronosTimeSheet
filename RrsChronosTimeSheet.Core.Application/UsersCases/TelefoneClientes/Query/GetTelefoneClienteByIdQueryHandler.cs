using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneClientes.Query
{
    public class GetTelefoneClienteByIdQueryHandler : IRequestHandler<GetTelefoneClienteByIdQuery, TelefoneCliente>
    {
        private readonly IBaseQuerysRepository<TelefoneCliente> _querysRepository;

        public GetTelefoneClienteByIdQueryHandler(IBaseQuerysRepository<TelefoneCliente> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<TelefoneCliente> Handle(GetTelefoneClienteByIdQuery request, CancellationToken cancellationToken)
        {
            var telefone = await _querysRepository.GetFirstAsync(
                filtro: t => t.Id == request.Id,
                orderBy: t => t.Id,
                cancellationToken: cancellationToken);

            return telefone ?? throw new KeyNotFoundException($"Telefone com id {request.Id} não encontrado.");
        }
    }
}
