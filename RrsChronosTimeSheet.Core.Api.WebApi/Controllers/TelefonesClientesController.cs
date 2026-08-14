using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RrsChronosTimeSheet.Core.Api.WebApi.Controllers.Base;
using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneClientes.Command;
using RrsChronosTimeSheet.Core.Application.UsersCases.TelefoneClientes.Query;
using RrsChronosTimeSheet.Core.Infrastructure.IoC.Utils.Notifications.Contracts;

namespace RrsChronosTimeSheet.Core.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefonesClientesController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public TelefonesClientesController(INotifications notification, IMediator mediator, IMapper mapper) : base(notification)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtém todos os telefones de um cliente
        /// </summary>
        /// <param name="clienteId">ID do cliente</param>
        /// <param name="cancellationToken">Token para cancelamento da operação</param>
        /// <returns>Lista de telefones do cliente</returns>
        [HttpGet("cliente/{clienteId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllTelefones(Guid clienteId, CancellationToken cancellationToken)
        {
            try
            {
                if (clienteId == Guid.Empty)
                {
                    NotifyError("ID do cliente não pode estar vazio");
                    return CustomResponse();
                }

                var query = new GetAllTelefoneClienteQuery();
                var result = await _mediator.Send(query, cancellationToken);

                // Filtrar telefones do cliente específico
                var telefonesDoCliente = result?.Where(t => t.ClienteId == clienteId).ToList();
                return CustomResponse(telefonesDoCliente);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao listar telefones do cliente: {ex.Message}");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Obtém um telefone específico de um cliente
        /// </summary>
        /// <param name="clienteId">ID do cliente</param>
        /// <param name="telefoneId">ID do telefone</param>
        /// <param name="cancellationToken">Token para cancelamento da operação</param>
        /// <returns>Dados do telefone solicitado</returns>
        [HttpGet("cliente/{clienteId:guid}/{telefoneId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetTelefoneById(Guid clienteId, Guid telefoneId, CancellationToken cancellationToken)
        {
            try
            {
                if (clienteId == Guid.Empty || telefoneId == Guid.Empty)
                {
                    NotifyError("IDs não podem estar vazios");
                    return CustomResponse();
                }

                var query = new GetTelefoneClienteByIdQuery { Id = telefoneId };
                var result = await _mediator.Send(query, cancellationToken);

                if (result == null || result.ClienteId != clienteId)
                {
                    NotifyError("Telefone não encontrado ou não pertence a este cliente");
                    return CustomResponse();
                }

                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao obter telefone: {ex.Message}");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Cria um novo telefone para um cliente
        /// </summary>
        /// <param name="clienteId">ID do cliente</param>
        /// <param name="telefoneDto">Dados do telefone a ser criado</param>
        /// <param name="cancellationToken">Token para cancelamento da operação</param>
        /// <returns>ID do telefone criado</returns>
        [HttpPost("cliente/{clienteId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(Guid clienteId, [FromBody] TelefoneClienteDto telefoneDto, CancellationToken cancellationToken)
        {
            try
            {
                if (clienteId == Guid.Empty)
                {
                    NotifyError("ID do cliente não pode estar vazio");
                    return CustomResponse();
                }

                if (telefoneDto == null)
                {
                    NotifyError("Dados do telefone não podem estar vazios");
                    return CustomResponse();
                }

                telefoneDto.ClienteId = (int)clienteId.GetHashCode();
                var command = new CriarTelefoneClienteCommand { TelefonesCliente = telefoneDto };
                await _mediator.Send(command, cancellationToken);

                if (!ValidOperation())
                {
                    return CustomResponse();
                }

                return CustomResponse(telefoneDto.Id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao criar telefone: {ex.Message}");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Atualiza um telefone de um cliente
        /// </summary>
        /// <param name="clienteId">ID do cliente</param>
        /// <param name="telefoneId">ID do telefone a ser atualizado</param>
        /// <param name="telefoneDto">Dados atualizados do telefone</param>
        /// <param name="cancellationToken">Token para cancelamento da operação</param>
        /// <returns>ID do telefone atualizado</returns>
        [HttpPut("cliente/{clienteId:guid}/{telefoneId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put(Guid clienteId, Guid telefoneId, [FromBody] TelefoneClienteDto telefoneDto, CancellationToken cancellationToken)
        {
            try
            {
                if (clienteId == Guid.Empty || telefoneId == Guid.Empty)
                {
                    NotifyError("IDs não podem estar vazios");
                    return CustomResponse();
                }

                if (telefoneDto == null)
                {
                    NotifyError("Dados do telefone não podem estar vazios");
                    return CustomResponse();
                }

                telefoneDto.Id = telefoneId;
                telefoneDto.ClienteId = (int)clienteId.GetHashCode();
                var command = new AlterarTelefoneClienteCommand { TelefoneCliente = telefoneDto };
                await _mediator.Send(command, cancellationToken);

                if (!ValidOperation())
                {
                    return CustomResponse();
                }

                return CustomResponse(telefoneId);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao atualizar telefone: {ex.Message}");
                return CustomResponse();
            }
        }
    }
}
