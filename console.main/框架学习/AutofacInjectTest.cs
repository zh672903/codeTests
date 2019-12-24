using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console.main.框架学习
{
    class AutofacInjectTest
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            #region Autofac默认构造函数注入
            //builder.RegisterType<A>();
            //builder.RegisterType<B>();
            //using (var container = builder.Build())
            //{
            //    //A的构造方法需要参数b，但是这里不需要做更多地操作,如果注册类型B,这里a._b=null
            //    var a = container.Resolve<A>();
            //}
            #endregion

            #region Autofac自动属性注入(PropertiesAutowired)
            // 通过PropertiesAutowired制定类型A在获取时会自动注入A的属性,前提是B必须也要被注册
            //builder.RegisterType<A>().PropertiesAutowired();
            //builder.RegisterType<B>();
            //using (var container = builder.Build())
            //{
            //    //A的构造方法需要参数b，但是这里不需要做更多地操作
            //    var a = container.Resolve<A>();
            //}
            #endregion

            #region 预先知道属性的名字和值，可以使用:WithProperty进行注入
            //builder.RegisterType<A>().WithProperty("_b", new B());
            //using (var container = builder.Build())
            //{
            //    var a = container.Resolve<A>();
            //}
            #endregion

            #region lambda表达式注入
            //builder.Register(c => new A { _b = c.Resolve<B>() });
            //builder.RegisterType<B>();
            //using (var container = builder.Build())
            //{
            //    var a = container.Resolve<A>();
            //}
            #endregion

            #region 方法注入,使用Activator.使用这种方法，类里必须要有这个方法
            //builder.Register(c =>
            //{
            //    var _a = new A();
            //    _a.SetInject(new B());
            //    return _a;
            //});
            //using (var container = builder.Build())
            //{
            //    var a = container.Resolve<A>();
            //}
            #endregion

            #region 方法注入,使用Activating Handler
            //builder.Register<A>(c => new A()).OnActivating(e => e.Instance.SetInject(new B()));
            //using (var container = builder.Build())
            //{
            //    var a = container.Resolve<A>();
            //}
            #endregion

            Console.ReadKey();
        }
    }
    class A
    {
        public B _b;
        public A()
        {

        }
        public A(B b)
        {
            this._b = b;
        }

        public void SetInject(B b)
        {
            _b = b;
        }
    }

    class B { }
}
