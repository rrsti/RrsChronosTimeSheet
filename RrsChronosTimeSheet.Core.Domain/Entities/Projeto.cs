namespace RrsChronosTimeSheet.Core.Domain.Entities
{
    public class Projeto: BaseEntities
    {
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public required Cliente Cliente { get; set; }
        public required StatusProjeto Status { get; set; }
        public required TipoProjeto Tipo { get; set; }
        public float Orçamento { get; set; } 
        public float QtdHorasEstimadas { get; set; }
        public required Profissional Responsavel { get; set; }
    }
}
