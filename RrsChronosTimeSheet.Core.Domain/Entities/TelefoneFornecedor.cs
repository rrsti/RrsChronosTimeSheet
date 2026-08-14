using System;
using System.Collections.Generic;
using System.Text;

namespace RrsChronosTimeSheet.Core.Domain.Entities
{
    public class TelefoneFornecedor: BaseEntities
    {
        public Guid FornecedorId { get; set; }
        public Fornecedor? Fornecedor{ get; set; }
        public string NumeroTelefone { get; set; } = string.Empty;
        public string NomeContato { get; set; } = string.Empty;
        public TipoTelefone? TipoTelefone { get; set; }
        public Guid TipoTelefoneId { get; set; }
        public bool WhatsApp { get; set; }
        public bool Telegram { get; set; }
        public bool IsPrincipal { get; set; }
    }
}
