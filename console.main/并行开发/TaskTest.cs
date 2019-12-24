using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace console.main.并行开发
{
    /// <summary>
    /// 并行开发Task学习
    /// </summary>
    class TaskTest
    {
        static void Main(string[] args)
        {
            #region Task创建方式            
            //var t = new TaskFactory().StartNew(() => Console.WriteLine("TaskFactory().StartNew方式创建Task"));
            //var t = Task.Factory.StartNew(() => Console.WriteLine("Task静态属性Factory创建Task"));
            //var t = new Task(() => Console.WriteLine("使用Task的构造函数创建Task,但必须调用Start方法启动"));
            //t.Start();
            //var t = Task.Run(() => Console.WriteLine("Task.Run方式创建Task"));
            #endregion

            #region Task同步(RunSynchronously)
            //var t = new Task(() => TaskMethod("t"));
            //t.RunSynchronously();
            //Console.WriteLine("主线程调用结束");
            #endregion

            #region Task使用单独线程(TaskCreationOptions)
            //var t = new Task(LongRunningTaskMethod, TaskCreationOptions.LongRunning);
            //t.Start();
            #endregion

            #region 获取Task返回值(T<TResult>)
            //Task<string> t = new Task<string>(() => TResultTaskMethod("t"));
            //t.Start();
            //Console.WriteLine(t.Result);
            #endregion

            #region 连续TasK(使用TaskContinuationOptions枚举的值可以指定连续任务只有在起始任务成功或失败结束时启动)
            //Task<string> t1 = new Task<string>(() => TResultTaskMethod("t1"));
            //Console.WriteLine("创建Task,状态为:{0}", t1.Status);
            //t1.Start();
            //Console.WriteLine("启动Task,状态为:{0}", t1.Status);
            //Console.WriteLine(t1.Result);
            //Console.WriteLine("创建Task,状态为:{0}", t1.Status);
            //Task t2 = t1.ContinueWith(ContinueWithTaskMethod);
            #endregion

            #region Task取消
            //CancellationTokenSource cts = new CancellationTokenSource();
            //cts.CancelAfter(8000);
            //Task t1 = Task.Run(() =>
            //{
            //    for (int i = 0; i < 30; i++)
            //    {
            //        if (cts.Token.IsCancellationRequested)
            //        {
            //            cts.Token.ThrowIfCancellationRequested();
            //        }
            //        else
            //        {
            //            Thread.Sleep(500);
            //            Console.WriteLine("任务t1,共执行30次,当前第{0}次", i);
            //        }
            //    }
            //}, cts.Token);
            //try
            //{
            //    t1.Wait();
            //}
            //catch (AggregateException e)
            //{
            //    foreach (var item in e.InnerExceptions)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            #endregion

            #region Task数组
            //CancellationTokenSource cts = new CancellationTokenSource();
            //cts.CancelAfter(8000);
            //Task[] tasks = new Task[2];
            //tasks[0] = Task.Run(() =>
            //{
            //    for (int i = 0; i < 30; i++)
            //    {
            //        if (cts.Token.IsCancellationRequested)
            //        {
            //            cts.Token.ThrowIfCancellationRequested();
            //        }
            //        else
            //        {
            //            Thread.Sleep(500);
            //            Console.WriteLine("任务t1,共执行30次,当前第{0}次", i);
            //        }
            //    }
            //}, cts.Token);
            //tasks[1] = Task.Run(() =>
            //{
            //    for (int i = 0; i < 50; i++)
            //    {
            //        if (cts.Token.IsCancellationRequested)
            //        {
            //            cts.Token.ThrowIfCancellationRequested();
            //        }
            //        else
            //        {
            //            Thread.Sleep(500);
            //            Console.WriteLine("任务t2,共执行50次,当前第{0}次", i);
            //        }
            //    }
            //}, cts.Token);
            //try
            //{
            //    Task.WaitAll(tasks);
            //}
            //catch (AggregateException e)
            //{
            //    foreach (var item in e.InnerExceptions)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            #endregion

            #region CancellationTokenSource.Token.Register()
            //CancellationTokenSource cts = new CancellationTokenSource();
            //var token = cts.Token;
            //cts.CancelAfter(8000);
            //token.Register(RegisterCallback);
            //Task t1 = Task.Run(() =>
            //{
            //    for (int i = 0; i < 30; i++)
            //    {
            //        if (token.IsCancellationRequested)
            //        {
            //            token.ThrowIfCancellationRequested();
            //        }
            //        else
            //        {
            //            Thread.Sleep(500);
            //            Console.WriteLine("任务t1,共执行30次,当前第{0}次", i);
            //        }
            //    }
            //}, token);
            //try
            //{
            //    t1.Wait();
            //}
            //catch (AggregateException e)
            //{
            //    foreach (var item in e.InnerExceptions)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            #endregion

            Console.ReadKey();
        }

        static void RegisterCallback()
        {
            Console.WriteLine("Register登记的任务取消回调函数");
        }

        public static string TResultTaskMethod(string taskName)
        {
            var result = string.Format("Task {0} 运行在线程id为{1}的线程上。是否是线程池中线程？:{2}", taskName, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
            return result;
        }

        public static void ContinueWithTaskMethod(Task t)
        {
            Console.WriteLine("运行在线程id为{0}的线程上。是否是线程池中线程？:{1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
        }

        public static void LongRunningTaskMethod()
        {
            Console.WriteLine("线程id为{0}。是否是线程池中线程？:{1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
        }

        public static void TaskMethod(string taskName)
        {
            Console.WriteLine("Task {0} 运行在线程id为{1}的线程上。是否是线程池中线程？:{2}", taskName, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
        }
    }
}
