using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Лр6
{
    public partial class Form1 : Form
    {
        const float scale = 20.2F;
        public Form1()
        {
            InitializeComponent();
        }
        ObjRectangle Rectangle1 = new ObjRectangle();
        ObjRectangles Rectangle2 = new ObjRectangles();
        
        float longP;
        float widthP;
        float longPm;
        float widthPm;
        float height;
        private void Button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            Graphics graf = pictureBox1.CreateGraphics();
            longP = float.Parse(textBox1.Text) * scale;
            widthP = float.Parse(textBox2.Text) * scale;
            height = pictureBox1.Height - widthP - scale;
            Rectangle1.CreateRectangle(graf, scale, height, longP, widthP);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            Graphics graf = pictureBox1.CreateGraphics();
            float NlongP = float.Parse(textBox3.Text) * scale;
            float NwidthP = float.Parse(textBox4.Text) * scale;
            Rectangle1.UpAnRectangle(graf, scale, height - NwidthP, longP + NlongP, widthP + NwidthP);
            height = height - NwidthP;
            longP = longP + NlongP;
            widthP = widthP + NwidthP;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            Graphics graf = pictureBox1.CreateGraphics();
            float NlongP = float.Parse(textBox3.Text) * scale;
            float NwidthP = float.Parse(textBox4.Text) * scale;
            Rectangle1.UpAnRectangle(graf, scale, height + NwidthP, longP - NlongP, widthP - NwidthP);
            height = height + NwidthP;
            longP  = longP  - NlongP;
            widthP = widthP - NwidthP;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            Graphics graf = pictureBox1.CreateGraphics();
            float NlongP = float.Parse(textBox5.Text) * float.Parse(textBox5.Text) * scale;
            float NwidthP = float.Parse(textBox5.Text) * float.Parse(textBox5.Text) * scale;
            Rectangle1.UpAnRectangle(graf, scale, height - NwidthP, longP + NlongP, widthP + NwidthP);
            height = height - NwidthP;
            longP = longP + NlongP;
            widthP = widthP + NwidthP;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            Graphics graf = pictureBox1.CreateGraphics();
            float NlongP = float.Parse(textBox5.Text) * float.Parse(textBox5.Text) * scale;
            float NwidthP = float.Parse(textBox5.Text) * float.Parse(textBox5.Text) * scale;
            Rectangle1.DownAnRectangle(graf, scale, height + NwidthP, longP - NlongP, widthP - NwidthP);
            height = height + NwidthP;
            longP = longP - NlongP;
            widthP = widthP - NwidthP;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Graphics graf = pictureBox1.CreateGraphics();
            longP = float.Parse(textBox6.Text) * scale;
            widthP = float.Parse(textBox7.Text) * scale;
            height = pictureBox1.Height - widthP - scale;
            Rectangle1.CreateRectangle(graf, scale, height, longP, widthP);


            if (float.Parse(textBox1.Text) >= float.Parse(textBox6.Text))
            {
                longP = float.Parse(textBox1.Text) * scale;
                longPm = float.Parse(textBox6.Text) * scale;
            }
            else
            {
                longP = float.Parse(textBox6.Text) * scale;
                longPm = float.Parse(textBox1.Text) * scale;
            }
            if (float.Parse(textBox2.Text) >= float.Parse(textBox7.Text))
            {
                widthP = float.Parse(textBox2.Text) * scale;
                widthPm = float.Parse(textBox7.Text) * scale;
            }
            else
            {
                widthP = float.Parse(textBox7.Text) * scale;
                widthPm = float.Parse(textBox2.Text) * scale;
            }
            height = pictureBox1.Height - widthP - scale;
            Rectangle1.RectangleColor = Color.Red;
            Rectangle1.CreateRectangle(graf, scale, height, longP, widthP);

            Rectangle1.RectangleColor = Color.Blue;
            height = pictureBox1.Height - widthPm - scale;
            Rectangle1.CreateRectangle(graf, scale, height, longPm, widthPm);
        }
        private void Fool_Protect(object sender, KeyPressEventArgs e) //Относительно универсальный ввод только чисел в текстовое поле
        {
            TextBox senderTextBox = sender as TextBox;
            char number = e.KeyChar; //Нажатая кнопка.
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true; // Ввод отменяется
                senderTextBox.BackColor = Color.Red; //Красим текстбокс в красный
            }
            else//Если ввод нормальный
            {
                senderTextBox.BackColor = Color.White; //Красим текстбокс в белый. Можно без этого.
            }
        }
    }
}
