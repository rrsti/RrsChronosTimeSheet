namespace RrsChronosTimeSheet.Web.Admin.Data.ViewModels
{
    public class ClienteViewModel: BaseViewModel
    {
        public string RazaoSocial { get; set; } = string.Empty;
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
        public UnidadeFederativaViewModel? UnidadeFederativa { get; set; }
        public ICollection<EmailClienteViewModel>? Emails { get; set; }
        public ICollection<TelefoneClienteViewModel>? Telefones { get; set; }
    }
}
