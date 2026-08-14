using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Clientes
{
    public interface IClienteRepository<Cliente>
    {
        public Task<IQueryable<Cliente>> GetClientesPorUF(Guid UfId);
    }

}
