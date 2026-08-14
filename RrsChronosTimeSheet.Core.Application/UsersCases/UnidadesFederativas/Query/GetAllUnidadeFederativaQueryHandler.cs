using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.UnidadesFederativas.Query
{
    public class GetAllUnidadeFederativaQueryHandler : IRequestHandler<GetAllUnidadeFederativaQuery, IEnumerable<UnidadeFederativa>>
    {
        private readonly IBaseQuerysRepository<UnidadeFederativa> _querysRepository;

        public GetAllUnidadeFederativaQueryHandler(IBaseQuerysRepository<UnidadeFederativa> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<UnidadeFederativa>> Handle(GetAllUnidadeFederativaQuery request, CancellationToken cancellationToken)
        {
            var ufs = await _querysRepository.GetWhereAsync(
                filtro: null,
                cancellationToken: cancellationToken);

            return ufs;
        }
    }
}
