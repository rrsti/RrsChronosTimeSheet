using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.StatusTarefa.Query
{
    public class GetStatusTarefaByIdQueryHandler : IRequestHandler<GetStatusTarefaByIdQuery, RrsChronosTimeSheet.Core.Domain.Entities.StatusTarefa>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.StatusTarefa> _querysRepository;

        public GetStatusTarefaByIdQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.StatusTarefa> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<RrsChronosTimeSheet.Core.Domain.Entities.StatusTarefa> Handle(GetStatusTarefaByIdQuery request, CancellationToken cancellationToken)
        {
            var statusTarefa = await _querysRepository.GetFirstAsync(
                filtro: st => st.Id == request.Id,
                orderBy: st => st.Id,
                cancellationToken: cancellationToken);

            return statusTarefa ?? throw new KeyNotFoundException($"Status da Tarefa com id {request.Id} não encontrado.");
        }
    }
}
