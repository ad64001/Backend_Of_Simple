using Backend.Model;
using Newtonsoft.Json;

namespace Backend.Repository.Base
{
    public class BaseRepository<AEntity> : IBaseRepository<AEntity> where AEntity : class, new()
    {
        public async Task<List<AEntity>> Query()
        {
            await Task.CompletedTask;
            var data = "[{\"Id\": 19,\"Name\":\"VBs8NNNN\"}]";
            return JsonConvert.DeserializeObject<List<AEntity>>(data) ?? new List<AEntity>();
        }
    }
}
