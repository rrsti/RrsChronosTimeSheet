using MediatR;
using AutoMapper;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;
using RrsChronosTimeSheet.Core.Application.UsersCases.TipoTelefone.Command;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TipoTelefone.Command
{
    public class AlterarTipoTelefoneHandler : IRequestHandler<AlterarTipoTelefoneCommand, Guid>
    {
        private readonly IBaseCommandRepository<Domain.Entities.TipoTelefone> _baseRepository;
        private readonly IMapper _mapper;

        public AlterarTipoTelefoneHandler(IBaseCommandRepository<Domain.Entities.TipoTelefone> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AlterarTipoTelefoneCommand request, CancellationToken cancellationToken)
        {
            var dto = request.TipoTelefone;
            var obj = _mapper.Map<Domain.Entities.TipoTelefone>(dto);

            if (obj != null)
            {
                if (obj.Id != null)
                    await _baseRepository.UpdateAsync(obj);
                return dto.Id;
            }
            return dto.Id;
        }
    }
}
