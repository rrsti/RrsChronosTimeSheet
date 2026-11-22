namespace RrsChronosTimeSheet.Core.Web.ChronosTS.Data.ViewModel
{
    public class EmailClienteViewModel: BaseViewModel
    {
        public string Email { get; set; } = string.Empty;
        public string ContatoEmail { get; set; } = string.Empty;
        public ClienteViewModel? Cliente { get; set; }
    }
}