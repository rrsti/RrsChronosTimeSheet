using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Tarefa
{
    public interface ITarefasRepository<Tarefas>
    {
        public Task<IQueryable<Tarefas>> GetTarefasPorProjeto(Guid ProjetoId);
        public Task<IQueryable<Tarefas>> GetTarefasPorResponsavel(Guid ProfissionalId);
        public Task<IQueryable<Tarefas>> GetTarefasPorStatus(Guid StatusId);
        public Task<IQueryable<Tarefas>> GetTarefasAtivas();
    }
}
