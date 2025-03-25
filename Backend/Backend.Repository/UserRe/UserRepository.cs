using Backend.Extensions.DB;
using Backend.Extensions.IAttributes;
using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.UserRe
{
    [AutoInject(typeof(IUserRepository), false)]
    public class UserRepository : IUserRepository
    {
        private readonly SqlSugarDbContext _dbContext;

        public UserRepository(SqlSugarDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task AddUserAsync(UserRole userRole)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserRole>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserRole> GetUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(UserRole userRole)
        {
            throw new NotImplementedException();
        }
    }
}
