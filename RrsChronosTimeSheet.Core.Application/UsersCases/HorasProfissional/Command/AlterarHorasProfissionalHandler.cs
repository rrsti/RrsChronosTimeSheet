using MediatR;
using AutoMapper;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.HorasProfissional.Command
{
    public class AlterarHorasProfissionalHandler : IRequestHandler<AlterarHorasProfissionalCommand, Guid>
    {
        private readonly IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.HorasProfissional> _baseRepository;
        private readonly IMapper _mapper;

        public AlterarHorasProfissionalHandler(IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.HorasProfissional> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AlterarHorasProfissionalCommand request, CancellationToken cancellationToken)
        {
            var hora = _mapper.Map<Domain.Entities.HorasProfissional>(request.Horas);
           
            if (hora != null)
            {
                if (hora.Id.ToString() != String.Empty)
                {
                    hora.DataAtualizacao = DateTime.Now.Date;
                }
            }

            await _baseRepository.UpdateAsync(hora);
            return hora.Id;
        }
    }
}
