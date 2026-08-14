using MediatR;
using AutoMapper;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Fornecedor.Command
{
    public class AlterarFornecedorHandler : IRequestHandler<AlterarFornecedorCommand, Guid>
    {
        private readonly IBaseCommandRepository<Domain.Entities.Fornecedor> _baseRepository;
        private readonly IMapper _mapper;

        public AlterarFornecedorHandler(IBaseCommandRepository<Domain.Entities.Fornecedor> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AlterarFornecedorCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Fornecedor;
            var fornecedor = _mapper.Map<Domain.Entities.Fornecedor>(dto);

            fornecedor.DataAtualizacao = DateTime.Now.Date;

            await _baseRepository.UpdateAsync(fornecedor);
            return fornecedor.Id;
        }
    }
}
