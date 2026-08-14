namespace RrsChronosTimeSheet.Core.Domain.Entities
{ 
    public class TelefoneCliente: BaseEntities
    {
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
        public string NumeroTelefone { get; set; } = string.Empty;
        public string NomeContato { get; set; } = string.Empty;
        public TipoTelefone? TipoTelefone { get; set; }
        public Guid TipoTelefoneId { get; set; }
        public bool WhatsApp { get; set; }
        public bool Telegram { get; set; }
        public bool IsPrincipal { get; set; }
    }
}
