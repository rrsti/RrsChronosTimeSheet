using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.HorasProfissional.Command
{
    public class DeleteHorasProfissionalCommand : ICommand, IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
