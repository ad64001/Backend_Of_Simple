using Backend.IServices;
using Backend.Model;
using Backend.Repository;
using Extensions.IAttributes;

namespace Backend.Services
{
    [AutoInject(typeof(IUserService),singleInstance:true)]
    public class UserService : IUserService
    {
        public string Query()
        {
            return "Love2000";
        }
    }
}
