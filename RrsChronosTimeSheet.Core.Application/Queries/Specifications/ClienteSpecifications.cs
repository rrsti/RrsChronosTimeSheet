using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Specifications;

namespace RrsChronosTimeSheet.Core.Application.Queries.Specifications
{
    /// <summary>
    /// Specification para filtrar clientes por Unidade Federativa
    /// Exemplo de uso do padrão Specification para encapsular critérios de consulta
    /// </summary>
    public class ClienteByUfSpecification : BaseSpecification<Cliente>
    {
        public ClienteByUfSpecification(Guid idUnidadeFederativa)
            : base(c => c.UnidadeFederativa != null && c.UnidadeFederativa.Id == idUnidadeFederativa && !c.IsDeleted)
        {
            AddOrderBy(c => c.NomeFantasia);
        }
    }

    /// <summary>
    /// Specification para filtrar clientes ativos com ordenação por nome fantasia
    /// </summary>
    public class ClientesAtivosSpecification : BaseSpecification<Cliente>
    {
        public ClientesAtivosSpecification()
            : base(c => !c.IsDeleted)
        {
            AddOrderBy(c => c.NomeFantasia);
        }
    }

    /// <summary>
    /// Specification para listar clientes com paginação e ordenação
    /// </summary>
    public class ClientesPaginadosSpecification : BaseSpecification<Cliente>
    {
        public ClientesPaginadosSpecification(int pageNumber, int pageSize, string? searchTerm = null)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Criteria = c => !c.IsDeleted;
            }
            else
            {
                Criteria = c => !c.IsDeleted &&
                               (c.NomeFantasia.Contains(searchTerm) || 
                                c.RazaoSocial.Contains(searchTerm) ||
                                c.Cnpj.Contains(searchTerm));
            }

            AddOrderBy(c => c.NomeFantasia);
            ApplyPaging((pageNumber - 1) * pageSize, pageSize);
        }
    }
}
