using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Context;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Projetos;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Repository.Projetos
{
    /// <summary>
    /// Repositório específico para a entidade Projeto.
    /// </summary>
    public class ProjetoRepository(ChronosContext dbContext) : IProjetoRepository<Projeto>
    {
        /// <summary>
        /// Obtém todos os projetos de um cliente específico.
        /// </summary>
        /// <param name="ClienteId">ID do cliente.</param>
        /// <returns>Queryable de projetos do cliente.</returns>
        public async Task<IQueryable<Projeto>> GetProjetosPorCliente(Guid ClienteId)
        {
            var projetos = await dbContext.Set<Projeto>()
                .Where(p => p.Cliente != null && p.Cliente.Id == ClienteId)
                .AsNoTracking()
                .ToListAsync();

            return projetos.AsQueryable();
        }

        /// <summary>
        /// Obtém todos os projetos com um status específico.
        /// </summary>
        /// <param name="StatusId">ID do status.</param>
        /// <returns>Queryable de projetos com o status especificado.</returns>
        public async Task<IQueryable<Projeto>> GetProjetosPorStatus(Guid StatusId)
        {
            var projetos = await dbContext.Set<Projeto>()
                .Where(p => p.Status != null && p.Status.Id == StatusId)
                .AsNoTracking()
                .ToListAsync();

            return projetos.AsQueryable();
        }

        /// <summary>
        /// Obtém todos os projetos de um tipo específico.
        /// </summary>
        /// <param name="TipoId">ID do tipo.</param>
        /// <returns>Queryable de projetos do tipo especificado.</returns>
        public async Task<IQueryable<Projeto>> GetProjetosPorTipo(Guid TipoId)
        {
            var projetos = await dbContext.Set<Projeto>()
                .Where(p => p.Tipo != null && p.Tipo.Id == TipoId)
                .AsNoTracking()
                .ToListAsync();

            return projetos.AsQueryable();
        }

        /// <summary>
        /// Obtém todos os projetos de um responsável específico.
        /// </summary>
        /// <param name="ProfissionalId">ID do profissional responsável.</param>
        /// <returns>Queryable de projetos do responsável.</returns>
        public async Task<IQueryable<Projeto>> GetProjetosPorResponsavel(Guid ProfissionalId)
        {
            var projetos = await dbContext.Set<Projeto>()
                .Where(p => p.Responsavel != null && p.Responsavel.Id == ProfissionalId)
                .AsNoTracking()
                .ToListAsync();

            return projetos.AsQueryable();
        }
    }
}
