using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Tarefas.Query
{
    public class GetTarefaByIdProjetoQueryHandler : IRequestHandler<GetTarefaByIdProjetoQuery, IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.Tarefas>>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Tarefas> _querysRepository;

        public GetTarefaByIdProjetoQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Tarefas> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.Tarefas>> Handle(GetTarefaByIdProjetoQuery request, CancellationToken cancellationToken)
        {
            var tarefas = await _querysRepository.GetWhereAsync(
                filtro: t => t.Projeto!.Id == request.IdProjeto,
                cancellationToken: cancellationToken);

            return tarefas;
        }
    }
}
