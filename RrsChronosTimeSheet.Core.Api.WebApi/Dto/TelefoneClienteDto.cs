namespace RrsChronosTimeSheet.Core.Api.WebApi.Dto
{
    public class TelefoneClienteDto: BaseDto
    {
        public Guid ClienteId { get; set; }
        public ClienteDto? Cliente { get; set; }
        public string NumeroTelefone { get; set; } = string.Empty;
        public string NomeContato { get; set; } = string.Empty;
        public TipoTelefoneDto? TipoTelefone { get; set; }
        public Guid TipoTelefoneId { get; set; }
        public bool WhatsApp { get; set; }
        public bool Telegram { get; set; }
        public bool IsPrincipal { get; set; }
    }
}