using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лр4._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            int n = 31;
            int[] mass = new int[n];
            int chet = 0;
            int nechet = 0;
            Random random = new Random();
            for (int i = 1; i < n; i++)
            {
                mass[i] = random.Next(100, 1000);
                textBox1.Text += i+ ") Осадков: " + mass[i]+" мм\r\n";
                if ((mass[i] % 2) == 0)
                    chet+= mass[i];
                else
                    nechet+= mass[i];
            }
            textBox1.Text += "По четным: "+ chet + "\r\n";
            textBox1.Text += "По не четным: "+ nechet;
            if (chet - nechet > 0)
                MessageBox.Show("Верно", "Результат");
            else
                MessageBox.Show("Не верно", "Результат"); 
        }
    }
}
