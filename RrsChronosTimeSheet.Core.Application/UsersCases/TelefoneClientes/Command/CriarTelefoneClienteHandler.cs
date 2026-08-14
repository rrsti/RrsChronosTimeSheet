using MediatR;
using AutoMapper;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;
using RrsChronosTimeSheet.Core.Application.UsersCases.TipoTelefone.Command;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneClientes.Command
{
    public class CriarTelefoneClienteHandler : IRequestHandler<CriarTelefoneClienteCommand, Guid>
    {
        private readonly IBaseCommandRepository<TelefoneCliente> _baseRepository;
        private readonly IMapper _mapper;

        public CriarTelefoneClienteHandler(IBaseCommandRepository<TelefoneCliente> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CriarTelefoneClienteCommand request, CancellationToken cancellationToken)
        {
            var dto = request.TelefonesCliente;
            var obj = _mapper.Map<TelefoneCliente>(dto);

            await _baseRepository.AddAsync(obj);
            return dto.Id;
        }
    }
}
