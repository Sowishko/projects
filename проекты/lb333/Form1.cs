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

namespace lb333
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Открытие выбранного файла
                StreamReader f = new StreamReader(openFileDialog1.FileName);
                String pattern = @"\b(\w+)";
                String s;
                int total = 0;
                Regex r = new Regex(pattern);
                // Чтение выбранного файла по строкам
                while ((s = f.ReadLine()) != null)
                {
                    Match m = r.Match(s);
                    // Поиск регулярного выражения в очередной строке
                    while (m.Success)
                    {
                        total++;
                        m = m.NextMatch();
                    }
                }
                f.Close();
                textBox1.Text = Convert.ToString(total);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            textBox2.Text. Clear();
            if (textBox2.Text != "")
            {
                List<string> WordList = new List<string>();
                string Temp;
                for (int i = 0; i < textBox2.TextLength; i++)
                {
                    if (!char.IsLetterOrDigit(textBox2[i]))
                    {
                        Temp = "";
                        for (int j = 0; j < i; j++)
                        {
                            Temp += Convert.ToString(textBox2[j]);
                        }
                        textBox2 = textBox2.Remove(0, i);
                        WordList.Add(Temp);
                        WordList.Add(Convert.ToString(textbox2[0]));
                        textBox2 = textBox2.Remove(0, 1);
                        i = 0;
                    }
                }
                if (textBox2 != "")
                {
                    WordList.Add(textBox2);
                }
                List<string> WordListOne = new List<string>();
                WordListOne = WordList.GetRange(0, WordList.Count);
                Temp = "";
                for (int i = 0; i < WordListOne.Count; i++)
                {
                    Temp = WordListOne[i];
                    if (Temp.Length == 1)
                    {
                        if (!char.IsLetterOrDigit(Convert.ToChar(Temp)))
                        {
                            WordListOne.RemoveAt(i);
                            i--;
                            continue;
                        }
                    }
                    WordListOne.RemoveAt(i);
                    if (WordListOne.FindIndex(s => s.ToLower() == Temp.ToLower()) != -1)
                    {
                        WordListOne.RemoveAll(s => s.ToLower() == Temp.ToLower());
                        i--;
                        continue;
                    }
                    else
                    {
                        WordListOne.Insert(i, Temp);
                    }
                }
                /*List<Color> Colors_ = new List<Color>();
                for (int i = 0; i < WordListOne.Count; i++)
                {
                    Color c = Color.FromRgb((byte)r.Next(256), (byte)r.Next(256), (byte)r.Next(256));
                    Colors_.Add(c);
                }
                for (int i = 0; i < WordList.Count; i++)*/
               /* {
                    if (WordListOne.Contains(WordList[i]))
                    {
                        int index = WordListOne.IndexOf(WordList[i]);
                        paragraphRichtextbox2.Inlines.Add(WordList[i]);
                        paragraphRichtextbox2.Inlines.Last().Foreground = new SolidColorBrush(Colors_[index]);
                    }
                    else
                    {
                        paragraphRichtextbox2.Inlines.Add(WordList[i]);
                        paragraphRichtextbox2.Inlines.Last().Foreground = new SolidColorBrush(Colors.Black);
                    }*/
                }
                if (WordListOne.Count == 0)
                {
                    paragraphRichtextbox3.Inlines.Add("Слов, встречающихся в тексте по одному разу не найдено!!!");
                   /* paragraphRichtextbox3.Inlines.Last().Foreground = new SolidColorBrush(Colors.Black);*/
                }
                else
                {
                    for (int i = 0; i < WordListOne.Count; i++)
                    {
                        paragraphRichtextbox3.Inlines.Add(WordListOne[i]);
                       /* paragraphRichtextbox3.Inlines.Last().Foreground = new SolidColorBrush(Colors_[i]);*/
                        if (i != WordListOne.Count - 1)
                        {
                            paragraphRichtextbox3.Inlines.Add(", ");
                          /*  paragraphRichtextbox3.Inlines.Last().Foreground = new SolidColorBrush(Colors.Black);*/
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Вы не ввели текст", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
    }
}

