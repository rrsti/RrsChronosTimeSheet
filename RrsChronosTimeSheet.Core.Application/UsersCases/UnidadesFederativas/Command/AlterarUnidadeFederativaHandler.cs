using MediatR;
using AutoMapper;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;
using RrsChronosTimeSheet.Core.Application.UsersCases.Clientes.Command;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.UnidadesFederativas.Command
{
    public class AlterarUnidadeFederativaHandler : IRequestHandler<AlterarUnidadeFederativaCommand, Guid>
    {
        private readonly IBaseCommandRepository<UnidadeFederativa> _baseRepository;
        private readonly IMapper _mapper;

        public AlterarUnidadeFederativaHandler(IBaseCommandRepository<UnidadeFederativa> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AlterarUnidadeFederativaCommand request, CancellationToken cancellationToken)
        {
            var dto = request.UF;
            var uf = _mapper.Map<UnidadeFederativa>(dto);

            if (uf != null)
            {
                if (uf.Id != null)
                    await _baseRepository.UpdateAsync(uf);
                return dto.Id;
            }
            return dto.Id;
        }
    }
}
