using RrsChronosTimeSheet.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RrsChronosTimeSheet.Core.Application.Dto
{
    public class EmailFornecedorDto: BaseDto
    {
        public string Email { get; set; } = string.Empty;
        public string ContatoEmail { get; set; } = string.Empty;
    }
}
