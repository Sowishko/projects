using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lb66
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public class rectangle
        {
            public static bool brake = false;
            int x, y, shirina, visota;

            public rectangle(int x, int y, int shirina, int visota)
            {
                this.x = x;
                this.y = y;
                this.shirina = shirina;
                this.visota = visota;
            }
            public void perem(int l, int h, ref int x, ref int y)
            {
                x -= l;
                y -= h;
            }

            public void sovm(int x1, int x2, int y1, int y2, int shirina1, int shirina2, int visota1, int visota2)
            {

                if (x1 > x2)
                {
                    int buf = x1;
                    x1 = x2;
                    x2 = buf;
                }
                if (x1 + shirina1 < x2 + shirina2)
                {
                    x = x1;
                    shirina = x2 - x1 + shirina2;
                }
                else
                {
                    x = x1;
                    shirina = shirina2;
                }
                ////////////////////////
                if (y1 > y2)
                {
                    int buf = y1;
                    y1 = y2;
                    y2 = buf;
                }
                if (y1 + visota1 < y2 + visota2)
                {
                    y = y1;
                    visota = y2 - y1 + visota2;
                }
                else
                {
                    y = y1;
                    visota = visota2;
                }
                Console.WriteLine("x={0},y={1},shirina={2},visota={3}", x, y, shirina, visota);
            }



            public void izm(int x, int y, ref int shirina, ref int visota)
            {
                shirina -= x;
                visota -= y;
            }

            public void show(int x, int y, int shirina, int visota)
            {
                Console.WriteLine("{0} {1} {2} {3}", x, y, shirina, visota);
            }

        }
        //-----------------------------------------------------------------------------------------------------------------------
        class Go
        {
            static void Main(string[] args)
            {

                Console.WriteLine("Строим по левой нижней точке, высоте и длине");
                Console.WriteLine("Варианты команд:\n Perem Izm Show Sovm Exit");

                int x = 0, y = 0, shirina = 1, visota = 1;
                int x2 = 3, y2 = 2, shirina2 = 3, visota2 = 2;
                rectangle rect1 = new rectangle(x, y, shirina, visota);
                // Здесь менять на сколько перемещать и изменять.
                int izmx = 1, izmy = 1;
                int perx = 1, pery = 1;
                //
                Console.WriteLine("Введите комманду");
                do
                {
                    switch (Console.ReadLine())
                    {
                        case "Perem": rect1.perem(perx, pery, ref x, ref y); break;
                        case "Izm": rect1.izm(izmx, izmy, ref shirina, ref visota); break;
                        case "Show": rect1.show(x, y, shirina, visota); break;
                        case "Sovm": rect1.sovm(x, x2, y, y2, shirina, shirina2, visota, visota2); break;
                        case "Exit": rectangle.brake = true; break;
                        default: Console.WriteLine("Не, ну это не серьёзно, вводи!"); break;
                    }
                } while (!rectangle.brake);
            }
        }
    }
}
