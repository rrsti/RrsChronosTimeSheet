using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Context;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Clientes;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Repository.Clientes
{
    public class EmailClienteRepository(ChronosContext dbContext) : IEmailClienteRepository<EmailCliente>
    {
        public async Task<IQueryable<EmailCliente>> GetAllEmailsPorClienteId(Guid ClienteId)
        {
            var queryEmail = await dbContext.Set<EmailCliente>()
                .Where(c => c.Cliente != null && c.Cliente.Id == ClienteId)
                .AsNoTracking()
                .ToListAsync();
            return queryEmail.AsQueryable();
        }
    }
}
