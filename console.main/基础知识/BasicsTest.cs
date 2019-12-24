using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console.main.基础知识
{
    /// <summary>
    /// 主要包括:内置数据类型/变量初始化/类型推断var/常量和字段字段/可空类型/类型转换/装箱拆箱/常见运算符/值类型和引用类型/枚举等
    /// </summary>
    public class BasicsTest
    {
        //常量：常量总是静态的，无需使用static修饰,必须在声明时初始化。指定了其值后,就不能再改写了
        const string conntionName = "testConntion";

        //实例只读字段
        readonly double taxRate;

        //静态字段字段
        static readonly double taxRate1;

        BasicsTest()
        {
            //只读字段可以在声明时赋值，也可以在构造函数中赋值
            taxRate = 0.8;
        }

        static BasicsTest()
        {
            //静态只读字段在类的静态构造函数中赋值
            taxRate1 = 0.9;
        }

        static void Main(string[] args)
        {
            #region 变量初始化:指定数据类型
            //string name = "wang";
            //string name1, name2 = "wang";
            #endregion

            #region 类型推断变量初始化:无需指定数据类型
            //var name = "wang";
            #endregion

            #region 可空类型
            //int? age = null;
            #endregion

            #region 类型转换

            #region 隐式类型转换：不需要加以声明就会自动执行隐式类型转换,在隐式转换过程,编译器无需对转换进行详细检查就能够安全的执行
            //int a = 10;
            //double b = a;//自动隐式类型转换
            #endregion

            #region 显式类型转换
            //double a = 10;
            //int b = (int)a;//显式将double类型转换为int
            #endregion

            #region 通过方法进行转换

            #region ToString()
            //int a = 10;
            //string s = a.ToString();
            #endregion

            #region int.Parse()
            //string a = "2";
            //string b = "2.6";
            //string c = null;
            //int a1 = int.Parse(a);//正常
            //int a2 = int.Parse(b);//错误:输入字符串格式错误
            //int a3 = int.Parse(c);//值不能为null
            #endregion

            #region int.TryParse()
            string a = "2";
            string b = "2.6";
            string c = null;
            int i;
            bool a1 = int.TryParse(a, out i);//转换成功,i=2
            bool a2 = int.TryParse(b, out i);//转换失败,a2=false
            bool a3 = int.TryParse(c, out i);//转换失败,a3=false
            #endregion

            #endregion

            #region 通过Convert类进行转换:Convert类提供了对多种类型的转换
            //string a = "2";
            //int a1 = Convert.ToInt32(a);
            #endregion

            #region 使用As运算符转换
            //object o = "abc";
            //string s = o as string; //执行第一次类型兼容性检查，并返回结果
            //if (s != null)
            //    Console.WriteLine("转换成功！");
            //else
            //    Console.WriteLine("转换失败！");
            #endregion

            #endregion

            #region is运算符
            //object o = "abc";
            //if (o is string) //执行第一次类型兼容性检查
            //{
            //    string s = (string)o; //执行第二次类型兼容性检查，并转换
            //    Console.WriteLine("转换成功！");
            //}
            //else
            //{
            //    Console.WriteLine("转换失败！");
            //}
            #endregion

            Console.ReadKey();
        }

        /// <summary>
        /// 枚举定义
        /// </summary>
        enum Color
        {
            Red,
            Green,
            Blue
        }
    }
}
