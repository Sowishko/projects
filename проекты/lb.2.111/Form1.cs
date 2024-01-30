using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lb._2._111
{
    public partial class Form1 : Form
    {
        int[] a;
        int n;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            n = Convert.ToInt32(textBox1.Text);
            a = new int[n];
            Random b = new Random();
            for (int i = 0; i < n; ++i)
            {
                a[i] = b.Next(5);
                textBox2.Text += Convert.ToString(a[i]) + (char)13 + (char)10;
                textBox5.Text += Convert.ToString(a[i]) + (char)13 + (char)10;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int b1 = 0;
            int b2 = 0;
            

            int x = 0, y = 0;
            int p = 1;
            for (int i = 0; i < n; i++)
            {
                if (a[i] == 0)
                {
                    b1 = 1; 
                    x = i;
                    break;
                }
            }
            for (int i = x + 1; i < n; i++)
            {
                if (a[i] == 0)
                {
                    b2 = 1;
                    y = i;
                    break;
                }
            }
            if (b1 == 0 || b2 == 0)
            {
                MessageBox.Show("Недостаточно нулей", "Ошибка");
                return;
            }
            if (x + 1 == y)

            {
                MessageBox.Show("НУЛИ ИДУТ ДРУГ ЗА ДРУГОМ!", "ERROR");
                return;
            }
            for (int i = x + 1; i < y; i++)
            {
            
                p *= a[i];
                
            }
            textBox3.Text = p.ToString("n");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int max = 0;
            int maxind = a[0];
            for (int i = 0; i < n; i++)
            {
                if (max < a[i])
                {
                    max = a[i];
                    maxind = i + 1;
                }
            }
            textBox4.Text = Convert.ToString(maxind);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
            
    }
}
