using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Web.Api.Controllers.Base;
using RrsChronosTimeSheet.Core.Application.UsersCases.Projeto.Command;
using RrsChronosTimeSheet.Core.Application.UsersCases.Projeto.Query;
using RrsChronosTimeSheet.Core.Infrastructure.IoC.Utils.Notifications.Contracts;

namespace RrsChronosTimeSheet.Core.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProjetoController(INotifications notification, IMediator mediator, IMapper mapper) : base(notification)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtém todos os projetos
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetAllProjetoQuery();
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao listar projetos: {ex.Message}");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Obtém um projeto por ID
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    NotifyError("ID do projeto não pode estar vazio");
                    return CustomResponse();
                }

                var query = new GetProjetoByIdQuery { Id = id };
                var result = await _mediator.Send(query, cancellationToken);

                if (result == null)
                {
                    NotifyError($"Projeto com ID {id} não encontrado");
                    return CustomResponse();
                }

                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao obter projeto: {ex.Message}");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Obtém projetos por Cliente
        /// </summary>
        [HttpGet("cliente/{clienteId:guid}")]
        public async Task<ActionResult> GetByClienteId(Guid clienteId, CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetProjetoByIdClienteQuery { IdCliente = clienteId };
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao obter projetos do cliente: {ex.Message}");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Cria um novo projeto
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProjetoDto projetoDto, CancellationToken cancellationToken)
        {
            try
            {
                if (projetoDto == null)
                {
                    NotifyError("Dados do projeto não podem estar vazios");
                    return CustomResponse();
                }

                var command = new CriarProjetoCommand { Projeto = projetoDto };
                await _mediator.Send(command, cancellationToken);

                if (!ValidOperation())
                {
                    return CustomResponse();
                }

                return CustomResponse(projetoDto);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao criar projeto: {ex.Message}");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Atualiza um projeto existente
        /// </summary>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ProjetoDto projetoDto, CancellationToken cancellationToken)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    NotifyError("ID do projeto não pode estar vazio");
                    return CustomResponse();
                }

                if (projetoDto == null)
                {
                    NotifyError("Dados do projeto não podem estar vazios");
                    return CustomResponse();
                }

                projetoDto.Id = id;
                var command = new AlterarProjetoCommand { Projeto = projetoDto };
                await _mediator.Send(command, cancellationToken);

                if (!ValidOperation())
                {
                    return CustomResponse();
                }

                return CustomResponse(projetoDto.Id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao atualizar projeto: {ex.Message}");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Deleta um projeto
        /// </summary>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    NotifyError("ID do projeto não pode estar vazio");
                    return CustomResponse();
                }

                var command = new DeleteProjetoCommand { Id = id };
                await _mediator.Send(command, cancellationToken);

                if (!ValidOperation())
                {
                    return CustomResponse();
                }

                return CustomResponse(id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao deletar projeto: {ex.Message}");
                return CustomResponse();
            }
        }
    }
}
