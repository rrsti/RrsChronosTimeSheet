using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneProfissional.Query
{
    public class GetAllTelefoneProfissionalByIdProfissionalQueryHandler : IRequestHandler<GetAllTelefoneProfissionalByIdProfissionalQuery, IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.TelefoneProfissional>>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.TelefoneProfissional> _querysRepository;

        public GetAllTelefoneProfissionalByIdProfissionalQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.TelefoneProfissional> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.TelefoneProfissional>> Handle(GetAllTelefoneProfissionalByIdProfissionalQuery request, CancellationToken cancellationToken)
        {
            var telefones = await _querysRepository.GetWhereAsync(
                filtro: t => t.Profissional.Id == request.IdProfissional,
                cancellationToken: cancellationToken);

            return telefones;
        }
    }
}
