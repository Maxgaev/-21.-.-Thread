using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Задание_21.Многопоточность.Класс_Thread
{
    internal class Program
    {

        //const int n = 10;
        //static int[] path = new int[n] { 1, 2, 0, 5, 5, 0, 1, 2, 4, 8 };
        static int[,] field;
        static int width;
        static int length;
        static void Main(string[] args)
        {
            Console.WriteLine("\nВведите размер поля в ширину:");
            width = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nВведите размер поля в длинну:");
            length = Convert.ToInt32(Console.ReadLine());
            field = new int[width, length];
            Random random = new Random();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {

                    field[i, j] = random.Next(9);

                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;

            }

            ThreadStart threadStart = new ThreadStart(Gardner1);
            Thread thread = new Thread(threadStart);
            thread.Start();
            Gardner2();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write(field[ i ,  j]  +  "  ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void Gardner1()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (field[i, j] >= 0)
                    {
                        int delay = field[i, j];
                        field[i, j] = -1;
                        Thread.Sleep(delay);
                        Console.ForegroundColor = ConsoleColor.Blue;

                    }
                   
                }

            }

        }
        static void Gardner2()
        {
            for (int i = width - 1; i >= 0; i--)
            {
                for (int j = length - 1; j >= 0; j--)
                {
                    if (field[i, j] >= 0)
                    {
                        int delay = field[i, j];
                        field[i, j] = -2;
                        Thread.Sleep(delay);
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }

            }

        }

        //static void Gardner1()
        //{
        //    for (int i = 0; i < n; i++)
        //    {
        //        if (path[i] >= 0)
        //        {
        //            int delay = path[i];
        //            path[i] = -1;
        //            Thread.Sleep(delay);
        //        }
        //    }

        //}
        //static void Gardner2()
        //{
        //    for (int i = n-1; i >= 0; i--)
        //    {
        //        if (path[i] >= 0)
        //        {
        //            int delay = path[i];
        //            path[i] = -2;
        //            Thread.Sleep(delay);
        //        }
        //    }

        //}
    }
}
