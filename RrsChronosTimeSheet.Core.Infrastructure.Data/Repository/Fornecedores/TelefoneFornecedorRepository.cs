using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Context;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Fornecedores;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Repository.Fornecedores
{
    public class TelefoneFornecedorRepository(ChronosContext dbContext) : ITelefoneFornecedorRepository<TelefoneFornecedor>
    {
        public async Task<IQueryable<TelefoneFornecedor>> GetAllPorFornecedorId(Guid FornecedorId)
        {
            var queryTelefone = await dbContext.Set<TelefoneFornecedor>()
                .Where(c => c.Fornecedor != null && c.Fornecedor.Id == FornecedorId)
                .AsNoTracking()
                .ToListAsync();
            return queryTelefone.AsQueryable();
        }

        public async Task<IQueryable<TelefoneFornecedor>> GetAllPorFornecedorIdAndTipoTelefone(Guid FornecedorId, Guid TipoTelefoneId)
        {
            var queryTelefone = await dbContext.Set<TelefoneFornecedor>()
                .Where(t => t.Fornecedor != null && t.Fornecedor.Id == FornecedorId && t.TipoTelefone != null && t.TipoTelefone.Id == TipoTelefoneId)
                .AsNoTracking()
                .ToListAsync();
            return queryTelefone.AsQueryable();
        }
    }
}
