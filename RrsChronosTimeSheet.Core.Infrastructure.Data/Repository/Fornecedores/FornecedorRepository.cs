using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Context;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts.Fornecedores;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Repository.Fornecedores
{
    public class FornecedorRepository(ChronosContext dbContext) : IFornecedorRepository<Domain.Entities.Fornecedor>
    {
        public async Task<IQueryable<Fornecedor>> GetClientesPorUF(Guid UfId)
        {
            var clientes = await dbContext.Set<Domain.Entities.Fornecedor>()
                .Where(c => c.UnidadeFederativa != null && c.UnidadeFederativa.Id == UfId)
                .AsNoTracking()
                .ToListAsync();
            return clientes.AsQueryable();
        }

        public async Task<IQueryable<Fornecedor>> GetFornecedoresTotais(Expression<Func<Fornecedor, bool>>? filtro = null, CancellationToken cancellationToken = default)
        {
            var result = await dbContext.Fornecedor
                .AsNoTracking()
                .Where(f => !f.IsDeleted)
                .Select(f => new Fornecedor
                {
                    Id = f.Id,
                    Cnpj = f.Cnpj,
                    RazaoSocial = f.RazaoSocial,
                    NomeFantasia = f.NomeFantasia,
                    InscricaoEstadual = f.InscricaoEstadual,
                    InscricaoMunicipal = f.InscricaoMunicipal,
                    DataCriacao = f.DataCriacao,
                    Bairro = f.Bairro,
                    Cep = f.Cep,
                    Cidade = f.Cidade,
                    Complemento = f.Complemento,
                    DataAtualizacao = f.DataAtualizacao,
                    Emails = f.Emails,
                    IsDeleted = f.IsDeleted,
                    Logradouro = f.Logradouro,
                    Numero = f.Numero,
                    Telefones = f.Telefones,
                    UnidadeFederativa = f.UnidadeFederativa,
                    UsuarioAlteracao = f.UsuarioAlteracao,
                    UsuarioCriacao = f.UsuarioCriacao,
                    TotalTelefones = dbContext.TelefoneFornecedor
                        .Where(tf => tf.Fornecedor != null & tf.FornecedorId == f.Id)
                        .Count(),

                    TotalEmails = dbContext.EmailFornecedor
                        .Where(ef => ef.Fornecedor != null && ef.Fornecedor.Id == f.Id)
                        .Count(),

                    TotalProfissionais = dbContext.Profissional
                        .Where(p => p.Fornecedor != null && p.Fornecedor.Id == f.Id)
                        .Count()
                })
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return result.AsQueryable();
        }
    }
}



