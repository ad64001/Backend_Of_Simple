using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.UserRe
{
    public interface IUserRepository
    {
        public Task AddUserAsync(UserRole userRole);
        public Task<UserRole> GetUserAsync(int id);
        public Task<List<UserRole>> GetAllUsersAsync();
        public Task DeleteUserAsync(int id);
        public Task UpdateUserAsync(UserRole userRole);
    }
}
