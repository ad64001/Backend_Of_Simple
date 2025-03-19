
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Backend.Extensions;
using Backend.Extensions.AutofacRegister;
using Backend.IServices;
using Backend.Repository.Base;
using Backend.Services;

namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //这里是依赖注入哦Ciallo
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(container =>
            {
                // 只需一行调用
                container.RegisterModule(new IAutofacRegister("Backend.Services","Backend.Repository"));

                // 其他手动注册可以继续添加
                // container.RegisterType<ManualService>().As<IManualService>();
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
            AutoMapperConfig.RegisterMapper();

            //builder.Services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));
            //builder.Services.AddScoped(typeof(IBaseService<,>),typeof(BaseService<,>));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
