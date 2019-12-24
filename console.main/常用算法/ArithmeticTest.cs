using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console.main.常用算法
{
    public class ArithmeticTest
    {
        static void Main(string[] args)
        {
            int[] arr = BubbleSort(new int[] { 78, 3, 2 });
            Console.ReadKey();
        }

        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int[] BubbleSort(int[] arr)
        {
            Console.WriteLine("原始序列：" + WriteFormat(arr));
            int Length = arr.Length;
            //判断进行多少次比较
            for (int i = 0; i < Length; i++)
            {
                //判断进行多少对比较
                for (int j = 0; j < Length - 1 - i; j++)
                {
                    //这里主要实现从小到大Or从大到小排序
                    if (arr[j + 1] < arr[j])
                    {
                        int temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }                    
                }
                Console.WriteLine("第" + (i + 1) + "次比较：" + WriteFormat(arr));
            }
            return arr;
        }

        private static string WriteFormat(int[] arr)
        {
            string temp = string.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != arr.Length - 1)
                    temp += arr[i] + ",";
                else
                    temp += arr[i];
            }
            return temp;
        }
    }

}
