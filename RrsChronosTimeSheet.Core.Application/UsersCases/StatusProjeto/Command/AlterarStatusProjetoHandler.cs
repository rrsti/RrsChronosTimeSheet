using AutoMapper;
using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.StatusProjeto.Command
{
    public class AlterarStatusProjetoHandler : IRequestHandler<AlterarStatusProjetoCommand, Guid>
    {
        private readonly IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.StatusProjeto> _baseRepository;
        private readonly IMapper _mapper;

        public AlterarStatusProjetoHandler(IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.StatusProjeto> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AlterarStatusProjetoCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Status;
            var statusProjeto = _mapper.Map<RrsChronosTimeSheet.Core.Domain.Entities.StatusProjeto>(dto);

            await _baseRepository.UpdateAsync(statusProjeto);
            return statusProjeto.Id;
        }
    }
}
