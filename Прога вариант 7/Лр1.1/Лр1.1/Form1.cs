using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лр1._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            double Number = 0;
            
            if (double.TryParse(textBox1.Text, out Number)) {
                label4.Text = "Отлично, нажмите Рассчитать!";
            }
            else {
                label4.Text = "Введите рациональное число!";
            }
               
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            double x;
            if (!Double.TryParse(textBox1.Text, out x))
            {
                // Ошибка
                label4.Text = "Ошибка, отправлено не число!";
                return;
            }
            double a = Convert.ToDouble(textBox1.Text);
            double z1 = Math.Pow(Math.Cos((3 * Math.PI / 8) - (a / 4)), 2) - Math.Pow(Math.Cos((11 * Math.PI / 8) + (a / 4)), 2);
            double z2 = (Math.Sqrt(2) / 2) * Math.Sin(a / 2);
            textBox2.Text = Convert.ToString(z1);
            textBox3.Text = Convert.ToString(z2);
        }
    }
}

