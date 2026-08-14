using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;
using RrsChronosTimeSheet.Core.Application.Dto;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneProfissional.Command
{
    public class AlterarTelefoneProfissionalCommand : ICommand, IRequest<Guid>
    {
        public TelefoneProfissionalDto TelefoneProfissional {  get; set; }
    }
}
