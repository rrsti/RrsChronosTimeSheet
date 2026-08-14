using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Fornecedor.Query
{
    public class GetFornecedorByIdQueryHandler : IRequestHandler<GetFornecedorByIdQuery, RrsChronosTimeSheet.Core.Domain.Entities.Fornecedor>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Fornecedor> _querysRepository;

        public GetFornecedorByIdQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Fornecedor> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<RrsChronosTimeSheet.Core.Domain.Entities.Fornecedor> Handle(GetFornecedorByIdQuery request, CancellationToken cancellationToken)
        {
            var fornecedor = await _querysRepository.GetFirstAsync(
                filtro: f => f.Id == request.Id,
                orderBy: f => f.Id,
                cancellationToken: cancellationToken);

            return fornecedor ?? throw new KeyNotFoundException($"Fornecedor com id {request.Id} não encontrado.");
        }
    }
}
