namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts
{
    /// <summary>
    /// Interface para operações de comando (Create, Update, Delete) em repositórios genéricos.
    /// </summary>
    /// <typeparam name="T">Tipo da entidade.</typeparam>
    public interface IBaseCommandRepository<T> where T : class
    {
        /// <summary>
        /// Adiciona uma nova entidade e salva as alterações.
        /// </summary>
        /// <param name="obj">Entidade a ser adicionada.</param>
        /// <param name="cancellationToken">Token para cancelamento de operação.</param>
        /// <returns>A entidade adicionada.</returns>
        Task<T> AddAsync(T obj, CancellationToken cancellationToken = default);

        /// <summary>
        /// Atualiza uma entidade existente e salva as alterações.
        /// </summary>
        /// <param name="obj">Entidade com dados atualizados.</param>
        /// <param name="cancellationToken">Token para cancelamento de operação.</param>
        /// <returns>A entidade atualizada.</returns>
        Task<T> UpdateAsync(T obj, CancellationToken cancellationToken = default);

        /// <summary>
        /// Remove uma entidade e salva as alterações.
        /// </summary>
        /// <param name="obj">Entidade a ser removida.</param>
        /// <param name="cancellationToken">Token para cancelamento de operação.</param>
        /// <returns>Task representando a operação assíncrona.</returns>
        Task RemoveAsync(T obj, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adiciona uma entidade sem salvar imediatamente.
        /// Use CommitAsync do UnitOfWork para confirmar as alterações.
        /// </summary>
        /// <param name="obj">Entidade a ser adicionada.</param>
        /// <returns>A entidade adicionada.</returns>
        T Add(T obj);

        /// <summary>
        /// Atualiza uma entidade sem salvar imediatamente.
        /// Use CommitAsync do UnitOfWork para confirmar as alterações.
        /// </summary>
        /// <param name="obj">Entidade com dados atualizados.</param>
        /// <returns>A entidade atualizada.</returns>
        T Update(T obj);

        /// <summary>
        /// Remove uma entidade sem salvar imediatamente.
        /// Use CommitAsync do UnitOfWork para confirmar as alterações.
        /// </summary>
        /// <param name="obj">Entidade a ser removida.</param>
        void Remove(T obj);
    }
}
