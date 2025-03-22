using Backend.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Extensions.Json
{
    public static class JsonCollectionExtensions
    {
        /// <summary>
        /// 注册应用程序所有配置选项
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configuration">配置根对象</param>
        /// <param name="validateOnStart">是否启用启动时验证（默认false）</param>
        /// <returns>服务集合</returns>
        public static IServiceCollection AddApplicationOptions(
            this IServiceCollection services,
            IConfiguration configuration,
            bool validateOnStart = false)
        {
            // 注册ConnectionStrings配置节
            // 方式2：显式配置绑定
            // 注册Logging配置节
            //services.Configure<LoggingOptions>(options =>
            //    configuration.GetSection(LoggingOptions.SectionName).Bind(options));

            services.Configure<SqlSugarOptions>(options =>
                configuration.GetSection(SqlSugarOptions.SectionName).Bind(options));

            // 启用启动时验证
            if (validateOnStart)
            {
                // 添加ConnectionStringsOptions的数据注解验证
                services.AddOptions<SqlSugarOptions>()
                    .ValidateDataAnnotations()// 启用数据注解验证
                    .ValidateOnStart();// 应用启动时立即验证
            }

            return services;
        }
    }
}
