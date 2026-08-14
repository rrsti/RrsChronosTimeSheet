using MediatR;
using AutoMapper;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TipoProjeto.Command
{
    public class AlterarTipoProjetoHandler : IRequestHandler<AlterarTipoProjetoCommand, Guid>
    {
        private readonly IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.TipoProjeto> _baseRepository;
        private readonly IMapper _mapper;

        public AlterarTipoProjetoHandler(IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.TipoProjeto> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AlterarTipoProjetoCommand request, CancellationToken cancellationToken)
        {
            var tipoProjeto = new RrsChronosTimeSheet.Core.Domain.Entities.TipoProjeto
            {
                Id = request.Tipo.Id,
                Descricao = request.Tipo.Descricao
            };

            await _baseRepository.UpdateAsync(tipoProjeto);
            return tipoProjeto.Id;
        }
    }
}
