using Backend.Extensions.DB;
using Backend.Model;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly SqlSugarDbContext _dbContext;

        public UserController(SqlSugarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 获取所有用户
        [HttpGet]
        public IActionResult GetUsers()
        {
            using var db = _dbContext.GetInstance();
            var users = db.Queryable<User>().ToList();
            return Ok(users);
        }

        // 添加新用户
        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            using var db = _dbContext.GetInstance();
            db.Insertable(user).ExecuteCommand();
            return Ok("User added successfully");
        }


    }
}
