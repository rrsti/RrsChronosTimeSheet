namespace RrsChronosTimeSheet.Core.Application.Dto
{
    public class EmailProfissionalDto: BaseDto
    {
        public string Email { get; set; } = string.Empty;
        public string ContatoEmail { get; set; } = string.Empty;
        public Guid ProfissionalId { get; set; }
        public ProfissionalDto? Profissional { get; set; }
    }
}