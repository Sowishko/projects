using System;
using System.Drawing;
using System.Windows.Forms;

namespace _3._12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private short choiceFunc = 0;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            choiceFunc = 1;
            Refresh();
            Draw();
            aBox.Text = "1";
            bBox.Text = "3";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            choiceFunc = 2;
            Refresh();
            Draw();
            aBox.Text = "8";
            bBox.Text = "10";
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (choiceFunc == 0)
                return;
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Red);
            switch (choiceFunc)
            {
                case 1:
                    g.DrawRectangle(pen, pictureBox1.Location.X - 1, pictureBox1.Location.Y - 1, pictureBox1.Width + 1, pictureBox1.Height + 1);
                    break;

                case 2:
                    g.DrawRectangle(pen, pictureBox2.Location.X - 1, pictureBox2.Location.Y - 1, pictureBox2.Width + 1, pictureBox2.Height + 1);
                    break;

                default:
                    break;
            }
            g.Dispose();
        }

        /// <summary>
        /// Рисует графики
        /// </summary>
        private void Draw()
        {
            switch (choiceFunc)
            {
                case 1:
                    for (int i = 0; i <= 3; i++)
                        chart1.Series[0].Points.AddXY(i, Funcs(i));
                    break;

                case 2:
                    for (double i = 7; i <= 10; i += 0.1)
                        chart1.Series[0].Points.AddXY(i, Funcs(i));
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Функции
        /// </summary>
        /// <param name="x">Значение x</param>
        /// <returns></returns>
        private double Funcs(double x)
        {
            switch (choiceFunc)
            {
                case 1:
                    return 1.4 * x + Math.Pow(Math.E, Math.Abs(x - 2));

                case 2:
                    return Math.Pow(x, 2) + Math.Pow(1 - x, 3) + Math.Pow(x - 5, 4);

                default:
                    break;
            }
            return -1;
        }

        /// <summary>
        /// Сделан ли выбор
        /// </summary>
        private bool CheckChoice => choiceFunc == 0;

        private void fButton_Click(object sender, EventArgs e)
        {
            if (CheckChoice)
            {
                MessageBox.Show("Выберите функцию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double a = Convert.ToDouble(aBox.Text), b = Convert.ToDouble(bBox.Text);
            double eps = Convert.ToDouble(epsBox.Text);

            //Поиск n - член последовательности
            int n = Find_N_(a, b, eps);
            if (n == -1)
            {
                MessageBox.Show("Ошибка n=-1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int k = 1; //Число итераций
            double x1 = 0, x2 = 0;

            listBox1.Items.Clear();

            //var app = new Microsoft.Office.Interop.Word.Application();
            //app.Visible = false;
            //var doc = app.Documents.Add();
            //doc.Tables.Add(doc.Range(0, 0), 30, 4);

            do
            {
                x1 = a + Fibonacсi(n - 2 - k) * ((b - a) / Fibonacсi(n - k)); //4
                x2 = a + Fibonacсi(n - 1 - k) * ((b - a) / Fibonacсi(n - k)); //4

                if (Funcs(x1) < Funcs(x2)) //6
                    b = x2;
                else a = x1;

                listBox1.Items.Add("x1=" + x1);
                listBox1.Items.Add("x2=" + x2);
                listBox1.Items.Add("k=" + k);
                listBox1.Items.Add("f=" + Funcs(x1));
                listBox1.Items.Add(Environment.NewLine);
                //WordTable(doc, k, x1, x2, Funcs(x1));
            } while (k++ < n - 1);

            xBox.Text = Math.Round(x1, 4).ToString();
            fBox.Text = Math.Round(Funcs(x1), 4).ToString();

            //app.Visible = true;
        }

        /// <summary>
        /// Ищет n
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="eps"></param>
        /// <returns></returns>
        private int Find_N_(double a, double b, double eps)
        {
            int n = -1;
            do
            {
                n++;
            } while (((b - a) / Fibonacсi(n)) >= eps);
            return n;
        }

        private int Fibonacсi(int i)
        {
            int f = 1;
            for (int j = 1; j <= i; j++)
                f += (j - 1);
            return f;
        }

        //private void WordTable(Microsoft.Office.Interop.Word.Document doc, int k, double x1, double x2, double f)
        //{
        //    try
        //    {
        //        doc.Tables[1].Cell(k, 1).Range.InsertAfter(k.ToString());
        //        doc.Tables[1].Cell(k, 2).Range.InsertAfter(x1.ToString());
        //        doc.Tables[1].Cell(k, 3).Range.InsertAfter(x2.ToString());
        //        doc.Tables[1].Cell(k, 4).Range.InsertAfter(f.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}
    }
}