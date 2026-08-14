using RrsChronosTimeSheet.Core.Application.Dto;

namespace RrsChronosTimeSheet.Core.Application.Dto
{
    public class EmailClienteDto: BaseDto
    {
        public string Email { get; set; } = string.Empty;
        public string ContatoEmail { get; set; } = string.Empty;
        public Guid ClienteId { get; set; }
        public ClienteDto? Cliente { get; set; }
    }
}
