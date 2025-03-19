using Backend.Model.User;
using Newtonsoft.Json;

namespace Backend.Repository
{
    public class UserRepository : IUserRepository
    {
        public async Task<List<Users>> Query()
        {
            await Task.CompletedTask;
            var data = "[{\"Id\": 19,\"Name\":\"VBs8\"}]";
            return JsonConvert.DeserializeObject<List<Users>>(data) ?? new List<Users>();
        }
    }
}
