using AutoMapper;
using MagicVilla2_VillaAPI.Models;
using MagicVilla2_VillaAPI.Models.Dto;

namespace MagicVilla2_VillaAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            //Villa
            CreateMap<Villa, VillaDto>(); CreateMap<VillaDto, Villa>();

            CreateMap<Villa, VillaCreateDto>().ReverseMap();

            CreateMap<Villa, VillaUpdateDto>().ReverseMap();

            //VillaNumber
            CreateMap<VillaNumber, VillaNumberDto>().ReverseMap();

            CreateMap<VillaNumber, VillaNumberCreateDto>().ReverseMap();

            CreateMap<VillaNumber, VillaNumberUpdateDto>().ReverseMap();
        }
    }
}
