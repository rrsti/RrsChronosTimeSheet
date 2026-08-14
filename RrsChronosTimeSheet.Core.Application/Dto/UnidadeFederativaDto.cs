using RrsChronosTimeSheet.Core.Application.Dto;

namespace RrsChronosTimeSheet.Core.Application.Dto
{
    public class UnidadeFederativaDto: BaseDto
    {
        public string Sigla { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
    }
}
