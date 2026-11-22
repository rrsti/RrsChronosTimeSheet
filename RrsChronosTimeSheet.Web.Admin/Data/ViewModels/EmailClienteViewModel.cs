namespace RrsChronosTimeSheet.Web.Admin.Data.ViewModels
{
    public class EmailClienteViewModel : BaseViewModel
    {
        public string Email { get; set; } = string.Empty;
        public string ContatoEmail { get; set; } = string.Empty;
        public ClienteViewModel Cliente { get; set; }
    }
}