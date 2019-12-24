using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console.main.基础知识
{
    class ClasseAndObject
    {
        static void Main(string[] args)
        {
            #region 类的实例方法调用
            //Test test = new Test();
            //test.Show();
            #endregion

            #region 类的静态方法调用
            //Test.Show2();
            #endregion

            #region 给方法传递参数,不加ref/out默认都是按值传递
            //int intValue = 5;
            //IntParam(intValue);

            //string stringValue = "wang";
            //StringParam(stringValue);

            //object objectValue = "obj";
            //ObjectParam(objectValue);

            //Console.WriteLine(stringValue);
            //Console.WriteLine(objectValue);
            //Console.WriteLine(arr);
            #endregion

            #region ref参数
            //int value = 0;
            //RefPrint(ref value);
            //Console.WriteLine("value:{0}", value);
            #endregion

            #region out参数
            //int value;//并未对变量value进行初始化
            //OutPrint(out value);
            //Console.WriteLine("value:{0}", value);
            #endregion

            #region ChangeArr1
            //int[] arr = new int[] { 1, 2, 3 };
            //ChangeArr1(arr);
            //Console.WriteLine(string.Join(",", arr));
            #endregion

            #region ChangeArr2
            //int[] arr = new int[] { 1, 2, 3 };
            //ChangeArr2(arr);
            //Console.WriteLine(string.Join(",", arr));
            #endregion

            Console.ReadKey();
        }

        /// <summary>
        /// ref参数传递
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static int RefPrint(ref int value)
        {
            return value += 10;
        }

        /// <summary>
        /// out参数传递
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static int OutPrint(out int value)
        {
            value = 0;
            return value += 10;
        }

        static void ChangeArr1(int[] values)
        {
            values = new int[3] { 4, 5, 6 };
        }

        static void ChangeArr2(int[] values)
        {
            values[0] = 999;
        }

        static void IntParam(int value)
        {
            value = 10;
        }

        static void StringParam(string value)
        {
            value += "hello";
        }

        static void ObjectParam(object value)
        {
            value += "obj哈哈";
        }
    }

    class Test
    {
        /// <summary>
        /// 实例方法
        /// </summary>
        public void Show()
        {
            Console.WriteLine("Test下实例方法");
        }

        /// <summary>
        /// 静态方法属于类本身
        /// </summary>
        public static void Show2()
        {
            Console.WriteLine("Test下静态方法");
        }
    }
}
