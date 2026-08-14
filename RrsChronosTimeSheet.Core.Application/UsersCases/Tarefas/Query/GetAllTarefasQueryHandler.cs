using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Tarefas.Query
{
    public class GetAllTarefasQueryHandler : IRequestHandler<GetAllTarefasQuery, IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.Tarefas>>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Tarefas> _querysRepository;

        public GetAllTarefasQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Tarefas> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.Tarefas>> Handle(GetAllTarefasQuery request, CancellationToken cancellationToken)
        {
            var tarefas = await _querysRepository.GetWhereAsync(
                filtro: null,
                cancellationToken: cancellationToken);

            return tarefas;
        }
    }
}
