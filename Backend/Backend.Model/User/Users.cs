namespace Backend.Model.User
{
    public class Users
    {
        public int UserId { get; set; }               // 用户ID（主键）
        public string Username { get; set; }          // 用户名（唯一）
        public string Email { get; set; }             // 邮箱（唯一）
        public string PasswordHash { get; set; }      // 密码哈希值
        public string Salt { get; set; }              // 加密盐值
        public DateTime CreatedAt { get; set; }       // 创建时间
        public bool IsActive { get; set; }            // 是否激活

        // 导航属性：用户与角色的关联
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
