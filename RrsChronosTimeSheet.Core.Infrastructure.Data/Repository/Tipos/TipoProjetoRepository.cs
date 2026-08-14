using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Context;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Tipos;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Repository.Tipos
{
    public class TipoProjetoRepository(ChronosContext dbContext) : ITipoProjetoRepository<TipoProjeto>
    {
    }
}
