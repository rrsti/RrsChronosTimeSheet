using System;
using System.Collections.Generic;
using System.Text;

namespace RrsChronosTimeSheet.Core.Domain.Entities
{
    public class Funcao: BaseEntities
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string? Observacao { get; set; }

    }
}
