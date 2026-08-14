namespace RrsChronosTimeSheet.Core.Web.Api.Dto
{
    public class EmailProfissionalDto : BaseDto
    {
        public Guid Id { get; set; }
        public required string Email { get; set; }
        public required ProfissionalDto Profissional { get; set; }
    }
}
