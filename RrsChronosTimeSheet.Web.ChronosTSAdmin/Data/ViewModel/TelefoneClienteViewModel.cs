namespace RrsChronosTimeSheet.Web.ChronosTSAdmin.Data.ViewModel
{
    public class TelefoneClienteViewModel: BaseViewModel
    {
        public ClienteViewModel Cliente { get; set; } = null!;
        public string NumeroTelefone { get; set; } = string.Empty;
        public string NomeContato { get; set; } = string.Empty;
        public TipoTelefoneViewModel? TipoTelefone { get; set; }
        public Guid TipoTelefoneId { get; set; }
        public bool WhatsApp { get; set; }
        public bool Telegram { get; set; }
        public bool IsPrincipal { get; set; }
    }
}