using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2._5тп
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string str = "";
        private void B1_Click(object sender, EventArgs e)
        {
            try
            {
                str = "";
                string _FileWay;
                OpenFileDialog OPF = new OpenFileDialog();
                OPF.Filter = "Файлы txt|*.txt|Файлы cs|*.cs";
                if (OPF.ShowDialog() == DialogResult.OK)
                {
                    _FileWay = OPF.FileName;
                }
                else
                    return;
                FileStream tempfile = new FileStream(_FileWay, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(tempfile, Encoding.Default);
                str = reader.ReadToEnd();
                reader.Close();
                RezT.Text = str;
                RezT.Text += "\r\n " + NameT.Text + " " + SecondNameT.Text;
                tempfile = new FileStream(_FileWay, FileMode.Open, FileAccess.Write);
                StreamWriter writer = new StreamWriter(tempfile, Encoding.UTF8);
                writer.Write(RezT.Text);
                writer.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Пропущенны некоторые поля");
            }
        }

        private void B2_Click(object sender, EventArgs e)
        {
            string _FileWay;
            str = "";
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Файлы txt|*.txt|Файлы cs|*.cs";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                _FileWay = OPF.FileName;
            }
            else
                return;
            FileStream tempfile = new FileStream(_FileWay, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(tempfile, Encoding.UTF8);
            str = reader.ReadToEnd();
            reader.Close();
            TB.Text = str;
            String[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string strMax = words[0];
            string strMin = words[0];
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i].Length > strMax.Length)
                    strMax = words[i];
                if (words[i].Length < strMin.Length)
                    strMin = words[i];
            }
            Smax.Text = strMax;
            Smin.Text = strMin;
        }
    }
}
