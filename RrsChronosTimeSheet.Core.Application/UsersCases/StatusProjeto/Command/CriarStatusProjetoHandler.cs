using MediatR;
using AutoMapper;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.StatusProjeto.Command
{
    public class CriarStatusProjetoHandler : IRequestHandler<CriarStatusProjetoCommand, Guid>
    {
        private readonly IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.StatusProjeto> _baseRepository;
        private readonly IMapper _mapper;

        public CriarStatusProjetoHandler(IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.StatusProjeto> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CriarStatusProjetoCommand request, CancellationToken cancellationToken)
        {
            var statusProjeto = new RrsChronosTimeSheet.Core.Domain.Entities.StatusProjeto
            {
                Id = request.Status.Id,
                Descricao = request.Status.Descricao
            };

            await _baseRepository.AddAsync(statusProjeto);
            return statusProjeto.Id;
        }
    }
}
