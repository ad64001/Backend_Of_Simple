using Autofac;
using Autofac.Extensions.DependencyInjection;
using Backend.Common;
using Backend.Extensions;
using Backend.Extensions.AutofacRegister;
using Backend.Extensions.DB;
using Backend.Extensions.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.IO;

namespace Backend.Test
{
    public static class TestServiceProviderFactory
    {
        public static IServiceProvider CreateServiceProvider()
        {
            var host = Host.CreateDefaultBuilder()
               .ConfigureAppConfiguration((hostingContext, config) =>
               {
                   // 这里可以根据需要配置测试环境的配置文件
                   config.SetBasePath(Directory.GetCurrentDirectory());
                   config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
               })
               .UseServiceProviderFactory(new AutofacServiceProviderFactory())
               .ConfigureServices((hostContext, services) =>
               {
                   // 注册应用程序所有配置选项
                   services.AddApplicationOptions(
                       configuration: hostContext.Configuration,
                       validateOnStart: true);

                   // 注册 SqlSugarDbContext
                   services.AddSingleton<SqlSugarDbContext>(serviceProvider =>
                   {
                       var options = serviceProvider.GetRequiredService<IOptions<SqlSugarOptions>>();
                       return new SqlSugarDbContext(options);
                   });

                   services.AddControllers();
                   services.AddEndpointsApiExplorer();
                   services.AddSwaggerGen();
                   // 假设你有 AutoMapperConfig 类
                   // services.AddAutoMapper(typeof(AutoMapperConfig));
               })
               .ConfigureContainer<ContainerBuilder>(container =>
               {
                   // 仅执行一次加载
                   container.RegisterModule(new IAutofacRegister("Backend.Services", "Backend.Repository"));
               })
               .Build();

            return host.Services;
        }
    }
}
