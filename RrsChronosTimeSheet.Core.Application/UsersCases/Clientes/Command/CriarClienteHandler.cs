using MediatR;
using AutoMapper;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Clientes.Command
{
    public class CriarClienteHandler : IRequestHandler<CriarClienteCommand, Guid>
    {
        private readonly IBaseCommandRepository<Cliente> _baseRepository;
        private readonly IMapper _mapper;

        public CriarClienteHandler(IBaseCommandRepository<Cliente> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;   
        }

        public async Task<Guid> Handle(CriarClienteCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Cliente;
            var cliente = _mapper.Map<Cliente>(dto);

            await _baseRepository.AddAsync(cliente);
            return dto.Id;
        }
    }
}
