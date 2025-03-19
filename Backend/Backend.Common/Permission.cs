using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common
{
    [Flags]  // 标志枚举，支持按位运算
    public enum Permission
    {
        None = 0,               // 无权限
        CreatePost = 1 << 0,    // 创建文章（二进制：0001）
        EditPost = 1 << 1,      // 编辑文章（二进制：0010）
        DeletePost = 1 << 2,    // 删除文章（二进制：0100）
        ManageUsers = 1 << 3,   // 管理用户（二进制：1000）
                                // 可根据需要扩展其他权限
    }


}
