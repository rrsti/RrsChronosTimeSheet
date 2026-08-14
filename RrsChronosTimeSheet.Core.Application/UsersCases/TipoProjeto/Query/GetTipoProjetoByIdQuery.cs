using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TipoProjeto.Query
{
    public class GetTipoProjetoByIdQuery : IRequest<Domain.Entities.TipoProjeto>
    {
        public Guid Id { get; set; }
    }
}
