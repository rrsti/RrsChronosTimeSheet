using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RrsChronosTimeSheet.Core.Api.WebApi.Controllers.Base;
using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Application.UsersCases.Clientes.Command;
using RrsChronosTimeSheet.Core.Application.UsersCases.Clientes.Queries;
using RrsChronosTimeSheet.Core.Infrastructure.IoC.Utils.Notifications.Contracts;

namespace RrsChronosTimeSheet.Core.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ClienteController(INotifications notification, IMediator mediator, IMapper mapper) : base(notification)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtém todos os clientes
        /// </summary>
        /// <param name="cancellationToken">Token para cancelamento da operação</param>
        /// <returns>Lista de todos os clientes</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetAllClienteQuery();
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao listar clientes: {ex.Message}");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Obtém um cliente por ID
        /// </summary>
        /// <param name="id">ID do cliente</param>
        /// <param name="cancellationToken">Token para cancelamento da operação</param>
        /// <returns>Dados do cliente solicitado</returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    NotifyError("ID do cliente não pode estar vazio");
                    return CustomResponse();
                }

                var query = new GetClienteByIdQuery { Id = id };
                var result = await _mediator.Send(query, cancellationToken);

                if (result == null)
                {
                    NotifyError($"Cliente com ID {id} não encontrado");
                    return CustomResponse();
                }

                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao obter cliente: {ex.Message}");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Obtém clientes por Unidade Federativa
        /// </summary>
        /// <param name="idUF">ID da Unidade Federativa</param>
        /// <param name="cancellationToken">Token para cancelamento da operação</param>
        /// <returns>Lista de clientes da UF solicitada</returns>
        [HttpGet("uf/{idUF:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetByUF(Guid idUF, CancellationToken cancellationToken)
        {
            try
            {
                if (idUF == Guid.Empty)
                {
                    NotifyError("ID da UF não pode estar vazio");
                    return CustomResponse();
                }

                var query = new GetClienteByIdUFQuery { IdUnidadeFederativa = idUF };
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao obter clientes por UF: {ex.Message}");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Cria um novo cliente
        /// </summary>
        /// <param name="clienteDto">Dados do cliente a ser criado</param>
        /// <param name="cancellationToken">Token para cancelamento da operação</param>
        /// <returns>ID do cliente criado</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] ClienteDto clienteDto, CancellationToken cancellationToken)
        {
            try
            {
                if (clienteDto == null)
                {
                    NotifyError("Dados do cliente não podem estar vazios");
                    return CustomResponse();
                }

                var command = new CriarClienteCommand { Cliente = clienteDto };
                await _mediator.Send(command, cancellationToken);

                if (!ValidOperation())
                {
                    return CustomResponse();
                }

                return CustomResponse(clienteDto.Id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao criar cliente: {ex.Message}");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Atualiza um cliente existente
        /// </summary>
        /// <param name="id">ID do cliente a ser atualizado</param>
        /// <param name="clienteDto">Dados atualizados do cliente</param>
        /// <param name="cancellationToken">Token para cancelamento da operação</param>
        /// <returns>ID do cliente atualizado</returns>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put(Guid id, [FromBody] ClienteDto clienteDto, CancellationToken cancellationToken)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    NotifyError("ID do cliente não pode estar vazio");
                    return CustomResponse();
                }

                if (clienteDto == null)
                {
                    NotifyError("Dados do cliente não podem estar vazios");
                    return CustomResponse();
                }

                clienteDto.Id = id;
                var command = new AlterarClienteCommand { Cliente = clienteDto };
                await _mediator.Send(command, cancellationToken);

                if (!ValidOperation())
                {
                    return CustomResponse();
                }

                return CustomResponse(id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao atualizar cliente: {ex.Message}");
                return CustomResponse();
            }
        }
    }
}
