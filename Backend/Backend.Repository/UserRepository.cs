using Backend.Model;
using Newtonsoft.Json;

namespace Backend.Repository
{
    public class UserRepository : IUserRepository
    {
        public async Task<List<User>> Query()
        {
            await Task.CompletedTask;
            var data = "[{\"Id\": 19,\"Name\":\"VBs8\"}]";
            return JsonConvert.DeserializeObject<List<User>>(data) ?? new List<User>();
        }
    }
}
