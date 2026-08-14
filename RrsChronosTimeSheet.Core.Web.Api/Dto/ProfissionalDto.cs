namespace RrsChronosTimeSheet.Core.Web.Api.Dto
{
    public class ProfissionalDto : BaseDto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
        public string? Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Nacionalidade { get; set; }
        public UnidadeFederativaDto? UfNaturalidade { get; set; }
        public FuncaoDto? Funcao { get; set; }
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public int? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Cidade { get; set; }
        public string? Bairro { get; set; }
        public UnidadeFederativaDto? UnidadeFederativa { get; set; }
        public ICollection<EmailProfissionalDto>? Emails { get; set; }
        public ICollection<TelefoneProfissionalDto>? Telefones { get; set; }
        public bool ProfissionalTerceirizado { get; set; }
        public FornecedorDto? Fornecedor { get; set; }
        public Byte[]? Foto { get; set; }
    }
}
