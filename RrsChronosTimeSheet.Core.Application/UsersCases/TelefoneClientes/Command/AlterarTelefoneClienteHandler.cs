using MediatR;
using AutoMapper;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;
using RrsChronosTimeSheet.Core.Application.UsersCases.TipoTelefone.Command;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneClientes.Command
{
    public class AlterarTelefoneClienteHandler : IRequestHandler<AlterarTelefoneClienteCommand, Guid>
    {
        private readonly IBaseCommandRepository<TelefoneCliente> _baseRepository;
        private readonly IMapper _mapper;

        public AlterarTelefoneClienteHandler(IBaseCommandRepository<TelefoneCliente> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AlterarTelefoneClienteCommand request, CancellationToken cancellationToken)
        {
            var dto = request.TelefoneCliente;
            var obj = _mapper.Map<TelefoneCliente>(dto);

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
