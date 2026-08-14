using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneProfissional.Query
{
    public class GetAllTelefoneProfissionalByIdProfissionalQuery : IRequest<IEnumerable<Domain.Entities.TelefoneProfissional>>
    {
        public Guid IdProfissional { get; set; }
    }
}
