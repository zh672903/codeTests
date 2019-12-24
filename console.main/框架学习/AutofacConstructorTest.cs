using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console.main.框架学习
{
    class AutofacConstructorTest
    {
        static void Main(string[] args)
        {
            //注册容器
            var builder = new ContainerBuilder();

            #region 默认的构造函数,Resolve对象构造方法选择原则(当我们注册的类型拥有多个构造方法，那么在Resolve时，将会以尽可能最多参数构造方法为准,这里的尽可能多是指在Autofac已注册的类型中)
            //builder.RegisterType<ConstructorClass>();
            //builder.RegisterType<Class2>();
            //builder.RegisterType<Class3>();
            //using (var container = builder.Build())
            //{            
            //    var obj = container.Resolve<ConstructorClass>();
            //    Console.WriteLine(obj);                       
            //}
            #endregion

            #region 注册时指定默认构造函数UsingConstructor,不指定默认使用最后一个构造函数
            //builder.RegisterType<ConstructorClass>().UsingConstructor(typeof(Class1), typeof(Class2));
            //builder.RegisterType<Class1>();
            //builder.RegisterType<Class2>();
            //builder.RegisterType<Class3>();
            //using (var container = builder.Build())
            //{               
            //    var obj = container.Resolve<ConstructorClass>();
            //    Console.WriteLine(obj);                             
            //}
            #endregion

            #region 注册时添加参数 WithParameter
            //builder.RegisterType<ConstructorClass>().WithParameter("guid", Guid.NewGuid());
            ////builder.RegisterType<Class1>();//将Class1注册因为在尽可能最多的原则上，出现了两个最多参数的构造方法，Autofac不知道应该选择哪个进行执行
            //builder.RegisterType<Class2>();
            //builder.RegisterType<Class3>();
            //using (var container = builder.Build())
            //{
            //    var obj = container.Resolve<ConstructorClass>();
            //    Console.WriteLine(obj);
            //}
            #endregion

            Console.ReadKey();
        }
    }
    class ConstructorClass
    {
        private Class1 _clas1;
        private Class2 _clas2;
        private Class3 _clas3 = null;

        public ConstructorClass()
        {
            _clas1 = null; _clas2 = new Class2 { Id = -1 };
        }

        public ConstructorClass(Class1 clas1, Class2 clas2)
        {
            _clas1 = clas1; _clas2 = clas2;
        }

        public ConstructorClass(Class2 clas2, Class3 clas3)
        {
            _clas2 = clas2; _clas3 = clas3;
        }

        public ConstructorClass(Class2 clas2, Class3 clas3, Guid guid)
        {
            _clas1 = new Class1 { Id = guid }; _clas2 = clas2; _clas3 = clas3;
        }

        public ConstructorClass(Class1 clas1, Class2 clas2, Class3 clas3)
        {
            _clas1 = clas1; _clas2 = clas2; _clas3 = clas3;
        }

        public override string ToString()
        {
            return string.Format(
                "{{Class1.Id: {0}, Class2.Id: {1}, Class3: {2}}}",
                _clas1 == null ? "null" : _clas1.Id.ToString(),
                _clas2 == null ? "null" : _clas2.Id.ToString(),
                _clas3 == null ? "null" : "not null");
        }
    }

    class Class1
    {
        public Guid Id { get; set; }
    }

    class Class2
    {
        public int Id { get; set; }
    }

    class Class3
    {

    }
}
