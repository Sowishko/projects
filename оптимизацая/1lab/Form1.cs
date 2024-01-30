using System;
using System.Drawing;
using System.Windows.Forms;

namespace _1lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Выбрана ли картинка . 0 - ничего не выбрано / 1 - первая функция / 2 - вторая функция
        /// </summary>
        private short choice = 0;
        private int choiceFunc = 0;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Red);
            switch (choice)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            choice = 1;
            choiceFunc = 1;
            Refresh();
            Draw();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            choice = 2;
            choiceFunc = 2;
            Refresh();
            Draw();
        }
        /// <summary>
        /// Метод Свенна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SvenButton_Click(object sender, EventArgs e)
        {
            if (CheckChoice()) return;
            InfoList.Items.Clear();
            int k = Convert.ToInt32(kBox.Text);
            double x = Convert.ToDouble(xBox.Text);
            double h = Convert.ToDouble(hBox.Text);
            double xNext = x, a, b;
            int i = 0;
            bool ch = false;
            do
            {
                if (ch)
                {
                    x += h;
                }
                InfoList.Items.Add("x=" + x.ToString());
                InfoList.Items.Add("k=" + i);
                InfoList.Items.Add("f=" + Funcs(x));
                InfoList.Items.Add(Environment.NewLine);
                if (Funcs(x - h) <= Funcs(x) && Funcs(x + h) >= Funcs(x)) //a
                {
                    a = x - h;
                    b = x + h;
                    break;
                }
                else if (Funcs(x - h) >= Funcs(x) && Funcs(x + h) <= Funcs(x))//б
                {
                    xNext += h;
                }
                else if (Funcs(x - h) <= Funcs(x) && Funcs(x) >= Funcs(x + h))//в
                {
                    h = -1 * h;
                    xNext += h;
                }
                else if (Funcs(x - h) <= Funcs(x) && Funcs(x + h) <= Funcs(x)) //г
                {
                    MessageBox.Show("11");
                    return;
                }

                i++;
                ch = true;
            } while (Funcs(xNext) <= Funcs(x) && i < k);

            if (h > 0)
            {
                a = x - 2*h;
                b = x + h;
                aBox.Text = a.ToString();
                bBox.Text = b.ToString();
                a2box.Text = a.ToString();
                b2box.Text = b.ToString();
                a3Box.Text = a.ToString();
                b3Box.Text = b.ToString();
            }
            else if (h < 0)
            {
                a = x + h;
                b = x - h;
                aBox.Text = a.ToString();
                bBox.Text = b.ToString();
                a2box.Text = a.ToString();
                b2box.Text = b.ToString();
                a3Box.Text = a.ToString();
                b3Box.Text = b.ToString();
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
        /// Рисует графики
        /// </summary>
        private void Draw()
        {
            switch (choiceFunc)
            {
                case 1:
                    for (double i = -3; i <= 5; i += 0.1)
                        chart1.Series[0].Points.AddXY(i, Funcs(i));
                    break;
                case 2:
                    for (double i = 2; i <= 10; i += 0.1)
                        chart1.Series[0].Points.AddXY(i, Funcs(i));
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Алгоритм равномерного поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (CheckChoice()) return;
            InfoList.Items.Clear();
            double a = Convert.ToDouble(a2box.Text);
            double b = Convert.ToDouble(b2box.Text);
            double h = Convert.ToDouble(eBox.Text);
            double x = a;
            int k = 1;

            while (k!=100)
            {
                if (Funcs(x) > Funcs(x + h))
                {
                    x += h;
                    InfoList.Items.Add("x=" + x);
                    InfoList.Items.Add("k=" + k++);
                    InfoList.Items.Add("f=" + Funcs(x));
                    InfoList.Items.Add(Environment.NewLine);
                }
                else if (x > b)
                {
                    InfoList.Items.Add("Точка x на границе интервала " + x);
                    break; ;
                }
                else
                    break;
            }
            x2Box.Text = x.ToString();

        }
        /// <summary>
        /// Заменяет точку на запятую
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                e.KeyChar = ',';
        }
        /// <summary>
        /// Метод дихотомии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DihButton_Click(object sender, EventArgs e)
        {
            if (CheckChoice()) return;
            InfoList.Items.Clear();
            double a = Convert.ToDouble(a3Box.Text);
            double b = Convert.ToDouble(b3Box.Text);
            double ep = Convert.ToDouble(e2Box.Text);
            int k = 1;
            do
            {
                double x = Math.Round((a + b) / 2, 3);
                if (Funcs(x - ep / 2) > Funcs(x + ep / 2))
                {
                    a = x;
                }
                else if (Funcs(x - ep / 2) < Funcs(x + ep / 2))
                {
                    b = x;
                }
                InfoList.Items.Add("a=" + a);
                InfoList.Items.Add("b=" + b);
                InfoList.Items.Add("x=" + x);
                InfoList.Items.Add("k=" + k++);
                InfoList.Items.Add("f=" + Funcs(x));
                InfoList.Items.Add(Environment.NewLine);
            } while ((b - a) > ep);
            x3Box.Text = ((b + a) / 2).ToString();
        }
        /// <summary>
        /// Сделан ли выбор
        /// </summary>
        private bool CheckChoice()
        {
            if (choice == 0)
            {
                MessageBox.Show("Выберите функцию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else return false;
        }
    }
}
