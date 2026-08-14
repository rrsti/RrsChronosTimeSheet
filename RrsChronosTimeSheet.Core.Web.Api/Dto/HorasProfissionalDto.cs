namespace RrsChronosTimeSheet.Core.Web.Api.Dto
{
    public class HorasProfissionalDto : BaseDto
    {
        public Guid Id { get; set; }
        public required ProfissionalDto Profissional { get; set; }
        public required TarefasDto Tarefas { get; set; }
        public float QtdHoras { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}
