using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.EmailsClientes.Query
{
    public class GetEmailClienteByIdQueryHandler : IRequestHandler<GetEmailClienteByIdQuery, EmailCliente>
    {
        private readonly IBaseQuerysRepository<EmailCliente> _querysRepository;

        public GetEmailClienteByIdQueryHandler(IBaseQuerysRepository<EmailCliente> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<EmailCliente> Handle(GetEmailClienteByIdQuery request, CancellationToken cancellationToken)
        {
            var email = await _querysRepository.GetFirstAsync(
                filtro: e => e.Id == request.Id,
                orderBy: e => e.Id,
                cancellationToken: cancellationToken);

            return email ?? throw new KeyNotFoundException($"Email com id {request.Id} não encontrado.");
        }
    }
}
