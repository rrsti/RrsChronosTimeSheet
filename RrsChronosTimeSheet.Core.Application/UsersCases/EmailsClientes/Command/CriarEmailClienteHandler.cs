using MediatR;
using AutoMapper;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.EmailsClientes.Command
{
    public class CriarEmailClienteHandler : IRequestHandler<CriarEmailClienteCommand, Guid>
    {
        private readonly IBaseCommandRepository<EmailCliente> _baseRepository;
        private readonly IMapper _mapper;

        public CriarEmailClienteHandler(IBaseCommandRepository<EmailCliente> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CriarEmailClienteCommand request, CancellationToken cancellationToken)
        {
            var dto = request.EmailCliente;
            var obj = _mapper.Map<EmailCliente>(dto);

            await _baseRepository.AddAsync(obj);
            return dto.Id;
        }
    }
}
