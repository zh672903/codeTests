using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console.main.基础知识
{
    class ArraysAndCollectionsTest
    {
        static void Main(string[] args)
        {
            #region 数组:针对特定类型固定长度
            ////数组可以先声明后赋值，也可以声明同时赋值,下面的方式是等价的,数组中必须存储同一类型数据，这在数组被定义时就已经确定
            ////第一种
            //int[] intArr = new int[5];
            //intArr[0] = 1;
            //intArr[1] = 2;
            //intArr[2] = 3;
            //intArr[3] = 4;
            //intArr[4] = 5;
            ////第二种
            ////int[] intArr = new int[5] { 1, 2, 3, 4, 5 };
            ////第三种
            ////int[] intArr = { 1, 2, 3, 4, 5 };
            ////注意这里是维度不是索引
            //Console.WriteLine("GetLength(int维度):返回指定维度中的元素数,值为：{0}", intArr.GetLength(0));
            //Console.WriteLine("GetLowerBound(int维度):返回指定维度的最低索引,值为：{0}", intArr.GetLowerBound(0));
            //Console.WriteLine("GetUpperBound(int维度):返回指定维度的最高索引,值为：{0}", intArr.GetUpperBound(0));
            //Console.WriteLine("GetValue(int index):	返回指定索引处的值,值为：{0}", intArr.GetValue(2));
            //Console.WriteLine("属性:Length:返回数组中元素的总数,值为：{0}", intArr.Length);

            ////使用索引来访问数组元素
            //Console.WriteLine("使用索引访问数组元素,索引为2的值为：{0}", intArr[2]);
            ////试图访问数组中不存在的索引元素，会发生数组越界
            //Console.WriteLine("使用索引访问数组元素,索引为10的值为：{0}", intArr[10]);
            //for (int i = 0; i < intArr.Length; i++)
            //{
            //    Console.WriteLine(intArr[i]);
            //}
            //foreach (var item in intArr)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region 多维数组,多维数组是像行和列的二维系列,多维数组又称为矩形数组;在本质上，是一个一维数组的列表
            ////下面的两种创建方式等价
            ////第一种
            ////int[,] intArray = { { 1, 1 }, { 1, 2 }, { 1, 3 } };

            ////第二种
            //int[,] intArray = new int[3, 4]{//初始化化一个三行四列的数组
            //                   {0, 1, 2, 3} ,   /*  初始化索引号为 0 的行 */
            //                   {4, 5, 6, 7} ,   /*  初始化索引号为 1 的行 */
            //                   {8, 9, 10, 11}   /*  初始化索引号为 2 的行 */
            //                };
            ////下面的语句将获取数组中第3行第4个元素
            //Console.WriteLine("二维数组中的元素是通过使用下标（即数组的行索引和列索引）来访问,值为：{0}", intArray[2, 3]);
            //Console.WriteLine("属性:Length:返回数组中元素的总数,值为：{0}", intArray.Length);
            #endregion

            #region Array:针对任意类型固定长度,作为所有数组的基类。它提供了用于创建，操作，搜索和排序数组的静态方法
            // Array 是抽象类，不能使用 new Array 创建
            //Array arr = Array.CreateInstance(Type.GetType("System.Int32"), 3);
            //arr.SetValue(1, 0);
            //arr.SetValue(3, 1);
            //arr.SetValue(null, 2);
            //Console.WriteLine("IsFixedSize:取一个值，该值指示数组是否带有固定大小,值为:{0}", arr.IsFixedSize);
            //Console.WriteLine("IsReadOnly:取一个值，该值指示数组是否只读,值为:{0}", arr.IsReadOnly);
            //Console.WriteLine("Length:获取一个 32 位整数，该值表示所有维度的数组中的元素总数,值为:{0}", arr.Length);
            //Console.WriteLine("LongLength:获取一个 64 位整数，该值表示所有维度的数组中的元素总数,值为:{0}", arr.LongLength);
            //Console.WriteLine("Rank:获取数组的秩（维度）,值为:{0}", arr.Rank);
            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region ArrayList:针对任意类型、任意长度的
            //不指定长度而且允许存储不同数据类型数据
            //ArrayList arrayList = new ArrayList();
            //arrayList.Add("wang");
            //arrayList.Add(1);       
            ////ArrayList允许插入null
            //arrayList.Add(null);

            //foreach (var item in arrayList)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region SortedList:集合默认按键的升序存储键值对
            //SortedList sortedList = new SortedList();
            //sortedList.Add(2, "wang");
            //sortedList.Add(5, "li");
            //sortedList.Add(3, 5);
            ////SortedList键可以是任何数据类型，但不能在同一SortedList中添加不同数据类型的键。
            //sortedList.Add("wang", 32);

            //for (int i = 0; i < sortedList.Count; i++)
            //{
            //    Console.WriteLine("key:{0},value:{1}", sortedList.GetKey(i), sortedList.GetByIndex(i));
            //}

            //foreach (DictionaryEntry item in sortedList)
            //{
            //    Console.WriteLine("key:{0},value:{1}", item.Key, item.Value);
            //}
            #endregion

            #region Stack:LIFO样式存储元素(后进先出)
            //Stack stack = new Stack();
            //stack.Push("1");
            //stack.Push(1);
            //stack.Push(false);

            //foreach (var item in stack)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Queue:以`FIFO样式(先进先出)`存储元素
            //Queue queue = new Queue();
            //queue.Enqueue("1");
            //queue.Enqueue(1);
            //queue.Enqueue(false);

            //foreach (var item in queue)
            //{
            //Console.WriteLine(item);
            //}
            #endregion

            #region Hashtable:集合存储键值对,通过计算每个密钥的哈希码来优化查找
            //Hashtable hashtable = new Hashtable();
            //hashtable.Add(1, "wang");
            //hashtable.Add(3, false);
            //hashtable.Add(2, "li");

            //foreach (DictionaryEntry item in hashtable)
            //{
            //Console.WriteLine("key:{0}, value:{1}", item.Key, item.Value);
            //}
            #endregion

            Console.ReadKey();
        }
    }
}
