using System;
using System.Drawing;
using System.Windows.Forms;


namespace _2._12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private short choice = 0;
        private short choiceFunc = 0;
        /// <summary>
        /// Левая и правая граница интервала
        /// </summary>
        private double a = 0, b = 0;
        /// <summary>
        /// Заполнена ли epsBox
        /// </summary>
        bool chk = false;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            choice = 1;
            choiceFunc = 1;
            Refresh();
            Draw();
            Svenn();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            choice = 2;
            choiceFunc = 2;
            Refresh();
            Draw();
            Svenn();
        }

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
        private bool CheckChoice()
        {
            if (choice == 0)
            {
                MessageBox.Show("Выберите функцию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Метод Свенна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Svenn()
        {
            if (CheckChoice()) return;
            int k = 100;
            double x = -5;
            double h = 1;
            double xNext = x;
            int i = 0;
            bool ch = false;
            do
            {
                if (ch)
                {
                    x += h;
                }
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
                if (choiceFunc == 1)
                {
                    a = x - 2 * h;
                    b = x + h - 1;
                }
                else
                {
                    a = x - h;
                    b = x + h;
                }
            }
            else if (h < 0)
            {
                a = x + h;
                b = x - h;
            }
            aBox.Text = a.ToString();
            bBox.Text = b.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                e.KeyChar = ',';
        }

        private void epsBox_TextChanged(object sender, EventArgs e)
        {
            Graphics graphics;
            graphics = CreateGraphics();
            if (!(double.TryParse(epsBox.Text, out double resualt) && epsBox.Text.Length > 0))
            {
                chk = false;
                graphics.DrawRectangle(new Pen(Color.Red), epsBox.Location.X - 1, epsBox.Location.Y - 1, epsBox.Width + 1, epsBox.Height + 1);
            }
            else
            {
                chk = true;
                graphics.DrawRectangle(new Pen(SystemColors.Control), epsBox.Location.X - 1, epsBox.Location.Y - 1, epsBox.Width + 1, epsBox.Height + 1);
            }
            graphics.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!(double.TryParse(epsBox.Text, out double resualt) && epsBox.Text.Length > 0))
                chk = false;
            else
                chk = true;
        }

        /// <summary>
        /// Золотое сечение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoldenRatio_Click(object sender, EventArgs e)
        {
            if (!chk)
            {
                MessageBox.Show("Заполните eps", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double x1 = a + 0.382 * (b - a);
            double x2 = a + 0.681 * (b - a);
            int k = 1;
            InfoList.Clear();
            InfoList.Text += $"x1={x1}" + Environment.NewLine +
                        $"x2={x2}" + Environment.NewLine +
                        $"k={k}" + Environment.NewLine + Environment.NewLine;

            try
            {
                //var app = new Word.Application();
                //var doc = app.Documents.Add();
                //doc.Tables.Add(doc.Range(0, 0), 20, 3);

                double eps = Convert.ToDouble(epsBox.Text);
                do
                {
                    if (Funcs(x1) < Funcs(x2))
                    {
                        b = x2;
                        x2 = x1;
                        x1 = a + 0.382 * (b - a);
                    }
                    else if (Funcs(x1) > Funcs(x2))
                    {
                        a = x1;
                        x1 = x2;
                        x2 = a + 0.681 * (b - a);
                    }
                    InfoList.Text += $"x1={x1}" + Environment.NewLine +
                        $"x2={x2}" + Environment.NewLine +
                        $"k={++k}" + Environment.NewLine + Environment.NewLine;


                    //WordTable(doc, k, x1, x2);
                } while (Math.Abs(b - a) > eps);

                //app.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void WordTable(Word.Document doc, int k, double x1, double x2)
        //{
        //    try
        //    {
        //        doc.Tables[1].Cell(k, 1).Range.InsertAfter(k.ToString());
        //        doc.Tables[1].Cell(k, 2).Range.InsertAfter(x1.ToString());
        //        doc.Tables[1].Cell(k, 3).Range.InsertAfter(x2.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}
    }
}
