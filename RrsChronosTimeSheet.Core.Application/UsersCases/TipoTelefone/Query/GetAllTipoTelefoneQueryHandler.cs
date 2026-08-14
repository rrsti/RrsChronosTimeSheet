using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TipoTelefone.Query
{
    public class GetAllTipoTelefoneQueryHandler : IRequestHandler<GetAllTipoTelefoneQuery, IEnumerable<Domain.Entities.TipoTelefone>>
    {
        private readonly IBaseQuerysRepository<Domain.Entities.TipoTelefone> _querysRepository;

        public GetAllTipoTelefoneQueryHandler(IBaseQuerysRepository<Domain.Entities.TipoTelefone> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<Domain.Entities.TipoTelefone>> Handle(GetAllTipoTelefoneQuery request, CancellationToken cancellationToken)
        {
            var tipostelefone = await _querysRepository.GetWhereAsync(
                filtro: null,
                cancellationToken: cancellationToken);

            return tipostelefone;
        }
    }
}
