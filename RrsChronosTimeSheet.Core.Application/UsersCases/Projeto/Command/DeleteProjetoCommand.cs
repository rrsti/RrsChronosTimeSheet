using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Projeto.Command
{
    public class DeleteProjetoCommand : ICommand, IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
