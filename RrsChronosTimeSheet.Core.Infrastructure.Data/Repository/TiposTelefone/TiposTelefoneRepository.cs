using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Context;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Fornecedores;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.TipoTelefone;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Repository.TiposTelefone
{
    public class TiposTelefoneRepository(ChronosContext dbContext) : ITiposTelefoneRepository<TipoTelefone>
    {
        public async Task<IQueryable<TipoTelefone>> GetTiposTelefonesTotais(Expression<Func<TipoTelefone, bool>>? filtro = null, CancellationToken cancellationToken = default)
        {
            var result = await dbContext.TipoTelefone
                .AsNoTracking()
                .Where(f => !f.IsDeleted)
                .Select(f => new TipoTelefone
                {
                    Id = f.Id,
                    Descricao = f.Descricao
                })
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return result.AsQueryable();

        }
    }
}