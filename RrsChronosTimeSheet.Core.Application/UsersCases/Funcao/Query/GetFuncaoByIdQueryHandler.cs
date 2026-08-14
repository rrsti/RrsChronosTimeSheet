using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Funcao.Query
{
    public class GetFuncaoByIdQueryHandler : IRequestHandler<GetFuncaoByIdQuery, RrsChronosTimeSheet.Core.Domain.Entities.Funcao>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Funcao> _querysRepository;

        public GetFuncaoByIdQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Funcao> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<RrsChronosTimeSheet.Core.Domain.Entities.Funcao> Handle(GetFuncaoByIdQuery request, CancellationToken cancellationToken)
        {
            var funcao = await _querysRepository.GetFirstAsync(
                filtro: f => f.Id == request.Id,
                orderBy: f => f.Id,
                cancellationToken: cancellationToken);

            return funcao ?? throw new KeyNotFoundException($"Funcao com id {request.Id} não encontrada.");
        }
    }
}
