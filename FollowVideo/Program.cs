using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FollowVideo
{
    class Program
    {
        static void Print1()
        {
            while (true)
                Console.WriteLine("Primary");
        }
        static void Print2()
        {
            while (true)
                Console.WriteLine(new string(' ', 20) + "Secondary");
        }

        //static void Print1(object name)
        //{
        //    while (true)
        //        Console.WriteLine((string)name);
        //}
        //static void Print2(object name)
        //{
        //    while (true)
        //        Console.WriteLine(new string(' ', 20) + (string)name);
        //}
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Print2);
            Thread thread = new Thread(threadStart);
            thread.Start();
            Print1();

            //ParameterizedThreadStart threadStart = new ParameterizedThreadStart(Print2);
            //Thread thread = new Thread(threadStart);
            //thread.Start("22222");
            //Print1("11111");

        }
    }
}
