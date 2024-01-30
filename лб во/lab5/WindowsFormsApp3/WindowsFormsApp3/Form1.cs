using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private double XD(double x, double y) =>
           10 * Math.Pow(x * y - 5, 2) + Math.Pow(y - 5, 2);

        private void DrawLine(double xx, double yy, double f)
        {
            var scene = new Scene()
            {
                new PlotCube(twoDMode: false)
                {
                    new Surface(
                        (x,y)=> (float)(10*Math.Pow(x*y - 5, 2) + Math.Pow(y-5,2))),
                    new LinePlot(xx,yy,f)
                }
            };

            panel1.Scene = scene;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Info.Items.Clear();

            var x0 = Convert.ToDouble(x0Box.Text);
            var y0 = Convert.ToDouble(y0Box.Text);
            var delta = Math.Abs(Convert.ToDouble(deltaBox.Text));
            var alpha = Math.Abs(Convert.ToDouble(alphaBox.Text));
            var eps = Math.Abs(Convert.ToDouble(epsBox.Text));

            var x = x0;
            var y = x0;
            var x_min = x0;
            var y_min = y0;
            var new_direction = true;

            var sign_x = 1;
            var sign_y = 1;

            var k = 0;

            double f_old;
            double x_old, y_old;

            while (true)
            {
                f_old = XD(x, y);

                AddInfo(k, x, y, f_old, delta);

                x_old = x;
                y_old = y;
                DrawLine(x_old, y_old, f_old);

                if (!new_direction)
                {
                    if (XD(x + delta * sign_x, y + delta * sign_y) >= f_old)
                    {
                        new_direction = true;
                    }
                    else
                    {
                        x = x + delta * sign_x;
                        y = y + delta * sign_y;
                    }
                }

                if (new_direction)
                {
                    sign_x = 1;
                    if (XD(x + delta * sign_x, y) >= f_old)
                    {
                        sign_x = -1;
                    }
                    if (XD(x + delta * sign_x, y) >= f_old)
                    {
                        sign_x = 0;
                    }
                    sign_y = 1;
                    if (XD(x, y + delta * sign_y) >= f_old)
                    {
                        sign_y = -1;
                    }
                    if (XD(x, y + delta * sign_y) >= f_old)
                    {
                        sign_y = 0;
                    }

                    y = y + delta * sign_y;

                    new_direction = false;
                    if (sign_x == 0 && sign_y == 0)
                    {
                        new_direction = true;
                        delta = delta / alpha;
                        if (delta < eps)
                        {
                            break;
                        }
                    }
                }
                DrawLine(x, y, f_old);
                k++;
            }
            panel1.Refresh();
        }

        private void AddInfo(int k, double x, double y, double f_old, double delta)
        {
            Info.Items.Add("k=" + k);
            Info.Items.Add("x=" + x);
            Info.Items.Add("y=" + y);
            Info.Items.Add("f=" + f_old);
            Info.Items.Add("delta=" + delta);
            Info.Items.Add("----------------------");
        }

        private void eps_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                e.KeyChar = ',';
        }
    }
}
