using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.EmailsClientes.Query
{
    public class GetAllEmailClienteQueryHandler : IRequestHandler<GetAllEmailClienteQuery, IEnumerable<EmailCliente>>
    {
        private readonly IBaseQuerysRepository<EmailCliente> _querysRepository;

        public GetAllEmailClienteQueryHandler(IBaseQuerysRepository<EmailCliente> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<EmailCliente>> Handle(GetAllEmailClienteQuery request, CancellationToken cancellationToken)
        {
            var emails = await _querysRepository.GetWhereAsync(
                filtro: null,
                cancellationToken: cancellationToken);

            return emails;
        }
    }
}
