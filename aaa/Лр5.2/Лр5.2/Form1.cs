using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Лр5._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Clear();
                int f = 0;
                string file1 = File.ReadAllText(openFileDialog1.FileName, Encoding.GetEncoding(1251));
                textBox1.Text = file1.ToString();
                for (int i = 0; i < file1.Length; i++)
                {
                    if (file1[i].ToString() == "(")
                        f++;
                    else if (file1[i].ToString() == ")")
                        f--;
                }
                if (f == 0)
                    MessageBox.Show(" Да, всё верно", "Результат");
                else
                    MessageBox.Show(" Нет неправильно", "Результат");
            }
        }
    }
}
