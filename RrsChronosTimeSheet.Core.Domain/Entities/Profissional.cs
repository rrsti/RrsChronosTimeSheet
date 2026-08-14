using System;
using System.Collections.Generic;
using System.Text;

namespace RrsChronosTimeSheet.Core.Domain.Entities
{
    public class Profissional: BaseEntities
    {
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
        public string? Rg { get; set; }
        public DateTime DataNascimento {  get; set; }
        public string? Nacionalidade { get; set; }
        public UnidadeFederativa? UfNaturalidade { get; set; }
        public Funcao? Funcao { get; set; }
        public string? Cep { get; set; }
        public string? Logradouro {  get; set; }
        public int? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Cidade {  get; set; }
        public string? Bairro { get; set; }
        public UnidadeFederativa? UnidadeFederativa { get; set; }
        public ICollection<EmailProfissional>? Emails { get; set; }
        public ICollection<TelefoneProfissional>? Telefones { get; set; }
        public bool ProfissionalTerceirizado { get; set; }
        public Fornecedor? Fornecedor { get; set; }
        public Byte[]? Foto { get; set; }
    }
}
