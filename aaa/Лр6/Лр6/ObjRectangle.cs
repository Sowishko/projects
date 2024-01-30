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
    class ObjRectangle
    {
        public Color RectangleColor = Color.Black;
        public void CreateRectangle (Graphics graf, float scale, float height, float longP, float widthP)
        {
            Pen blackPen = new Pen(RectangleColor, 3);
            graf.DrawRectangle(blackPen, scale, height, longP, widthP);
            
        }
        public void UpAnRectangle(Graphics graf, float scale, float height, float longP, float widthP)
        {
            Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 3);
            graf.DrawRectangle(blackPen, scale, height, longP, widthP);

        }
        public void DownAnRectangle(Graphics graf, float scale, float height, float longP, float widthP)
        {
            Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 3);
            graf.DrawRectangle(blackPen, scale, height, longP, widthP);

        }
        public void UpNRectangle(Graphics graf, float scale, float height, float longP, float widthP)
        {
            Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 3);
            graf.DrawRectangle(blackPen, scale, height, longP, widthP);

        }
        public void DownNRectangle(Graphics graf, float scale, float height, float longP, float widthP)
        {
            Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 3);
            graf.DrawRectangle(blackPen, scale, height, longP, widthP);

        }
    }
    class ObjRectangles : ObjRectangle
    {
        
    }
}
