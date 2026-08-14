using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Context;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Fornecedores;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Repository.Fornecedores
{
    public class EmailFornecedorRepository(ChronosContext dbContext) : IEmailFornecedorRepository<EmailFornecedor>
    {
        public async Task<IQueryable<EmailFornecedor>> GetAllEmailsPorFornecedorId(Guid FornecedorId)
        {
            var queryEmail = await dbContext.Set<EmailFornecedor>()
                .Where(c => c.Fornecedor != null && c.Fornecedor.Id == FornecedorId)
                .AsNoTracking()
                .ToListAsync();
            return queryEmail.AsQueryable();
        }
    }
}
