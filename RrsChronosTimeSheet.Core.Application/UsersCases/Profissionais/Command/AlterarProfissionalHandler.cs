using MediatR;
using AutoMapper;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Profissionais.Command
{
    public class AlterarProfissionalHandler : IRequestHandler<AlterarProfissionalCommand, Guid>
    {
        private readonly IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.Profissional> _baseRepository;
        private readonly IMapper _mapper;

        public AlterarProfissionalHandler(IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.Profissional> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AlterarProfissionalCommand request, CancellationToken cancellationToken)
        {
            var profissional = _mapper.Map<Profissional>(request.Profissional);

            if (profissional != null)
            {
                if (profissional.Id.ToString() !=  String.Empty)
                {
                    profissional.DataAtualizacao = DateTime.Now.Date;
                }
            }

            await _baseRepository.UpdateAsync(profissional);
            return profissional.Id;
        }
    }
}
