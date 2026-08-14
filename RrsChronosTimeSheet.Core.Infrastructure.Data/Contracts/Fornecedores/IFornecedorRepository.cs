using System.Linq.Expressions;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Fornecedores
{
    public interface IFornecedorRepository<Fornecedor>
    {
        public Task<IQueryable<Domain.Entities.Fornecedor>> GetFornecedoresTotais(Expression<Func<Fornecedor, bool>>? filtro = null, CancellationToken cancellationToken = default);
        public Task<IQueryable<Domain.Entities.Fornecedor>> GetClientesPorUF(Guid UfId);
    }
}
