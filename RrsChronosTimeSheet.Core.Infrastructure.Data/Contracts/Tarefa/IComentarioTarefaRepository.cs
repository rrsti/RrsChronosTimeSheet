using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Tarefa
{
    public interface IComentarioTarefaRepository<ComentarioTarefa>
    {
        public Task<IQueryable<ComentarioTarefa>> GetComentariosPorTarefa(Guid TarefaId);
        public Task<IQueryable<ComentarioTarefa>> GetComentariosPorAutor(Guid UsuarioId);
    }
}
