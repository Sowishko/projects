using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string str = "",str2 = "";
        private void ChooseFile_Click(object sender, EventArgs e)
        {
            string FileWay;
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Файлы txt|*.txt|Файлы cs|*.cs";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                FileWay = OPF.FileName;
            }
            else
                return;
            FileStream tempfile = new FileStream(FileWay, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(tempfile, Encoding.UTF8);
            Regex r = new Regex(@"([0123456789ABCDEF]{2}-){5}[0123456789ABCDEF]{2}");
            while ((str = reader.ReadLine()) != null)
            {
                Match m = r.Match(str);
                while (m.Success)
                {
                    str2 += m.Groups[0].Value  + "\r\n";
                    m = m.NextMatch();
                }   
            }
            reader.Close();
            TextB.Text = str2;
        }
    }
}
