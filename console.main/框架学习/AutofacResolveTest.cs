using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console.main.框架学习
{
    class AutofacResolveTest
    {
        static void Main(string[] args)
        {
            //注册容器
            var builder = new ContainerBuilder();
            //向容器中注册类型
            builder.RegisterType<SqlDal>();
            using (var container = builder.Build())
            {
                #region 使用Resolve方法获取容器中注册的类型实例,如果类型未注册会抛异常               
                //var sqlDal = container.Resolve<SqlDal>();
                //sqlDal.Add();
                #endregion

                #region 使用ResolveOptional方法获取容器中注册的类型实例,如果类型未注册会返回null
                //var sqlDal2 = container.ResolveOptional<SqlDal>();
                //sqlDal2.Add();
                #endregion

                #region 使用TryResolve方法获取容器中注册的类型实例,使用out参数，并且返回一个bool类型表示是否成功获取到类型实例。 
                //SqlDal sqlDal3 = null;
                //if (container.TryResolve<SqlDal>(out sqlDal3))
                //    sqlDal3.Add();
                //else
                //    Console.WriteLine("类型未注册");
                #endregion              
            }
            Console.ReadKey();
        }
    }    
}
