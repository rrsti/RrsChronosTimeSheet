using MediatR;
using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Application.Abstractions;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Fornecedor.Command
{
    public class CriarFornecedorCommand : ICommand, IRequest<Guid>
    {
        public FornecedorDto Fornecedor { get; set; }
    }
}
