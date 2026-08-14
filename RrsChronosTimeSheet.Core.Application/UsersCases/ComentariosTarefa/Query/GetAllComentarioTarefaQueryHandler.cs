using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.ComentariosTarefa.Query
{
    public class GetAllComentarioTarefaQueryHandler : IRequestHandler<GetAllComentarioTarefaQuery, IEnumerable<ComentarioTarefa>>
    {
        private readonly IBaseQuerysRepository<ComentarioTarefa> _querysRepository;

        public GetAllComentarioTarefaQueryHandler(IBaseQuerysRepository<ComentarioTarefa> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<ComentarioTarefa>> Handle(GetAllComentarioTarefaQuery request, CancellationToken cancellationToken)
        {
            var comentarios = await _querysRepository.GetWhereAsync(
                filtro: null,
                cancellationToken: cancellationToken);

            return comentarios;
        }
    }
}
