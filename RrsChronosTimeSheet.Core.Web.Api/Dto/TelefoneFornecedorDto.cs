namespace RrsChronosTimeSheet.Core.Web.Api.Dto
{
    public class TelefoneFornecedorDto : BaseDto
    {
        public Guid Id { get; set; }
        public required string Numero { get; set; }
        public required FornecedorDto Fornecedor { get; set; }
        public required TipoTelefoneDto TipoTelefone { get; set; }
    }
}
