using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лр2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] a = new int[6][];
            a[0] = new int[2] { 9, 0 };
            a[1] = new int[2] { 7, 5 };
            a[2] = new int[6] { 6, 15, 5, 1, 7, 9 };
            a[3] = new int[6] { 4, -4, 3, 1, 7, 4 };
            a[4] = new int[2] { 9, -1 };
            a[5] = new int[2] { 7, 9  };
            Console.WriteLine("Исходный массив: ");
            for (int i=0;i<a.Length;i++) 
            {
                for (int j = 0; j < a[i].Length; j++)
                    Console.Write(" " + a[i][j]);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
