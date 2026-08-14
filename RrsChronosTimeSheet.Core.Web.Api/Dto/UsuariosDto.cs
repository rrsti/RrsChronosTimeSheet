namespace RrsChronosTimeSheet.Core.Web.Api.Dto
{
    public class UsuariosDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string? Telefone { get; set; }
        public string? CPF { get; set; }
        public string? Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
