using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;
using RrsChronosTimeSheet.Core.Application.Dto;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Clientes.Command
{
    public class CriarClienteCommand : ICommand, IRequest<Guid>
    {
        public ClienteDto Cliente { get; set; }
    }
}
