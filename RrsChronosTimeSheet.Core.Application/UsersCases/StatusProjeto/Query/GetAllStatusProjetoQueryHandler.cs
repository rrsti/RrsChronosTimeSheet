using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.StatusProjeto.Query
{
    public class GetAllStatusProjetoQueryHandler : IRequestHandler<GetAllStatusProjetoQuery, IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.StatusProjeto>>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.StatusProjeto> _querysRepository;

        public GetAllStatusProjetoQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.StatusProjeto> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.StatusProjeto>> Handle(GetAllStatusProjetoQuery request, CancellationToken cancellationToken)
        {
            var statusProjetos = await _querysRepository.GetWhereAsync(
                filtro: null,
                cancellationToken: cancellationToken);

            return statusProjetos;
        }
    }
}
