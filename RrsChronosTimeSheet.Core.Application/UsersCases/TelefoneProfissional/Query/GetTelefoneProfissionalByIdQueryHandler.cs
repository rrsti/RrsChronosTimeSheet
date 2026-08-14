using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneProfissional.Query
{
    public class GetTelefoneProfissionalByIdQueryHandler : IRequestHandler<GetTelefoneProfissionalByIdQuery, RrsChronosTimeSheet.Core.Domain.Entities.TelefoneProfissional>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.TelefoneProfissional> _querysRepository;

        public GetTelefoneProfissionalByIdQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.TelefoneProfissional> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<RrsChronosTimeSheet.Core.Domain.Entities.TelefoneProfissional> Handle(GetTelefoneProfissionalByIdQuery request, CancellationToken cancellationToken)
        {
            var telefone = await _querysRepository.GetFirstAsync(
                filtro: t => t.Id == request.Id,
                orderBy: t => t.Id,
                cancellationToken: cancellationToken);

            return telefone ?? throw new KeyNotFoundException($"Telefone do Profissional com id {request.Id} não encontrado.");
        }
    }
}
