using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Context;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Status;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Repository.Status
{
    public class StatusTarefaRepository(ChronosContext dbContext) : IStatusTarefaRepository<StatusTarefa>
    {
    }
}
