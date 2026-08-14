using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TipoTelefone.Query
{
    public class GetTipoTelefoneByIdQueryHandler : IRequestHandler<GetTipoTelefoneByIdQuery, Domain.Entities.TipoTelefone>
    {
        private readonly IBaseQuerysRepository<Domain.Entities.TipoTelefone> _querysRepository;

        public GetTipoTelefoneByIdQueryHandler(IBaseQuerysRepository<Domain.Entities.TipoTelefone> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<Domain.Entities.TipoTelefone> Handle(GetTipoTelefoneByIdQuery request, CancellationToken cancellationToken)
        {
            var tipoTelefone = await _querysRepository.GetFirstAsync(
                filtro: tt => tt.Id == request.Id,
                orderBy: tt => tt.Id,
                cancellationToken: cancellationToken);

            return tipoTelefone ?? throw new KeyNotFoundException($"Tipo de Telefone com id {request.Id} não encontrado.");
        }
    }
}
