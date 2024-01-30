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

namespace _3._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string str;
        private void ChooseFile1_Click(object sender, EventArgs e)
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
            StreamReader reader = new StreamReader(tempfile, Encoding.UTF8);
            str = reader.ReadToEnd();
            reader.Close();
            NalText.Text = str;
            string temp;
            String[] Pr = str.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            str = "";
            for (int i = 0; i < Pr.Length; i++)
            {
                Pr[i] = Pr[i].Replace("\r\n", "");
                String[] words = Pr[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                
                for (int j = 0; j < words.Length; j = j + 2)
                {
                    if(words.Length % 2 != 0 && j == words.Length - 1)
                    {
                        str += " " + words[j] + "\r\n";
                        break;
                    }
                    else
                    {
                        temp = words[j];
                        words[j] = words[j + 1];
                        words[j + 1] = temp;
                        str += words[j] + " " + words[j + 1];
                    }
                }
            }
            RezText.Text = str;
        }

        private void ChooseFile2_Click(object sender, EventArgs e)
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
            StreamReader reader = new StreamReader(tempfile, Encoding.UTF8);
            str = reader.ReadToEnd();
            reader.Close();
            NalText2.Text = str;
            for (int i = 0; i < str.Length - 1; i++)
            {
                if ( (str[i] == 'ж' && str[i+1] == 'ы') || (str[i] == 'ш' && str[i+1] == 'ы') )
                {
                    str = str.Remove(i+1, 1);
                    str = str.Insert(i + 1, "и");
                    continue;
                }
                if ((str[i] == 'ч' && str[i + 1] == 'я') || (str[i] == 'щ' && str[i + 1] == 'я'))
                {
                    str = str.Remove(i + 1, 1);
                    str = str.Insert(i + 1, "а");
                    continue;
                }
                if ((str[i] == 'ч' && str[i + 1] == 'ю') || (str[i] == 'щ' && str[i + 1] == 'ю'))
                {
                    str = str.Remove(i + 1, 1);
                    str = str.Insert(i + 1, "у");
                    continue;
                }
            }
            RezText2.Text = str;
        }
    }
}
