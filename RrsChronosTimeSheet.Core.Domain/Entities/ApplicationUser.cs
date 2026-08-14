using Microsoft.AspNetCore.Identity;

namespace RrsChronosTimeSheet.Core.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string NomeCompleto { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
