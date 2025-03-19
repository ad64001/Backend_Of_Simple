using Autofac;
using Extensions.IAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.AutofacRegister
{
    public class IAutofacRegister : Autofac.Module
    {
        private readonly string[] _assemblyPatterns;

        public IAutofacRegister(params string[] assemblyPatterns)
        {
            _assemblyPatterns = assemblyPatterns;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // 动态加载程序集（核心改进点）
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var assemblyFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");

            foreach (var file in assemblyFiles)
            {
                var assemblyName = Path.GetFileNameWithoutExtension(file);

                // 如果符合模式且未被加载
                if (_assemblyPatterns.Any(p => assemblyName.Contains(p)) &&
                    !loadedAssemblies.Any(a => a.GetName().Name == assemblyName))
                {
                    try
                    {
                        // 动态加载程序集
                        var assembly = Assembly.LoadFrom(file);
                        loadedAssemblies.Add(assembly);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"加载程序集失败: {assemblyName}, 错误: {ex.Message}");
                    }
                }
            }

            // 注册所有匹配程序集中的类型
            foreach (var assembly in loadedAssemblies
                .Where(a => _assemblyPatterns.Any(p => a.FullName.Contains(p))))
            {
                RegisterTypesFromAssembly(builder, assembly);
            }
        }

        private void RegisterTypesFromAssembly(ContainerBuilder builder, Assembly assembly)
        {
            var types = assembly.GetTypes()
                .Where(t => t.IsClass &&
                           !t.IsAbstract &&
                            t.IsDefined(typeof(AutoInjectAttribute)));

            foreach (var type in types)
            {
                var attr = type.GetCustomAttribute<AutoInjectAttribute>();
                var registration = builder.RegisterType(type).As(attr.InterfaceType);

                if (attr.SingleInstance)
                {
                    registration.SingleInstance();
                }
            }
        }
    }
}
