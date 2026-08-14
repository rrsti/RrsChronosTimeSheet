using MediatR;
using AutoMapper;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TipoProjeto.Command
{
    public class CriarTipoProjetoHandler : IRequestHandler<CriarTipoProjetoCommand, Guid>
    {
        private readonly IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.TipoProjeto> _baseRepository;
        private readonly IMapper _mapper;

        public CriarTipoProjetoHandler(IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.TipoProjeto> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CriarTipoProjetoCommand request, CancellationToken cancellationToken)
        {
            var tipoProjeto = new RrsChronosTimeSheet.Core.Domain.Entities.TipoProjeto
            {
                Id = request.Tipo.Id,
                Descricao = request.Tipo.Descricao
            };

            await _baseRepository.AddAsync(tipoProjeto);
            return tipoProjeto.Id;
        }
    }
}
