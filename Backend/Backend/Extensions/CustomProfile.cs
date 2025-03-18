using AutoMapper;
using Backend.Model;

namespace Backend.Extensions
{
    public class CustomProfile:Profile
    {
        public CustomProfile()
        {
            CreateMap<Role, RoleVo>().ForMember(one => one.RoleName, two => two.MapFrom(three=>three.Name));
            CreateMap<RoleVo, Role>().ForMember(one => one.Name, two => two.MapFrom(three=>three.RoleName));
        }
    }
}
