using MediatR;
using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Application.Abstractions;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Fornecedor.Command
{
    public class AlterarFornecedorCommand : ICommand, IRequest<Guid>
    {
        public required FornecedorDto Fornecedor { get; set; }
    }
}
