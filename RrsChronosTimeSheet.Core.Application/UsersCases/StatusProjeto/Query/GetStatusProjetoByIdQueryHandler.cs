using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.StatusProjeto.Query
{
    public class GetStatusProjetoByIdQueryHandler : IRequestHandler<GetStatusProjetoByIdQuery, RrsChronosTimeSheet.Core.Domain.Entities.StatusProjeto>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.StatusProjeto> _querysRepository;

        public GetStatusProjetoByIdQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.StatusProjeto> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<RrsChronosTimeSheet.Core.Domain.Entities.StatusProjeto> Handle(GetStatusProjetoByIdQuery request, CancellationToken cancellationToken)
        {
            var statusProjeto = await _querysRepository.GetFirstAsync(
                filtro: sp => sp.Id == request.Id,
                orderBy: sp => sp.Id,
                cancellationToken: cancellationToken);

            return statusProjeto ?? throw new KeyNotFoundException($"Status do Projeto com id {request.Id} não encontrado.");
        }
    }
}
