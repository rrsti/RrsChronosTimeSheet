using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.HorasProfissional.Query
{
    public class GetHorasProfissionalByIdProfissionalQueryHandler : IRequestHandler<GetHorasProfissionalByIdProfissionalQuery, IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.HorasProfissional>>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.HorasProfissional> _querysRepository;

        public GetHorasProfissionalByIdProfissionalQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.HorasProfissional> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.HorasProfissional>> Handle(GetHorasProfissionalByIdProfissionalQuery request, CancellationToken cancellationToken)
        {
            var horas = await _querysRepository.GetWhereAsync(
                filtro: h => h.Profissional.Id == request.IdProfissional,
                cancellationToken: cancellationToken);

            return horas;
        }
    }
}
