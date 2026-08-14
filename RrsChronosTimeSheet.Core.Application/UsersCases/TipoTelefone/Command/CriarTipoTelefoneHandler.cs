using MediatR;
using AutoMapper;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;
using RrsChronosTimeSheet.Core.Application.UsersCases.TipoTelefone.Command;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TipoTelefone.Command
{
    public class CriarTipoTelefoneHandler : IRequestHandler<CriarTipoTelefoneCommand, Guid>
    {
        private readonly IBaseCommandRepository<Domain.Entities.TipoTelefone> _baseRepository;
        private readonly IMapper _mapper;

        public CriarTipoTelefoneHandler(IBaseCommandRepository<Domain.Entities.TipoTelefone> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CriarTipoTelefoneCommand request, CancellationToken cancellationToken)
        {
            var dto = request.TipoTelefone;
            var obj = _mapper.Map<Domain.Entities.TipoTelefone>(dto);

            await _baseRepository.AddAsync(obj);
            return dto.Id;
        }
    }
}
