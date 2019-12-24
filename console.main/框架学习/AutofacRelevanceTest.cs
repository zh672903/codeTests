using Autofac;
using Autofac.Features.Indexed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console.main.框架学习
{
    class AutofacRelevanceTest
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            #region 普通关联 As
            //IPerson类型的服务和Worker的组件连接起来，这个服务可以创建Worker类的实例
            //builder.RegisterType<Worker>().As<IPerson>();
            //using (var container = builder.Build())
            //{
            //    var obj = container.Resolve<IPerson>();
            //    obj.Say();              
            //}
            #endregion

            #region 多关联,链式As
            //builder.RegisterType<Worker>()
            //    .As<IPerson>()
            //    .As<IDuty>();
            //using (var container = builder.Build())
            //{
            //    var obj1 = container.Resolve<IPerson>();
            //    var obj2 = container.Resolve<IDuty>();
            //    obj1.Say();
            //    obj2.Write();
            //}
            #endregion

            #region 自关联,两句代码效果相同
            //builder.RegisterType<Worker>().As<IPerson>();//这么写获取实例必须使用As类型进行Resolve 
            //builder.RegisterType<Worker>().As<IPerson>().As<Worker>();//这么写可以使用原类型进行Resolve 
            //using (var container = builder.Build())
            //{
            //    var obj1 = container.Resolve<Worker>();//builder.RegisterType<Worker>().As<IPerson>().As<Worker>();Orbuilder.RegisterType<Worker>().As<IPerson>().AsSelf();都可以
            //    var obj2 = container.Resolve<IPerson>();//必须builder.RegisterType<Worker>().As<IPerson>();          
            //    obj1.Say();
            //    obj2.Say();
            //}
            #endregion

            #region 批量关联,AsImplementedInterfaces
            //builder.RegisterType<Worker>().AsImplementedInterfaces();
            //using (var container = builder.Build())
            //{
            //    var obj1 = container.Resolve<IPerson>();
            //    var obj2 = container.Resolve<IDuty>();
            //    obj1.Say();
            //    obj2.Write();
            //}
            #endregion

            #region 一个接口关联多个类型,后覆盖前
            //builder.RegisterType<Worker>().As<IPerson>();
            //builder.RegisterType<Student>().As<IPerson>();
            //using (var container = builder.Build())
            //{
            //    var obj = container.Resolve<IPerson>();
            //    obj.Say();
            //}
            #endregion

            #region Named,区分服务
            //builder.RegisterType<Worker>().Named<IPerson>("worker");
            //builder.RegisterType<Student>().Named<IPerson>("student");
            //using (var container = builder.Build())
            //{
            //    var obj1 = container.ResolveNamed<IPerson>("worker");
            //    obj1.Say();
            //    var obj2 = container.ResolveNamed<IPerson>("student");
            //    obj2.Say();
            //}
            #endregion

            #region Name的方式很方便，但是值支持字符串，但有时候我们可能需要通过其他类型作键
            //builder.RegisterType<Worker>().Keyed<IPerson>(State.Worker);
            //builder.RegisterType<Student>().Keyed<IPerson>(State.Student);
            //using (var container = builder.Build())
            //{
            //    var obj1 = container.ResolveKeyed<IPerson>(State.Worker);
            //    obj1.Say();
            //    var obj2 = container.ResolveKeyed<IPerson>(State.Student);
            //    obj2.Say();
            //}
            #endregion

            #region IIndex索引
            //builder.RegisterType<Student>().Keyed<IPerson>(State.Student);
            //using (IContainer container = builder.Build())
            //{
            //    IIndex<State, IPerson> IIndex = container.Resolve<IIndex<State, IPerson>>();
            //    IPerson p = IIndex[State.Student];
            //    p.Say();
            //}
            #endregion


            #region 声明周期事件
            builder.RegisterType<Worker>().As<IPerson>()
                   .OnRegistered(e => Console.WriteLine("调用ContainerBuilder的Build方法时触发OnRegistered事件!"))
                   .OnPreparing(e => Console.WriteLine("在调用Resolve时触发，具体触发时机，是根据Resolve的类型获取到类型相关配置时触发的，而这时，类型对象还没有实例化!"))
                   .OnActivating(e => Console.WriteLine("在创建之前调用!"))
                   .OnActivated(e => Console.WriteLine("创建之后调用!"))
                   .OnRelease(e => Console.WriteLine("在释放占用的资源之前调用!"));
            using (var container = builder.Build())
            {
                var obj1 = container.Resolve<IPerson>();
                obj1.Say();
            }
            #endregion
            Console.ReadKey();
        }
    }
    public interface IPerson
    {
        void Say();
    }
    public interface IDuty
    {
        void Write();
    }

    public enum State { Worker, Student }

    public class Worker : IPerson, IDuty
    {
        public void Say()
        {
            Console.WriteLine("工人！");
        }

        public void Write()
        {
            Console.WriteLine("我的工作内容是搬砖！");
        }
    }

    public class Student : IPerson
    {
        public void Say()
        {
            Console.WriteLine("学生！");
        }
    }

    public class AutoFacManager
    {
        IPerson person;

        public AutoFacManager(IPerson MyPerson)
        {
            person = MyPerson;
        }

        public void Say()
        {
            person.Say();
        }
    }
}
