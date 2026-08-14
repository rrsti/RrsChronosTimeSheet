using System.ComponentModel.DataAnnotations.Schema;

namespace RrsChronosTimeSheet.Core.Domain.Entities
{
    public class Fornecedor: BaseEntities
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
        public UnidadeFederativa? UnidadeFederativa { get; set; }
        public ICollection<EmailFornecedor>? Emails { get; set; }
        public ICollection<TelefoneFornecedor>? Telefones { get; set; }
        
        [NotMapped]
        public int TotalTelefones { get; set; }
        [NotMapped]
        public int TotalEmails { get; set; }
        [NotMapped]
        public int TotalProfissionais { get; set; }
    }
}