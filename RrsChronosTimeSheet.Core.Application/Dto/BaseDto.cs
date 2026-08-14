using System;
using System.Collections.Generic;
using System.Text;

namespace RrsChronosTimeSheet.Core.Application.Dto
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool IsDeleted { get; set; }
        public Guid UsuarioCriacao { get; set; }
        public Guid UsuarioAlteracao { get; set; }
    }
}
