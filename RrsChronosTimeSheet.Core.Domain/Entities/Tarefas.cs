using System;
using System.Collections.Generic;
using System.Text;

namespace RrsChronosTimeSheet.Core.Domain.Entities
{
    public class Tarefas: BaseEntities
    {
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public required Profissional Responsavel { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public float QtdHorasEstimadas { get; set; }
        public StatusTarefa? Status { get; set; }
        public required Projeto Projeto { get; set; }
    }
}
