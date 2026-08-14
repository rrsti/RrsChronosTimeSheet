using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Context;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Clientes;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Repository.Clientes
{
    /// <summary>
    /// Repositório específico para a entidade Cliente.
    /// </summary>
    public class ClienteRepository : BaseQuerysRepository<Cliente>, IClienteRepository<Cliente>
    {
        /// <summary>
        /// Inicializa uma nova instância da classe ClienteRepository.
        /// </summary>
        /// <param name="unitOfWork">Unit of Work para operações de dados.</param>
        public ClienteRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Obtém todos os clientes pertencentes a uma unidade federativa específica.
        /// </summary>
        /// <param name="UfId">ID da unidade federativa.</param>
        /// <returns>Queryable de clientes da UF especificada.</returns>
        public async Task<IQueryable<Cliente>> GetClientesPorUF(Guid UfId)
        {
            var clientes = await _dbSet
                .Where(c => c.UnidadeFederativa != null && c.UnidadeFederativa.Id == UfId)
                .AsNoTracking()
                .ToListAsync();

            return clientes.AsQueryable();
        }
    }
}
