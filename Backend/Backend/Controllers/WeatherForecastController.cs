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
        private readonly IUserService userService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IUserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }

        [HttpGet(Name = "GetUserQ")]
        public async Task<Object> Get()
        {
            //UserService userService = new UserService();
            //List<UserVo> userVos = await userService.Query();
            //return userVos;

            //var roleService = new BaseService<Role, RoleVo>(_mapper);

            return userService.Query();
        }
    }
}
