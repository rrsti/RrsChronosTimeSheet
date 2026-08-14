using MediatR;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Projeto.Query
{
    public class GetProjetoByIdClienteQueryHandler : IRequestHandler<GetProjetoByIdClienteQuery, IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.Projeto>>
    {
        private readonly IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Projeto> _querysRepository;

        public GetProjetoByIdClienteQueryHandler(IBaseQuerysRepository<RrsChronosTimeSheet.Core.Domain.Entities.Projeto> querysRepository)
        {
            _querysRepository = querysRepository;
        }

        public async Task<IEnumerable<RrsChronosTimeSheet.Core.Domain.Entities.Projeto>> Handle(GetProjetoByIdClienteQuery request, CancellationToken cancellationToken)
        {
            var projetos = await _querysRepository.GetWhereAsync(
                filtro: p => p.Cliente.Id == request.IdCliente,
                cancellationToken: cancellationToken);

            return projetos;
        }
    }
}
