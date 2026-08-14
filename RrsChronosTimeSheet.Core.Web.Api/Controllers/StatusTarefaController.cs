using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Web.Api.Controllers.Base;
using RrsChronosTimeSheet.Core.Application.UsersCases.StatusTarefa.Command;
using RrsChronosTimeSheet.Core.Application.UsersCases.StatusTarefa.Query;
using RrsChronosTimeSheet.Core.Infrastructure.IoC.Utils.Notifications.Contracts;

namespace RrsChronosTimeSheet.Core.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusTarefaController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public StatusTarefaController(INotifications notification, IMediator mediator, IMapper mapper) : base(notification)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetAllStatusTarefaQuery();
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao listar status: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetStatusTarefaByIdQuery { Id = id };
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao obter status: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StatusTarefaDto statusDto, CancellationToken cancellationToken)
        {
            try
            {
                var command = new CriarStatusTarefaCommand { Status = statusDto };
                await _mediator.Send(command, cancellationToken);
                return CustomResponse(statusDto);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao criar status: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] StatusTarefaDto statusDto, CancellationToken cancellationToken)
        {
            try
            {
                statusDto.Id = id;
                var command = new AlterarStatusTarefaCommand { Status = statusDto };
                await _mediator.Send(command, cancellationToken);
                return CustomResponse(statusDto);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao atualizar status: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var command = new DeleteStatusTarefaCommand { Id = id };
                await _mediator.Send(command, cancellationToken);
                return CustomResponse(id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao deletar status: {ex.Message}");
                return CustomResponse();
            }
        }
    }
}
