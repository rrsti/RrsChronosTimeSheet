using MediatR;
using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Application.Abstractions;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Funcao.Command
{
    public class CriarFuncaoCommand : ICommand, IRequest<Guid>
    {
        public FuncaoDto Funcao { get; set; }
        
    }
}
