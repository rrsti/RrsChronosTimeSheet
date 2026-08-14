using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Profissionais
{
    public interface IEmailProfissionalRepository<EmailProfissional>
    {
        public Task<IQueryable<EmailProfissional>> GetAllEmailsPorProfissionalId(Guid ProfissionalId);
    }
}
