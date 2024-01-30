using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Text.RegularExpressions;


namespace Расчетка
{
    public partial class Form1 : Form
    {
        private SQLiteConnection DB;

        public Form1()
        {
            InitializeComponent();
        }

        static public string goroda;
        static public string gorodb;
        static public string kdata;
        static public string data;

        private void cBox1()
        {

            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "select distinct Откуда from Рейсы";
            SQLiteDataReader SQL = CMD.ExecuteReader();
            if (SQL.HasRows)
            {
                while (SQL.Read())
                {
                    comboBox1.Items.Add(SQL["Откуда"]);
                }
            }
        }
        private void cBox2()
        {

            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "select distinct Куда from Рейсы";
            SQLiteDataReader SQL = CMD.ExecuteReader();
            if (SQL.HasRows)
            {
                while (SQL.Read())
                {
                    comboBox2.Items.Add(SQL["Куда"]);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection("Data Source=DataBase.db; Version=3");
            DB.Open();
            cBox1();
            cBox2();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Close();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                goroda = comboBox1.SelectedItem.ToString();
                gorodb = comboBox2.SelectedItem.ToString();
                kdata = dateTimePicker1.Value.ToString("D");
                data = dateTimePicker1.Value.ToString("dd.MM.yyyy"); ;

                Hide();
                Form2 Form2 = new Form2();
                Form2.ShowDialog();
                Close();
                //tabControl1.SelectedTab = tabPage2;
            }
            else if (comboBox1.Text != "" && comboBox2.Text != "")
            {
                goroda = comboBox1.Text.ToString();
                gorodb = comboBox2.Text.ToString();
                kdata = dateTimePicker1.Value.ToString("D");
                data = dateTimePicker1.Value.ToString("dd.MM.yyyy"); ;

                Hide();
                Form2 Form2 = new Form2();
                Form2.ShowDialog();
                Close();
                //tabControl1.SelectedTab = tabPage2;
            }
            else MessageBox.Show("Введите город!");
        }

        private void BtAdmin_Click(object sender, EventArgs e)
        {
            //Hide();
            //FormAdmin FormAdmin = new FormAdmin();
            //FormAdmin.ShowDialog();
            //Close();
            Hide();
            CheckToAdmin CheckToAdmin = new CheckToAdmin();
            CheckToAdmin.ShowDialog();
            Close();
        }
    }
}
