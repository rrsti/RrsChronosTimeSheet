using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Context;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Tarefa;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Repository.Tarefa
{
    /// <summary>
    /// Repositório específico para a entidade ComentarioTarefa.
    /// </summary>
    public class ComentarioTarefaRepository(ChronosContext dbContext) : IComentarioTarefaRepository<ComentarioTarefa>
    {
        /// <summary>
        /// Obtém todos os comentários de uma tarefa específica.
        /// </summary>
        /// <param name="TarefaId">ID da tarefa.</param
        /// <returns>Queryable de comentários da tarefa.</returns>
        public async Task<IQueryable<ComentarioTarefa>> GetComentariosPorTarefa(Guid TarefaId)
        {
            var comentarios = await dbContext.Set<ComentarioTarefa>()
                .Where(c => c.Tarefa != null && c.Tarefa.Id == TarefaId)
                .AsNoTracking()
                .ToListAsync();

            return comentarios.AsQueryable();
        }

        /// <summary>
        /// Obtém todos os comentários criados por um usuário específico.
        /// </summary>
        /// <param name="UsuarioId">ID do usuário.</param>
        /// <returns>Queryable de comentários do usuário.</returns>
        public async Task<IQueryable<ComentarioTarefa>> GetComentariosPorAutor(Guid UsuarioId)
        {
            var comentarios = await dbContext.Set<ComentarioTarefa>()
                .Where(c => c.UsuarioCriacao == UsuarioId)
                .AsNoTracking()
                .ToListAsync();

            return comentarios.AsQueryable();
        }
    }
}
