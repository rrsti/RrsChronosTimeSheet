namespace RrsChronosTimeSheet.Core.Web.Api.Dto
{
    public class EmailFornecedorDto : BaseDto
    {
        public Guid Id { get; set; }
        public required string Email { get; set; }
        public required FornecedorDto Fornecedor { get; set; }
    }
}
