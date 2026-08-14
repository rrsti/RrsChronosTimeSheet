using MediatR;
using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Application.Abstractions;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneClientes.Command
{
    public class CriarTelefoneClienteCommand: ICommand, IRequest<Guid>
    {
        public TelefoneClienteDto TelefonesCliente { get; set; }
    }
}
