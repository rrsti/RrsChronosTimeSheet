using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Profissionais.Query
{
    public class GetAllProfissionalQueryHandler : IRequestHandler<GetAllProfissionalQuery, IEnumerable<Profissional>>
    {
        private readonly IBaseQuerysRepository<Profissional> _querysRepository;

        public GetAllProfissionalQueryHandler(IBaseQuerysRepository<Profissional> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<Profissional>> Handle(GetAllProfissionalQuery request, CancellationToken cancellationToken)
        {
            var profissionais = await _querysRepository.GetWhereAsync(
                filtro: null,
                cancellationToken: cancellationToken);

            return profissionais;
        }
    }
}
