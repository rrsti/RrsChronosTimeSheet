using System;
using System.Text;
using System.Collections.Generic;

namespace RrsChronosTimeSheet.Core.Application.Dto
{
    public class TelefoneFornecedorDto: BaseDto
    {
        public string NumeroTelefone { get; set; } = string.Empty;
        public string NomeContato { get; set; } = string.Empty;
        public TipoTelefoneDto? TipoTelefone { get; set; }
        public Guid TipoTelefoneId { get; set; }
        public bool WhatsApp { get; set; }
        public bool Telegram { get; set; }
        public bool IsPrincipal { get; set; }
    }
}
