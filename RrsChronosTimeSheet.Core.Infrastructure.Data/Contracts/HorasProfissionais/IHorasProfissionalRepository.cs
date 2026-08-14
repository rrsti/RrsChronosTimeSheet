using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.HorasProfissionais
{
    public interface IHorasProfissionalRepository<HorasProfissional>
    {
        public Task<IQueryable<HorasProfissional>> GetHorasPorProfissional(Guid ProfissionalId);
        public Task<IQueryable<HorasProfissional>> GetHorasPorTarefa(Guid TarefaId);
        public Task<IQueryable<HorasProfissional>> GetHorasEntreData(DateTime DataInicio, DateTime DataFim);
        public Task<IQueryable<HorasProfissional>> GetHorasPorProfissionalETarefa(Guid ProfissionalId, Guid TarefaId);
    }
}
