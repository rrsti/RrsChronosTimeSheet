using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Fornecedores
{
    public interface IEmailFornecedorRepository<EmailFornecedor>
    {
        public Task<IQueryable<EmailFornecedor>> GetAllEmailsPorFornecedorId(Guid FornecedorId);
    }
}
