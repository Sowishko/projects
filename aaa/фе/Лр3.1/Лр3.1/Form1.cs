using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лр3._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != " " && textBox2.Text != "")//Защита от пустого ввода
            {
                {
                    int sCount = 0;
                    string f = textBox2.Text;
                    string[] s = f.Split('\n', ' ');
                    for (int i = 0; i < s.Length; i++)
                        if (s[i].Length < 5)
                            sCount++;
                    textBox1.Text = (sCount.ToString());
                }
            }
            else
            {
                MessageBox.Show("Введите что-нибудь.");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            string f = textBox2.Text;
            string[] s = f.Split('\n', ' ');
            for (int i = 0; i < s.Length; i++)
            {
                textBox3.Text += s[i].ToString() + "\r\n";
            }
        }
    }
}
