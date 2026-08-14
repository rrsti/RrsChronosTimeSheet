using MediatR;
using AutoMapper;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.HorasProfissional.Command
{
    public class CriarHorasProfissionalHandler : IRequestHandler<CriarHorasProfissionalCommand, Guid>
    {
        private readonly IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.HorasProfissional> _baseRepository;
        private readonly IMapper _mapper;

        public CriarHorasProfissionalHandler(IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.HorasProfissional> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CriarHorasProfissionalCommand request, CancellationToken cancellationToken)
        {
            var hora = _mapper.Map<Domain.Entities.HorasProfissional>(request.Horas); ;

            await _baseRepository.AddAsync(hora);
            return hora.Id;
        }
    }
}
