using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console.main.并行开发
{
    class DelegateTest
    {
        static void Main(string[] args)
        {
            //int x = 3;
            //while (x > 0)
            //{
            //    if (x > 2)
            //    {
            //        Console.Write("a");
            //    }
            //    x = x - 1;
            //    Console.Write("-");
            //    if (x == 2)
            //    {
            //        Console.Write("b c");
            //    }
            //    x = x - 1;
            //    Console.Write("-");
            //    if (x == 1)
            //    {
            //        Console.Write("d");
            //        x = x - 1;
            //    }
            //}
            //int x = 1;
            //while (x < 10)
            //{
            //    if (x > 3)
            //    {
            //        Console.WriteLine(x);
            //    }
            //}
            //int x = 5;
            //while (x > 1)
            //{
            //    x = x - 1;
            //    if (x < 3)
            //    {
            //        Console.WriteLine(x);
            //    }
            //}

            int x = 0;
            int y = 0;
            while (x < 5)
            {
                y = x - y;
                Console.WriteLine(x + "" + y + "");
                x = x + 1;
            }
            Console.ReadKey();
        }
    }
}
