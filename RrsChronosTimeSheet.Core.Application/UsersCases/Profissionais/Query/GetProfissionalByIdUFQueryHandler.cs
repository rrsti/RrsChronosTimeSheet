using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Profissionais.Query
{
    public class GetProfissionalByIdUFQueryHandler : IRequestHandler<GetProfissionalByIdUFQuery, IEnumerable<Profissional>>
    {
        private readonly IBaseQuerysRepository<Profissional> _querysRepository;

        public GetProfissionalByIdUFQueryHandler(IBaseQuerysRepository<Profissional> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<Profissional>> Handle(GetProfissionalByIdUFQuery request, CancellationToken cancellationToken)
        {
            var profissionais = await _querysRepository.GetWhereAsync(
                filtro: p => p.UnidadeFederativa.Id == request.IdUnidadeFederativa,
                cancellationToken: cancellationToken);

            return profissionais;
        }
    }
}
