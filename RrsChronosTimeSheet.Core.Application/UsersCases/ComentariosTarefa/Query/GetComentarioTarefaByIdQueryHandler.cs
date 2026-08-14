using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.ComentariosTarefa.Query
{
    public class GetComentarioTarefaByIdQueryHandler : IRequestHandler<GetComentarioTarefaByIdQuery, ComentarioTarefa>
    {
        private readonly IBaseQuerysRepository<ComentarioTarefa> _querysRepository;

        public GetComentarioTarefaByIdQueryHandler(IBaseQuerysRepository<ComentarioTarefa> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<ComentarioTarefa> Handle(GetComentarioTarefaByIdQuery request, CancellationToken cancellationToken)
        {
            var comentario = await _querysRepository.GetFirstAsync(
                filtro: ct => ct.Id == request.Id,
                orderBy: ct => ct.Id,
                cancellationToken: cancellationToken);

            return comentario ?? throw new KeyNotFoundException($"Comentário com id {request.Id} não encontrado.");
        }
    }
}
