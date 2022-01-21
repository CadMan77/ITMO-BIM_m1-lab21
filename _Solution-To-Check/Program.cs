using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать. 
//Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом. 
//Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз. 
//Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево. 
//Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше. 
//Садовники должны работать параллельно. 
//Создать многопоточное приложение, моделирующее работу садовников.

namespace MY_solution_for_lab21
{
    class Program
    {
        static void Main(string[] args)
        {
            const int d1 = 6; //длина/высота
            const int d2 = 10; //ширина
            int[,] garden = new int[d1, d2];
            //Console.WriteLine($"Размеры сада:\n\tДлина = {garden.GetLength(0)}\n\tШирина = {garden.GetLength(1)}");
            //garden[0, d2 - 3] = 2;
            //garden[2, d2 - 1] = 1;
            //PrintIt(garden);
            //Console.ReadKey();

            ThreadStart threadStart = new ThreadStart(Keeper2);
            Thread thread = new Thread(threadStart);
            thread.Start();
            Keeper1();
            PrintIt(garden);
            Console.ReadKey();

            void Keeper1()
            {
                for (int i = 0; i < d1; i++)
                {
                    for (int j = 0; j < d2; j++)
                    {
                        if (garden[i, j] != 0)
                            continue;
                        garden[i, j] = 1;
                        //PrintIt(garden);
                        Thread.Sleep(1);
                    }
                }
            }
            void Keeper2()
            {
                for (int j = d2 - 1; j >= 0; j--)
                {
                    for (int i = d1 - 1; i >= 0; i--)
                    {
                        if (garden[i, j] != 0)
                        {
                            continue;
                        }
                        garden[i, j] = 2;
                        //PrintIt(garden);
                        Thread.Sleep(1);
                    }
                }
            }
            void PrintIt(int[,] g2)
            {
                string result = "";
                for (int i = 0; i < d1; i++)
                {
                    for (int j = 0; j < d2; j++)
                    {
                        if (g2[i, j] != 0)
                            result += " "+ g2[i, j];
                        else
                            result += " ·";
                    }
                    result += "\n";
                }
                //result += "--8<---8<---8<--\n";
                Console.Write(result);
            }
        }
    }
}
