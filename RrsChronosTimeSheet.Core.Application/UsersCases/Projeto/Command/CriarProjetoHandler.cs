using MediatR;
using AutoMapper;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Projeto.Command
{
    public class CriarProjetoHandler : IRequestHandler<CriarProjetoCommand, Guid>
    {
        private readonly IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.Projeto> _baseRepository;
        private readonly IMapper _mapper;

        public CriarProjetoHandler(IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.Projeto> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CriarProjetoCommand request, CancellationToken cancellationToken)
        {
            var projeto = _mapper.Map<RrsChronosTimeSheet.Core.Domain.Entities.Projeto>(request);

            await _baseRepository.AddAsync(projeto);
            return projeto.Id;
        }
    }
}
