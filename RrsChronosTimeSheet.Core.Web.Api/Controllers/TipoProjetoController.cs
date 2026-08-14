using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Web.Api.Controllers.Base;
using RrsChronosTimeSheet.Core.Application.UsersCases.TipoProjeto.Command;
using RrsChronosTimeSheet.Core.Application.UsersCases.TipoProjeto.Query;
using RrsChronosTimeSheet.Core.Infrastructure.IoC.Utils.Notifications.Contracts;

namespace RrsChronosTimeSheet.Core.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProjetoController : MainController
    {
        private readonly IMediator _mediator;

        public TipoProjetoController(INotifications notification, IMediator mediator) : base(notification)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetAllTipoProjetoQuery();
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao listar tipos: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetTipoProjetoByIdQuery { Id = id };
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao obter tipo: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoProjetoDto tipoDto, CancellationToken cancellationToken)
        {
            try
            {
                var command = new CriarTipoProjetoCommand { Tipo = tipoDto };
                await _mediator.Send(command, cancellationToken);
                return CustomResponse(tipoDto.Id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao criar tipo: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] TipoProjetoDto tipoDto, CancellationToken cancellationToken)
        {
            try
            {
                tipoDto.Id = id;
                var command = new AlterarTipoProjetoCommand { Tipo = tipoDto };
                await _mediator.Send(command, cancellationToken);
                return CustomResponse(tipoDto.Id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao atualizar tipo: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var command = new DeleteTipoProjetoCommand { Id = id };
                await _mediator.Send(command, cancellationToken);
                return CustomResponse(id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao deletar tipo: {ex.Message}");
                return CustomResponse();
            }
        }
    }
}
