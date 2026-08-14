namespace RrsChronosTimeSheet.Core.Web.Api.Dto
{
    public class FuncaoDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
    }
}
