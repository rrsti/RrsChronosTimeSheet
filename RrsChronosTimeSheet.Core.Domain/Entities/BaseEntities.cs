namespace RrsChronosTimeSheet.Core.Domain.Entities
{
    public class BaseEntities
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAtivo { get; set; }
        public Guid? UsuarioCriacao { get; set; }
        public Guid? UsuarioAlteracao { get; set; }
        public BaseEntities()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.UtcNow;
            IsDeleted = false;
            IsAtivo = true;
        }
    }
}
