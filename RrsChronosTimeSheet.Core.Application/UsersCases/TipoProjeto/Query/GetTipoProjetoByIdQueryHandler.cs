using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TipoProjeto.Query
{
    public class GetTipoProjetoByIdQueryHandler : IRequestHandler<GetTipoProjetoByIdQuery, RrsChronosTimeSheet.Core.Domain.Entities.TipoProjeto>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.TipoProjeto> _querysRepository;

        public GetTipoProjetoByIdQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.TipoProjeto> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<RrsChronosTimeSheet.Core.Domain.Entities.TipoProjeto> Handle(GetTipoProjetoByIdQuery request, CancellationToken cancellationToken)
        {
            var tipoProjeto = await _querysRepository.GetFirstAsync(
                filtro: tp => tp.Id == request.Id,
                orderBy: tp => tp.Id,
                cancellationToken: cancellationToken);

            return tipoProjeto ?? throw new KeyNotFoundException($"Tipo de Projeto com id {request.Id} não encontrado.");
        }
    }
}
