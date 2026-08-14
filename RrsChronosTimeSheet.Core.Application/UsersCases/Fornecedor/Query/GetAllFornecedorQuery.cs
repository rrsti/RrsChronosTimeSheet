using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Fornecedor.Query
{
    public class GetAllFornecedorQuery : IRequest<IEnumerable<Domain.Entities.Fornecedor>>;
}
