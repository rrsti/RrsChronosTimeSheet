namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts
{
    /// <summary>
    /// Interface para o padrão Unit of Work.
    /// Gerencia o ciclo de vida de transações e operações de banco de dados.
    /// </summary>
    public interface IUnitOfWork : IAsyncDisposable, IDisposable
    {
        /// <summary>
        /// Inicia uma transação de banco de dados.
        /// </summary>
        /// <param name="cancellationToken">Token para cancelamento de operação.</param>
        /// <returns>Task representando a operação assíncrona.</returns>
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Confirma todas as alterações pendentes e valida a transação.
        /// </summary>
        /// <param name="cancellationToken">Token para cancelamento de operação.</param>
        /// <returns>Task representando a operação assíncrona.</returns>
        Task CommitAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Reverte todas as alterações pendentes.
        /// </summary>
        /// <param name="cancellationToken">Token para cancelamento de operação.</param>
        /// <returns>Task representando a operação assíncrona.</returns>
        Task RollbackAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Salva todas as mudanças rastreadas pelo contexto.
        /// </summary>
        /// <param name="cancellationToken">Token para cancelamento de operação.</param>
        /// <returns>Task representando a operação assíncrona.</returns>
        Task SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtém o contexto do banco de dados.
        /// </summary>
        /// <remarks>
        /// Use com cautela. Preferencialmente, utilize os repositórios.
        /// </remarks>
        IUnitOfWorkContext Context { get; }

        /// <summary>
        /// Obtém um valor indicando se uma transação está ativa.
        /// </summary>
        bool HasActiveTransaction { get; }
    }

    /// <summary>
    /// Interface para o contexto do Unit of Work.
    /// </summary>
    public interface IUnitOfWorkContext
    {
        /// <summary>
        /// Obtém o DbSet para uma entidade específica.
        /// </summary>
        /// <typeparam name="T">Tipo da entidade.</typeparam>
        /// <returns>DbSet para a entidade.</returns>
        Microsoft.EntityFrameworkCore.DbSet<T> Set<T>() where T : class;

        /// <summary>
        /// Salva todas as mudanças no banco de dados.
        /// </summary>
        /// <param name="cancellationToken">Token para cancelamento de operação.</param>
        /// <returns>Número de entidades afetadas.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Inicia uma transação de banco de dados.
        /// </summary>
        Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction BeginTransaction();

        /// <summary>
        /// Inicia uma transação de banco de dados de forma assíncrona.
        /// </summary>
        Task<Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction> BeginTransactionAsync(
            CancellationToken cancellationToken = default);
    }
}
