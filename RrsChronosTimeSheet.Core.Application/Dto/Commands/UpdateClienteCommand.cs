namespace RrsChronosTimeSheet.Core.Application.Dto.Commands
{
    /// <summary>
    /// DTO para atualizar um cliente existente
    /// </summary>
    public class UpdateClienteCommand
    {
        public Guid Id { get; set; }
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
        public Guid? IdUnidadeFederativa { get; set; }
    }
}
