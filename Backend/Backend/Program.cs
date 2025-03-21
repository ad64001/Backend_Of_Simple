
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Backend.Extensions;
using Backend.Extensions.AutofacRegister;
using Backend.Extensions.DB;


namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //����������ע��ŶCiallo
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(container =>
            {
                // ֻ��һ�е���
                container.RegisterModule(new IAutofacRegister("Backend.Services","Backend.Repository"));

                // �����ֶ�ע����Լ������
                // container.RegisterType<ManualService>().As<IManualService>();
            });

            // ע�� SqlSugar ����
            // ע�� SqlSugarDbContext
            builder.Services.AddSingleton<SqlSugarDbContext>(sp =>
                new SqlSugarDbContext(builder.Configuration));
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
            DatabaseInitializer.Initialize(app.Services);

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
