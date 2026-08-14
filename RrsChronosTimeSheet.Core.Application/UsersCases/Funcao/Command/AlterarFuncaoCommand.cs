using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;
using RrsChronosTimeSheet.Core.Application.Dto;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Funcao.Command
{
    public class AlterarFuncaoCommand : ICommand, IRequest<Guid>
    {
        public FuncaoDto Funcao { get; set; }
    }
}
