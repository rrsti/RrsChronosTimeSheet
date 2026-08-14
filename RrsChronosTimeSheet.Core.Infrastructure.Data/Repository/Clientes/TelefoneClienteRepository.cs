using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Context;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Clientes;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Repository.Clientes
{
    public class TelefoneClienteRepository(ChronosContext dbContext) : ITelefoneClienteRepository<TelefoneCliente>
    {
        public async Task<IQueryable<TelefoneCliente>> GetAllPorClienteId(Guid ClienteId)
        {
            var queryTelefone = await dbContext.Set<TelefoneCliente>()
                .Where(c => c.Cliente != null && c.Cliente.Id == ClienteId)
                .AsNoTracking()
                .ToListAsync();
            return queryTelefone.AsQueryable();
        }

        public async Task<IQueryable<TelefoneCliente>> GetAllPorClienteIdAndTipoTelefone(Guid ClienteId, Guid TipoTelefoneId)
        {
            var queryTelefone = await dbContext.Set<TelefoneCliente>()
                .Where(t => t.Cliente != null && t.Cliente.Id == ClienteId && t.TipoTelefone != null && t.TipoTelefone.Id == TipoTelefoneId)
                .AsNoTracking()
                .ToListAsync();
            return queryTelefone.AsQueryable();
        }
    }
}
