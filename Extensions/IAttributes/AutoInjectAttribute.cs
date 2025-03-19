using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.IAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoInjectAttribute : Attribute
    {
        public Type InterfaceType { get; }   // 要注册的接口类型
        public bool SingleInstance { get; }  // 是否为单例
        public AutoInjectAttribute(Type interfaceType, bool singleInstance = false)
        {
            InterfaceType = interfaceType;
            SingleInstance = singleInstance;
        }
    }
}
