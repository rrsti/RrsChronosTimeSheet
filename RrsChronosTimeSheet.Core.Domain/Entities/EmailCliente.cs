namespace RrsChronosTimeSheet.Core.Domain.Entities
{
    public class EmailCliente: BaseEntities
    {
        public string Email { get; set; } = string.Empty;
        public string ContatoEmail { get; set; } = string.Empty;
        public Guid ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
