using MediatR;
using AutoMapper;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneProfissional.Command
{
    public class AlterarTelefoneProfissionalHandler : IRequestHandler<AlterarTelefoneProfissionalCommand, Guid>
    {
        private readonly IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.TelefoneProfissional> _baseRepository;
        private readonly IMapper _mapper;

        public AlterarTelefoneProfissionalHandler(IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.TelefoneProfissional> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AlterarTelefoneProfissionalCommand request, CancellationToken cancellationToken)
        {
            var dto = request.TelefoneProfissional;
            var obj = _mapper.Map<RrsChronosTimeSheet.Core.Domain.Entities.TelefoneProfissional>(dto);

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
