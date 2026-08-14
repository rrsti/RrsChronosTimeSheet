using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Clientes
{
    public interface IEmailClienteRepository<EmailCliente>
    {
        public Task<IQueryable<EmailCliente>> GetAllEmailsPorClienteId(Guid ClienteId);
    }
}
