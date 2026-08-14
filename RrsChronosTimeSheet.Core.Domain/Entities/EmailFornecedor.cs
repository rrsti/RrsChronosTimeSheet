using System;
using System.Collections.Generic;
using System.Text;

namespace RrsChronosTimeSheet.Core.Domain.Entities
{
    public class EmailFornecedor: BaseEntities
    {
        public string Email { get; set; } = string.Empty;
        public string ContatoEmail { get; set; } = string.Empty;
        public Guid FornecedorId { get; set; }
        public Fornecedor? Fornecedor { get; set; }
    }
}
