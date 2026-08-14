using MediatR;
using AutoMapper;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.ComentariosTarefa.Command
{
    public class CriarComentarioTarefaHandler : IRequestHandler<CriarComentarioTarefaCommand, Guid>
    {
        private readonly IBaseCommandRepository<ComentarioTarefa> _baseRepository;
        private readonly IMapper _mapper;

        public CriarComentarioTarefaHandler(IBaseCommandRepository<ComentarioTarefa> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CriarComentarioTarefaCommand request, CancellationToken cancellationToken)
        {
            var comentario = _mapper.Map <ComentarioTarefa>(request.ComentarioTarefa);
            await _baseRepository.AddAsync(comentario);
            return comentario.Id;
        }
    }
}
