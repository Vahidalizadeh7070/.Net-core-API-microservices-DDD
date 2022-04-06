using AutoMapper;
using PlatformService.DTO;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatformsProfile:Profile
    {
        public PlatformsProfile()
        {
            CreateMap<Platforms,PlatformReadDTO>();
            CreateMap<PlatformCreateDTO,Platforms>();
             CreateMap<PlatformReadDTO,PlatformPublishedDto>();
        }
    }
}