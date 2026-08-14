using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Projeto.Query
{
    public class GetAllProjetoQueryHandler : IRequestHandler<GetAllProjetoQuery, IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.Projeto>>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Projeto> _querysRepository;

        public GetAllProjetoQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Projeto> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.Projeto>> Handle(GetAllProjetoQuery request, CancellationToken cancellationToken)
        {
            var projetos = await _querysRepository.GetWhereAsync(
                filtro: null,
                cancellationToken: cancellationToken);

            return projetos;
        }
    }
}
