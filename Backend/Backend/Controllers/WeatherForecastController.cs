using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Backend.IServices;
using Backend.Model;
using Backend.Services;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IBaseService<Role,RoleVo> baseService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IBaseService<Role, RoleVo> baseService)
        {
            _logger = logger;
            this.baseService = baseService;
        }

        [HttpGet(Name = "GetUserQ")]
        public async Task<Object> Get()
        {
            //UserService userService = new UserService();
            //List<UserVo> userVos = await userService.Query();
            //return userVos;

            //var roleService = new BaseService<Role, RoleVo>(_mapper);
            var task = await baseService.Query();
            return task;
        }
    }
}
