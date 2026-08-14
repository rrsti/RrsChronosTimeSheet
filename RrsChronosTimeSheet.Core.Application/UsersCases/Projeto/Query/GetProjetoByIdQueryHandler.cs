using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Projeto.Query
{
    public class GetProjetoByIdQueryHandler : IRequestHandler<GetProjetoByIdQuery, RrsChronosTimeSheet.Core.Domain.Entities.Projeto>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Projeto> _querysRepository;

        public GetProjetoByIdQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Projeto> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<RrsChronosTimeSheet.Core.Domain.Entities.Projeto> Handle(GetProjetoByIdQuery request, CancellationToken cancellationToken)
        {
            var projeto = await _querysRepository.GetFirstAsync(
                filtro: p => p.Id == request.Id,
                orderBy: p => p.Id,
                cancellationToken: cancellationToken);

            return projeto ?? throw new KeyNotFoundException($"Projeto com id {request.Id} não encontrado.");
        }
    }
}
