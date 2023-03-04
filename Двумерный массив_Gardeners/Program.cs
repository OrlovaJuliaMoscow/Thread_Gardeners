using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Gardeners
{
    class Program
    {
        const int n = 4;
        //const int m = 2;

        static int[,] path = new int[n, n];  //{1, 2, 0, 20, 5, 0, 1, 2, 6, 10, 1, 2, 0, 20, 5, 0, 1, 2, 6, 1};
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Gardner1);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Gardner2();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{path[i,j]} ");
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }




        static void Gardner1()
        {
            for (int i = 0; i < n; i++)
            { 
                for (int j = 0; j < n; j++)
                {


                    if (path[i,j] >= 0) //array[n,m] >= 0)
                    {
                        int delay = path[i, j];
                        path[i, j] = -1;
                        Thread.Sleep(delay);
                    }
                }
            }
        }
        static void Gardner2()
        {
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (path[i, j] >= 0)
                    {
                        int delay = path[i, j];
                        path[i, j] = -2;
                        Thread.Sleep(delay);
                    }
                }
            }
        }
    }
}
