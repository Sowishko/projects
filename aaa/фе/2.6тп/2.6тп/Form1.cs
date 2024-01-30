using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2._6тп
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ComplexCh1 ch1;
        private void CreateCh_Click(object sender, EventArgs e)
        {
            try
            {
                ch1 = new ComplexCh1(Convert.ToDouble(ReStr.Text), Convert.ToDouble(ImStr.Text));
                StatusRe.Text = ch1.re.ToString();
                StatusIm.Text = ch1.im.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните пропуски");
            }
        }

        private void IncI_Click(object sender, EventArgs e)
        {
            try
            {
                if (ch1 == null)
                {
                    MessageBox.Show("Создайте запись числа");
                    return;
                }
                ch1.IncCh(Convert.ToDouble(ReInc.Text), Convert.ToDouble(ImInc.Text));
                StatusRe.Text = ch1.re.ToString();
                StatusIm.Text = ch1.im.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните пропуски");
            }
        }

        private void DecI_Click(object sender, EventArgs e)
        {
            try
            {
                if (ch1 == null)
                {
                    MessageBox.Show("Создайте запись числа");
                    return;
                }
                ch1.DecCh(Convert.ToDouble(ReDec.Text), Convert.ToDouble(ImDec.Text));
                StatusRe.Text = ch1.re.ToString();
                StatusIm.Text = ch1.im.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните пропуски");
            }
        }

        private void Yi_Click(object sender, EventArgs e)
        {
            try
            {
                if (ch1 == null)
                {
                    MessageBox.Show("Создайте запись числа");
                    return;
                }
                ch1.Pr(Convert.ToDouble(ReYm.Text), Convert.ToDouble(ImYm.Text));
                StatusRe.Text = ch1.re.ToString();
                StatusIm.Text = ch1.im.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните пропуски");
            }
        }
    }


    class ComplexCh
    {
        public double re { get; set; }
        public double im { get; set; }
        public ComplexCh(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public void IncCh(double re, double im)
        {
            this.re += re;
            this.im += im;
        }

        public void DecCh(double re, double im)
        {
            this.re -= re;
            this.im -= im;
        }
    }

    class ComplexCh1 : ComplexCh
    {
        public ComplexCh1(double re, double im) : base(re, im)
        {
            this.re = re;
            this.im = im;
        }

        public void Pr(double re, double im)
        {
            double tempRe = this.re;
            double tempIm = this.im;

            this.re = tempRe * re - tempIm * im;
            this.im = tempRe * im + re * tempIm;
        }
    }
}
