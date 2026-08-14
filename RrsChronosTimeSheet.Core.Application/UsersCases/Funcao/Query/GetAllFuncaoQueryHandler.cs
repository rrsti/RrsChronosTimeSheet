using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Funcao.Query
{
    public class GetAllFuncaoQueryHandler : IRequestHandler<GetAllFuncaoQuery, IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.Funcao>>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Funcao> _querysRepository;

        public GetAllFuncaoQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Funcao> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.Funcao>> Handle(GetAllFuncaoQuery request, CancellationToken cancellationToken)
        {
            var funcoes = await _querysRepository.GetWhereAsync(
                filtro: null,
                cancellationToken: cancellationToken);

            return funcoes;
        }
    }
}
