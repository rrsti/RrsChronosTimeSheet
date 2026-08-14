namespace RrsChronosTimeSheet.Core.Application.Dto
{
    public class ComentarioTarefaDto: BaseDto
    {
        public required TarefasDto Tarefa { get; set; }
        public required ProfissionalDto Profissional { get; set; }
        public string? Comentario { get; set; }
    }
}
