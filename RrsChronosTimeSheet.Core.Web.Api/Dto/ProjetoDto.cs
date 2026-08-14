namespace RrsChronosTimeSheet.Core.Web.Api.Dto
{
    public class ProjetoDto : BaseDto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public required ClienteDto Cliente { get; set; }
        public required StatusProjetoDto Status { get; set; }
        public required TipoProjetoDto Tipo { get; set; }
        public float Orçamento { get; set; }
        public float QtdHorasEstimadas { get; set; }
        public required ProfissionalDto Responsavel { get; set; }
    }
}
