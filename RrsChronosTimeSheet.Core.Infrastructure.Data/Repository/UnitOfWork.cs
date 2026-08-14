using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using RrsChronosTimeSheet.Core.Infrastructure.Data.Context;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Repository
{
    /// <summary>
    /// Implementação do padrão Unit of Work para gerenciamento de transações e contexto de banco de dados.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChronosContext _context;
        private IDbContextTransaction? _transaction;
        private bool _disposed;

        /// <summary>
        /// Inicializa uma nova instância da classe UnitOfWork.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        /// <exception cref="ArgumentNullException">Quando context é nulo.</exception>
        public UnitOfWork(ChronosContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "O contexto do banco de dados não pode ser nulo.");
            _disposed = false;
        }

        /// <summary>
        /// Obtém o contexto do Unit of Work.
        /// </summary>
        public IUnitOfWorkContext Context => new UnitOfWorkContextAdapter(_context);

        /// <summary>
        /// Obtém um valor indicando se uma transação está ativa.
        /// </summary>
        public bool HasActiveTransaction => _transaction != null;

        /// <summary>
        /// Inicia uma transação de banco de dados.
        /// </summary>
        /// <param name="cancellationToken">Token para cancelamento de operação.</param>
        /// <returns>Task representando a operação assíncrona.</returns>
        /// <exception cref="InvalidOperationException">Quando já existe uma transação ativa.</exception>
        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();

            if (_transaction != null)
            {
                throw new InvalidOperationException(
                    "Uma transação já está ativa. Conclua ou reverta a transação atual antes de iniciar uma nova.");
            }

            _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            Debug.WriteLine($"[UnitOfWork] Transação iniciada: {_transaction.TransactionId}");
        }

        /// <summary>
        /// Confirma todas as alterações pendentes e valida a transação.
        /// </summary>
        /// <param name="cancellationToken">Token para cancelamento de operação.</param>
        /// <returns>Task representando a operação assíncrona.</returns>
        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();

            try
            {
                await _context.SaveChangesAsync(cancellationToken);

                if (_transaction != null)
                {
                    await _transaction.CommitAsync(cancellationToken);
                    Debug.WriteLine($"[UnitOfWork] Transação confirmada: {_transaction.TransactionId}");
                }
            }
            catch (DbUpdateException ex)
            {
                await RollbackAsync(cancellationToken);
                Debug.WriteLine($"[UnitOfWork] Erro ao confirmar transação: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                await RollbackAsync(cancellationToken);
                Debug.WriteLine($"[UnitOfWork] Erro inesperado: {ex.Message}");
                throw;
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        /// <summary>
        /// Reverte todas as alterações pendentes.
        /// </summary>
        /// <param name="cancellationToken">Token para cancelamento de operação.</param>
        /// <returns>Task representando a operação assíncrona.</returns>
        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();

            try
            {
                if (_transaction != null)
                {
                    await _transaction.RollbackAsync(cancellationToken);
                    Debug.WriteLine($"[UnitOfWork] Transação revertida: {_transaction.TransactionId}");
                }
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        /// <summary>
        /// Salva todas as mudanças rastreadas pelo contexto.
        /// </summary>
        /// <param name="cancellationToken">Token para cancelamento de operação.</param>
        /// <returns>Task representando a operação assíncrona.</returns>
        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                Debug.WriteLine("[UnitOfWork] Alterações salvas com sucesso.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[UnitOfWork] Erro ao salvar alterações: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Libera os recursos gerenciados.
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
                return;

            _transaction?.Dispose();
            _context?.Dispose();
            _disposed = true;

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Libera os recursos gerenciados de forma assíncrona.
        /// </summary>
        public async ValueTask DisposeAsync()
        {
            if (_disposed)
                return;

            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }

            if (_context != null)
            {
                await _context.DisposeAsync();
            }

            _disposed = true;

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Verifica se a instância foi descartada.
        /// </summary>
        /// <exception cref="ObjectDisposedException">Quando a instância foi descartada.</exception>
        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(
                    nameof(UnitOfWork),
                    "A instância de UnitOfWork foi descartada e não pode mais ser usada.");
            }
        }

        /// <summary>
        /// Adaptador interno para expor o contexto através da interface IUnitOfWorkContext.
        /// </summary>
        private class UnitOfWorkContextAdapter : IUnitOfWorkContext
        {
            private readonly ChronosContext _context;

            public UnitOfWorkContextAdapter(ChronosContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public DbSet<T> Set<T>() where T : class
            {
                return _context.Set<T>();
            }

            public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            {
                return _context.SaveChangesAsync(cancellationToken);
            }

            public IDbContextTransaction BeginTransaction()
            {
                return _context.Database.BeginTransaction();
            }

            public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
            {
                return _context.Database.BeginTransactionAsync(cancellationToken);
            }
        }
    }
}
