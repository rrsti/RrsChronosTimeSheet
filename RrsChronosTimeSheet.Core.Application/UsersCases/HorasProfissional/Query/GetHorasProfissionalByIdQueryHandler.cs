using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.HorasProfissional.Query
{
    public class GetHorasProfissionalByIdQueryHandler : IRequestHandler<GetHorasProfissionalByIdQuery, RrsChronosTimeSheet.Core.Domain.Entities.HorasProfissional>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.HorasProfissional> _querysRepository;

        public GetHorasProfissionalByIdQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.HorasProfissional> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<RrsChronosTimeSheet.Core.Domain.Entities.HorasProfissional> Handle(GetHorasProfissionalByIdQuery request, CancellationToken cancellationToken)
        {
            var hora = await _querysRepository.GetFirstAsync(
                filtro: h => h.Id == request.Id,
                orderBy: h => h.Id,
                cancellationToken: cancellationToken);

            return hora ?? throw new KeyNotFoundException($"Horas do Profissional com id {request.Id} não encontrada.");
        }
    }
}
