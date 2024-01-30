using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lr2._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Random rand = new Random();
            int[][] mas = new int[6][];
            mas[0] = new int[2];
            mas[1] = new int[2];
            mas[2] = new int[6];
            mas[3] = new int[6];
            mas[4] = new int[2];
            mas[5] = new int[2];
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < mas[i].Length; j++)
                {
                    mas[i][j] = rand.Next(10);
                }
            dataGridView1.RowCount = 6;
            dataGridView1.ColumnCount = 6;
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < mas[i].Length; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = mas[i][j];
                }
        }
    }
}
