using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Model.User.User
{
    public class Roles
    {
        public int RoleId { get; set; }              // 角色ID（主键）
        public string RoleName { get; set; }         // 角色名称（如 "Admin"）
        public string Description { get; set; }      // 角色描述

        // 导航属性：角色与用户的关联
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
