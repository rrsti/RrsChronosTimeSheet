using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Projetos
{
    public interface IProjetoRepository<Projeto>
    {
        public Task<IQueryable<Projeto>> GetProjetosPorCliente(Guid ClienteId);
        public Task<IQueryable<Projeto>> GetProjetosPorStatus(Guid StatusId);
        public Task<IQueryable<Projeto>> GetProjetosPorTipo(Guid TipoId);
        public Task<IQueryable<Projeto>> GetProjetosPorResponsavel(Guid ProfissionalId);
    }
}
