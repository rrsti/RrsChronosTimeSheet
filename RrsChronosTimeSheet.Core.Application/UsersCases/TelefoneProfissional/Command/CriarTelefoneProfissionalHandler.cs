using MediatR;
using AutoMapper;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneProfissional.Command
{
    public class CriarTelefoneProfissionalHandler : IRequestHandler<CriarTelefoneProfissionalCommand, Guid>
    {
        private readonly IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.TelefoneProfissional> _baseRepository;
        private readonly IMapper _mapper;

        public CriarTelefoneProfissionalHandler(IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.TelefoneProfissional> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CriarTelefoneProfissionalCommand request, CancellationToken cancellationToken)
        {
            var telefone = _mapper.Map<RrsChronosTimeSheet.Core.Domain.Entities.TelefoneProfissional>(request);

            await _baseRepository.AddAsync(telefone);
            return telefone.Id;
        }
    }
}
