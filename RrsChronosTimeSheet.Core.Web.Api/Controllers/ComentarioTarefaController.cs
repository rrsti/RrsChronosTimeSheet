using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Web.Api.Controllers.Base;
using RrsChronosTimeSheet.Core.Application.UsersCases.ComentariosTarefa.Command;
using RrsChronosTimeSheet.Core.Application.UsersCases.ComentariosTarefa.Query;
using RrsChronosTimeSheet.Core.Infrastructure.IoC.Utils.Notifications.Contracts;

namespace RrsChronosTimeSheet.Core.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioTarefaController : MainController
    {
        private readonly IMediator _mediator;

        public ComentarioTarefaController(INotifications notification, IMediator mediator) : base(notification)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetAllComentarioTarefaQuery();
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao listar comentários: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetComentarioTarefaByIdQuery { Id = id };
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao obter comentário: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpGet("tarefa/{tarefaId:guid}")]
        public async Task<ActionResult> GetByTarefaId(Guid tarefaId, CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetComentarioTarefaByIdTarefaQuery { IdTarefa = tarefaId };
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao obter comentários da tarefa: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ComentarioTarefaDto comentarioDto, CancellationToken cancellationToken)
        {
            try
            {
                var command = new CriarComentarioTarefaCommand { ComentarioTarefa = comentarioDto };
                await _mediator.Send(command, cancellationToken);
                return CustomResponse(comentarioDto.Id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao criar comentário: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ComentarioTarefaDto comentarioDto, CancellationToken cancellationToken)
        {
            try
            {
                comentarioDto.Id = id;
                var command = new AlterarComentarioTarefaCommand { ComentarioTarefa = comentarioDto };
                await _mediator.Send(command, cancellationToken);
                return CustomResponse(comentarioDto.Id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao atualizar comentário: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var command = new DeleteComentarioTarefaCommand { Id = id };
                await _mediator.Send(command, cancellationToken);
                return CustomResponse(id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao deletar comentário: {ex.Message}");
                return CustomResponse();
            }
        }
    }
}
