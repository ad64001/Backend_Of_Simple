using Backend.Model;

namespace Backend.IServices
{
    public interface IUserService
    {
        Task<List<UserVo>> Query();
    }
}
