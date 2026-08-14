using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.StatusTarefa.Query
{
    public class GetAllStatusTarefaQueryHandler : IRequestHandler<GetAllStatusTarefaQuery, IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.StatusTarefa>>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.StatusTarefa> _querysRepository;

        public GetAllStatusTarefaQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.StatusTarefa> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.StatusTarefa>> Handle(GetAllStatusTarefaQuery request, CancellationToken cancellationToken)
        {
            var statusTarefas = await _querysRepository.GetWhereAsync(
                filtro: null,
                cancellationToken: cancellationToken);

            return statusTarefas;
        }
    }
}
