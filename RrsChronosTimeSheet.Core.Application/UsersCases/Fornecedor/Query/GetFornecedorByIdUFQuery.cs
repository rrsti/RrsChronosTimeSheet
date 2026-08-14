using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Fornecedor.Query
{
    public class GetFornecedorByIdUFQuery : IRequest<IEnumerable<Domain.Entities.Fornecedor>>
    {
        public Guid IdUnidadeFederativa { get; set; }
    }
}
