using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;
using RrsChronosTimeSheet.Core.Application.Dto;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.HorasProfissional.Command
{
    public class CriarHorasProfissionalCommand : ICommand, IRequest<Guid>
    {
        public HorasProfissionalDto Horas { get; set; }
    }
}
