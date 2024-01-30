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
using System.Data.SqlClient;

namespace Курсовая
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] fields = { "LostWeapon", "UniqueNumber", "TypeOfWeapon", "Date", "District" };
            listBox1.Items.AddRange(fields);

            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;


            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "*.xls;*.xlsx";
            ofd.Filter = "Microsoft Excel (*.xls*)|*.xls*";
            ofd.Title = "Выберите документ для загрузки данных";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Вы не выбрали файл для открытия", "Загрузка данных...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
            ofd.FileName + ";Extended Properties='Excel 12.0 XML;HDR=YES;IMEX=1';";

            System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection(constr);
            
             con.Open();
            DataSet ds = new DataSet();
            DataTable schemaTable = con.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string sheet1 = (string)schemaTable.Rows[0].ItemArray[2];
            string select = String.Format("SELECT * FROM [{0}] ", sheet1);
            System.Data.OleDb.OleDbDataAdapter ad = new System.Data.OleDb.OleDbDataAdapter(select, con);
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            con.Close();
            con.Dispose();
            dataGridView1.DataSource = dt;


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
       

            {
                
            }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string selectedFields = listBox1.SelectedItem.ToString();
            /*textBox1.Text = Convert.ToString(selectedFields);*/
            label2.Text = Question(selectedFields);
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public string Question(string question)
        {
            string question2 = question;
            string count = listBox2.Items.Count.ToString();
            switch (question2)
            {
                case "UniqueNumber":
                    question2 = "Выберите индивидуальный номер оружия";
                    string[] number = { "1", "2", "3", "4" };
                    Analyze(number);
                    break;
                case "TypeOfWeapon":
                    question2 = "Выберите вид оружия";
                    string[] typeofweapon = { "Combat", "Rifle", "Arm" };
                    Analyze(typeofweapon);
                    break;
                case "LostWeapon":
                    question2 = "Выберите утерянное или похищенное оружие";
                    string[] lostweapon = { "Dropped", "Stolen" };
                    Analyze(lostweapon);
                    break;
                case "Date":
                    question2 = "Выберите время года утраты оружия";
                    string[] date = { "Winter", "Spring","Summer", "Autumn" };
                    Analyze(date);
                    break;
                case "District":
                    question2 = "Выберите район утраты оружия";
                    string[] district = { "Leninskyi", "Promishleniy", "Zadneprovskiy" };
                    Analyze(district);
                    break;
            }
            return question2;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           /*string[] fields = { "Leninskyi", "Promishleniy", "Zadneprovskiy"};
            listBox2.Items.AddRange(fields);*/

            /*listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            string selectedFields = listBox2.SelectedItem.ToString();
            label2.Text = Question(selectedFields);*/
        }

        public void Analyze(string[] analyze1)
        {
            string[] Analyze = analyze1;
            string count = listBox2.Items.Count.ToString();

            if (Convert.ToInt32(count) > 0)
            {
                listBox2.Items.Clear();
                string[] fields =  Analyze ;
                listBox2.Items.AddRange(fields);
            }
            else
            {
                string[] fields =  Analyze ;
                listBox2.Items.AddRange(fields);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selectedfields = listBox1.SelectedItem.ToString();
            string selectedfields2 = listBox2.SelectedItem.ToString();


            string path = "D:\\2курс-20191012T183954Z-001\\2курс\\Raschet\\Книга1.xlsx";
            String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
           path + ";Extended Properties='Excel 12.0 XML;HDR=YES;IMEX=1';";

            System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection(constr);
            
            con.Open();
            DataSet ds = new DataSet();
            DataTable schemaTable = con.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string sheet1 = (string)schemaTable.Rows[0].ItemArray[2];
            string select = String.Format("SELECT * FROM [{0}] WHERE " + selectedfields + " like " + "'" + selectedfields2 + "'", sheet1);
             System.Data.OleDb.OleDbDataAdapter ad = new System.Data.OleDb.OleDbDataAdapter(select, con);
             ad.Fill(ds);
             DataTable dt = ds.Tables[0];
             con.Close();
             con.Dispose();
             dataGridView2.DataSource = dt;
        }
        
        public void checkfields()
        {
            string selectedfields = listBox1.SelectedItem.ToString();
            string selectedfields2 = listBox2.SelectedItem.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }
