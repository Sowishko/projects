using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lb2_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void AddColumns( DataGridView dgw)
        {
            DataGridViewColumn column;
            for (int i = 0; i < 8; i++)
            {
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "Column" + i.ToString();
                column.Name = "Column" + i.ToString();
                dgw.Columns.Add(column);
            }
        }
        private void AddRows( DataGridView dgw)
        {
            for (int i = 0; i < 8; i++)
            {
                dgw.Rows.Add();
                dgw.Rows[i].HeaderCell.Value = "row" + i.ToString();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int a = 0;
                int k = 0;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        while (Convert.ToInt32(dataGridView1[j, i].Value) == Convert.ToInt32(dataGridView1[i, j].Value))
                        {
                            a++;
                        }
                    }
                    if (a == 7)
                    {
                        k = i;

                        textBox1.Text += Convert.ToString(k + 1) + " строка и столбец совпадают" + (char)13 + (char)10;
                    }
                    else
                    {
                        textBox1.Text = Convert.ToString(i + 1) + " строка и столбец не совпадают" + (char)13 + (char)10;
                    }
                    a = 0;
                }
            }
            catch (Exception)
                {
                   
                }
        }
        private void button2_Click(object sender, EventArgs e)
        {
                try
                {

                    int k = 0;
                    Random r = new Random();
                    k = dataGridView1.ColumnCount;
                    if (k != 0)
                        for (int i = 0; i < k; i++)
                            dataGridView1.Columns.RemoveAt(0);
                    AddColumns(dataGridView1);
                    AddRows(dataGridView1);
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            dataGridView1[i, j].Value = r.Next(-1, 1);
                        }
                    }
                }
                catch (Exception)
                {
                   
                }
            
        }
    }
}
