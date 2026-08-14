using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneProfissional.Command
{
    public class CriarTelefoneProfissionalCommand : ICommand, IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid IdProfissional { get; set; }
        public Guid IdTipoTelefone { get; set; }
        public string Numero { get; set; }

        public CriarTelefoneProfissionalCommand(Guid id, Guid idProfissional, Guid idTipoTelefone, string numero)
        {
            Id = id;
            IdProfissional = idProfissional;
            IdTipoTelefone = idTipoTelefone;
            Numero = numero;
        }
    }
}
