using AutoMapper;
using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Fornecedores;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Repository.Fornecedores;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Fornecedor.Query
{
    public class GetAllFornecedorQueryHandler : IRequestHandler<GetAllFornecedorQuery, IEnumerable<Domain.Entities.Fornecedor>>
    {
        private readonly IBaseQuerysRepository<Domain.Entities.Fornecedor> _querysRepository;
        private readonly IFornecedorRepository<Domain.Entities.Fornecedor> _fornecedorQueryRepository;
        private readonly IMapper _mapper;

        public GetAllFornecedorQueryHandler(IBaseQuerysRepository<Domain.Entities.Fornecedor> querysRepository,
                                            IFornecedorRepository<Domain.Entities.Fornecedor> fornecedorRepository,
                                            IMapper mapper)
        {
            _querysRepository = querysRepository;
            _fornecedorQueryRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Domain.Entities.Fornecedor>> Handle(GetAllFornecedorQuery request, CancellationToken cancellationToken)
        {
            var requesFornecedor = _mapper.Map<Domain.Entities.Fornecedor>(request);
            var fornecedores = await _fornecedorQueryRepository.GetFornecedoresTotais(filtro: null, cancellationToken: cancellationToken);
            
            //var fornecedores = await _querysRepository.GetWhereAsync(filtro: null, cancellationToken: cancellationToken);

            return fornecedores;
        }
    }
}
