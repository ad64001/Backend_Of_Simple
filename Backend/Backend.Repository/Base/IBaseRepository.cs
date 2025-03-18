﻿using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.Base
{
    public interface IBaseRepository<AEntity> where AEntity : class
    {
        Task<List<AEntity>> Query();
    }
}
