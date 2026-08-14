using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Context;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.HorasProfissionais;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Repository.HorasProfissionais
{
    /// <summary>
    /// Repositório específico para a entidade HorasProfissional.
    /// </summary>
    public class HorasProfissionalRepository(ChronosContext dbContext) : IHorasProfissionalRepository<HorasProfissional>
    {
        /// <summary>
        /// Obtém todas as horas registradas por um profissional específico.
        /// </summary>
        /// <param name="ProfissionalId">ID do profissional.</param>
        /// <returns>Queryable de horas do profissional.</returns>
        public async Task<IQueryable<HorasProfissional>> GetHorasPorProfissional(Guid ProfissionalId)
        {
            var horas = await dbContext.Set<HorasProfissional>()
                .Where(h => h.Profissional != null && h.Profissional.Id == ProfissionalId)
                .AsNoTracking()
                .ToListAsync();

            return horas.AsQueryable();
        }

        /// <summary>
        /// Obtém todas as horas registradas para uma tarefa específica.
        /// </summary>
        /// <param name="TarefaId">ID da tarefa.</param>
        /// <returns>Queryable de horas da tarefa.</returns>
        public async Task<IQueryable<HorasProfissional>> GetHorasPorTarefa(Guid TarefaId)
        {
            var horas = await dbContext.Set<HorasProfissional>()
                .Where(h => h.Tarefa != null && h.Tarefa.Id == TarefaId)
                .AsNoTracking()
                .ToListAsync();

            return horas.AsQueryable();
        }

        /// <summary>
        /// Obtém todas as horas registradas entre duas datas.
        /// </summary>
        /// <param name="DataInicio">Data de início.</param>
        /// <param name="DataFim">Data de fim.</param>
        /// <returns>Queryable de horas no período especificado.</returns>
        public async Task<IQueryable<HorasProfissional>> GetHorasEntreData(DateTime DataInicio, DateTime DataFim)
        {
            var horas = await dbContext.Set<HorasProfissional>()
                .Where(h => h.DataCriacao >= DataInicio && h.DataCriacao <= DataFim)
                .AsNoTracking()
                .ToListAsync();

            return horas.AsQueryable();
        }

        /// <summary>
        /// Obtém todas as horas de um profissional em uma tarefa específica.
        /// </summary>
        /// <param name="ProfissionalId">ID do profissional.</param>
        /// <param name="TarefaId">ID da tarefa.</param>
        /// <returns>Queryable de horas do profissional na tarefa.</returns>
        public async Task<IQueryable<HorasProfissional>> GetHorasPorProfissionalETarefa(Guid ProfissionalId, Guid TarefaId)
        {
            var horas = await dbContext.Set<HorasProfissional>()
                .Where(h => h.Profissional != null && h.Profissional.Id == ProfissionalId && h.Tarefa != null && h.Tarefa.Id == TarefaId)
                .AsNoTracking()
                .ToListAsync();

            return horas.AsQueryable();
        }
    }
}
