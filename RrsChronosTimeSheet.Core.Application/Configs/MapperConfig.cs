using AutoMapper;
using RrsChronosTimeSheet.Core.Application.Dto;
using RrsChronosTimeSheet.Core.Domain.Entities;
using System.Diagnostics;

namespace RrsChronosTimeSheet.Core.Application.Configs
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<TelefoneCliente, TelefoneClienteDto>().ReverseMap();
            CreateMap<EmailCliente, EmailClienteDto>().ReverseMap();
            CreateMap<TipoTelefone, TipoTelefoneDto>().ReverseMap();
            CreateMap<UnidadeFederativa, UnidadeFederativaDto>().ReverseMap();
        }
    }
}
