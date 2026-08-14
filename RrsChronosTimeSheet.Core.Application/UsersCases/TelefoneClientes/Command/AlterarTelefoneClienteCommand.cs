using MediatR;
using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Application.Abstractions;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneClientes.Command
{
    public class AlterarTelefoneClienteCommand : ICommand, IRequest<Guid>
    {
        public TelefoneClienteDto TelefoneCliente { get;set; }
    }
}
