namespace RrsChronosTimeSheet.Core.Web.Api.Dto
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool IsDeleted { get; set; }
        public Guid UsuarioCriacao { get; set; }
        public Guid UsuarioAlteracao { get; set; }
    }
}
