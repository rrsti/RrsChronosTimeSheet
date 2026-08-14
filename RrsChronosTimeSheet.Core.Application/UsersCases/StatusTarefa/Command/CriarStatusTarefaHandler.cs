using MediatR;
using AutoMapper;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.StatusTarefa.Command
{
    public class CriarStatusTarefaHandler : IRequestHandler<CriarStatusTarefaCommand, Guid>
    {
        private readonly IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.StatusTarefa> _baseRepository;
        private readonly IMapper _mapper;

        public CriarStatusTarefaHandler(IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.StatusTarefa> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CriarStatusTarefaCommand request, CancellationToken cancellationToken)
        {
            var statusTarefa = new RrsChronosTimeSheet.Core.Domain.Entities.StatusTarefa
            {
                Id = request.Status.Id,
                Descricao = request.Status.Descricao
            };

            await _baseRepository.AddAsync(statusTarefa);
            return statusTarefa.Id;
        }
    }
}
