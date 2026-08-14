using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.TipoProjeto.Command
{
    public class DeleteTipoProjetoCommand : ICommand, IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
