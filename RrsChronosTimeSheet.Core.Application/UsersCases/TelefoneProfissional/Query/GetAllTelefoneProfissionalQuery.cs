using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneProfissional.Query
{
    public class GetAllTelefoneProfissionalQuery : IRequest<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.TelefoneProfissional>>;
}
