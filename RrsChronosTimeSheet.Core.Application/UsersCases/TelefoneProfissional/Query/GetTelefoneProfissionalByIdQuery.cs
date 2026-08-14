using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneProfissional.Query
{
    public class GetTelefoneProfissionalByIdQuery : IRequest<Domain.Entities.TelefoneProfissional>
    {
        public Guid Id { get; set; }
    }
}
