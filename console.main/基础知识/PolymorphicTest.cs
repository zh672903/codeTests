using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console.main.基础知识
{
    class PolymorphicTest
    {
        static void Main(string[] args)
        {
            #region 虚方法实现多态virtual
            //实例化基类对象,调用自身Eat()方法
            //Bird b1 = new Bird();
            //b1.Eat();

            ////父类类型对象指向子类类型对象
            //Bird b2 = new Magpie();
            //b2.Eat();

            //Bird b3 = new Eagle();
            //b3.Eat();

            //Bird b4 = new Penguin();
            #endregion

            #region 抽象方法实现多态
            //此时Bird是抽象类无法创建实例
            //Bird b1 = new Bird();
            //b1.Eat();

            //Bird b2 = new Magpie();
            //b2.Eat();

            //Bird b3 = new Eagle();
            //b3.Eat();

            //Bird b4 = new Penguin();
            //b4.Eat();
            #endregion

            #region 接口实现多态
            IFly[] flys = {
                       new Magpie(),
                       new Eagle(),
                       new Plane()
             };
            foreach (IFly fly in flys)
            {
                fly.Fly();
            }
            #endregion

            ////这种创建方式是错误的:因为子类中的属性父类不一定有,里式替换原则里有解释
            //Magpie magpie = new Bird();
            Console.ReadKey();
        }
    }

    ///// <summary>
    ///// 鸟类：父类
    ///// </summary>
    //public class Bird
    //{
    //    /// <summary>
    //    /// 吃：虚方法
    //    /// </summary>
    //    public virtual void Eat()
    //    {
    //        Console.WriteLine("我是一只小小鸟，我喜欢吃虫子~");
    //    }
    //}

    /// <summary>
    /// 飞 接口
    /// </summary>
    public interface IFly
    {
        void Fly();
    }

    /// <summary>
    /// 抽象鸟类：父类
    /// </summary>
    public abstract class Bird
    {
        /// <summary>
        /// 吃：抽象方法
        /// </summary>
        public abstract void Eat();
    }

    /// <summary>
    /// 喜鹊：子类
    /// </summary>
    public class Magpie : Bird, IFly
    {
        /// <summary>
        /// 重写父类中Eat方法
        /// </summary>
        public override void Eat()
        {
            Console.WriteLine("我是一只喜鹊，我喜欢吃虫子~");
        }

        /// <summary>
        /// 实现IFly接口的方法
        /// </summary>
        public void Fly()
        {
            Console.WriteLine("我是一只喜鹊，我可以飞");
        }
    }

    /// <summary>
    /// 老鹰：子类
    /// </summary>
    public class Eagle : Bird, IFly
    {
        /// <summary>
        /// 重写父类中Eat方法
        /// </summary>
        public override void Eat()
        {
            Console.WriteLine("我是一只老鹰，我喜欢吃肉~");
        }

        public void Fly()
        {
            Console.WriteLine("我是一只老鹰，我可以飞");
        }
    }

    /// <summary>
    /// 企鹅：子类
    /// </summary>
    public class Penguin : Bird
    {
        /// <summary>
        /// 重写父类中Eat方法
        /// </summary>
        public override void Eat()
        {
            Console.WriteLine("我是一只小企鹅，我喜欢吃鱼~");
        }
    }
    /// <summary>
    /// 飞机类，实现IFly接口
    /// </summary>
    public class Plane : IFly
    {
        /// <summary>
        /// 实现接口方法
        /// </summary>
        public void Fly()
        {
            Console.WriteLine("我是一架飞机，我也能飞~~");
        }
    }
}
