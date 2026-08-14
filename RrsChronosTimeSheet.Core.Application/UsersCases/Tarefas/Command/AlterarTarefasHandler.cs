using AutoMapper;
using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Tarefas.Command
{
    public class AlterarTarefasHandler : IRequestHandler<AlterarTarefasCommand, Guid>
    {
        private readonly IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.Tarefas> _baseRepository;
        private readonly IMapper _mapper;

        public AlterarTarefasHandler(IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.Tarefas> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AlterarTarefasCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Tarefa;
            var obj = _mapper.Map<RrsChronosTimeSheet.Core.Domain.Entities.Tarefas>(dto);

            if (obj != null)
            {
                if (obj.Id != null)
                {
                    obj.DataAtualizacao = DateTime.Now.Date;
                    await _baseRepository.UpdateAsync(obj);
                }
                return dto.Id;
            }
            return dto.Id;
        }
    }
}
