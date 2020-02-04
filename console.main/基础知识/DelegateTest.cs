using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace console.main.基础知识
{
    class DelegateTest
    {
        #region 一般版本
        //step01：使用delegate关键字定义委托
        //public delegate int Sum(int x, int y);

        //static void Main(string[] args)
        //{
        //    //step03：实例化委托将方法作为参数传入
        //    Sum sum = new Sum(new DelegateTest().Add);
        //    int result = sum.Invoke(1, 2);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
        //// step02：声明委托对应的方法
        //public int Add(int x, int y)
        //{
        //    return x + y;
        //}
        #endregion

        #region 匿名方法
        ////step01：首先用delegate定义一个委托 
        //public delegate int Sum(int x, int y);

        //static void Main(string[] args)
        //{
        //    //step02：使用匿名方法的写法把一个方法赋值给委托
        //    Sum sum = delegate (int x, int y) { return x + y; };
        //    int result = sum.Invoke(1, 2);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
        #endregion

        #region Lambda
        ////step01：首先用delegate定义一个委托 
        //public delegate int Sum(int x, int y);

        //static void Main(string[] args)
        //{
        //    //方法一：
        //    Sum sum1 = (int x, int y) => { return x + y; };
        //    int result1 = sum1(1, 2);

        //    //方法二：
        //    Sum sum2 = (x, y) => { return x + y; };
        //    int result2 = sum2(1, 2);

        //    //方法三：
        //    Sum sum3 = (x, y) => x + y;
        //    int result3 = sum3(1, 2);
        //}
        #endregion

        #region 泛型委托Func<T>和Action<T>
        //static void Main(string[] args)
        //{
        //    // 方法一
        //    Func<int, int, int> add1 = (int x, int y) => { return x + y; };
        //    int result1 = add1(1, 2);

        //    // 方法二
        //    Func<int, int, int> add2 = (x, y) => { return x + y; };
        //    int result2 = add2(1, 2);

        //    // 方法三
        //    Func<int, int, int> add3 = (x, y) => x + y;
        //    int result3 = add3(1, 2);

        //    // Action：无参数
        //    Action action1 = () => { Console.WriteLine("啦啦啦啦"); };
        //    action1();

        //    // Action：一个参数
        //    Action<string> action2 = p => { Console.WriteLine("啦啦啦啦,name:{0}", p); };
        //    action2("wang");

        //    // Action：多个参数
        //    Action<string, int> action3 = (name, age) => { Console.WriteLine("啦啦啦啦,name:{0},age:{1}", name, age); };
        //    action3("wang", 25);

        //    Console.ReadKey();
        //}
        #endregion

        #region 表达式树
        //static void Main(string[] args)
        //{
        //    Expression<Func<int, int, int>> exp = (x, y) => x + y;
        //    Func<int, int, int> fun = exp.Compile();
        //    int result = fun(1, 2);
        //}
        #endregion

        #region 多播委托
        //static void Main(string[] args)
        //{
        //    Action action = Print.First;
        //    action += Print.Second;
        //    action();

        //    Action action2 = Print.First;
        //    action2 += Print.Second;
        //    action2 -= Print.First;
        //    action2();

        //    // 使用Delegate的GetInvocationList()方法自己迭代方法列表
        //    Delegate[] delegates = action.GetInvocationList();
        //    foreach (Action item in delegates)
        //    {
        //        try
        //        {
        //            item();
        //        }
        //        catch (Exception error)
        //        {
        //            Console.WriteLine(error.Message);
        //        }
        //    }
        //    Console.ReadKey();
        //}
        //class Print
        //{
        //    public static void First()
        //    {
        //        Console.WriteLine("FirstMethod");
        //    }
        //    public static void Second()
        //    {
        //        Console.WriteLine("SecondMethod");
        //    }
        //}
        #endregion

        #region 委托的陷阱
        //static void Main(string[] args)
        //{
        //    // 源码
        //    //List<Action> list = new List<Action>();
        //    //for (int i = 0; i < 5; i++)
        //    //{
        //    //    Action t = () => Console.WriteLine(i.ToString());
        //    //    list.Add(t);
        //    //}
        //    //foreach (Action t in list)
        //    //{
        //    //    t();
        //    //}

        //    //修改后的源码
        //    //List<Action> list = new List<Action>();
        //    //for (int i = 0; i < 5; i++)
        //    //{
        //    //    int temp = i;
        //    //    Action t = () => Console.WriteLine(temp.ToString());
        //    //    list.Add(t);
        //    //}
        //    //foreach (Action t in list)
        //    //{
        //    //    t();
        //    //}

        //    //// IL反编译后
        //    //List<Action> list = new List<Action>();
        //    //TempClass tempClass = new TempClass();
        //    //for (tempClass.i = 0; tempClass.i < 5; tempClass.i++)
        //    //{
        //    //    Action t = tempClass.TempFunc;
        //    //    list.Add(t);
        //    //}
        //    //foreach (Action t in list)
        //    //{
        //    //    t();
        //    //}
        //    Console.ReadLine();
        //    Console.ReadKey();
        //}
        //public class TempClass
        //{
        //    public int i;
        //    public void TempFunc()
        //    {
        //        Console.WriteLine(i.ToString());
        //    }
        //}
        #endregion


        #region 事件
        #region 一般处理
        //static void Main(string[] args)
        //{
        //    Mum mum = new Mum();            
        //    mum.MealisReady();
        //    Console.ReadKey();
        //}

        //public class Mum
        //{
        //    /// <summary>
        //    /// 饭做好了
        //    /// </summary>
        //    public void MealisReady()
        //    {
        //        Son son = new Son();
        //        Father father = new Father();
        //        son.Eat();
        //        father.Eat();
        //    }
        //}

        ///// <summary>
        ///// 大儿子
        ///// </summary>
        //public class Son
        //{
        //    public void Eat()
        //    {
        //        Console.WriteLine("打完游戏就过来");
        //    }
        //}

        ///// <summary>
        ///// 孩子他爹
        ///// </summary>
        //public class Father
        //{
        //    public void Eat()
        //    {
        //        Console.WriteLine("看完电视就过来");
        //    }
        //}
        #endregion

        #region 使用委托
        static void Main(string[] args)
        {
            Mum mum = new Mum();

            mum.mealisReadyEvent += new Son().Eat;
            mum.mealisReadyEvent += new Father().Eat;
            mum.MealisReady();

            Console.ReadKey();
        }


        public class Mum
        {
            public event Action mealisReadyEvent;

            /// <summary>
            /// 饭做好了
            /// </summary>
            public void MealisReady()
            {
                mealisReadyEvent?.Invoke();
            }
        }

        public class Son
        {
            public void Eat()
            {
                Console.WriteLine("打完游戏就过来");
            }
        }

        public class Father
        {
            public void Eat()
            {
                Console.WriteLine("看完电视就过来");
            }
        }
        #endregion
        #endregion
    }
}
