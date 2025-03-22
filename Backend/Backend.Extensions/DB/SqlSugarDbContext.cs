using Backend.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SqlSugar;


namespace Backend.Extensions.DB
{
    public class SqlSugarDbContext
    {
        private readonly SqlSugarOptions options;

        public SqlSugarDbContext(IOptions<SqlSugarOptions> options)
        {
            this.options = options.Value;
        }

        public SqlSugarScope GetInstance()
        {
            return new SqlSugarScope(new ConnectionConfig()
            {
                ConnectionString = options.DefaultPath,
                DbType = DbType.SqlServer,  // 根据实际数据库类型修改
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
        }
    }
}
