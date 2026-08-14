using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Profissionais.Query
{
    public class GetProfissionalByIdQuery : IRequest<Profissional>
    {
        public Guid Id { get; set; }
    }
}
