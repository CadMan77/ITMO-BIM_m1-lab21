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
            const int d1 = 7; //длина/высота
            const int d2 = 6; //ширина
            bool[,] garden = new bool[d1, d2];
            garden[0, d2 - 3] = true;
            garden[1, d2 - 2] = true;
            garden[2, d2 - 1] = true;
            PrintIt(garden);
            Console.ReadKey();

            //Console.WriteLine($"Размеры сада:\n\tДлина = {garden.GetLength(0)}\n\tШирина = {garden.GetLength(1)}");
            ////string result = ""
            garden = Keeper1(garden);
            //Console.ReadKey();

            //void Gardener1(bool[,] sad_IN)
            bool[,] Keeper1(bool[,] g1)
            {
                for (int i = 0; i < d1; i++)
                {
                    for (int j = 0; j < d2; j++)
                    {
                        if (garden[i, j] == true)
                            break;
                        garden[i, j] = true;
                        PrintIt(garden);
                        Thread.Sleep(500);
                    }
                }
                return garden;
            }
            bool[,] Keeper2(bool[,] g1)
            {
                for (int j = d2-1; j >= 0; j--)
                {
                    for (int i = d1-1; i >= 0; i--)
                    {
                        if (garden[i, j] == true)
                        {
                            break;
                        }
                        garden[i, j] = true;
                        PrintIt(garden);
                        Thread.Sleep(500);
                    }
                }
                return garden;
            }
            void PrintIt(bool[,] g2)
            {
                string result = "";
                for (int i = 0; i < d1; i++)
                {
                    for (int j = 0; j < d2; j++)
                    {
                        if (g2[i, j])
                            result += " +";
                        else 
                            result += " ·";
                    }
                    result += "\n";
                }
                result += "--8<---8<---8<--\n";
                Console.Write(result);
            }
        }
    }
}
