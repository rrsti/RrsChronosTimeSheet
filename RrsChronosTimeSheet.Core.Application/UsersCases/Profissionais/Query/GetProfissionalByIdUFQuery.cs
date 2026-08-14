using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Profissionais.Query
{
    public class GetProfissionalByIdUFQuery() : IRequest<IEnumerable<Profissional>>
    {
        public Guid IdUnidadeFederativa { get; set; }
    }
}
