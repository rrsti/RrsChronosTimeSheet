using MediatR;
using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Application.Abstractions;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.EmailsClientes.Command
{
    public class AlterarEmailClienteCommand : ICommand, IRequest<Guid>
    {
        public EmailClienteDto EmailCliente { get; set; }
    }
}
