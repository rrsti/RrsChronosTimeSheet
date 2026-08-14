using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;
using RrsChronosTimeSheet.Core.Application.Dto;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Projeto.Command
{
    public class AlterarProjetoCommand : ICommand, IRequest<Guid>
    {
        public ProjetoDto Projeto { get; set; }
    }
}
