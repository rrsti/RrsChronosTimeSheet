using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Web.Api.Controllers.Base;
using RrsChronosTimeSheet.Core.Application.UsersCases.StatusProjeto.Command;
using RrsChronosTimeSheet.Core.Application.UsersCases.StatusProjeto.Query;
using RrsChronosTimeSheet.Core.Infrastructure.IoC.Utils.Notifications.Contracts;

namespace RrsChronosTimeSheet.Core.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusProjetoController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public StatusProjetoController(INotifications notification, IMediator mediator, IMapper mapper) : base(notification)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetAllStatusProjetoQuery();
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
                var query = new GetStatusProjetoByIdQuery { Id = id };
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
        public async Task<ActionResult> Post([FromBody] StatusProjetoDto statusDto, CancellationToken cancellationToken)
        {
            try
            {
                var command = new CriarStatusProjetoCommand { Status = statusDto };
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
        public async Task<ActionResult> Put(Guid id, [FromBody] StatusProjetoDto statusDto, CancellationToken cancellationToken)
        {
            try
            {
                statusDto.Id = id;
                var command = new AlterarStatusProjetoCommand { Status = statusDto };
                await _mediator.Send(command, cancellationToken);
                return CustomResponse(statusDto.Id);
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
                var command = new DeleteStatusProjetoCommand { Id = id };
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
