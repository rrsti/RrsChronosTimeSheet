namespace RrsChronosTimeSheet.Core.Application.Dto
{
    public class FuncaoDto: BaseDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string? Observacao { get; set; }
    }
}