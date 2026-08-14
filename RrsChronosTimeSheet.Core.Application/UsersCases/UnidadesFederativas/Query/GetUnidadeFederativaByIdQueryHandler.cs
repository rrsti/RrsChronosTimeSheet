using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.UnidadesFederativas.Query
{
    public class GetUnidadeFederativaByIdQueryHandler : IRequestHandler<GetUnidadeFederativaByIdQuery, UnidadeFederativa>
    {
        private readonly IBaseQuerysRepository<UnidadeFederativa> _querysRepository;

        public GetUnidadeFederativaByIdQueryHandler(IBaseQuerysRepository<UnidadeFederativa> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<UnidadeFederativa> Handle(GetUnidadeFederativaByIdQuery request, CancellationToken cancellationToken)
        {
            var uf = await _querysRepository.GetFirstAsync(
                filtro: u => u.Id == request.IdUnidadeFederativa,
                orderBy: u => u.Id,
                cancellationToken: cancellationToken);

            return uf ?? throw new KeyNotFoundException($"Unidade Federativa com id {request.IdUnidadeFederativa} não encontrada.");
        }
    }
}
