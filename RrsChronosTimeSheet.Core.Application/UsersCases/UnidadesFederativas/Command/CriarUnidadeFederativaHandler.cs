using MediatR;
using AutoMapper;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;
using RrsChronosTimeSheet.Core.Application.UsersCases.Clientes.Command;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.UnidadesFederativas.Command
{
    public class CriarUnidadeFederativaHandler : IRequestHandler<CriarUnidadeFederativaCommand, Guid>
    {
        private readonly IBaseCommandRepository<UnidadeFederativa> _baseRepository;
        private readonly IMapper _mapper;

        public CriarUnidadeFederativaHandler(IBaseCommandRepository<UnidadeFederativa> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CriarUnidadeFederativaCommand request, CancellationToken cancellationToken)
        {
            var dto = request.UF;
            var uf = _mapper.Map<UnidadeFederativa>(dto);

            await _baseRepository.AddAsync(uf);
            return dto.Id;
        }
    }
}
