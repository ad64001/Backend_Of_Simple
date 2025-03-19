using Backend.Common;
using Backend.Model.User.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model.User
{
    public class UserRole
    {
        public int UserId { get; set; }              // 用户ID（外键
        public int RoleId { get; set; }              // 角色ID（外键
        public Permission Permissions { get; set; }  // 权限集合（标志枚举
        // 导航属性
        public Users User { get; set; }
        public Roles Role { get; set; }
    }
}
