using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Web.Api.Controllers.Base;
using RrsChronosTimeSheet.Core.Application.UsersCases.Tarefas.Command;
using RrsChronosTimeSheet.Core.Application.UsersCases.Tarefas.Query;
using RrsChronosTimeSheet.Core.Infrastructure.IoC.Utils.Notifications.Contracts;

namespace RrsChronosTimeSheet.Core.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public TarefaController(INotifications notification, IMediator mediator, IMapper mapper) : base(notification)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetAllTarefasQuery();
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao listar tarefas: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    NotifyError("ID da tarefa não pode estar vazio");
                    return CustomResponse();
                }

                var query = new GetTarefaByIdQuery { Id = id };
                var result = await _mediator.Send(query, cancellationToken);

                if (result == null)
                {
                    NotifyError($"Tarefa com ID {id} não encontrada");
                    return CustomResponse();
                }

                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao obter tarefa: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpGet("projeto/{projetoId:guid}")]
        public async Task<ActionResult> GetByProjetoId(Guid projetoId, CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetTarefaByIdProjetoQuery { IdProjeto = projetoId };
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao obter tarefas do projeto: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TarefasDto tarefaDto, CancellationToken cancellationToken)
        {
            try
            {
                if (tarefaDto == null)
                {
                    NotifyError("Dados da tarefa não podem estar vazios");
                    return CustomResponse();
                }

                var command = new CriarTarefasCommand { Tarefa = tarefaDto };
                await _mediator.Send(command, cancellationToken);

                if (!ValidOperation())
                {
                    return CustomResponse();
                }

                return CustomResponse(tarefaDto.Id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao criar tarefa: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] TarefasDto tarefaDto, CancellationToken cancellationToken)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    NotifyError("ID da tarefa não pode estar vazio");
                    return CustomResponse();
                }

                if (tarefaDto == null)
                {
                    NotifyError("Dados da tarefa não podem estar vazios");
                    return CustomResponse();
                }

                tarefaDto.Id = id;
                var command = new AlterarTarefasCommand { Tarefa = tarefaDto };
                await _mediator.Send(command, cancellationToken);

                if (!ValidOperation())
                {
                    return CustomResponse();
                }

                return CustomResponse(tarefaDto.Id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao atualizar tarefa: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    NotifyError("ID da tarefa não pode estar vazio");
                    return CustomResponse();
                }

                var command = new DeleteTarefasCommand { Id = id };
                await _mediator.Send(command, cancellationToken);

                if (!ValidOperation())
                {
                    return CustomResponse();
                }

                return CustomResponse(id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao deletar tarefa: {ex.Message}");
                return CustomResponse();
            }
        }
    }
}
