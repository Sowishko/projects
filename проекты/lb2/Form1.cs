using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lb2
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

        private void button1_Click(object sender, EventArgs e)
        {
            int n;        //размеры матрицы
            double[,] A;          //сами матрицы
            n = 8;
            n = Convert.ToInt32(textBox1.Text);
            A = new double[n, n];
            // Чистка DataGridView, усли они не пусты
            int k = 0;
            k = dataGridView1.ColumnCount;
            if (k != 0)
                for (int i = 0; i < k; i++)
                    dataGridView1.Columns.RemoveAt(0);
            // Заполнение DataGridView столбцами
            AddColumns(n, dataGridView1);
            // Заполнение DataGridView строками
            AddRows(n, dataGridView1);

        }
        private void AddColumns(int n, DataGridView dgw)
        {
            // добавляет n столбцов в элемент управления dgw
            DataGridViewColumn column;
            for (int i = 0; i < n; i++)
            {
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "Column" + i.ToString();
                column.Name = "Column" + i.ToString();
                dgw.Columns.Add(column);
            }
        }
        private void AddRows(int n, DataGridView dgw)
        {
            // добавляет m строк в элемент управления dgw
            for (int i = 0; i < n; i++)
            {
                dgw.Rows.Add();
                dgw.Rows[i].HeaderCell.Value = "row" + i.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*6textBox2.Clear();*/
            int n = 4;
            int[] sum = new int[n];
            int Sum = 0;
            //int n;*/
            for (int i=0; i < n; i++)
            {
                for (int j=0; j < n; j++)
                {
                    Sum +=  Convert.ToInt32(dataGridView1[i, j]);
                    sum[i] = Sum;
                    if (sum[i] < 0)
                    {
                        sum[i] = 0;
                        textBox2.Text += Convert.ToString(i + 1) + "строка содержит отрицательный элемент " + (char)13 + (char)10;
                        Sum = 0;
                        if (sum[i] > 0)
                        textBox2.Text += Convert.ToString(sum[i]) + (char)13 + (char) 10;
                    }

                }
            }

            /*int n;
            n = 3;
            int sum = 0;
            int[,] a = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)

                {
                    if (Convert.ToInt32(dataGridView1[i, j].Value) < 0)

                        {
                        
                           sum = sum + Convert.ToInt32(dataGridView1[i, j].Value);


                        break;
                    }
                    textBox2.Text = Convert.ToString(sum);*/
                }
            }
        }
    

