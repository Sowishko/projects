using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lb111
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double A = Convert.ToDouble(textBox1.Text);
            double Z_1 = (Math.Cos((3 / 8 * Math.PI) - A / 4) * (Math.Cos((3 / 8 * Math.PI) - A / 4))) - (Math.Cos((11 / 8 * Math.PI) + A / 4) * (Math.Cos((11 / 8 * Math.PI) + A / 4)));
            double Z_2 = (Math.Sqrt(2) / 2) * (Math.Sin(A / 2));
            textBox2.Text = Convert.ToString(Z_1);
            textBox3.Text = Convert.ToString(Z_2);
            Console.ReadLine();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            { 
                textBox6.Clear();
            double E = Convert.ToDouble(textBox4.Text);
                if (E > 0.1 || E == 0)
                    MessageBox.Show("Введите погрешность 0 < 0.1", "Ошибка.");
                else
                {
                    
                    for (double x = 0.5; x <= 0.8; x += 0.05)
                    {
                        double y = Math.Log(2 - 2 * x + Math.Pow(x, 2));
                        double s = 0;
                        int k = 1;
                        while (Math.Abs(y - s) > E)
                        {
                            double S = (Math.Pow((-1), k - 1)) * (Math.Pow((x - 1), 2 * k)) / k;
                            s += y;
                            k++;
                        }
                        textBox6.Text += Math.Round(y, 5) + "\t        " + Math.Round(s, 5) + "\r\n";
                        
                    }


                } }
            catch (Exception)
            {
                MessageBox.Show("Ошибка.", "Введите корректные значения");
            }
            


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '8'))
                e.KeyChar = '\0';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
