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
            int n = 31;
            int[] mass = new int[n];
            int chet = 0;
            int nechet = 0;
            Random rnd = new Random();
            for (int i = 1; i < n; i++)
            {
                mass[i] = rnd.Next(10, 1000);
                if ((mass[i] % 2) == 0)
                    chet+= mass[i];
                else
                    nechet+= mass[i];
            }
            if (chet - nechet > 0)
                label2.Text = "ДА";
            else
                label2.Text = "НЕТ";
        }
    }
}
