using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Fornecedores;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Fornecedor.Query
{
    public class GetFornecedorByIdUFQueryHandler : IRequestHandler<GetFornecedorByIdUFQuery, IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.Fornecedor>>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Fornecedor> _querysRepository;
        private readonly IFornecedorRepository<RrsChronosTimeSheet.Core.Domain.Entities.Fornecedor> _fornecedorQueryRepository;

        public GetFornecedorByIdUFQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Fornecedor> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.Fornecedor>> Handle(GetFornecedorByIdUFQuery request, CancellationToken cancellationToken)
        {
            var fornecedores = await _fornecedorQueryRepository.GetClientesPorUF(request.IdUnidadeFederativa);
            return fornecedores;
        }
    }
}
