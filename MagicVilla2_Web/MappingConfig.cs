using AutoMapper;
using MagicVilla2_Web.Models;
using MagicVilla2_Web.Models.Dto;

namespace MagicVilla2_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<VillaDto, VillaCreateDto>().ReverseMap();

            CreateMap<VillaDto, VillaUpdateDto>().ReverseMap();
        

            CreateMap<VillaNumberDto, VillaNumberUpdateDto>().ReverseMap();

            CreateMap<VillaNumberDto, VillaNumberUpdateDto>().ReverseMap();
        }
    }
}
