using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Profissionais.Command
{
    public class DeleteProfissionalCommand : ICommand, IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
