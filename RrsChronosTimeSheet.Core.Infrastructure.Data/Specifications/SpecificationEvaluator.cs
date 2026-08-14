using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Specifications
{
    /// <summary>
    /// Avaliador de Specifications que aplica os critérios a um IQueryable
    /// Trata includes, filtros, ordenação e paginação
    /// </summary>
    public class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;

            // Aplicar criteria (where)
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            // Aplicar includes (navigation properties)
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            // Aplicar ordenação
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            // Aplicar paginação
            if (specification.IsPagingEnabled)
            {
                if (specification.Skip.HasValue)
                {
                    query = query.Skip(specification.Skip.Value);
                }

                if (specification.Take.HasValue)
                {
                    query = query.Take(specification.Take.Value);
                }
            }

            return query;
        }
    }
}
