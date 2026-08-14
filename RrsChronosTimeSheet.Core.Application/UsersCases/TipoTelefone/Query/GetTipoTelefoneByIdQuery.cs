using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TipoTelefone.Query
{
    public class GetTipoTelefoneByIdQuery : IRequest<Domain.Entities.TipoTelefone>
    {
        public Guid Id { get; set; }
    }
}
