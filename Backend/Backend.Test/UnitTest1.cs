using Backend.Repository.UserRe;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Test
{
    public class UnitTest1
    {
        private readonly IUserRepository _userRepository;

        public UnitTest1()
        {
            var serviceProvider = TestServiceProviderFactory.CreateServiceProvider();
            _userRepository = serviceProvider.GetRequiredService<IUserRepository>();
        }
        [Fact]
        public void Test1()
        {
            // 创建一个测试用的 UserRole 实例
            var userRole = new Backend.Model.UserModel.UserRole
            {
                UserId = 1,
                RoleId = 1
            };
            _userRepository.AddUserAsync(userRole);

        }
    }
}
