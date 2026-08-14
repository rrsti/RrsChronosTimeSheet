using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.HorasProfissional.Query
{
    public class GetHorasProfissionalByIdTarefaQueryHandler : IRequestHandler<GetHorasProfissionalByIdTarefaQuery, IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.HorasProfissional>>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.HorasProfissional> _querysRepository;

        public GetHorasProfissionalByIdTarefaQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.HorasProfissional> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.HorasProfissional>> Handle(GetHorasProfissionalByIdTarefaQuery request, CancellationToken cancellationToken)
        {
            var horas = await _querysRepository.GetWhereAsync(
                filtro: h => h.Tarefa.Id == request.IdTarefa,
                cancellationToken: cancellationToken);

            return horas;
        }
    }
}
