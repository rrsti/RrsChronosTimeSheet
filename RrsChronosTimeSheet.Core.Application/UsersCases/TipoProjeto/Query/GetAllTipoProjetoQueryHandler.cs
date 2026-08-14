using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TipoProjeto.Query
{
    public class GetAllTipoProjetoQueryHandler : IRequestHandler<GetAllTipoProjetoQuery, IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.TipoProjeto>>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.TipoProjeto> _querysRepository;

        public GetAllTipoProjetoQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.TipoProjeto> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.TipoProjeto>> Handle(GetAllTipoProjetoQuery request, CancellationToken cancellationToken)
        {
            var tiposProjeto = await _querysRepository.GetWhereAsync(
                filtro: null,
                cancellationToken: cancellationToken);

            return tiposProjeto;
        }
    }
}
