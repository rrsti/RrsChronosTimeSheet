using RrsChronosTimeSheet.Core.Application.Dto;

namespace RrsChronosTimeSheet.Core.Application.Dto
{ 
    public class TelefoneClienteDto: BaseDto
    {
        public int ClienteId { get; set; }
        public ClienteDto Cliente { get; set; } = null!;
        public string NumeroTelefone { get; set; } = string.Empty;
        public string NomeContato { get; set; } = string.Empty;
        public TipoTelefoneDto? TipoTelefone { get; set; }
        public int TipoTelefoneId { get; set; }
        public bool WhatsApp { get; set; }
        public bool Telegram { get; set; }
        public bool IsPrincipal { get; set; }
    }
}
