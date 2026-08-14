namespace RrsChronosTimeSheet.Core.Web.Api.Dto
{
    public class FornecedorDto : BaseDto
    {
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string InscricaoEstadual { get; set; } = string.Empty;
        public string InscricaoMunicipal { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public int? Numero { get; set; }
        public string Cep { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public UnidadeFederativaDto? UnidadeFederativa { get; set; }
        public ICollection<EmailFornecedorDto>? Emails { get; set; }
        public ICollection<TelefoneFornecedorDto>? Telefones { get; set; }
    }
}
