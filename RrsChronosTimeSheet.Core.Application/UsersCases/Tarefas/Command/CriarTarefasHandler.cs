using AutoMapper;
using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Tarefas.Command
{
    public class CriarTarefasHandler : IRequestHandler<CriarTarefasCommand, Guid>
    {
        private readonly IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.Tarefas> _baseRepository;
        private readonly IMapper _mapper;

        public CriarTarefasHandler(IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.Tarefas> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CriarTarefasCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Tarefa;
            var tarefa = _mapper.Map<RrsChronosTimeSheet.Core.Domain.Entities.Tarefas>(dto);

            await _baseRepository.AddAsync(tarefa);
            return dto.Id;
        }
    }
}
