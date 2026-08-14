using MediatR;
using RrsChronosTimeSheet.Core.Application.Abstractions;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Fornecedor.Command
{
    public class DeleteFornecedorCommand : ICommand, IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
