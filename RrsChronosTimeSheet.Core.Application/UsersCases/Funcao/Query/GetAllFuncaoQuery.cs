using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Funcao.Query
{
    public class GetAllFuncaoQuery : IRequest<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.Funcao>>;
}
