using System;
using System.Collections.Generic;
using System.Text;

namespace RrsChronosTimeSheet.Core.Domain.Entities
{
    public class Usuarios: BaseEntities
    {
        public Profissional Profissional { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool EmailLogin { get; set; }
        public bool AlterarSenhaProximoLogin { get; set; }
        public Guid AspNetUserId { get; set; }

    }
}
