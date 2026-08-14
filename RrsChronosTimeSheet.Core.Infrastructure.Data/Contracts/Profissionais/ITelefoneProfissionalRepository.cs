using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Profissionais
{
    public interface ITelefoneProfissionalRepository<TelefoneProfissional>
    {
        public Task<IQueryable<TelefoneProfissional>> GetAllPorProfissionalId(Guid ProfissionalId);
        public Task<IQueryable<TelefoneProfissional>> GetAllPorProfissionalIdAndTipoTelefone(Guid ProfissionalId, Guid TipoTelefoneId);
    }
}
