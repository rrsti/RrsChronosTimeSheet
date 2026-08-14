using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Funcao.Command
{
    public class DeleteFuncaoCommand : ICommand, IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
