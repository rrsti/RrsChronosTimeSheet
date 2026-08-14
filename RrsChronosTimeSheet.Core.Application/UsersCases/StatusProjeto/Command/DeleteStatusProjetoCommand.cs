using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.StatusProjeto.Command
{
    public class DeleteStatusProjetoCommand : ICommand, IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
