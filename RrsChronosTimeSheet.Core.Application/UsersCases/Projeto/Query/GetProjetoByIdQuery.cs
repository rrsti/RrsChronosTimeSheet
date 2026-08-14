using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Projeto.Query
{
    public class GetProjetoByIdQuery : IRequest<Domain.Entities.Projeto>
    {
        public Guid Id { get; set; }
    }
}
