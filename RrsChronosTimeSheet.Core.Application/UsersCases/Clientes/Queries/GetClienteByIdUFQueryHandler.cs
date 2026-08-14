using MediatR;
using RrsChronosTimeSheet.Core.Application.Queries.Specifications;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Clientes.Queries
{
    public class GetClienteByIdUFQueryHandler : IRequestHandler<GetClienteByIdUFQuery, IEnumerable<Cliente>>
    {
        private readonly IBaseQuerysRepository<Cliente> _querysRepository;

        public GetClienteByIdUFQueryHandler(IBaseQuerysRepository<Cliente> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<Cliente>> Handle(GetClienteByIdUFQuery request, CancellationToken cancellationToken)
        {
            var specification = new ClienteByUfSpecification(request.IdUnidadeFederativa);
            var clientes = await _querysRepository.GetBySpecificationAsync(specification, cancellationToken);

            return clientes;
        }
    }
}
