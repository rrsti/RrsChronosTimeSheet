using MediatR;
using AutoMapper;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Funcao.Command
{
    public class AlterarFuncaoHandler : IRequestHandler<AlterarFuncaoCommand, Guid>
    {
        private readonly IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.Funcao> _baseRepository;
        private readonly IMapper _mapper;

        public AlterarFuncaoHandler(IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.Funcao> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AlterarFuncaoCommand request, CancellationToken cancellationToken)
        {
            var funcao = new RrsChronosTimeSheet.Core.Domain.Entities.Funcao
            {
                Id = request.Funcao.Id,
                Descricao = request.Funcao.Descricao
            };

            await _baseRepository.UpdateAsync(funcao);
            return funcao.Id;
        }
    }
}
