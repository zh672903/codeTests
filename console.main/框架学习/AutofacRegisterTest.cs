using Autofac;
using console.main.设计思想;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace console.main.框架学习
{
    class AutofacRegisterTest
    {
        static void Main(string[] args)
        {
            //创建容器
            var builder = new ContainerBuilder();

            #region 最简单的类型注册将SqlDal类注册到容器中RegisterType<T>()         
            //builder.RegisterType<SqlDal>();           
            //using (var container = builder.Build())
            //{
            //    //通过Resolve()方法获取注册类型的实例,不推荐这种方式只作为测试
            //    var sqlDal = container.Resolve<SqlDal>();
            //    sqlDal.Add();
            //}
            #endregion

            #region 通过Type对象进行注册  
            //Assembly assembly = Assembly.Load("console.main.Model");
            //var type = assembly.GetType("console.main.Model.AutofacTestModel");           
            //builder.RegisterType(type);
            //using (var container = builder.Build())
            //{
            //    //var model = container.Resolve<AutofacTestModel>();
            //    //Console.WriteLine(model.SayHello());               
            //}
            #endregion

            #region 程序集批量注册
            ////获取当前应用程序加载程序集（C/S应用中使用）
            //var assembly = Assembly.GetExecutingAssembly();
            //////注册所有程序集类定义的所有非静态类型
            //builder.RegisterAssemblyTypes(assembly);
            //using (var container = builder.Build())
            //{
            //    var sqldal = container.Resolve<SqlDal>();
            //    sqldal.Add();
            //    var mysqlDal = container.Resolve<MySqlDal>();
            //    mysqlDal.Add();
            //}
            #endregion

            #region 程序集过滤后批量注册    
            //var assembly = Assembly.GetExecutingAssembly();
            //这里限制只注册某个命名空间的非静态类
            //builder.RegisterAssemblyTypes(assembly).
            //    Where(type => type.Namespace.Equals("console.main.框架学习"));
            //using (var container = builder.Build())
            //{
            //    //上面如果使用Where(type => type.Namespace.Contains("console.main"));的注册方式,下方的代码是可以运行的,否则会报未注册异常          
            //    //var test = container.Resolve<console.main.设计思想.SqlDal>();
            //    //test.Add();

            //    var sqldal = container.Resolve<SqlDal>();
            //    sqldal.Add();
            //    var mysqlDal = container.Resolve<MySqlDal>();
            //    mysqlDal.Add();
            //}
            #endregion

            #region 排除指定类型的注册:Except      
            //var assembly = Assembly.GetExecutingAssembly();
            //builder.RegisterAssemblyTypes(assembly).
            //    Where(type => type.Namespace.Contains("console.main")).Except<console.main.设计思想.SqlDal>();
            //using (var container = builder.Build())
            //{
            //    //Where(type => type.Namespace.Contains("console.main"))是可以运行的,但是因为使用Except排除了console.main.设计思想.SqlDal类型,所以同样会报未注册异常
            //    var test = container.Resolve<console.main.设计思想.SqlDal>();
            //    test.Add();

            //    var sqldal = container.Resolve<SqlDal>();
            //    sqldal.Add();
            //    var mysqlDal = container.Resolve<MySqlDal>();
            //    mysqlDal.Add();
            //}
            #endregion

            #region 被注册的类型需要在指定命名空间中      
            //var assembly = Assembly.GetExecutingAssembly();
            //builder.RegisterAssemblyTypes(assembly).InNamespaceOf<AutofacTest>();
            //using (var container = builder.Build())
            //{
            //    //限制只注册AutofacTest类所在命名空间下的类,故此处抛出未注册异常
            //    //var test = container.Resolve<console.main.设计思想.SqlDal>();
            //    //test.Add();

            //    var sqldal = container.Resolve<SqlDal>();
            //    sqldal.Add();
            //    var mysqlDal = container.Resolve<MySqlDal>();
            //    mysqlDal.Add();
            //}
            #endregion

            #region lambda表达式注册
            //builder.Register(type =>
            //{
            //    //通过lambda表达式注册时添加属性值
            //    var sqlDal = new SqlDal();                
            //    sqlDal.Str = "Test";
            //    return sqlDal;
            //});
            //using (var container = builder.Build())
            //{              
            //    var sqlDal = container.Resolve<SqlDal>();
            //    sqlDal.Add();
            //}
            #endregion

            #region 单例注册           
            //builder.RegisterInstance(new SqlDal());
            //using (var container = builder.Build())
            //{
            //var sqlDal = container.Resolve<SqlDal>();
            //sqlDal.Add();
            //}
            #endregion

            #region 泛型注册
            builder.RegisterGeneric(typeof(List<>)).As(typeof(IList<>)).InstancePerLifetimeScope();
            using (IContainer container = builder.Build())
            {
                var ListString = container.Resolve<IList<string>>();
            }
            #endregion

            #region Module注册
            //builder.RegisterModule<SqlModule>();            
            //builder.RegisterModule<MySqlModule>();
            //using (var container = builder.Build())
            //{
            //    var sqldal = container.Resolve<SqlDal>();
            //    sqldal.Add();
            //    var mysqldal = container.Resolve<MySqlDal>();
            //    mysqldal.Add();
            //}
            #endregion

            #region Module程序集注册
            //var assembly = Assembly.GetExecutingAssembly();
            ////注册assembly程序集中所有实现了IModule接口的类型（多层继承也算），这样只需要取出所有程序集，然后通过RegisterAssemblyModules进行一次性注册，就可以自动注册所有Module了
            //builder.RegisterAssemblyModules(assembly);            
            //builder.RegisterAssemblyModules<SqlModule>(assembly);//指定泛型类型只注册assembly程序集中继承自SqlModule的Module
            //using (var container = builder.Build())
            //{
            //    var sqldal = container.Resolve<SqlDal>();
            //    sqldal.Add();
            //    var mysqldal = container.Resolve<MySqlDal>();
            //    mysqldal.Add();
            //}
            #endregion

            Console.ReadKey();
        }
    }

    class SqlModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlDal>();
        }
    }
    class MySqlModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MySqlDal>();
        }
    }
    class SqlDal
    {
        public string Str { get; set; }

        public void Add()
        {
            Console.WriteLine("向SqlServer数据库写入一条数据,Str={0}", Str);
        }
    }

    class MySqlDal
    {
        public void Add()
        {
            Console.WriteLine("向MySql数据库写入一条数据");
        }
    }
}
