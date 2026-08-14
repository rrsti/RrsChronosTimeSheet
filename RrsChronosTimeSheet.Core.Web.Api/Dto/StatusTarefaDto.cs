namespace RrsChronosTimeSheet.Core.Web.Api.Dto
{
    public class StatusTarefaDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
    }
}
