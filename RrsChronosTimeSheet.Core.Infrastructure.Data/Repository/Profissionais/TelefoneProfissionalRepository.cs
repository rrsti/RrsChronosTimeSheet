using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Context;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Profissionais;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Repository.Profissionais
{
    public class TelefoneProfissionalRepository(ChronosContext dbContext) : ITelefoneProfissionalRepository<TelefoneProfissional>
    {
        public async Task<IQueryable<TelefoneProfissional>> GetAllPorProfissionalId(Guid ProfissionalId)
        {
            var queryTelefone = await dbContext.Set<TelefoneProfissional>()
                .Where(c => c.Profissional != null && c.Profissional.Id == ProfissionalId)
                .AsNoTracking()
                .ToListAsync();
            return queryTelefone.AsQueryable();
        }

        public async Task<IQueryable<TelefoneProfissional>> GetAllPorProfissionalIdAndTipoTelefone(Guid ProfissionalId, Guid TipoTelefoneId)
        {
            var queryTelefone = await dbContext.Set<TelefoneProfissional>()
                .Where(t => t.Profissional != null && t.Profissional.Id == ProfissionalId && t.TipoTelefone != null && t.TipoTelefone.Id == TipoTelefoneId)
                .AsNoTracking()
                .ToListAsync();
            return queryTelefone.AsQueryable();
        }
    }
}
