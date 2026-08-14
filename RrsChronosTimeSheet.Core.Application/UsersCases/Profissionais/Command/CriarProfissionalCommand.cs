using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;
using RrsChronosTimeSheet.Core.Application.Dto;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Profissionais.Command
{
    public class CriarProfissionalCommand : ICommand, IRequest<Guid>
    {
        public ProfissionalDto Profissional { get; set; }
    }
}
