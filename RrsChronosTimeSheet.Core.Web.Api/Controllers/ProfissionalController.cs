using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Web.Api.Controllers.Base;
using RrsChronosTimeSheet.Core.Application.UsersCases.Profissionais.Command;
using RrsChronosTimeSheet.Core.Application.UsersCases.Profissionais.Query;
using RrsChronosTimeSheet.Core.Infrastructure.IoC.Utils.Notifications.Contracts;

namespace RrsChronosTimeSheet.Core.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProfissionalController(INotifications notification, IMediator mediator, IMapper mapper) : base(notification)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtém todos os profissionais
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetAllProfissionalQuery();
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao listar profissionais: {ex.Message}");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Obtém um profissional por ID
        /// </summary>
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
                    NotifyError("ID do profissional não pode estar vazio");
                    return CustomResponse();
                }

                var query = new GetProfissionalByIdQuery { Id = id };
                var result = await _mediator.Send(query, cancellationToken);

                if (result == null)
                {
                    NotifyError($"Profissional com ID {id} não encontrado");
                    return CustomResponse();
                }

                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao obter profissional: {ex.Message}");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Obtém profissionais por Unidade Federativa
        /// </summary>
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

                var query = new GetProfissionalByIdUFQuery { IdUnidadeFederativa = idUF };
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao obter profissionais por UF: {ex.Message}");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Cria um novo profissional
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] ProfissionalDto profissionalDto, CancellationToken cancellationToken)
        {
            try
            {
                if (profissionalDto == null)
                {
                    NotifyError("Dados do profissional não podem estar vazios");
                    return CustomResponse();
                }

                var command = new CriarProfissionalCommand { Profissional = profissionalDto };
                await _mediator.Send(command, cancellationToken);

                if (!ValidOperation())
                {
                    return CustomResponse();
                }

                return CustomResponse(profissionalDto.Id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao criar profissional: {ex.Message}");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Atualiza um profissional existente
        /// </summary>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put(Guid id, [FromBody] ProfissionalDto profissionalDto, CancellationToken cancellationToken)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    NotifyError("ID do profissional não pode estar vazio");
                    return CustomResponse();
                }

                if (profissionalDto == null)
                {
                    NotifyError("Dados do profissional não podem estar vazios");
                    return CustomResponse();
                }

                profissionalDto.Id = id;
                var command = new AlterarProfissionalCommand { Profissional = profissionalDto };
                await _mediator.Send(command, cancellationToken);

                if (!ValidOperation())
                {
                    return CustomResponse();
                }

                return CustomResponse(profissionalDto.Id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao atualizar profissional: {ex.Message}");
                return CustomResponse();
            }
        }

        /// <summary>
        /// Deleta um profissional
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    NotifyError("ID do profissional não pode estar vazio");
                    return CustomResponse();
                }

                var command = new DeleteProfissionalCommand { Id = id };
                await _mediator.Send(command, cancellationToken);

                if (!ValidOperation())
                {
                    return CustomResponse();
                }

                return CustomResponse(id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao deletar profissional: {ex.Message}");
                return CustomResponse();
            }
        }
    }
}
