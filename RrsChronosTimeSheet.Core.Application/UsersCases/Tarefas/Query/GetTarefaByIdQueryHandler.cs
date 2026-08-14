using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Tarefas.Query
{
    public class GetTarefaByIdQueryHandler : IRequestHandler<GetTarefaByIdQuery, RrsChronosTimeSheet.Core.Domain.Entities.Tarefas>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Tarefas> _querysRepository;

        public GetTarefaByIdQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Tarefas> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<RrsChronosTimeSheet.Core.Domain.Entities.Tarefas> Handle(GetTarefaByIdQuery request, CancellationToken cancellationToken)
        {
            var tarefa = await _querysRepository.GetFirstAsync(
                filtro: t => t.Id == request.Id,
                orderBy: t => t.Id,
                cancellationToken: cancellationToken);

            return tarefa ?? throw new KeyNotFoundException($"Tarefa com id {request.Id} não encontrada.");
        }
    }
}
