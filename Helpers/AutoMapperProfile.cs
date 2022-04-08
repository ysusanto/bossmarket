using AutoMapper;
using bossmarket.Entities;
using bossmarket.Models.Users;

namespace bossmarket.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateUser, Users>();

        }
    }
}