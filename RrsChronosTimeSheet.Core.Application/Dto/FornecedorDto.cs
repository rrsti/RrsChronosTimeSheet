using System;
using System.Collections.Generic;
using System.Text;

namespace RrsChronosTimeSheet.Core.Application.Dto
{
    public class FornecedorDto: BaseDto
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
        public UnidadeFederativaDto? UnidadeFederativa { get; set; }
        public ICollection<EmailFornecedorDto>? Emails { get; set; }
        public ICollection<TelefoneFornecedorDto>? Telefones { get; set; }
    }
}
