using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace console.main.基础知识
{
    /// <summary>
    /// 泛型
    /// </summary>
    class GenericityTest
    {
        static void Main(string[] args)
        {
            #region 非泛型集合Array,添加/读取时需要装箱拆箱,且类型不安全
            //var arr1 = new ArrayList();
            //arr1.Add(10);//Add方法参数值是object类型，这里将int->object
            //arr1.Add("wang");//Add方法参数值是object类型，这里将int->object
            //foreach (int item in arr1)//这里如果用int类型遍历集合,就挂掉了
            //{
            //    Console.WriteLine(item);//读取时要进行拆箱
            //}
            #endregion

            #region 泛型集合List
            /*泛型集合在使用时定义好类型,之后就不存在装箱拆箱;
             * 因为已经定义当前集合只能存入int类型，也就不能存入其他类型
             * 编译时就会报错，错误应及早发现
             */
            var arr2 = new List<int>();
            arr2.Add(10);
            foreach (var item in arr2)
            {
                Console.WriteLine(item);
            }
            #endregion
            Console.ReadKey();
        }
    }
}
