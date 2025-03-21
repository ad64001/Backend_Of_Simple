using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Extensions.DB
{
    // Data/TableInitializer.cs
    public static class DatabaseInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<SqlSugarDbContext>();
            using var db = dbContext.GetInstance();

            // 扫描所有带 [SugarTable] 的实体
            var entityTypes = GetAllClassesFromAssembly("Backend.Model");

            // 配置字段差异更新并初始化表
            db.CodeFirst
                .SetStringDefaultLength(100)   // 设置字符串默认长度
                .InitTables(entityTypes);      // 执行表结构同步
        }

       public static Type[] GetAllClassesFromAssembly(string assemblyName)
    {
        try
        {
            // 通过程序集名称加载程序集
            var assembly = Assembly.Load(assemblyName);
            
            if (assembly == null)
            {
                throw new Exception($"无法加载程序集: {assemblyName}");
            }

            // 扫描所有类
            var classTypes = assembly.GetTypes()
                .Where(t => t.GetCustomAttribute<SugarTable>() != null)
                .ToArray();

                return classTypes;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"扫描类时出错: {ex.Message}");
            return Array.Empty<Type>(); // 返回空数组，避免程序崩溃
        }
    }
    }
}
