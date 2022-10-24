using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlataformsProfile : Profile
    {
        public PlataformsProfile()
        {
            CreateMap<Platform, PlataformReadDto>();
            CreateMap<Platform, PlataformCreateDto>();
        }
    }

}