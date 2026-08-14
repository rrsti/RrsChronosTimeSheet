using System;
using System.Collections.Generic;
using System.Text;

namespace RrsChronosTimeSheet.Core.Domain.Entities
{
    public class EmailProfissional : BaseEntities
    {
        public string Email { get; set; } = string.Empty;
        public string ContatoEmail { get; set; } = string.Empty;
        public Guid ProfissionalId { get; set; }
        public Profissional? Profissional { get; set; }
    }
}
