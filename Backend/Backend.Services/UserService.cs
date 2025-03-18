using Backend.IServices;
using Backend.Model;
using Backend.Repository;

namespace Backend.Services
{
    public class UserService : IUserService
    {
        public async Task<List<UserVo>> Query()
        {
            UserRepository userRepo = new UserRepository();
            var users = await userRepo.Query();
            return users.Select(d=>new UserVo { UserName = d.Name}).ToList();
        }
    }
}
