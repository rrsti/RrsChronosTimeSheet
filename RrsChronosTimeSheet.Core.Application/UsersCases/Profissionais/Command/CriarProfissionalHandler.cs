using MediatR;
using AutoMapper;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Profissionais.Command
{
    public class CriarProfissionalHandler : IRequestHandler<CriarProfissionalCommand, Guid>
    {
        private readonly IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.Profissional> _baseRepository;
        private readonly IMapper _mapper;

        public CriarProfissionalHandler(IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.Profissional> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CriarProfissionalCommand request, CancellationToken cancellationToken)
        {
            var profissional = _mapper.Map<Profissional>(request.Profissional);

            await _baseRepository.AddAsync(profissional);
            return profissional.Id;
        }
    }
}
