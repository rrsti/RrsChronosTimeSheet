using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.HorasProfissional.Query
{
    public class GetHorasProfissionalByIdProfissionalQuery : IRequest<IEnumerable<Domain.Entities.HorasProfissional>>
    {
        public Guid IdProfissional { get; set; }
    }
}
