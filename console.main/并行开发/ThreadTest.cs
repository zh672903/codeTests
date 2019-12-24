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
    /// 线程Thread相关学习
    /// </summary>
    class ThreadTest
    {
        static void Main(string[] args)
        {
            #region 线程Thread的创建方式
            //创建方式一
            //Thread t = new Thread(new ThreadStart(ThreadMethod));
            //创建方式二
            //Thread t = new Thread(ThreadMethod);
            //匿名函数创建
            //Thread t = new Thread(delegate () { Console.WriteLine("匿名函数创建线程"); });
            //lambda表达式创建
            //Thread t = new Thread(() => Console.WriteLine("匿名函数创建"));
            //t.Start();
            #endregion

            #region 线程的调用顺序(线程是由操作系统调度的,每次哪个线程先被执行可以不同)
            //Thread t = new Thread(() => Console.WriteLine("A"));
            //Thread t1 = new Thread(() => Console.WriteLine("B"));
            //Thread t2 = new Thread(() => Console.WriteLine("C"));
            //Thread t3 = new Thread(() => Console.WriteLine("D"));
            //t.Start();
            //t1.Start();
            //t2.Start();
            //t3.Start();
            #endregion

            #region 线程传递数据

            #region 不带参数
            //Thread t = new Thread(() => Console.WriteLine("不带参数的线程执行"));
            //t.Start();
            #endregion

            #region 带一个参数(使用带ParameterrizeThreadStart委托参数的Thread构造函数)
            //Thread t = new Thread(ThreadMethodOnePara);
            //t.Start("t");            
            #endregion

            #region 多个参数(创建自定义类.把线程方法定义为实例方法,之后初始化实例数据,启动线程)
            //var data = new Data("Wang", 24);
            //Thread t = new Thread(data.Write);
            //t.Start();
            #endregion

            #endregion

            #region 前台线程阻止进程的关闭(应用程序必须运行完所有的前台线程才可以退出)
            //Thread thread = new Thread(() =>
            //{
            //    Thread.Sleep(5000);
            //    Console.WriteLine("前台线程执行");
            //});
            //thread.Start();
            //Console.WriteLine("主线程执行完毕");
            #endregion

            #region 后台线程(应用程序可以不考虑其是否已经运行完毕而直接退出，所有的后台线程在应用程序退出时都会自动结束)
            //Thread thread = new Thread(() =>
            //{
            //    Thread.Sleep(5000);
            //    Console.WriteLine("前台线程执行");
            //})
            //{ IsBackground = true };

            //thread.Start();
            //Console.WriteLine("主线程执行完毕");
            #endregion

            #region 线程优先级设置(设置优先级并不是会指定线程固定执行的顺序,设置线程优先级只是提高了线程被调用的概率，并不是定义CPU调用线程的顺序，具体还是要由操作系统内部来调度)
            //Thread normal = new Thread(() =>
            //{
            //    Console.WriteLine("优先级为正常线程");
            //});
            //normal.Start();

            //Thread aboseNormal = new Thread(() =>
            //{
            //    Console.WriteLine("优先级为高于正常线程");
            //})
            //{ Priority = ThreadPriority.AboveNormal };
            //aboseNormal.Start();

            //Thread belowNormal = new Thread(() =>
            //{
            //    Console.WriteLine("优先级为低于正常线程");
            //})
            //{ Priority = ThreadPriority.BelowNormal };
            //belowNormal.Start();

            //Thread highest = new Thread(() =>
            //{
            //    Console.WriteLine("优先级最高线程");
            //})
            //{ Priority = ThreadPriority.Highest };
            //highest.Start();

            //Thread lowest = new Thread(() =>
            //{
            //    Console.WriteLine("优先级最低线程");
            //})
            //{ Priority = ThreadPriority.Lowest };
            //lowest.Start();

            //Console.WriteLine("主线程执行完毕");
            #endregion

            #region 暂停线程(Thread.Sleep())
            //Thread t = new Thread(ThreadMethodSleep);
            //t.Start();
            //ThreadMethod();
            #endregion

            #region 线程等待(Thread.Join())
            //Thread t = new Thread(ThreadMethodSleep);
            //t.Start();
            //t.Join();
            //ThreadMethod();
            #endregion

            #region 终止线程(Thread.Abort())
            //Thread t = new Thread(ThreadMethodSleep);
            //t.Start();
            ////5秒后调用Abort()方法终止线程
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            //t.Abort();
            #endregion

            #region 线程的状态监测(通过Thread.ThreadState属性读取当前线程状态)
            //Thread t = new Thread(ThreadMethodSleep);
            //Console.WriteLine("创建线程,线程状态:{0}", t.ThreadState);
            //t.Start();
            //Console.WriteLine("线程调用Start()方法,线程状态:{0}", t.ThreadState);
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            //Console.WriteLine("线程休眠5s,线程状态:{0}", t.ThreadState);
            //t.Join();
            //Console.WriteLine("等待线程结束,线程状态:{0}", t.ThreadState);
            #endregion

            #region  线程异常处理(Exception)
            //Thread t = new Thread(ThreadMethodExceptionB);
            //t.Start();
            //t.Join();
            //try
            //{
            //    Thread t1 = new Thread(ThreadMethodExceptionA);
            //    t1.Start();
            //}
            //catch (Exception e)//这里可以捕获到ThreadMethodExceptionB()的异常.这里可以捕获到ThreadMethodExceptionA捕获不到
            //{
            //    Console.WriteLine("Error:{0}", e.Message);
            //}
            #endregion

            #region 线程池ThreadPool
            //int workThread;
            //int ioThread;
            //ThreadPool.GetMaxThreads(out workThread, out ioThread);
            //Console.WriteLine("工作线程数:{0},io线程数{1}", workThread, ioThread);

            //for (int i = 0; i < 5; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(ThreadPoolAdd);
            //    workThread = ioThread = 0;
            //}
            #endregion

            Console.ReadKey();
        }

        public static void ThreadPoolAdd(object e)
        {
            Console.WriteLine("线程池调用,当前线程ID:{0},是否为后台线程:{1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground);
        }

        static void ThreadMethodExceptionA()
        {
            throw new Exception("AError");
        }

        static void ThreadMethodExceptionB()
        {
            try
            {
                throw new Exception("BError");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:{0}", ex.Message);
            }
        }

        static void ThreadMethodSleep()
        {
            for (int i = 0; i < 10; i++)
            {
                //暂停2s
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine("b");
            }
        }

        static void ThreadMethod()
        {
            Console.WriteLine("无参数的线程调用");
        }

        static void ThreadMethodOnePara(object o)
        {
            Console.WriteLine("带一个参数的线程调用,value={0}", o);
        }
    }

    class Data
    {
        public string name;
        public int age;
        public Data(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public void Write()
        {
            Console.WriteLine("name:{0},age:{1}", this.name, this.age);
        }
    }
}
