using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.ComentariosTarefa.Query
{
    public class GetComentarioTarefaByIdTarefaQueryHandler : IRequestHandler<GetComentarioTarefaByIdTarefaQuery, IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.ComentarioTarefa>>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.ComentarioTarefa> _querysRepository;

        public GetComentarioTarefaByIdTarefaQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.ComentarioTarefa> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.ComentarioTarefa>> Handle(GetComentarioTarefaByIdTarefaQuery request, CancellationToken cancellationToken)
        {
            var comentarios = await _querysRepository.GetWhereAsync(
                filtro: ct => ct.Tarefa.Id == request.IdTarefa,
                cancellationToken: cancellationToken);

            return comentarios;
        }
    }
}
