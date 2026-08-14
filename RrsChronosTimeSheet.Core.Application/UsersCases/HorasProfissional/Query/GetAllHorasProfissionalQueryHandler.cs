using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.HorasProfissional.Query
{
    public class GetAllHorasProfissionalQueryHandler : IRequestHandler<GetAllHorasProfissionalQuery, IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.HorasProfissional>>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.HorasProfissional> _querysRepository;

        public GetAllHorasProfissionalQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.HorasProfissional> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.HorasProfissional>> Handle(GetAllHorasProfissionalQuery request, CancellationToken cancellationToken)
        {
            var horas = await _querysRepository.GetWhereAsync(
                filtro: null,
                cancellationToken: cancellationToken);

            return horas;
        }
    }
}
