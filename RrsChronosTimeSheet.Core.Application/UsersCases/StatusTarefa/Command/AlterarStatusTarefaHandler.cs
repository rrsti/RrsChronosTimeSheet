using AutoMapper;
using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.StatusTarefa.Command
{
    public class AlterarStatusTarefaHandler : IRequestHandler<AlterarStatusTarefaCommand, Guid>
    {
        private readonly IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.StatusTarefa> _baseRepository;
        private readonly IMapper _mapper;

        public AlterarStatusTarefaHandler(IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.StatusTarefa> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AlterarStatusTarefaCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Status;
            var status = _mapper.Map<Core.Domain.Entities.StatusTarefa>(dto);

            await _baseRepository.UpdateAsync(status);
            return status.Id;
        }
    }
}
