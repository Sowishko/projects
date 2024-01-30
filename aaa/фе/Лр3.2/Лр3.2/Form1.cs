using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лр3._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string file1;
        string file2;
        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox3.Text != "")//Защита от пустого ввода
            {
                string pattern1 = textBox1.Text;
                string pattern2 = textBox3.Text;
                string f = textBox2.Text;
                label4.Text = "Результат замены из файла g";
                textBox4.Text = new Regex(pattern1).Replace(f, pattern2);
                File.WriteAllText(file2, textBox4.Text, Encoding.GetEncoding(1251));
            }
            else
            {
                MessageBox.Show("Введите что-нибудь.");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file1 = openFileDialog1.FileName;
                textBox2.Text = File.ReadAllText(file1, Encoding.GetEncoding(1251));
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                file2 = openFileDialog2.FileName;
                textBox4.Text = File.ReadAllText(file2, Encoding.GetEncoding(1251));
                label4.Text = "Содержимое файла g";
            }
        }
    }
}
