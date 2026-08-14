namespace RrsChronosTimeSheet.Core.Application.Dto
{
    public class HorasProfissionalDto: BaseDto
    {
        public required TarefasDto Tarefa { get; set; }
        public required ProfissionalDto Profissional { get; set; }
        public DateTime Data { get; set; }
        public double HoraInicio { get; set; }
        public double HoraFim { get; set; }
    }
}
