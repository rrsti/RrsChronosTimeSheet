using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

using RrsChronosTimeSheet.Core.Infrastructure.Data.Context;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Repository
{
    /// <summary>
    /// Repositório base genérico para operações de comando (Create, Update, Delete).
    /// Utiliza o padrão Unit of Work para gerenciar transações.
    /// </summary>
    /// <typeparam name="T">Tipo da entidade.</typeparam>
    public class BaseCommandRepository<T> : IBaseCommandRepository<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IUnitOfWorkContext _context;
        protected readonly DbSet<T> _dbSet;

        /// <summary>
        /// Inicializa uma nova instância da classe BaseCommandRepository.
        /// </summary>
        /// <param name="unitOfWork">Unit of Work para gerenciar operações.</param>
        /// <exception cref="ArgumentNullException">Quando unitOfWork é nulo.</exception>
        public BaseCommandRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork), "Unit of Work não pode ser nulo.");
            _context = _unitOfWork.Context;
            _dbSet = _context.Set<T>();
        }

        /// <summary>
        /// Adiciona uma nova entidade e salva as alterações imediatamente.
        /// </summary>
        /// <param name="obj">Entidade a ser adicionada.</param>
        /// <param name="cancellationToken">Token para cancelamento de operação.</param>
        /// <returns>A entidade adicionada.</returns>
        /// <exception cref="ArgumentNullException">Quando obj é nulo.</exception>
        public virtual async Task<T> AddAsync(T obj, CancellationToken cancellationToken = default)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), "A entidade não pode ser nula.");

            try
            {
                Add(obj);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                Debug.WriteLine($"[BaseCommandRepository] Entidade {typeof(T).Name} adicionada com sucesso.");
                return obj;
            }
            catch (DbUpdateException ex)
            {
                Debug.WriteLine($"[BaseCommandRepository] Erro ao adicionar entidade: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Atualiza uma entidade existente e salva as alterações imediatamente.
        /// </summary>
        /// <param name="obj">Entidade com dados atualizados.</param>
        /// <param name="cancellationToken">Token para cancelamento de operação.</param>
        /// <returns>A entidade atualizada.</returns>
        /// <exception cref="ArgumentNullException">Quando obj é nulo.</exception>
        public virtual async Task<T> UpdateAsync(T obj, CancellationToken cancellationToken = default)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), "A entidade não pode ser nula.");

            try
            {
                Update(obj);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                Debug.WriteLine($"[BaseCommandRepository] Entidade {typeof(T).Name} atualizada com sucesso.");
                return obj;
            }
            catch (DbUpdateException ex)
            {
                Debug.WriteLine($"[BaseCommandRepository] Erro ao atualizar entidade: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Remove uma entidade e salva as alterações imediatamente.
        /// </summary>
        /// <param name="obj">Entidade a ser removida.</param>
        /// <param name="cancellationToken">Token para cancelamento de operação.</param>
        /// <returns>Task representando a operação assíncrona.</returns>
        /// <exception cref="ArgumentNullException">Quando obj é nulo.</exception>
        public virtual async Task RemoveAsync(T obj, CancellationToken cancellationToken = default)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), "A entidade não pode ser nula.");

            try
            {
                Remove(obj);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                Debug.WriteLine($"[BaseCommandRepository] Entidade {typeof(T).Name} removida com sucesso.");
            }
            catch (DbUpdateException ex)
            {
                Debug.WriteLine($"[BaseCommandRepository] Erro ao remover entidade: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Adiciona uma entidade sem salvar imediatamente.
        /// Use CommitAsync do UnitOfWork para confirmar as alterações.
        /// </summary>
        /// <param name="obj">Entidade a ser adicionada.</param>
        /// <returns>A entidade adicionada.</returns>
        /// <exception cref="ArgumentNullException">Quando obj é nulo.</exception>
        public virtual T Add(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), "A entidade não pode ser nula.");

            _dbSet.Add(obj);
            Debug.WriteLine($"[BaseCommandRepository] Entidade {typeof(T).Name} marcada para adição.");
            return obj;
        }

        /// <summary>
        /// Atualiza uma entidade sem salvar imediatamente.
        /// Use CommitAsync do UnitOfWork para confirmar as alterações.
        /// </summary>
        /// <param name="obj">Entidade com dados atualizados.</param>
        /// <returns>A entidade atualizada.</returns>
        /// <exception cref="ArgumentNullException">Quando obj é nulo.</exception>
        public virtual T Update(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), "A entidade não pode ser nula.");

            _dbSet.Update(obj);
            Debug.WriteLine($"[BaseCommandRepository] Entidade {typeof(T).Name} marcada para atualização.");
            return obj;
        }

        /// <summary>
        /// Remove uma entidade sem salvar imediatamente.
        /// Use CommitAsync do UnitOfWork para confirmar as alterações.
        /// </summary>
        /// <param name="obj">Entidade a ser removida.</param>
        /// <exception cref="ArgumentNullException">Quando obj é nulo.</exception>
        public virtual void Remove(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), "A entidade não pode ser nula.");

            _dbSet.Remove(obj);
            Debug.WriteLine($"[BaseCommandRepository] Entidade {typeof(T).Name} marcada para remoção.");
        }
    }
}
