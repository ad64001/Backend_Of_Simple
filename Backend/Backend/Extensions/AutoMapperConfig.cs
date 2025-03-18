using AutoMapper;

namespace Backend.Extensions
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMapper()
        {
            return new MapperConfiguration(cfg => {
                cfg.AddProfile(new CustomProfile());
            });
        }
    }
}
