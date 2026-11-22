namespace RrsChronosTimeSheet.Web.Admin.Data.ViewModels
{
    public class BaseViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAtivo { get; set; }
        public Guid? UsuarioCriacao { get; set; }
        public Guid? UsuarioAlteracao { get; set; }
        public BaseViewModel()
        {
            DataCriacao = DateTime.UtcNow;
            IsDeleted = false;
            IsAtivo = true;
        }
    }
}
