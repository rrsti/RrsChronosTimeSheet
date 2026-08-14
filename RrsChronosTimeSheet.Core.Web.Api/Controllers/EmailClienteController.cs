using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RrsChronosTimeSheet.Core.Web.Api.Controllers.Base;
using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Application.UsersCases.EmailsClientes.Command;
using RrsChronosTimeSheet.Core.Application.UsersCases.EmailsClientes.Query;
using RrsChronosTimeSheet.Core.Infrastructure.IoC.Utils.Notifications.Contracts;

namespace RrsChronosTimeSheet.Core.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailClienteController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public EmailClienteController(INotifications notification, IMediator mediator, IMapper mapper) : base(notification)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        /// <summary>
        /// Obtém todos os emails de um cliente
        /// </summary>
        /// <param name="clienteId">ID do cliente</param>
        /// <param name="cancellationToken">Token para cancelamento da operação</param>
        /// <returns>Lista de emails do cliente</returns>
        [HttpGet("cliente/{clienteId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllEmails(Guid clienteId, CancellationToken cancellationToken)
        {
            try
            {
                if (clienteId == Guid.Empty)
                {
                    NotifyError("ID do cliente não pode estar vazio");
                    return CustomResponse();
                }

                var query = new GetAllEmailClienteQuery();
                var result = await _mediator.Send(query, cancellationToken);

                // Filtrar emails do cliente específico
                var emailsDoCliente = result?.Where(e => e.ClienteId == clienteId).ToList();
                return CustomResponse(emailsDoCliente);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao listar emails do cliente: {ex.Message}");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Obtém um email específico de um cliente
        /// </summary>
        /// <param name="clienteId">ID do cliente</param>
        /// <param name="emailId">ID do email</param>
        /// <param name="cancellationToken">Token para cancelamento da operação</param>
        /// <returns>Dados do email solicitado</returns>
        [HttpGet("cliente/{clienteId:guid}/{emailId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetEmailById(Guid clienteId, Guid emailId, CancellationToken cancellationToken)
        {
            try
            {
                if (clienteId == Guid.Empty || emailId == Guid.Empty)
                {
                    NotifyError("IDs não podem estar vazios");
                    return CustomResponse();
                }

                var query = new GetEmailClienteByIdQuery { Id = emailId };
                var result = await _mediator.Send(query, cancellationToken);

                if (result == null || result.ClienteId != clienteId)
                {
                    NotifyError("Email não encontrado ou não pertence a este cliente");
                    return CustomResponse();
                }

                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao obter email: {ex.Message}");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Cria um novo email para um cliente
        /// </summary>
        /// <param name="clienteId">ID do cliente</param>
        /// <param name="emailDto">Dados do email a ser criado</param>
        /// <param name="cancellationToken">Token para cancelamento da operação</param>
        /// <returns>ID do email criado</returns>
        [HttpPost("cliente/{clienteId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(Guid clienteId, [FromBody] EmailClienteDto emailDto, CancellationToken cancellationToken)
        {
            try
            {
                if (clienteId == Guid.Empty)
                {
                    NotifyError("ID do cliente não pode estar vazio");
                    return CustomResponse();
                }

                if (emailDto == null)
                {
                    NotifyError("Dados do email não podem estar vazios");
                    return CustomResponse();
                }

                emailDto.ClienteId = clienteId;
                var command = new CriarEmailClienteCommand { EmailCliente = emailDto };
                await _mediator.Send(command, cancellationToken);

                if (!ValidOperation())
                {
                    return CustomResponse();
                }

                return CustomResponse(emailDto.Id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao criar email: {ex.Message}");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Atualiza um email de um cliente
        /// </summary>
        /// <param name="clienteId">ID do cliente</param>
        /// <param name="emailId">ID do email a ser atualizado</param>
        /// <param name="emailDto">Dados atualizados do email</param>
        /// <param name="cancellationToken">Token para cancelamento da operação</param>
        /// <returns>ID do email atualizado</returns>
        [HttpPut("cliente/{clienteId:guid}/{emailId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put(Guid clienteId, Guid emailId, [FromBody] EmailClienteDto emailDto, CancellationToken cancellationToken)
        {
            try
            {
                if (clienteId == Guid.Empty || emailId == Guid.Empty)
                {
                    NotifyError("IDs não podem estar vazios");
                    return CustomResponse();
                }

                if (emailDto == null)
                {
                    NotifyError("Dados do email não podem estar vazios");
                    return CustomResponse();
                }

                emailDto.Id = emailId;
                emailDto.ClienteId = clienteId;
                var command = new AlterarEmailClienteCommand { EmailCliente = emailDto };
                await _mediator.Send(command, cancellationToken);

                if (!ValidOperation())
                {
                    return CustomResponse();
                }

                return CustomResponse(emailId);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao atualizar email: {ex.Message}");
                return CustomResponse();
            }
        }
    }
}
