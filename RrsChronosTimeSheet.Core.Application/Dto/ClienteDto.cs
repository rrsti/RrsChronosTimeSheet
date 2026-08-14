using RrsChronosTimeSheet.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RrsChronosTimeSheet.Core.Application.Dto
{
    public class ClienteDto: BaseDto
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
        public ICollection<EmailClienteDto>? Emails { get; set; }
        public ICollection<TelefoneClienteDto>? Telefones { get; set; }
    }
}
