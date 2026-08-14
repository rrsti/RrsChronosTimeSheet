using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.HorasProfissional.Query
{
    public class GetAllHorasProfissionalQuery : IRequest<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.HorasProfissional>>;
}
