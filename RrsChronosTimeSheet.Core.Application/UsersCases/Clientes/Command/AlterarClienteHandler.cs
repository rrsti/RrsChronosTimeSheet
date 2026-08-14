using MediatR;
using AutoMapper;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Clientes.Command
{
    public class AlterarClienteHandler : IRequestHandler<AlterarClienteCommand, Guid>
    {
        private readonly IBaseCommandRepository<Cliente> _baseRepository;
        private readonly IMapper _mapper;

        public AlterarClienteHandler(IBaseCommandRepository<Cliente> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(AlterarClienteCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Cliente;
            var obj = _mapper.Map<Cliente>(dto);

            if (obj != null)
            {
                if (obj.Id != null)
                {
                    obj.DataAtualizacao = DateTime.Now.Date;
                    await _baseRepository.UpdateAsync(obj);
                }
                return dto.Id;
            }
            return dto.Id;
        }
    }
}
