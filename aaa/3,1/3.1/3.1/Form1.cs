using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace _3._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string str = "";
                StreamReader f = new StreamReader(openFileDialog1.FileName);
                String pattern = @"(\b\w+\b)";
                String s;
                Regex r = new Regex(pattern);
                while ((s = f.ReadLine()) != null)
                {
                    Match m = r.Match(s);
                    while (m.Success)
                    {
                        str += m.Groups[1].Value + " ";
                        m = m.NextMatch();
                    }
                }
                f.Close();
                textBox1.Text = Convert.ToString(str);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string str = "";
                StreamReader f = new StreamReader(openFileDialog1.FileName);
                String pattern = @"(\b\w{1,4}\b)";
                String s;
                Regex r = new Regex(pattern);
                while ((s = f.ReadLine()) != null)
                {
                    Match m = r.Match(s);
                    while (m.Success)
                    {
                        str += m.Groups[1].Value + " ";
                        m = m.NextMatch();
                    }
                }
                f.Close();
                textBox2.Text = Convert.ToString(str);
            }
        }
    }
}
