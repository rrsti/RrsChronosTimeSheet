using AutoMapper;
using RrsChronosTimeSheet.Core.Web.Api.Dto;
using RrsChronosTimeSheet.Core.Domain.Entities;

namespace RrsChronosTimeSheet.Core.Web.Api.Config
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<TipoTelefone, TipoTelefoneDto>().ReverseMap();
            CreateMap<EmailCliente, EmailClienteDto>().ReverseMap();
            CreateMap<TelefoneCliente, TelefoneClienteDto>().ReverseMap();
            CreateMap<UnidadeFederativa, UnidadeFederativaDto>().ReverseMap();
        }
    }
}
