using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lb2._22
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*static void Main()
        {
            int[,] arr =
            {
                {1, 3, 5, 7, 9,},
                {3, 6, 4, 8, 2,},
                {5, 4, 2, 1, 0,},
                {7, 8, 1, 6, 4,},
                {9, 2, 0, 4, 5,}
            };

            var result = TrimSame(arr);
            Console.WriteLine(result.Length);
        }

        private static T[,] TrimSame<T>(T[,] a)
        {
            int n = a.GetLength(0);
            if (n == a.GetLength(1))
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (CheckRowColumn(a, i, j))
                        {
                            return GenerateResult(a, n, i, j);
                        }
                    }
                }
            }
            return (T[,])a.Clone();
        }

        private static T[,] GenerateResult<T>(T[,] a, int n, int i, int j)
        {
            T[,] result = new T[n - 1, n - 1];
            for (int isource = 0, idest = 0; isource < n; isource++)
            {
                if (isource == i)
                    continue;
                for (int jsource = 0, jdest = 0; jsource < n; jsource++)
                {
                    if (jsource == j)
                        continue;
                    result[idest, jdest++] = a[isource, jsource];
                }
                isource++;
            }
            return result;
        }

        private static bool CheckRowColumn<T>(T[,] a, int row, int column)
        {
            int n = a.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                if (!a[row, i].Equals(a[i, column]))
                    return false;
            }
            return true;
        }*/
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Random rand = new Random();
            int[][] mas = new int[9][];
            mas[0] = new int[8];
            mas[1] = new int[8];
            mas[2] = new int[8];
            mas[3] = new int[8];
            mas[4] = new int[8];
            mas[5] = new int[8];
            mas[6] = new int[8];
            mas[7] = new int[8];
            mas[8] = new int[8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < mas[i].Length; j++)
                {
                    mas[i][j] = rand.Next(10);
                }
            dataGridView1.RowCount = 8;
            dataGridView1.ColumnCount = 8;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < mas[i].Length; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = mas[i][j];
                }
        }
    }
}
