namespace RrsChronosTimeSheet.Core.Domain.Entities
{
    public class HorasProfissional: BaseEntities
    {
        public required Tarefas Tarefa { get; set; }
        public required Profissional Profissional { get; set; }
        public DateTime Data { get; set; }
        public double HoraInicio { get; set; }
        public double HoraFim { get; set; }
    }
}
