using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Context;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Profissionais;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Repository.Profissionais
{
    public class EmailProfissionalRepository(ChronosContext dbContext) : IEmailProfissionalRepository<EmailProfissional>
    {
        public async Task<IQueryable<EmailProfissional>> GetAllEmailsPorProfissionalId(Guid ProfissionalId)
        {
            var queryEmail = await dbContext.Set<EmailProfissional>()
                .Where(c => c.Profissional != null && c.Profissional.Id == ProfissionalId)
                .AsNoTracking()
                .ToListAsync();
            return queryEmail.AsQueryable();
        }
    }
}
