namespace RrsChronosTimeSheet.Core.Web.Api.Dto
{
    public class TelefoneProfissionalDto : BaseDto
    {
        public Guid Id { get; set; }
        public required string Numero { get; set; }
        public required ProfissionalDto Profissional { get; set; }
        public required TipoTelefoneDto TipoTelefone { get; set; }
    }
}
