using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//namespace laba66
//{
  //  public partial class Form1 : Form
    //{
      //  public Form1()
        //{
         //   InitializeComponent();
       // }

//        private void button1_Click(object sender, EventArgs e)
  //      {
  
  //      }
    //}
//}

//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;

namespace laba66 
{
    public partial class Form1 : Form
    {
        public CRect Rect;
        public CRectMod RectMod;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rect.ClearWin(pictureBox1);
            Rect.Draw(pictureBox1);
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            RectMod = new CRectMod(0, 0);
            Rect = new CRect(50, 25);
            Rect.x = 50;
            Rect.y = 25;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rect.ClearWin(pictureBox1);
            Rect.dy -= 10;
            Rect.Draw(pictureBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rect.ClearWin(pictureBox1);
            Rect.dy += 10;
            Rect.Draw(pictureBox1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Rect.ClearWin(pictureBox1);
            Rect.dx -= 10;
            Rect.Draw(pictureBox1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Rect.ClearWin(pictureBox1);
            Rect.dx += 10;
            Rect.Draw(pictureBox1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Rect.ClearWin(pictureBox1);
            Rect.ddx += 10;
            Rect.ddy += 6;
            Rect.Draw(pictureBox1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Rect.ClearWin(pictureBox1);
            Rect.ddx -= 10;
            Rect.ddy -= 6;
            Rect.Draw(pictureBox1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RectMod.x1 = Convert.ToInt32(textBox1.Text);
            RectMod.y1 = Convert.ToInt32(textBox2.Text);
            RectMod.h1 = Convert.ToInt32(textBox3.Text);
            RectMod.w1 = Convert.ToInt32(textBox4.Text);
            RectMod.x2 = Convert.ToInt32(textBox5.Text);
            RectMod.y2 = Convert.ToInt32(textBox6.Text);
            RectMod.h2 = Convert.ToInt32(textBox7.Text);
            RectMod.w2 = Convert.ToInt32(textBox8.Text);
            RectMod.ClearWin(pictureBox1);
            RectMod.opredmin();
            RectMod.Draw(pictureBox1);
            Graphics k = pictureBox1.CreateGraphics();
            SolidBrush BlueBrush = new SolidBrush(Color.Blue);
            k.FillRectangle(BlueBrush, RectMod.x - RectMod.dx, RectMod.y - RectMod.dy, RectMod.x + RectMod.ddx, RectMod.y + RectMod.ddy);
            RectMod.x = RectMod.x1;
            RectMod.y = RectMod.y1;
            RectMod.ddx = RectMod.h1 - RectMod.x1;
            RectMod.ddy = RectMod.w1 - RectMod.y1;
            RectMod.Draw(pictureBox1);
            RectMod.x = RectMod.x2;
            RectMod.y = RectMod.y2;
            RectMod.ddx = RectMod.h2 - RectMod.x2;
            RectMod.ddy = RectMod.w2 - RectMod.y2;
            RectMod.Draw(pictureBox1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            RectMod.x1 = Convert.ToInt32(textBox1.Text);
            RectMod.y1 = Convert.ToInt32(textBox2.Text);
            RectMod.h1 = Convert.ToInt32(textBox3.Text);
            RectMod.w1 = Convert.ToInt32(textBox4.Text);
            RectMod.x2 = Convert.ToInt32(textBox5.Text);
            RectMod.y2 = Convert.ToInt32(textBox6.Text);
            RectMod.h2 = Convert.ToInt32(textBox7.Text);
            RectMod.w2 = Convert.ToInt32(textBox8.Text);
            RectMod.ClearWin(pictureBox1);
            RectMod.x = RectMod.x1;
            RectMod.y = RectMod.y1;
            RectMod.ddx = RectMod.h1 - RectMod.x1;
            RectMod.ddy = RectMod.w1 - RectMod.y1;
            RectMod.Draw(pictureBox1);
            RectMod.x = RectMod.x2;
            RectMod.y = RectMod.y2;
            RectMod.ddx = RectMod.h2 - RectMod.x2;
            RectMod.ddy = RectMod.w2 - RectMod.y2;
            RectMod.Draw(pictureBox1);
        }
    }
    public class CRect : Object
    {
        public int x, y, dx = 0, dy = 0, ddx = 0, ddy = 0;
        public void ClearWin(PictureBox pbx1)
        {
            Graphics e = pbx1.CreateGraphics();
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            e.FillRectangle(whiteBrush, 0, 0, pbx1.Width, pbx1.Height);
        }
        public void Draw(PictureBox pbx1)
        {
            Graphics e = pbx1.CreateGraphics();
            e.DrawRectangle(Pens.Black, x - dx, y - dy, x + ddx, y + ddy);
        }
        public CRect(int we, int he)
        {
            we = x;
            he = y;
        }
    }

    public class CRectMod : CRect
    {
        public int x1, y1, x2, y2, xf, yf, h1, w1, h2, w2;
        public CRectMod(int x, int y) : base(x, y)
        {
            x = x1;
            y = y1;
        }
        public void opredmin()
        {
            if (x1 <= x2) x = x1;
            if (x2 < x1) x = x2;
            if (y1 <= y2) y = y1;
            if (y2 < y1) y = y2;
            if (x == x1) ddx = x2 - x1 * 2 + h2;
            if (x == x2) ddx = x1 - x2 * 2 + h1;
            if (y == y1) ddy = y2 + w2 - y1 * 2;
            if (y == y2) ddy = y1 + w1 - y2 * 2;

        }
    }

}

