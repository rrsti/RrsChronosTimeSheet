namespace RrsChronosTimeSheet.Core.Application.Dto
{
    public class TarefasDto: BaseDto
    {
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public required ProfissionalDto Responsavel { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public float QtdHorasEstimadas { get; set; }
        public StatusTarefaDto? Status { get; set; }
        public required ProjetoDto Projeto { get; set; }
    }
}