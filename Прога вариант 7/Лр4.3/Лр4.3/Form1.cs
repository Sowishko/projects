using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лр4._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            
            int[] a;
            int[] b;
            int an = 0;
            int ak = 0;
            int bn = 0;
            int bk = 0;

            bn = Convert.ToInt32(tbBn.Text);
            bk = Convert.ToInt32(tbBk.Text);
            an = Convert.ToInt32(tbAn.Text);
            ak = Convert.ToInt32(tbAk.Text);
            int an_buff = an;
            int bn_buff = bn;
            int ann = ak-an;
            int bnn = bk-bn;

            a = new int[ak-an];
            for (int i = 0; i < ann; ++i)
            {
                a[i] = an_buff;
                an_buff++;
            }

            b = new int[bk-bn];
            int f = 0;
            for (int i = 0; i < bnn; ++i)
            {
                b[i] = bn_buff;
                bn_buff++;
            }
            if (bnn > ann)
            {
                for (int i = 0; i < bnn; ++i)
                {
                    for (int j = 0; j < ann; ++j)
                    {
                        if (b[i] == a[j])
                            f++;
                    }
                }
                if (f == ann)
                    label4.Text = "ДА";
                else
                    label4.Text = "НЕТ";
            }
            else
                MessageBox.Show("Последовательность b меньше последовательности a");
        }

    }
}
