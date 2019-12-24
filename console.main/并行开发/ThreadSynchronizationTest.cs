using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace console.main.并行开发
{
    /// <summary>
    /// 线程同步技术学习
    /// </summary>
    class ThreadSynchronizationTest
    {
        static void Main(string[] args)
        {
            #region 争用条件(如果两个或多个线程访问相同的对象,并且对共享状态的访问没有同步,就会出现争用条件)         
            StateObject m = new StateObject();
            Thread t1 = new Thread(ChangeState);
            t1.Start(m);//单线程调用(此时运行程序是没有输出的,因为StateObject类中state初始值是5,if条件不会进入,随后又将state从新初始化为5)           
            Thread t2 = new Thread(ChangeState);
            t2.Start(m);//多线程调用(时会不停的打印"value=5",原因在于:一个线程在判断语句处时，另一个线程可能又将state的值改为了5，而导致输出合法)
            #endregion

            #region 死锁         
            //Thread t1 = new Thread(Deadlock.DeadlockA);
            //Thread t2 = new Thread(Deadlock.DeadlockB);
            //t1.Start("t1");
            //t2.Start("t2");
            #endregion

            #region lock锁
            //StateObject m = new StateObject();
            //Thread t1 = new Thread(LockChangeState);
            //Thread t2 = new Thread(LockChangeState);
            //t1.Start(m);
            //t2.Start(m);
            #endregion
        }

        static void ChangeState(object o)
        {
            StateObject m = o as StateObject;
            while (true)
            {
                m.ChangeState();
            }
        }

        static void LockChangeState(object o)
        {
            StateObject m = o as StateObject;
            while (true)
            {
                lock (m)//这里最好的办法是使用SyncRoot模式创建私有变量来应用与lock锁
                {
                    m.ChangeState();
                }
            }
        }
    }
    class Deadlock
    {
        static StateObject o1 = new StateObject();
        static StateObject o2 = new StateObject();
        public static void DeadlockA(object o)
        {
            lock (o1)
            {
                Console.WriteLine("我是线程{0},我锁定了对象o1", o);
                lock (o2)
                {
                    Console.WriteLine("我是线程{0},我锁定了对象o2", o);
                }
            }
        }

        public static void DeadlockB(object o)
        {
            lock (o2)
            {
                Console.WriteLine("我是线程{0},我锁定了对象o2", o);
                lock (o1)
                {
                    Console.WriteLine("我是线程{0},我锁定了对象o1", o);
                }
            }
        }
    }

    class StateObject
    {
        private int state = 5;

        public void ChangeState()
        {
            state++;
            if (state == 5)
            {
                Console.WriteLine("value=5");
            }
            state = 5;
        }
    }
}
