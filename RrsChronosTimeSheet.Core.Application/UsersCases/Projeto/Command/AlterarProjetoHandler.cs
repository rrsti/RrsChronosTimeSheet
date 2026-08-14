using AutoMapper;
using MediatR;
using RrsChronosTimeSheet.Core.Domain.Entities;
using RrsChronosTimeSheet.Core.Infrastructure.Data.Contracts;

namespace RrsChronosTimeSheet.Core.Application.UsersCases.Projeto.Command
{
    public class AlterarProjetoHandler : IRequestHandler<AlterarProjetoCommand, Guid>
    {
        private readonly IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.Projeto> _baseRepository;
        private readonly IMapper _mapper;

        public AlterarProjetoHandler(IBaseCommandRepository<RrsChronosTimeSheet.Core.Domain.Entities.Projeto> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AlterarProjetoCommand request, CancellationToken cancellationToken)
        {

            var dto = request.Projeto;
            var obj = _mapper.Map<RrsChronosTimeSheet.Core.Domain.Entities.Projeto>(dto);

            if (obj != null)
            {
                if (obj.Id != null)
                {
                    obj.DataAtualizacao = DateTime.Now.Date;
                    await _baseRepository.UpdateAsync(obj);
                }
                return dto.Id;
            }
            return dto.Id;
        }
    }
}
