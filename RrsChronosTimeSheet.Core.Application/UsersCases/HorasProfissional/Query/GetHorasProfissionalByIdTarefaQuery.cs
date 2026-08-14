using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.HorasProfissional.Query
{
    public class GetHorasProfissionalByIdTarefaQuery : IRequest<IEnumerable<Domain.Entities.HorasProfissional>>
    {
        public Guid IdTarefa { get; set; }
    }
}
