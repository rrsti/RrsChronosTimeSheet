using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Profissionais
{
    public interface IProfissionalRepository<Profissional>
    {
        public Task<IQueryable<Profissional>> GetProfissionaisPorUF(Guid UfId);
        public Task<IQueryable<Profissional>> GetProfissionaisPorFuncao(Guid FuncaoId);
        public Task<IQueryable<Profissional>> GetProfissionaisTerceirizados();
        public Task<IQueryable<Profissional>> GetProfissionaisPorFornecedor(Guid FornecedorId);
    }
}
