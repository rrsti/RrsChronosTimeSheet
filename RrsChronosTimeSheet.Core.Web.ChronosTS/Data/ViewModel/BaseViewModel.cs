namespace RrsChronosTimeSheet.Core.Web.ChronosTS.Data.ViewModel
{
    public class BaseViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAtivo { get; set; }
        public Guid? UsuarioCriacao { get; set; }
        public Guid? UsuarioAlteracao { get; set; }
    }
}
