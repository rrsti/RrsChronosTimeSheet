using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Fornecedores
{
    public interface ITelefoneFornecedorRepository<TelefoneFornecedor>
    {
        public Task<IQueryable<TelefoneFornecedor>> GetAllPorFornecedorId(Guid FornecedorId);
        public Task<IQueryable<TelefoneFornecedor>> GetAllPorFornecedorIdAndTipoTelefone(Guid FornecedorId, Guid TipoTelefoneId);
    }
}
