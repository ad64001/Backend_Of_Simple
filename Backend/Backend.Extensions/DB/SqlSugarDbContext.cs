using Microsoft.Extensions.Configuration;
using SqlSugar;


namespace Backend.Extensions.DB
{
    public class SqlSugarDbContext
    {
        private readonly IConfiguration _config;

        public SqlSugarDbContext(IConfiguration config)
        {
            _config = config;
        }

        public SqlSugarScope GetInstance()
        {
            return new SqlSugarScope(new ConnectionConfig()
            {
                ConnectionString = _config.GetConnectionString("Default"),
                DbType = DbType.SqlServer,  // 根据实际数据库类型修改
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
        }
    }
}
