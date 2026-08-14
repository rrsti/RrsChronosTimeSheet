using RrsChronosTimeSheet.Core.Domain.Entities;
using System.Linq.Expressions;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.TipoTelefone
{
    public interface ITiposTelefoneRepository<TipoTelefone>
    {
        public Task<IQueryable<Domain.Entities.TipoTelefone>> GetTiposTelefonesTotais(Expression<Func<TipoTelefone, bool>>? filtro = null, CancellationToken cancellationToken = default);
    }
}
