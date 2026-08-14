namespace RrsChronosTimeSheet.Core.Web.Api.Dto
{
    public class ComentarioTarefaDto : BaseDto
    {
        public Guid Id { get; set; }
        public required TarefasDto Tarefas { get; set; }
        public required string Comentario { get; set; }
        public Guid UsuarioCriacao { get; set; }
    }
}
