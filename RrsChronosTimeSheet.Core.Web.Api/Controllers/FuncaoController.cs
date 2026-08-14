using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Web.Api.Controllers.Base;
using RrsChronosTimeSheet.Core.Application.UsersCases.Funcao.Command;
using RrsChronosTimeSheet.Core.Application.UsersCases.Funcao.Query;
using RrsChronosTimeSheet.Core.Infrastructure.IoC.Utils.Notifications.Contracts;

namespace RrsChronosTimeSheet.Core.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncaoController : MainController
    {
        private readonly IMediator _mediator;

        public FuncaoController(INotifications notification, IMediator mediator) : base(notification)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetAllFuncaoQuery();
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao listar funções: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetFuncaoByIdQuery { Id = id };
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao obter função: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FuncaoDto funcaoDto, CancellationToken cancellationToken)
        {
            try
            {
                var command = new CriarFuncaoCommand { Funcao = funcaoDto };
                await _mediator.Send(command, cancellationToken);
                return CustomResponse(funcaoDto.Id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao criar função: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] FuncaoDto funcaoDto, CancellationToken cancellationToken)
        {
            try
            {
                funcaoDto.Id = id;
                var command = new AlterarFuncaoCommand { Funcao = funcaoDto };
                await _mediator.Send(command, cancellationToken);
                return CustomResponse(funcaoDto.Id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao atualizar função: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var command = new DeleteFuncaoCommand { Id = id };
                await _mediator.Send(command, cancellationToken);
                return CustomResponse(id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao deletar função: {ex.Message}");
                return CustomResponse();
            }
        }
    }
}
