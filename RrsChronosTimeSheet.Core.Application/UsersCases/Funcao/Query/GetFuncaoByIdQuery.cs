using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Funcao.Query
{
    public class GetFuncaoByIdQuery : IRequest<Domain.Entities.Funcao>
    {
        public Guid Id { get; set; }
    }
}
