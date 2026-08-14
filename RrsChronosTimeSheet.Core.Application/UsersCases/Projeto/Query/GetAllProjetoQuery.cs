using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Projeto.Query
{
    public class GetAllProjetoQuery : IRequest<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.Projeto>>;
}
