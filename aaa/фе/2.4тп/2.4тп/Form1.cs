using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2._4тп
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void R1_Click(object sender, EventArgs e)
        {
            try
            {
                Random r = new Random();
                int N = Convert.ToInt32(_N1.Text); string str = "";
                double sum = 0; double[] x = new double[N];
                for (int i = 0; i < N; i++)
                {
                    x[i] = r.Next(50);
                    if (x[i] > 20)
                        sum += x[i];
                    str += x[i] + " ";
                }
                MasX1.Text = str;
                if (sum > 100)
                    R1_T.Text = "Сумма чисел массива x, больших  20, больше 100. Сумма:" + sum;
                else
                    R1_T.Text = "Сумма чисел массива x, больших  20, меньше 100. Сумма:" + sum;

            }
            catch (Exception)
            {
                MessageBox.Show("Введите корректное значение", "Сообщение");
            }
        }

        private void CheckPN_Button_Click(object sender, EventArgs e)
        {
            try
            {
                double X1 = Convert.ToDouble(x1.Text);
                double X2 = Convert.ToDouble(x2.Text);
                double X3 = Convert.ToDouble(x3.Text);
                double X4 = Convert.ToDouble(x4.Text);

                double Y1 = Convert.ToDouble(y1.Text);
                double Y2 = Convert.ToDouble(y2.Text);
                double Y3 = Convert.ToDouble(y3.Text);
                double Y4 = Convert.ToDouble(y4.Text);

                double k1 = (Y1 - Y2) / (X1 - X2);
                double k2 = (Y3 - Y4) / (X3 - X4);

                double b1 = Y2 - X2 * k1;
                double b2 = Y4 - X4 * k2;

                double x = ((X1 * Y2 - X2 * Y1) * (X4 - X3) - (X3 * Y4 - X4 * Y3) * (X2 - X1)) / ((Y1 - Y2) * (X4 - X3) - (Y3 - Y4) * (X2 - X1));
                double y = ((Y3 - Y4) * x - (X3 * Y4 - X4 * Y3)) / (X4 - X3);

                if (((X1 <= x) && (X2 >= x) && (X3 <= x) && (X4 >= x)) || ((Y1 <= y) && (Y2 >= y) && (Y3 <= y) && (Y4 >= y)))
                {
                    MessageBox.Show("Точка пересечения существует");
                }
                else
                    MessageBox.Show("Точка пересечения нет");
            }
            catch (FormatException)
            {
                MessageBox.Show("Заполните все поля!");
            }

        }

        private void ZD3_Click(object sender, EventArgs e)
        {
            MasA.Text = "";
            MasB.Text = "";
            _Rez3.Text = "";
            try
            {
                Random r = new Random();
                int N = Convert.ToInt32(_N3.Text);
                int[] A = new int[25];
                int[] B = new int[N];

                A[0] = 1; MasA.Text += A[0] + " ";
                for (int i = 1; i < A.Length; i++)
                {
                    A[i] = A[i - 1] + r.Next(1, 3);
                    MasA.Text += A[i] + " ";
                }
                B[0] = 1; MasB.Text += B[0] + " ";
                for (int i = 1; i < B.Length; i++)
                {
                    B[i] = B[i - 1] + r.Next(1, 3);
                    MasB.Text += B[i] + " ";
                }

                int counter = 0;
                for (int i = 0; i < B.Length; i++)
                {
                    counter = 0;
                    for (int j = 0; j < A.Length; j++)
                        if (A[j] != B[i])
                            counter++;
                    if (counter == A.Length)
                        _Rez3.Text += B[i] + " ";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Введите целое, положительное число", "Предупреждение");
            }
        }

       
    }
}
