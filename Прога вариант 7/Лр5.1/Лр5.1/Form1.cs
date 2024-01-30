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
using System.Text.RegularExpressions;

namespace Лр5._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string file1;
        private void Button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file1 = openFileDialog1.FileName;
                string fileText;
                int fileNumber = 0;
                int summ = 0;
                fileText = File.ReadAllText(file1, Encoding.GetEncoding(1251));
                for (int i = 0; i < fileText.Length; i++)
                {
                    if (char.IsNumber(fileText[i]))
                    {

                        summ += Convert.ToInt32(fileText[i].ToString());
                        fileNumber++;
                    }
                }
                label1.Text = ("Средний балл: "+(summ/fileNumber).ToString());
            }
        }
    }
}
