using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace console.main.并行开发
{
    /// <summary>
    /// 并行开发Parallel学习
    /// </summary>
    class ParallelTest
    {
        #region Parallel.Invoke使用,串行代码并行化
        //static void Main(string[] args)
        //{
        //    var watch = Stopwatch.StartNew();
        //    watch.Start();
        //    Run1();
        //    Run2();
        //    Run3();
        //    watch.Stop();
        //    Console.WriteLine("串行开发,总耗时{0}", watch.ElapsedMilliseconds);
        //    watch.Restart();
        //    Parallel.Invoke(Run1, Run2, Run3);
        //    watch.Stop();
        //    Console.WriteLine("并行开发,总耗时{0}", watch.ElapsedMilliseconds);
        //    Console.ReadKey();
        //}
        //static void Run1()
        //{
        //    Console.WriteLine("Run1,我需要1s");
        //    Thread.Sleep(1000);
        //}
        //static void Run2()
        //{
        //    Console.WriteLine("Run2,我需要3s");
        //    Thread.Sleep(3000);
        //}
        //static void Run3()
        //{
        //    Console.WriteLine("Run3,我需要4s");
        //    Thread.Sleep(4000);
        //}
        #endregion

        #region Parallel.Invoke执行顺序(无序)
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("主线程启动,线程ID:{0}", Thread.CurrentThread.ManagedThreadId);
        //    Parallel.Invoke(() => Run1("task1"), () => Run2("task2"), () => Run3("task3"));
        //    Console.WriteLine("主线程结束,线程ID:{0}", Thread.CurrentThread.ManagedThreadId);
        //    Console.ReadKey();
        //}
        //static void Run1(string taskName)
        //{
        //    Console.WriteLine("任务名：{0}线程ID:{1}", taskName, Thread.CurrentThread.ManagedThreadId);
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Console.WriteLine("a");
        //    }
        //}
        //static void Run2(string taskName)
        //{
        //    Console.WriteLine("任务名：{0}线程ID:{1}", taskName, Thread.CurrentThread.ManagedThreadId);
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Console.WriteLine("b");
        //    }
        //}
        //static void Run3(string taskName)
        //{
        //    Console.WriteLine("任务名：{0}线程ID:{1}", taskName, Thread.CurrentThread.ManagedThreadId);
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Console.WriteLine("c");
        //    }
        //}
        #endregion

        #region Parallel.For使用
        //static void Main(string[] args)
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        //线程安全的集合
        //        ConcurrentBag<int> bag = new ConcurrentBag<int>();
        //        var watch = Stopwatch.StartNew();
        //        watch.Start();
        //        for (int j = 0; j < 20000000; j++)
        //        {
        //            bag.Add(i);
        //        }
        //        watch.Stop();
        //        Console.WriteLine("串行添加,总数20000000,耗时{0}", watch.ElapsedMilliseconds);
        //        GC.Collect();
        //        watch.Restart();
        //        Parallel.For(0, 20000000, j =>
        //        {
        //            bag.Add(j);
        //        });
        //        watch.Stop();
        //        Console.WriteLine("并行添加,总数20000000,耗时{0}", watch.ElapsedMilliseconds);
        //        Console.WriteLine("***********************************");
        //        GC.Collect();
        //    }
        //    Console.ReadKey();
        //}
        #endregion

        #region Parallel.ForEach使用
        //static void Main(string[] args)
        //{
        //    ConcurrentBag<int> bag = new ConcurrentBag<int>();
        //    Parallel.For(0, 10, j =>
        //    {
        //        bag.Add(j);
        //    });
        //    Console.WriteLine("集合总数:{0}", bag.Count);
        //    Parallel.ForEach(bag, item =>
        //    {
        //        Console.WriteLine(item);
        //    });
        //    Console.ReadKey();
        //}
        #endregion        

        #region 中断
        //static void Main(string[] args)
        //{
        //    ConcurrentBag<int> bag = new ConcurrentBag<int>();

        //    #region Parallel.For中断,使用ParallelLoopState(Stop和Break)
        //    //for (int j = 0; j < 5; j++)
        //    //{
        //    //    bag = new ConcurrentBag<int>();
        //    //    Parallel.For(0, 2000, (i, state) =>
        //    //    {
        //    //        if (bag.Count == 1000)
        //    //        {
        //    //            state.Stop();
        //    //            return;//return是必须的,否则依旧会继续执行
        //    //        }
        //    //        else
        //    //        {
        //    //            bag.Add(i);
        //    //        }
        //    //    });
        //    //    Console.WriteLine("一共添加2000个元素,集合元素实际个数为:{0}", bag.Count);
        //    //    Console.WriteLine("*************************************************");
        //    //}
        //    #endregion

        //    Console.ReadKey();
        //}
        #endregion

        #region Parallel重载ParallelOptions的使用
        //static CancellationTokenSource _cts = new CancellationTokenSource();
        //static CancellationToken token = _cts.Token;
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("主线程启动,线程ID:{0}", Thread.CurrentThread.ManagedThreadId);
        //    //创建ParallelOptions
        //    var p = new ParallelOptions
        //    {
        //        // 控制线程取消
        //        CancellationToken = token,
        //        // 设置最大的线程数2
        //        MaxDegreeOfParallelism = 3
        //    };
        //    _cts.CancelAfter(5);
        //    try
        //    {
        //        Parallel.Invoke(p, () => Run1("task1"), () => Run2("task2"));
        //    }
        //    catch (AggregateException ex)
        //    {
        //        foreach (var item in ex.InnerExceptions)
        //        {
        //            Console.WriteLine(item);
        //        }
        //    }
        //    Console.WriteLine("主线程结束,线程ID:{0}", Thread.CurrentThread.ManagedThreadId);
        //    Console.ReadKey();
        //}
        //static void Run1(string taskName)
        //{
        //    Console.WriteLine("任务名：{0}线程ID ： {1}", taskName, Thread.CurrentThread.ManagedThreadId);
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine("a");
        //    }
        //}
        //static void Run2(string taskName)
        //{
        //    //是否请求取消标记
        //    if (token.IsCancellationRequested)
        //    {
        //        //token.ThrowIfCancellationRequested();
        //        Console.WriteLine("任务被取消");
        //        return;
        //    }
        //    else
        //    {
        //        Console.WriteLine("任务名：{0}线程ID ： {1}", taskName, Thread.CurrentThread.ManagedThreadId);
        //        for (int i = 0; i < 10; i++)
        //        {
        //            Thread.Sleep(1);
        //            Console.WriteLine("b");
        //        }
        //    }
        //}
        #endregion

        #region 并行开发异常处理(Exception/AggregateException)
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("主线程启动,线程ID:{0}", Thread.CurrentThread.ManagedThreadId);
        //    try
        //    {
        //        Parallel.Invoke(() => Run1("task1"), () => Run2("task2"), () => Run3("task3"));
        //    }
        //    catch (AggregateException ex)//注意这里Exception是可以捕获到两个异常的,断点可见,但是遍历找不到InnerExceptions属性?
        //    {
        //        //AggregateException捕获并行产生的一组异常集合
        //        foreach (var item in ex.InnerExceptions)
        //        {
        //            Console.WriteLine(item);
        //        };
        //    }
        //    Console.WriteLine("主线程结束,线程ID:{0}", Thread.CurrentThread.ManagedThreadId);
        //    Console.ReadKey();
        //}
        //static void Run1(string taskName)
        //{
        //    Console.WriteLine("任务名：{0}线程ID:{1}", taskName, Thread.CurrentThread.ManagedThreadId);
        //    throw new Exception("Run1出现异常");
        //}
        //static void Run2(string taskName)
        //{
        //    Console.WriteLine("任务名：{0}线程ID:{1}", taskName, Thread.CurrentThread.ManagedThreadId);
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Console.WriteLine("b");
        //    }
        //}
        //static void Run3(string taskName)
        //{
        //    Console.WriteLine("任务名：{0}线程ID:{1}", taskName, Thread.CurrentThread.ManagedThreadId);
        //    throw new Exception("Run3出现异常");
        //}
        #endregion
    }
}
