namespace RrsChronosTimeSheet.Web.ChronosTSAdmin.Data.ViewModel
{
    public class EmailClienteViewModel: BaseViewModel
    {
        public string Email { get; set; } = string.Empty;
        public string ContatoEmail { get; set; } = string.Empty;
        public Guid ClienteId { get; set; }
        public ClienteViewModel? Cliente { get; set; }
    }
}