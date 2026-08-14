using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Web.Api.Controllers.Base;
using RrsChronosTimeSheet.Core.Application.UsersCases.Fornecedor.Command;
using RrsChronosTimeSheet.Core.Application.UsersCases.Fornecedor.Query;
using RrsChronosTimeSheet.Core.Infrastructure.IoC.Utils.Notifications.Contracts;

namespace RrsChronosTimeSheet.Core.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public FornecedorController(INotifications notification, IMediator mediator, IMapper mapper) : base(notification)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetAllFornecedorQuery();
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao listar fornecedores: {ex.Message}");
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
                    NotifyError("ID do fornecedor não pode estar vazio");
                    return CustomResponse();
                }

                var query = new GetFornecedorByIdQuery { Id = id };
                var result = await _mediator.Send(query, cancellationToken);

                if (result == null)
                {
                    NotifyError($"Fornecedor com ID {id} não encontrado");
                    return CustomResponse();
                }

                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao obter fornecedor: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpGet("uf/{idUF:guid}")]
        public async Task<ActionResult> GetByUF(Guid idUF, CancellationToken cancellationToken)
        {
            try
            {
                if (idUF == Guid.Empty)
                {
                    NotifyError("ID da UF não pode estar vazio");
                    return CustomResponse();
                }

                var query = new GetFornecedorByIdUFQuery { IdUnidadeFederativa = idUF };
                var result = await _mediator.Send(query, cancellationToken);
                return CustomResponse(result);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao obter fornecedores por UF: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FornecedorDto fornecedorDto, CancellationToken cancellationToken)
        {
            try
            {
                if (fornecedorDto == null)
                {
                    NotifyError("Dados do fornecedor não podem estar vazios");
                    return CustomResponse();
                }

                var command = new CriarFornecedorCommand { Fornecedor = fornecedorDto };
                await _mediator.Send(command, cancellationToken);

                if (!ValidOperation())
                {
                    return CustomResponse();
                }

                return CustomResponse(fornecedorDto.Id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao criar fornecedor: {ex.Message}");
                return CustomResponse();
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] FornecedorDto fornecedorDto, CancellationToken cancellationToken)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    NotifyError("ID do fornecedor não pode estar vazio");
                    return CustomResponse();
                }

                if (fornecedorDto == null)
                {
                    NotifyError("Dados do fornecedor não podem estar vazios");
                    return CustomResponse();
                }

                fornecedorDto.Id = id;
                var command = new AlterarFornecedorCommand { Fornecedor = fornecedorDto };
                await _mediator.Send(command, cancellationToken);

                if (!ValidOperation())
                {
                    return CustomResponse();
                }

                return CustomResponse(fornecedorDto.Id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao atualizar fornecedor: {ex.Message}");
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
                    NotifyError("ID do fornecedor não pode estar vazio");
                    return CustomResponse();
                }

                var command = new DeleteFornecedorCommand { Id = id };
                await _mediator.Send(command, cancellationToken);

                if (!ValidOperation())
                {
                    return CustomResponse();
                }

                return CustomResponse(id);
            }
            catch (Exception ex)
            {
                NotifyError($"Erro ao deletar fornecedor: {ex.Message}");
                return CustomResponse();
            }
        }
    }
}
