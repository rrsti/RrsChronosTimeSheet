using MediatR;
using AutoMapper;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.ComentariosTarefa.Command
{
    public class AlterarComentarioTarefaHandler : IRequestHandler<AlterarComentarioTarefaCommand, Guid>
    {
        private readonly IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.ComentarioTarefa> _baseRepository;
        private readonly IMapper _mapper;

        public AlterarComentarioTarefaHandler(IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.ComentarioTarefa> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AlterarComentarioTarefaCommand request, CancellationToken cancellationToken)
        {
            var comentario = _mapper.Map<ComentarioTarefa>(request.ComentarioTarefa);

            if (comentario != null)
            {
                if (comentario.Id.ToString() != String.Empty)
                {
                    comentario.DataAtualizacao = DateTime.Now.Date;
                }
            }
            await _baseRepository.UpdateAsync(comentario);
            return comentario.Id;
        }
    }
}
