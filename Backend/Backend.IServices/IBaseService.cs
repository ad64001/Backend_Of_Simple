using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.IServices
{
    public interface IBaseService<AEntity, AVo> where AEntity : class
    {
        Task<List<AVo>> Query();
    }
}
