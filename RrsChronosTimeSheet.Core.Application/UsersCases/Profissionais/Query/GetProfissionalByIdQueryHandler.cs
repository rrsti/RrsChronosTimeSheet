using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Profissionais.Query
{
    public class GetProfissionalByIdQueryHandler : IRequestHandler<GetProfissionalByIdQuery, RrsChronosTimeSheet.Core.Domain.Entities.Profissional>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Profissional> _querysRepository;

        public GetProfissionalByIdQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Profissional> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<RrsChronosTimeSheet.Core.Domain.Entities.Profissional> Handle(GetProfissionalByIdQuery request, CancellationToken cancellationToken)
        {
            var profissional = await _querysRepository.GetFirstAsync(
                filtro: p => p.Id == request.Id,
                orderBy: p => p.Id,
                cancellationToken: cancellationToken);

            return profissional ?? throw new KeyNotFoundException($"Profissional com id {request.Id} não encontrado.");
        }
    }
}
