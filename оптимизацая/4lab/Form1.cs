using System;
using System.Drawing;
using System.Windows.Forms;

namespace _4
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
            xBox.Text = "0";
            hBox.Text = "0,001";
            eps1Box.Text = "0,001";
            eps2Box.Text = "0,001";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            choiceFunc = 2;
            Refresh();
            Draw();
            xBox.Text = "0";
            hBox.Text = "0,001";
            eps1Box.Text = "0,001";
            eps2Box.Text = "0,001";
        }

        private void Draw()
        {
            switch (choiceFunc)
            {
                case 1:
                    for (int i = 0; i <= 3; i++)
                        chart1.Series[0].Points.AddXY(i, Funcs(i));
                    break;
                case 2:
                    for (double i = 5; i <= 10; i += 0.1)
                        chart1.Series[0].Points.AddXY(i, Funcs(i));
                    break;
                default:
                    break;
            }
        }

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

        private void Search_Button_Click(object sender, EventArgs e)
        {
            if (choiceFunc == 0)
            {
                MessageBox.Show("Выберите функцию", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            listBox1.Items.Clear();
            try
            {
                //var app = new Microsoft.Office.Interop.Word.Application();
                //app.Visible = false;
                //var doc = app.Documents.Add();
                //doc.Tables.Add(doc.Range(0, 0), 100, 11);

                var x0 = Convert.ToDouble(xBox.Text); // x0
                var h = Math.Abs(Convert.ToDouble(hBox.Text)); // h
                var eps1 = Math.Abs(Convert.ToDouble(eps1Box.Text)); // eps1
                var eps2 = Math.Abs(Convert.ToDouble(eps2Box.Text)); // eps2
                var steps = Convert.ToInt32(kBox.Text);

                var x1 = x0;
                var fx1 = Funcs(x1);
                double fx2, fx3, // f
                    delta, fdelta,
                    xmin, fxmin,
                    comp1, comp2,
                    x2, x3,
                    total = 0;

                int k = 1; //счетчик

                while (true)
                {
                    //Вторая точка
                    x2 = x1 + h;
                    fx2 = Funcs(x2);

                    //Третья точка
                    if (fx1 > fx2)
                        x3 = x1 + 2 * h;
                    else
                        x3 = x1 - h;
                    fx3 = Funcs(x3);

                    //Минимум
                    xmin = x1;
                    fxmin = fx1;
                    if (fx2 < fxmin)
                    {
                        xmin = x2;
                        fxmin = fx2;
                    }
                    if (fx3 < fxmin)
                    {
                        xmin = x3;
                        fxmin = fx3;
                    }

                    //Дельта
                    var d1 = (x1 + x2) / 2;
                    var d2 = ((fx1 - fx2) * (x2 - x3) * (x3 - x1) / ((x2 - x3) * fx1 + (x3 - x1) * fx2 + (x1 - x2) * fx3));
                    var d3 = d2 / 2;
                    delta = d1 + d3;
                    //delta = (x1 + x2) / 2 + (fx1 - fx2) * (x2 - x3) * (x3 - x1) / ((x2 - x3) * fx1 + (x3 - x1) * fx2 + (x1 - x3) * fx3);
                    fdelta = Funcs(delta);

                    //Проверка
                    comp1 = Math.Abs((fxmin - fdelta) / fdelta);
                    comp2 = Math.Abs((xmin - delta) / delta);
                    if (comp1 < eps1 && comp2 < eps2)
                    {
                        total = delta;
                        break;
                    }

                    listBox1.Items.Add($"k= {k}");
                    listBox1.Items.Add($"x1= {Math.Round(x1, 3)}");
                    listBox1.Items.Add($"x2= {Math.Round(x2, 3)}");
                    listBox1.Items.Add($"x3= {Math.Round(x3, 3)}");
                    listBox1.Items.Add($"fx1= {Math.Round(fx1, 3)}");
                    listBox1.Items.Add($"fx2= {Math.Round(fx2, 3)}");
                    listBox1.Items.Add($"fx3= {Math.Round(fx3, 3)}");
                    listBox1.Items.Add($"delta= {Math.Round(delta, 3)}");
                    listBox1.Items.Add($"fdelta= {Math.Round(fdelta, 3)}");
                    listBox1.Items.Add($"comp1= {Math.Round(comp1, 3)}");
                    listBox1.Items.Add($"comp2= {Math.Round(comp2, 3)}");
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                    //WordTable(doc, k, x1, x2, x3, fx1, fx2, fx3, delta, fdelta, comp1, comp2);

                    //Заменяем точки
                    if (fdelta < fxmin || x1 == xmin)
                    {
                        x1 = delta;
                        fx1 = fdelta;
                    }
                    else
                    {
                        x1 = xmin;
                        fx1 = fxmin;
                    }

                    //Выход
                    if (steps > 1)
                        steps--;
                    else
                    {
                        listBox1.Items.Add("Превышен k");
                        total = delta;
                        break;
                    }
                    k++;
                }
                deltaBox.Text = delta.ToString();
                fBox.Text = fdelta.ToString();
                listBox1.TopIndex = listBox1.Items.Count - 1;

                //app.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Dot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
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
    }
}