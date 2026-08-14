using System.Linq.Expressions;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Specifications
{
    /// <summary>
    /// Interface para o padrão Specification
    /// Permite encapsular critérios de consulta complexas
    /// </summary>
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>>? OrderBy { get; }
        Expression<Func<T, object>>? OrderByDescending { get; }
        int? Take { get; }
        int? Skip { get; }
        bool IsPagingEnabled { get; }
    }
}
