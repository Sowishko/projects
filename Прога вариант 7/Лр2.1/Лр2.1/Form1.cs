using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лр2._1
{
    public partial class Form1 : Form
    {
        int[] a;
        int[] c;
        int n;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")//Защита от пустого ввода
            {
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                n = Convert.ToInt32(textBox1.Text);
                a = new int[n];
                Random b = new Random();
                for (int i = 0; i < n; ++i)
                {
                    a[i] = b.Next(10);
                    textBox2.Text+=i+") "+Convert.ToString(a[i]) + (char)13 + (char)10;
                }
                c = new int[n];
                for (int i = 0; i < n; ++i)
                {
                    c[i] = a[i];
                }
            }
            else
            {
                MessageBox.Show("Введите что-нибудь.");
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" & textBox2.Text != "")//Защита от пустого ввода
            {
                textBox3.Clear();
                int max = a[0];
                int maxind = 0;
                for (int i = 1; i < n; ++i)
                {
                    if (a[i] > max)
                    {
                        max = a[i];
                        maxind = i;
                    }
                }
                textBox3.Text = Convert.ToString(maxind);
            }
            else
            {
                MessageBox.Show("Введите что-нибудь.");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" & textBox1.Text != "")//Защита от пустого ввода
            {
                textBox4.Clear();
                int proisved = 1;
                int nula = 0;
                int nulb = 0;
                int nulaind = a[0];
                int nulbind = a[0];
                int nulf = 0;
                if (nulb - nula == 0)
                {
                    textBox4.Text = "0";
                }
                for (int i = 0; i < n; ++i)
                {
                    if (a[i] == 0 & nulf == 1)
                    {
                        nulbind = a[i];
                        nulb = i;
                        break;
                    }
                    if (a[i] == 0)
                    {
                        nulaind = a[i];
                        nula = i;
                        nulf = 1;
                    }
                }
                for (int i = nula + 1; i < nulb; ++i)
                {
                    proisved = proisved * a[i];
                    textBox4.Text = Convert.ToString(proisved);
                }
            }
            else
            {
                MessageBox.Show("Введите что-нибудь.");
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" & textBox1.Text != "")//Защита от пустого ввода
            {
                textBox2.Text += "Сортировка" + (char)13 + (char)10;
                for (int i = 0; i < n; ++i)
                {
                    if (i % 2 != 0)
                    {
                        textBox2.Text += Convert.ToString(c[i]) + (char)13 + (char)10;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    if (i % 2 == 0)
                    {
                        textBox2.Text += Convert.ToString(c[i]) + (char)13 + (char)10;
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите что-нибудь.");
            }
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox senderTextBox = sender as TextBox;
            char number = e.KeyChar; //Нажатая кнопка.
            if (!Char.IsDigit(number)&& number != 8)
            {
                e.Handled = true; // Ввод отменяется
                senderTextBox.BackColor = Color.Red;
            }
            else//Если ввод нормальный
            {
                senderTextBox.BackColor = Color.White; //Красим текстбокс в белый. Можно без этого.
            }
        }
    }
}
