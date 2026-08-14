using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Fornecedor.Query
{
    public class GetFornecedorByIdQuery : IRequest<Domain.Entities.Fornecedor>
    {
        public Guid Id { get; set; }
    }
}
