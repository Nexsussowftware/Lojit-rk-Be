using AutoMapper;
using Core.Domains.User;
using Core.Dtos;

namespace Lojit_rk_Be.Utilites.AutoMapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<UserForRegistrationDto, Driver>();
        }
    }
}
