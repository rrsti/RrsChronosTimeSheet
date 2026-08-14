using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Clientes
{
    public interface ITelefoneClienteRepository<TelefoneCliente>
    {
        public Task<IQueryable<TelefoneCliente>> GetAllPorClienteId(Guid ClienteId);

        public Task<IQueryable<TelefoneCliente>> GetAllPorClienteIdAndTipoTelefone(Guid ClienteId, Guid TipoTelefoneId);

    }
}
