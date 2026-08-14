using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using RrsChronosTimeSheet.Core.Infrastructure.Data.Context;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Specifications;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Repository
{
    /// <summary>
    /// Repositório base genérico para operações de consulta (Read).
    /// </summary>
    /// <typeparam name="T">Tipo da entidade.</typeparam>
    public class BaseQuerysRepository<T> : IBaseQuerysRepository<T> where T : class
    {
        protected readonly IUnitOfWorkContext _context;
        protected readonly DbSet<T> _dbSet;

        /// <summary>
        /// Inicializa uma nova instância da classe BaseQuerysRepository.
        /// </summary>
        /// <param name="unitOfWork">Unit of Work para acessar o contexto.</param>
        /// <exception cref="ArgumentNullException">Quando unitOfWork é nulo.</exception>
        public BaseQuerysRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork), "Unit of Work não pode ser nulo.");

            _context = unitOfWork.Context;
            _dbSet = _context.Set<T>();
        }

        /// <summary>
        /// Obtém todas as entidades que atendem ao filtro especificado.
        /// </summary>
        /// <param name="filtro">Expressão de filtro lambda (opcional).</param>
        /// <param name="cancellationToken">Token para cancelamento de operação.</param>
        /// <returns>Coleção de entidades.</returns>
        public virtual async Task<IEnumerable<T>> GetWhereAsync(
            Expression<Func<T, bool>>? filtro = null,
            CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbSet;

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            return await query
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Obtém a primeira entidade que atende ao filtro, ordenada conforme especificado.
        /// </summary>
        /// <typeparam name="TProperty">Tipo da propriedade de ordenação.</typeparam>
        /// <param name="filtro">Expressão de filtro lambda.</param>
        /// <param name="orderBy">Expressão de ordenação lambda.</param>
        /// <param name="cancellationToken">Token para cancelamento de operação.</param>
        /// <returns>A entidade encontrada ou null.</returns>
        public virtual async Task<T?> GetFirstAsync<TProperty>(
            Expression<Func<T, bool>> filtro,
            Expression<Func<T, TProperty>> orderBy,
            CancellationToken cancellationToken = default)
        {
            if (filtro == null)
                throw new ArgumentNullException(nameof(filtro), "Filtro não pode ser nulo.");

            if (orderBy == null)
                throw new ArgumentNullException(nameof(orderBy), "Expressão de ordenação não pode ser nula.");

            return await _dbSet
                .AsNoTracking()
                .OrderBy(orderBy)
                .FirstOrDefaultAsync(filtro, cancellationToken);
        }

        /// <summary>
        /// Obtém entidades que atendem à especificação fornecida.
        /// </summary>
        /// <param name="specification">Objeto de Specification com critérios, includes, ordenação e paginação.</param>
        /// <param name="cancellationToken">Token para cancelamento de operação.</param>
        /// <returns>Coleção de entidades filtradas conforme a specification.</returns>
        public virtual async Task<IEnumerable<T>> GetBySpecificationAsync(
            ISpecification<T> specification,
            CancellationToken cancellationToken = default)
        {
            if (specification == null)
                throw new ArgumentNullException(nameof(specification), "Specification não pode ser nula.");

            var query = SpecificationEvaluator<T>.GetQuery(_dbSet.AsQueryable(), specification);

            return await query
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
