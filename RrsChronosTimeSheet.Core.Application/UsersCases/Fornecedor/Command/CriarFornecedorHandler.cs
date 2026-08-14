using MediatR;
using AutoMapper;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Fornecedor.Command
{
    public class CriarFornecedorHandler : IRequestHandler<CriarFornecedorCommand, Guid>
    {
        private readonly IBaseCommandRepository<Domain.Entities.Fornecedor> _baseRepository;
        private readonly IMapper _mapper;

        public CriarFornecedorHandler(IBaseCommandRepository<Domain.Entities.Fornecedor> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CriarFornecedorCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Fornecedor;
            var fornecedor = _mapper.Map<Domain.Entities.Fornecedor>(dto);

            await _baseRepository.AddAsync(fornecedor);
            return fornecedor.Id;
        }
    }
}
