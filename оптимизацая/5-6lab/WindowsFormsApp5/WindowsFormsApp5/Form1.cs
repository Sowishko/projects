using System;
using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private double F(double x, double y) =>
          Math.Pow(10*x - 5, 2) + 0.2*Math.Pow(y-2,2);

        private void button1_Click(object sender, EventArgs e)
        {
            Scene scene = new Scene();
            PlotCube plotCube = scene.Add(new PlotCube(twoDMode: false));

            Array<double> X = new double[100];
            Array<double> Y = new double[100];
            Array<double> Z = new double[100];

            var x0 = Convert.ToDouble(x0Box.Text);
            var y0 = Convert.ToDouble(y0Box.Text);
            var x1 = Convert.ToDouble(x1Box.Text);
            var y1 = Convert.ToDouble(y1Box.Text);
            var x2 = Convert.ToDouble(x2Box.Text);
            var y2 = Convert.ToDouble(y2Box.Text);
            var eps = Math.Abs(Convert.ToDouble(epsBox.Text));

            int k = 0;
            double alpha = 1, beta = 0.5, gamma = 2;

            double f0, f1, f2,
                   xh, yh, fh,
                   xl, yl, fl,
                   xg, yg, fg,
                   xr, yr, fr,
                   xe, ye, fe,
                   xc, yc, fc,
                   sigma, f_, min_x, min_y;
            var check = false;

            while (true)
            {
                f0 = F(x0, y0);
                f1 = F(x1, y1);
                f2 = F(x2, y2);

                //Макс
                fh = f0;
                xh = x0;
                yh = y0;
                if (f1 > fh)
                {
                    fh = f1;
                    xh = x1;
                    yh = y1;
                }
                if (f2 > fh)
                {
                    fh = f2;
                    xh = x2;
                    yh = y2;
                }

                //Мин
                fl = f0;
                xl = x0;
                yl = y0;
                if (f1 < fl)
                {
                    fl = f1;
                    xl = x1;
                    yl = y1;
                }
                if (f2 < fl)
                {
                    fl = f2;
                    xl = x2;
                    yl = y2;
                }

                //Некст макс
                fg = fl;
                xg = xl;
                yg = yl;
                if (f0 > fg && f0 < fh)
                {
                    fg = f0;
                    xg = x0;
                    yg = y0;
                }
                if (f1 > fg && f1 < fh)
                {
                    fg = f1;
                    xg = x1;
                    yg = y1;
                }
                if (f2 > fg && f2 < fh)
                {
                    fg = f2;
                    xg = x2;
                    yg = y2;
                }

                X[k] = xh; X[k + 1] = xg; X[k + 2] = xl;
                Y[k] = yh; Y[k + 1] = yg; Y[k + 2] = yl;
                Z[k] = fh; Z[k + 1] = fg; Z[k + 2] = fl;

                //Поиск центра тяжести
                x0 = (xl + xg) / 2;
                y0 = (yl + yg) / 2;
                f0 = F(x0, y0);

                //Отражение
                xr = (1 + alpha) * x0 - alpha * xh;
                yr = (1 + alpha) * y0 - alpha * yh;
                fr = F(xr, yr);
                if (fr < fl)
                {
                    //Растяжение
                    xe = gamma * xr + (1 - gamma) * x0;
                    ye = gamma * yr + (1 - gamma) * y0;
                    fe = F(xe, ye);
                    if (fe < fl)
                    {
                        xh = xe;
                        yh = ye;
                        fh = fe;
                    }
                    else
                    {
                        xh = xr;
                        yh = yr;
                        fh = fr;
                    }
                }
                else if (fr > fg)
                {
                    if (fr < fh)
                    {
                        xh = xr;
                        yh = yr;
                        fh = fr;
                    }

                    xc = beta * xh + (1 - beta) * x0;
                    yc = beta * yh + (1 - beta) * y0;
                    fc = F(xc, yc);

                    if (fc < fh)
                    {
                        xh = xc;
                        yh = yc;
                        fh = fc;
                    }
                    else
                    {
                        xh = (xh + xl) / 2;
                        yh = (yh + yl) / 2;
                        fh = F(xh, yh);

                        xl = (xl + xl) / 2;
                        yl = (yl + yl) / 2;
                        fl = F(xl, yl);

                        xg = (xg + xl) / 2;
                        yg = (yg + yl) / 2;
                        fg = F(xg, yg);
                    }
                }
                else
                {
                    xh = xr;
                    yh = yr;
                    fh = fr;
                }

                f_ = (fh + fg + fl) / 3;
                sigma = Math.Sqrt(((fh - f_) * (fh - f_) + (fl - f_) * (fl - f_) + (fg - f_) * (fg - f_)) / 3);

                min_x = xl;
                min_y = yl;

                if (sigma < eps)
                {
                    break;
                }

                x0 = xl;
                y0 = yl;
                x1 = xh;
                y1 = yh;
                x2 = xg;
                y2 = yg;

                AddInfo(k, xl, yl, fl, xg, yg, fg, xh, yh, fh, sigma);

                k++;
                check = true;
            }

            plotCube.Add(new Surface(
                        (x, y) => (float)(Math.Pow(10*x - 5, 2) + 0.2*Math.Pow(y - 2, 2))));
            plotCube.Add(new LinePlot(X, Y, Z));
            ilPanel1.Scene = scene;
        }
        private void AddInfo(int k, double xl, double yl, double fl, double xg, double yg, double fg, double xh, double yh, double fh, double sigma)
        {
            Info.Items.Add("k=" + k);
            Info.Items.Add("xl=" + xl);
            Info.Items.Add("yl=" + yl);
            Info.Items.Add("fl=" + fl);
            Info.Items.Add("xg=" + xg);
            Info.Items.Add("yg=" + yg);
            Info.Items.Add("fg=" + fg);
            Info.Items.Add("xh=" + xh);
            Info.Items.Add("yh=" + yh);
            Info.Items.Add("fh=" + fh);
            Info.Items.Add("sigma=" + sigma);
            Info.Items.Add("----------------------");
        }
    }
}
