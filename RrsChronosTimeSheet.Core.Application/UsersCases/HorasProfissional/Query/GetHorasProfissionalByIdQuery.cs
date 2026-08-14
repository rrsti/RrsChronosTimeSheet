using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.HorasProfissional.Query
{
    public class GetHorasProfissionalByIdQuery : IRequest<Domain.Entities.HorasProfissional>
    {
        public Guid Id { get; set; }
    }
}
