using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Context;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Tarefa;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Repository.Tarefa
{
    /// <summary>
    /// Repositório específico para a entidade Tarefas.
    /// </summary>
    public class TarefasRepository(ChronosContext dbContext) : ITarefasRepository<Tarefas>
    {
        /// <summary>
        /// Obtém todas as tarefas de um projeto específico.
        /// </summary>
        /// <param name="ProjetoId">ID do projeto.</param>
        /// <returns>Queryable de tarefas do projeto.</returns>
        public async Task<IQueryable<Tarefas>> GetTarefasPorProjeto(Guid ProjetoId)
        {
            var tarefas = await dbContext.Set<Tarefas>()
                .Where(t => t.Projeto != null && t.Projeto.Id == ProjetoId)
                .AsNoTracking()
                .ToListAsync();

            return tarefas.AsQueryable();
        }

        /// <summary>
        /// Obtém todas as tarefas de um responsável específico.
        /// </summary>
        /// <param name="ProfissionalId">ID do profissional responsável.</param>
        /// <returns>Queryable de tarefas do responsável.</returns>
        public async Task<IQueryable<Tarefas>> GetTarefasPorResponsavel(Guid ProfissionalId)
        {
            var tarefas = await dbContext.Set<Tarefas>()
                .Where(t => t.Responsavel != null && t.Responsavel.Id == ProfissionalId)
                .AsNoTracking()
                .ToListAsync();

            return tarefas.AsQueryable();
        }

        /// <summary>
        /// Obtém todas as tarefas com um status específico.
        /// </summary>
        /// <param name="StatusId">ID do status.</param>
        /// <returns>Queryable de tarefas com o status especificado.</returns>
        public async Task<IQueryable<Tarefas>> GetTarefasPorStatus(Guid StatusId)
        {
            var tarefas = await dbContext.Set<Tarefas>()
                .Where(t => t.Status != null && t.Status.Id == StatusId)
                .AsNoTracking()
                .ToListAsync();

            return tarefas.AsQueryable();
        }

        /// <summary>
        /// Obtém todas as tarefas ativas.
        /// </summary>
        /// <returns>Queryable de tarefas ativas.</returns>
        public async Task<IQueryable<Tarefas>> GetTarefasAtivas()
        {
            var tarefas = await dbContext.Set<Tarefas>()
                .Where(t => t.IsAtivo && !t.IsDeleted && t.DataFim == null)
                .AsNoTracking()
                .ToListAsync();

            return tarefas.AsQueryable();
        }
    }
}
