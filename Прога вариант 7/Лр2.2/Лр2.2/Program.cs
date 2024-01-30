using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лр2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            int[,] a = new int[n, n];
            int summ = 0;
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //a[i, j] = random.Next(-2,10);
                    int vvod = int.Parse(Console.ReadLine());
                    a[i, j] = vvod;
                    //Console.Write("{0,4}", a[i, j]);
                }
                Console.WriteLine();
            }

            
            for (int row = 0; row < n; row++)
            {
                bool match = false;
                // проверяем ряд на отрицательные элементы
                for (int col = 0; col < n && !match; col++)
                {
                    if (a[row, col] < 0)
                        match = true;
                }
                if (match)
                {
                    for (int col = 0; col < n; col++)
                    {
                        summ +=a[row, col];
                    }
                }
            }
            Console.Write("Summ: ");
            Console.WriteLine(summ);

            for (int j = 0; j < n; j++)
            {
                bool match = true;
                for (int i = 0; i < n && match; i++)
                {
                    if (a[j, i] != a[i, j])
                        match = false;
                }
                if (match)
                    Console.WriteLine(j);
            }
            Console.ReadKey();
        }
    }
}
