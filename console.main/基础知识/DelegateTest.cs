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
    }
}
