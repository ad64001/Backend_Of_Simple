﻿using Backend.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository
{
    public interface IUserRepository
    {
        Task<List<Users>> Query();
    }
}
