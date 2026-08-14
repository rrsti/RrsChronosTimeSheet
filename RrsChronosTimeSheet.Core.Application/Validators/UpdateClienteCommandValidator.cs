using FluentValidation;
using RrsChronosTimeSheet.Core.Application.Dto.Commands;

namespace RrsChronosTimeSheet.Core.Application.Validators
{
    /// <summary>
    /// Validador para o command de atualizar cliente
    /// </summary>
    public class UpdateClienteCommandValidator : AbstractValidator<UpdateClienteCommand>
    {
        public UpdateClienteCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID do cliente é obrigatório");

            RuleFor(x => x.RazaoSocial)
                .NotEmpty().WithMessage("Razão social é obrigatória")
                .MinimumLength(3).WithMessage("Razão social deve ter no mínimo 3 caracteres")
                .MaximumLength(255).WithMessage("Razão social não pode exceder 255 caracteres");

            RuleFor(x => x.NomeFantasia)
                .NotEmpty().WithMessage("Nome fantasia é obrigatório")
                .MinimumLength(3).WithMessage("Nome fantasia deve ter no mínimo 3 caracteres")
                .MaximumLength(255).WithMessage("Nome fantasia não pode exceder 255 caracteres");

            RuleFor(x => x.Cnpj)
                .NotEmpty().WithMessage("CNPJ é obrigatório")
                .Length(14).WithMessage("CNPJ deve ter 14 dígitos")
                .Matches(@"^\d{14}$").WithMessage("CNPJ deve conter apenas números");

            RuleFor(x => x.InscricaoEstadual)
                .NotEmpty().WithMessage("Inscrição estadual é obrigatória")
                .MaximumLength(30).WithMessage("Inscrição estadual não pode exceder 30 caracteres");

            RuleFor(x => x.InscricaoMunicipal)
                .MaximumLength(30).WithMessage("Inscrição municipal não pode exceder 30 caracteres");

            RuleFor(x => x.Logradouro)
                .NotEmpty().WithMessage("Logradouro é obrigatório")
                .MaximumLength(255).WithMessage("Logradouro não pode exceder 255 caracteres");

            RuleFor(x => x.Numero)
                .GreaterThan(0).WithMessage("Número deve ser maior que 0").When(x => x.Numero.HasValue);

            RuleFor(x => x.Cep)
                .NotEmpty().WithMessage("CEP é obrigatório")
                .Length(8).WithMessage("CEP deve ter 8 dígitos")
                .Matches(@"^\d{8}$").WithMessage("CEP deve conter apenas números");

            RuleFor(x => x.Complemento)
                .MaximumLength(255).WithMessage("Complemento não pode exceder 255 caracteres");

            RuleFor(x => x.Bairro)
                .NotEmpty().WithMessage("Bairro é obrigatório")
                .MaximumLength(100).WithMessage("Bairro não pode exceder 100 caracteres");

            RuleFor(x => x.Cidade)
                .NotEmpty().WithMessage("Cidade é obrigatória")
                .MaximumLength(100).WithMessage("Cidade não pode exceder 100 caracteres");

            RuleFor(x => x.IdUnidadeFederativa)
                .NotEmpty().WithMessage("Unidade Federativa é obrigatória");
        }
    }
}
