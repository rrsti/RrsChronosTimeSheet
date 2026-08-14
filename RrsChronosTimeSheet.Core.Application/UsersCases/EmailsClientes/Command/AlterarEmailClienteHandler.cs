using MediatR;
using AutoMapper;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.EmailsClientes.Command
{
    public class AlterarEmailClienteHandler : IRequestHandler<AlterarEmailClienteCommand, Guid>
    {
        private readonly IBaseCommandRepository<EmailCliente> _baseRepository;
        private readonly IMapper _mapper;

        public AlterarEmailClienteHandler(IBaseCommandRepository<EmailCliente> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AlterarEmailClienteCommand request, CancellationToken cancellationToken)
        {
            var dto = request.EmailCliente;
            var obj = _mapper.Map<EmailCliente>(dto);

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
