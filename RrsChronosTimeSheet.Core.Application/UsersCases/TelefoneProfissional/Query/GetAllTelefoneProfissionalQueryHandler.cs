using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneProfissional.Query
{
    public class GetAllTelefoneProfissionalQueryHandler : IRequestHandler<GetAllTelefoneProfissionalQuery, IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.TelefoneProfissional>>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.TelefoneProfissional> _querysRepository;

        public GetAllTelefoneProfissionalQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.TelefoneProfissional> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.TelefoneProfissional>> Handle(GetAllTelefoneProfissionalQuery request, CancellationToken cancellationToken)
        {
            var telefones = await _querysRepository.GetWhereAsync(
                filtro: null,
                cancellationToken: cancellationToken);

            return telefones;
        }
    }
}
