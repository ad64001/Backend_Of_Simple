using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model.UserModel
{
    // UserRole.cs
    public class UserRole
    {
        public int UserId { get; set; }   // 复合主键部分
        public int RoleId { get; set; }   // 复合主键部分

        // 导航属性（仅存在于联结表）
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
