using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Context;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Profissionais;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Repository.Profissionais
{
    /// <summary>
    /// Repositório específico para a entidade Profissional.
    /// </summary>
    public class ProfissionalRepository(ChronosContext dbContext) : IProfissionalRepository<Profissional>
    {
        /// <summary>
        /// Obtém todos os profissionais de uma unidade federativa específica.
        /// </summary>
        /// <param name="UfId">ID da unidade federativa.</param>
        /// <returns>Queryable de profissionais da UF especificada.</returns>
        public async Task<IQueryable<Profissional>> GetProfissionaisPorUF(Guid UfId)
        {
            var profissionais = await dbContext.Set<Profissional>()
                .Where(p => p.UnidadeFederativa != null && p.UnidadeFederativa.Id == UfId)
                .AsNoTracking()
                .ToListAsync();

            return profissionais.AsQueryable();
        }

        /// <summary>
        /// Obtém todos os profissionais de uma função específica.
        /// </summary>
        /// <param name="FuncaoId">ID da função.</param>
        /// <returns>Queryable de profissionais da função especificada.</returns>
        public async Task<IQueryable<Profissional>> GetProfissionaisPorFuncao(Guid FuncaoId)
        {
            var profissionais = await dbContext.Set<Profissional>()
                .Where(p => p.Funcao != null && p.Funcao.Id == FuncaoId)
                .AsNoTracking()
                .ToListAsync();

            return profissionais.AsQueryable();
        }

        /// <summary>
        /// Obtém todos os profissionais terceirizados.
        /// </summary>
        /// <returns>Queryable de profissionais terceirizados.</returns>
        public async Task<IQueryable<Profissional>> GetProfissionaisTerceirizados()
        {
            var profissionais = await dbContext.Set<Profissional>()
                .Where(p => p.ProfissionalTerceirizado)
                .AsNoTracking()
                .ToListAsync();

            return profissionais.AsQueryable();
        }

        /// <summary>
        /// Obtém todos os profissionais de um fornecedor específico.
        /// </summary>
        /// <param name="FornecedorId">ID do fornecedor.</param>
        /// <returns>Queryable de profissionais do fornecedor especificado.</returns>
        public async Task<IQueryable<Profissional>> GetProfissionaisPorFornecedor(Guid FornecedorId)
        {
            var profissionais = await dbContext.Set<Profissional>()
                .Where(p => p.Fornecedor != null && p.Fornecedor.Id == FornecedorId)
                .AsNoTracking()
                .ToListAsync();

            return profissionais.AsQueryable();
        }
    }
}
