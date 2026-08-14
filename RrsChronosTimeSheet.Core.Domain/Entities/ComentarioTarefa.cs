namespace RrsChronosTimeSheet.Core.Domain.Entities
{
    public class ComentarioTarefa: BaseEntities
    {
        public required Tarefas Tarefa { get; set; }
        public required Profissional Profissional { get; set; }
        public string? Comentario { get; set; }
    }
}
