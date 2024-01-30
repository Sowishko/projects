using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лр4._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            int num = int.Parse(textBox1.Text);
            for (int j = 2; j <= num; j++)
            {
                while (num % j == 0)
                {
                textBox2.Text += j.ToString();
                textBox2.Text += "*";
                num /= j;
                }
            }
            textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
        }
    }
}
