using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Web.Api.Controllers.Base;
using RrsChronosTimeSheet.Core.Application.UsersCases.HorasProfissional.Command;
using RrsChronosTimeSheet.Core.Application.UsersCases.HorasProfissional.Query;
using RrsChronosTimeSheet.Core.Infrastructure.IoC.Utils.Notifications.Contracts;

namespace RrsChronosTimeSheet.Core.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorasProfissionalController : MainController
    {
        private readonly IMediator _mediator;

        public HorasProfissionalController(INotifications notification, IMediator mediator) : base(notification)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetAllHorasProfissionalQuery();
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao listar horas: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetHorasProfissionalByIdQuery { Id = id };
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao obter horas: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpGet("profissional/{profissionalId:guid}")]
        public async Task<ActionResult> GetByProfissionalId(Guid profissionalId, CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetHorasProfissionalByIdProfissionalQuery { IdProfissional = profissionalId };
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao obter horas do profissional: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpGet("tarefa/{tarefaId:guid}")]
        public async Task<ActionResult> GetByTarefaId(Guid tarefaId, CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetHorasProfissionalByIdTarefaQuery { IdTarefa = tarefaId };
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao obter horas da tarefa: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] HorasProfissionalDto horasDto, CancellationToken cancellationToken)
        {
            try
            {
                var command = new CriarHorasProfissionalCommand { Horas = horasDto };
                await _mediator.Send(command, cancellationToken);
                return CustomResponse(horasDto.Id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao criar horas: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] HorasProfissionalDto horasDto, CancellationToken cancellationToken)
        {
            try
            {
                horasDto.Id = id;
                var command = new AlterarHorasProfissionalCommand { Horas = horasDto };
                await _mediator.Send(command, cancellationToken);
                return CustomResponse(horasDto.Id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao atualizar horas: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var command = new DeleteHorasProfissionalCommand { Id = id };
                await _mediator.Send(command, cancellationToken);
                return CustomResponse(id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao deletar horas: {ex.Message}");
                return CustomResponse();
            }
        }
    }
}
