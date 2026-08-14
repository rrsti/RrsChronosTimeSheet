namespace RrsChronosTimeSheet.Core.Application.Dto
{
    public class TelefoneProfissionalDto:BaseDto
    {
        public Guid ProfissionalId { get; set; }
        public ProfissionalDto? Profissional { get; set; }
        public string NumeroTelefone { get; set; } = string.Empty;
        public string NomeContato { get; set; } = string.Empty;
        public TipoTelefoneDto? TipoTelefone { get; set; }
        public Guid TipoTelefoneId { get; set; }
        public bool WhatsApp { get; set; }
        public bool Telegram { get; set; }
        public bool IsPrincipal { get; set; }
    }
}