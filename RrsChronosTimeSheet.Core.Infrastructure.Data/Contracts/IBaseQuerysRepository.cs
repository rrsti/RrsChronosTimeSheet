using System.Linq.Expressions;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Specifications;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts
{
    /// <summary>
    /// Interface para operações de consulta (Read) em repositórios genéricos.
    /// </summary>
    /// <typeparam name="T">Tipo da entidade.</typeparam>
    public interface IBaseQuerysRepository<T> where T : class
    {
        /// <summary>
        /// Obtém todas as entidades que atendem ao filtro especificado.
        /// </summary>
        /// <param name="filtro">Expressão de filtro lambda (opcional).</param>
        /// <param name="cancellationToken">Token para cancelamento de operação.</param>
        /// <returns>Coleção de entidades.</returns>
        Task<IEnumerable<T>> GetWhereAsync(
            Expression<Func<T, bool>>? filtro = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtém a primeira entidade que atende ao filtro, ordenada conforme especificado.
        /// </summary>
        /// <typeparam name="TProperty">Tipo da propriedade de ordenação.</typeparam>
        /// <param name="filtro">Expressão de filtro lambda.</param>
        /// <param name="orderBy">Expressão de ordenação lambda.</param>
        /// <param name="cancellationToken">Token para cancelamento de operação.</param>
        /// <returns>A entidade encontrada ou null.</returns>
        Task<T?> GetFirstAsync<TProperty>(
            Expression<Func<T, bool>> filtro,
            Expression<Func<T, TProperty>> orderBy,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtém entidades que atendem à especificação fornecida.
        /// </summary>
        /// <param name="specification">Objeto de Specification com critérios, includes, ordenação e paginação.</param>
        /// <param name="cancellationToken">Token para cancelamento de operação.</param>
        /// <returns>Coleção de entidades filtradas conforme a specification.</returns>
        Task<IEnumerable<T>> GetBySpecificationAsync(
            ISpecification<T> specification,
            CancellationToken cancellationToken = default);
    }
}
