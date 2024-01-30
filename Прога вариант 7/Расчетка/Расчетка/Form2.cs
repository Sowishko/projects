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


namespace Расчетка
{
    public partial class Form2 : Form
    {
        private SQLiteConnection DB;
        static public string reis;
        static public string wagon;
        static public int mesto = 0;
        static public bool chekmesto = false;
        static public string wagonNum;
        static public string wagonType;
        static public string mestoNum;
        static public int SvMesta = 0;
        static public int ZMesta = 0;
        static public string mestoColor;
        static public int y;
        static public int x;
        ListItem[] ListItem = new ListItem[100];
        ListWagon[] ListWagon = new ListWagon[100];
        public Form2()
        {
            InitializeComponent();
            flowLayoutPanel2.Enabled = false;
            panel3.Enabled = false;
            panel4.Enabled = false;
            panel5.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var s = (DataGridView)sender;
            mesto = Int32.Parse((s[e.ColumnIndex, e.RowIndex].Value).ToString());
            //s.ClearSelection();
            chekMesto(mesto);

        }
        private void GoToTab2(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            flowLayoutPanel2.Enabled = true;
            Button btMest = (Button)sender;
            reis = ((int)btMest.Tag).ToString();
            label3.Text = "Выберите вагон, чтобы заказать билеты онлайн " + Form1.goroda + " → " + Form1.gorodb + ", " + Form1.kdata + ", рейс №" + reis;
            SerchWagon();
        }
        private void GoToTab3(object sender, EventArgs e)
        {
            if (mesto > 0)
            {
                Button btWg = (Button)sender;
                wagon = ((int)btWg.Tag).ToString();
                chekMesto(mesto);
                if (chekmesto == false)
                    MessageBox.Show("Место занято!");

                if (chekmesto == true)
                {
                    tabControl1.SelectedIndex = 2;
                    panel3.Enabled = true;
                }
            }
            else MessageBox.Show("Место не выбрано!");
        }

        public void PriceWagon()
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "SELECT Вагоны.Рейс, max(case when Вагоны.Тип ='Купе' then Вагоны.Цена else null end) max_Цена_Купе, max(case when Вагоны.Тип ='Сидячий' then Вагоны.Цена else null end) max_Цена_Сидячий, max(case when Вагоны.Тип ='Плацкарт' then Вагоны.Цена else null end) max_Цена_Плацкарт, max(case when Вагоны.Тип ='Люкс' then Вагоны.Цена else null end) max_Цена_Люкс, MIN(case when Вагоны.Тип ='Купе' then Вагоны.Цена else null end) min_Цена_Купе, MIN(case when Вагоны.Тип ='Сидячий' then Вагоны.Цена else null end) min_Цена_Сидячий, MIN(case when Вагоны.Тип ='Плацкарт' then Вагоны.Цена else null end) min_Цена_Плацкарт, MIN(case when Вагоны.Тип ='Люкс' then Вагоны.Цена else null end) min_Цена_Люкс FROM Вагоны LEFT JOIN Рейсы ON Рейсы.Рейс = Вагоны.Рейс  where Рейсы.Дата = '" + Form1.data + "' group by Вагоны.Рейс";
            SQLiteDataReader SQL = CMD.ExecuteReader();

            int i = 0;
            if (SQL.HasRows)
            {
                while (SQL.Read())
                {
                    ListItem[i] = new ListItem();
                    ListItem[i].SidPrice = (SQL["min_Цена_Сидячий"]).ToString();
                    ListItem[i].KupePrice = (SQL["min_Цена_Купе"]).ToString();
                    ListItem[i].PlacPrice = (SQL["min_Цена_Плацкарт"]).ToString();
                    ListItem[i].LuksPrice = (SQL["min_Цена_Люкс"]).ToString();
                    i++;
                }
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection("Data Source=DataBase.db; Version=3");
            DB.Open();
            label1.Text = "Выберите поезд, чтобы заказать билеты онлайн " + Form1.goroda + " → " + Form1.gorodb + ", " + Form1.kdata;
            SerchReis();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Close();
        }
        public void SerchReis()
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "select distinct Рейсы.Рейс, Рейсы.Откуда, Рейсы.Куда, Рейсы.Отправление, Рейсы.Прибытие, ifnull(Места.КолМест,0) as Всего_мест, Занятые_Места.Занятые_КолМест, ifnull(Места.КолМест_Купе,0)-ifnull(Занятые_Места.Занятые_КолМест_Купе,0) as Свободные_купе, ifnull(Места.КолМест_Сидячий,0)-ifnull(Занятые_Места.Занятые_КолМест_Сидячий,0) as Свободные_сидячий, ifnull(Места.КолМест_Люкс,0)-ifnull(Занятые_Места.Занятые_КолМест_Люкс,0) as Свободные_люкс, ifnull(Места.КолМест_Плацкарт,0)-ifnull(Занятые_Места.Занятые_КолМест_Плацкарт,0) as Свободные_плацкарт from Рейсы Left Join Вагоны ON Рейсы.Рейс = Вагоны.Рейс Left join (Select Места.Рейс, count(*) as КолМест, sum(case when Вагоны.Тип = 'Купе' then 1 else 0 end) as КолМест_Купе, sum(case when Вагоны.Тип = 'Сидячий' then 1 else 0 end) as КолМест_Сидячий, sum(case when Вагоны.Тип = 'Плацкарт' then 1 else 0 end) as КолМест_Плацкарт, sum(case when Вагоны.Тип = 'Люкс' then 1 else 0 end) as КолМест_Люкс from Места join Вагоны on Места.Рейс=Вагоны.Рейс and Места.Вагон=Вагоны.Номер Group By Места.Рейс) as Места on Рейсы.Рейс=Места.Рейс Left join (Select Места.Рейс, count(*) as Занятые_КолМест, sum(case when Вагоны.Тип = 'Купе' then 1 else 0 end) as Занятые_КолМест_Купе, sum(case when Вагоны.Тип = 'Сидячий' then 1 else 0 end) as Занятые_КолМест_Сидячий, sum(case when Вагоны.Тип = 'Плацкарт' then 1 else 0 end) as Занятые_КолМест_Плацкарт, sum(case when Вагоны.Тип = 'Люкс' then 1 else 0 end) as Занятые_КолМест_Люкс from Места join Вагоны on Места.Рейс=Вагоны.Рейс and Места.Вагон=Вагоны.Номер join Билеты on Билеты.Рейс=Вагоны.Рейс and Билеты.Вагон=Вагоны.Номер and Билеты.Место=Места.Место Group By Места.Рейс) as Занятые_Места on Рейсы.Рейс=Занятые_Места.Рейс where Рейсы.Откуда = @goroda and Рейсы.Куда = @gorodb and  Рейсы.Дата = '" + Form1.data + "'";
            CMD.Parameters.Add("@goroda", System.Data.DbType.String).Value = Form1.goroda;
            CMD.Parameters.Add("@gorodb", System.Data.DbType.String).Value = Form1.gorodb;
            SQLiteDataReader SQL = CMD.ExecuteReader();

            int i = 0;
            if (SQL.HasRows)
            {
                while (SQL.Read())
                {
                    ListItem[i] = new ListItem();
                    PriceWagon();
                    if (Int32.Parse((SQL["Свободные_сидячий"]).ToString()) + Int32.Parse((SQL["Свободные_купе"]).ToString()) + Int32.Parse((SQL["Свободные_плацкарт"]).ToString()) + Int32.Parse((SQL["Свободные_люкс"]).ToString()) > 0)
                    {
                        ListItem[i].NumbersReis = "№" + (SQL["Рейс"]).ToString();
                        ListItem[i].Timea = (SQL["Отправление"]).ToString();
                        ListItem[i].Timeb = (SQL["Прибытие"]).ToString();
                        ListItem[i].Goroda = (SQL["Откуда"]).ToString();
                        ListItem[i].Gorodb = (SQL["Куда"]).ToString();


                        if ((SQL["Свободные_сидячий"]).ToString() == "0")
                        {
                            ListItem[i].SidPriceVisible = false;
                            ListItem[i].Rubl1 = "";
                            ListItem[i].Ot1 = "";
                            ListItem[i].SidPlace = "Таких вагонов нет";
                        }
                        else ListItem[i].SidPlace = (SQL["Свободные_сидячий"]).ToString();

                        if ((SQL["Свободные_купе"]).ToString() == "0")
                        {
                            ListItem[i].KupePriceVisible = false;
                            ListItem[i].Rubl2 = "";
                            ListItem[i].Ot2 = "";
                            ListItem[i].KupePlace = "Таких вагонов нет";
                        }
                        else ListItem[i].KupePlace = (SQL["Свободные_купе"]).ToString();

                        if ((SQL["Свободные_плацкарт"]).ToString() == "0")
                        {
                            ListItem[i].PlacPrice = "";
                            ListItem[i].PlacPriceVisible = false;
                            ListItem[i].Rubl3 = "";
                            ListItem[i].Ot3 = "";
                            ListItem[i].PlacPlace = "Таких вагонов нет";
                        }
                        else ListItem[i].PlacPlace = (SQL["Свободные_плацкарт"]).ToString();

                        if ((SQL["Свободные_люкс"]).ToString() == "0")
                        {
                            ListItem[i].LuksPriceVisible = false;
                            ListItem[i].Rubl4 = "";
                            ListItem[i].Ot4 = "";
                            ListItem[i].LuksPlace = "Таких вагонов нет";
                        }
                        else ListItem[i].LuksPlace = (SQL["Свободные_люкс"]).ToString();
                        ListItem[i].btMest.Tag = Int32.Parse((SQL["Рейс"]).ToString());
                        ListItem[i].btMest.Click += new System.EventHandler(GoToTab2);
                        if (flowLayoutPanel1.Controls.Count < 0)
                        {
                            flowLayoutPanel1.Controls.Clear();
                        }
                        else
                            flowLayoutPanel1.Controls.Add(ListItem[i]);
                        i++;
                    }
                }

            }
            else
            {
                Close();
                MessageBox.Show("Рейсов по этому маршруту нет, выберите другой!");
                Hide();
                Form1 Form1 = new Form1();
                Form1.ShowDialog();
                Close();

            }
        }
        private void WgMesta(int i)
        {
            mesto = 0;
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "SELECT * FROM Места where Места.Вагон = '" + wagonNum + "' and Места.Рейс = '" + reis + "'";
            SQLiteDataReader SQL = CMD.ExecuteReader();
            if (SQL.HasRows)
            {
                if (wagonType == "Купе")
                {
                    x = 0;
                    ListWagon[i].DataRow = 2;
                    ListWagon[i].DataColumn = 18;
                    while (SQL.Read())
                    {
                        SvMesta++;
                        mestoNum = (SQL["Место"]).ToString();
                        if (Int32.Parse((SQL["Место"]).ToString()) % 2 == 0)
                        {
                            ListWagon[i].y = 0;
                            ListWagon[i].x = x;
                            ListWagon[i].DataColor = Color.Gray;
                            ListWagon[i].Data = (SQL["Место"]).ToString();
                            ListWagon[i].dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
                            x++;
                        }
                        else
                        {
                            ListWagon[i].y = 1;
                            ListWagon[i].x = x;
                            ListWagon[i].DataColor = Color.Gray;
                            ListWagon[i].Data = (SQL["Место"]).ToString();
                            ListWagon[i].dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
                        }
                        WgMesto(i);
                        if (flowLayoutPanel2.Controls.Count < 0)
                        {
                            flowLayoutPanel2.Controls.Clear();
                        }
                        else
                            flowLayoutPanel2.Controls.Add(ListWagon[i]);
                    }
                }
                if (wagonType == "Сидячий")
                {
                    x = 0;
                    ListWagon[i].DataRow = 2;
                    ListWagon[i].DataColumn = 28;
                    while (SQL.Read())
                    {
                        SvMesta++;
                        mestoNum = (SQL["Место"]).ToString();
                        if (Int32.Parse((SQL["Место"]).ToString()) % 2 == 0)
                        {
                            ListWagon[i].y = 1;
                            ListWagon[i].x = x;
                            ListWagon[i].DataColor = Color.Gray;
                            ListWagon[i].Data = (SQL["Место"]).ToString();
                            ListWagon[i].dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
                            x++;
                        }
                        else
                        {
                            ListWagon[i].y = 0;
                            ListWagon[i].x = x;
                            ListWagon[i].DataColor = Color.Gray;
                            ListWagon[i].Data = (SQL["Место"]).ToString();
                            ListWagon[i].dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
                        }
                        WgMesto(i);
                        if (flowLayoutPanel2.Controls.Count < 0)
                        {
                            flowLayoutPanel2.Controls.Clear();
                        }
                        else
                            flowLayoutPanel2.Controls.Add(ListWagon[i]);
                    }
                }
                if (wagonType == "Плацкарт")
                {
                    x = 0;
                    ListWagon[i].DataRow = 2;
                    ListWagon[i].DataColumn = 27;
                    while (SQL.Read())
                    {
                        SvMesta++;
                        mestoNum = (SQL["Место"]).ToString();
                        if (Int32.Parse((SQL["Место"]).ToString()) % 2 == 0)
                        {
                            ListWagon[i].y = 1;
                            ListWagon[i].x = x;
                            ListWagon[i].DataColor = Color.Gray;
                            ListWagon[i].Data = (SQL["Место"]).ToString();
                            ListWagon[i].dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
                            x++;
                        }
                        else
                        {
                            ListWagon[i].y = 0;
                            ListWagon[i].x = x;
                            ListWagon[i].DataColor = Color.Gray;
                            ListWagon[i].Data = (SQL["Место"]).ToString();
                            ListWagon[i].dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
                        }
                        WgMesto(i);
                        if (flowLayoutPanel2.Controls.Count < 0)
                        {
                            flowLayoutPanel2.Controls.Clear();
                        }
                        else
                            flowLayoutPanel2.Controls.Add(ListWagon[i]);
                    }
                }
                if (wagonType == "Люкс")
                {
                    x = 0;
                    ListWagon[i].DataRow = 1;
                    ListWagon[i].DataColumn = 18;
                    while (SQL.Read())
                    {
                        SvMesta++;
                        mestoNum = (SQL["Место"]).ToString();
                        ListWagon[i].y = 0;
                        ListWagon[i].x = x;
                        WgMesto(i);
                        ListWagon[i].Data = (SQL["Место"]).ToString();
                        ListWagon[i].dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
                        x++;
                        if (flowLayoutPanel2.Controls.Count < 0)
                        {
                            flowLayoutPanel2.Controls.Clear();
                        }
                        else
                            flowLayoutPanel2.Controls.Add(ListWagon[i]);
                    }
                }
            }
            chekmesto = false;
        }
        private void chekMesto(int s)
        {
            chekmesto = false;
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "SELECT * FROM Билеты where Билеты.Место = '" + s + "' and Билеты.Вагон = '" + wagon + "' and Билеты.Рейс = '" + reis + "'";
            SQLiteDataReader SQL = CMD.ExecuteReader();
            if (SQL.HasRows)
            {
                while (SQL.Read())
                {
                    chekmesto = false;
                }
            }
            else
            {
                chekmesto = true;
            }
        }
        private void WgMesto(int i)
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "SELECT * FROM Билеты where Билеты.Место = '" + mestoNum + "' and Билеты.Вагон = '" + wagonNum + "' and Билеты.Рейс = '" + reis + "'";
            SQLiteDataReader SQL = CMD.ExecuteReader();
            if (SQL.HasRows)
            {
                while (SQL.Read())
                {
                    ZMesta++;
                    if ((SvMesta - ZMesta) > 0)
                    {
                        ListWagon[i].y = y;
                        ListWagon[i].x = x;
                        ListWagon[i].DataColor = Color.Gray;
                        mestoColor = "Color.Gray";

                        if (flowLayoutPanel2.Controls.Count < 0)
                        {
                            flowLayoutPanel2.Controls.Clear();
                        }
                        else
                            flowLayoutPanel2.Controls.Add(ListWagon[i]);
                    }
                    else
                        break;
                }
            }
            else
            {
                ListWagon[i].DataColor = Color.Blue;
                mestoColor = "Color.Blue";
            }
        }
        private void SerchWagon()
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "SELECT * FROM Вагоны where Вагоны.Рейс = '" + reis + "' ORDER BY Номер";
            SQLiteDataReader SQL = CMD.ExecuteReader();
            flowLayoutPanel2.Controls.Clear();
            this.flowLayoutPanel2.Controls.Add(this.panel2);
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.btBack2);
            int i = 0;
            if (SQL.HasRows)
            {
                while (SQL.Read())
                {
                    ListWagon[i] = new ListWagon();
                    ListWagon[i].WgNum = "№" + (SQL["Номер"]).ToString();
                    wagonNum = (SQL["Номер"]).ToString();
                    ListWagon[i].WgType = (SQL["Тип"]).ToString();
                    wagonType = (SQL["Тип"]).ToString();
                    ListWagon[i].WgPrice = (SQL["Цена"]).ToString();
                    ListWagon[i].WgInfo = (SQL["Инфо"]).ToString();
                    ListWagon[i].btWg.Tag = Int32.Parse((SQL["Номер"]).ToString());
                    WgMesta(i);
                    ListWagon[i].WgMesta = (SvMesta - ZMesta).ToString();
                    ListWagon[i].btWg.Click += new System.EventHandler(GoToTab3);

                    if ((SvMesta - ZMesta) < 1)
                    {
                        flowLayoutPanel2.Controls.Remove(ListWagon[i]);
                    }
                    else
                        flowLayoutPanel2.Controls.Add(ListWagon[i]);
                    i++;
                    SvMesta = 0;
                    ZMesta = 0;
                }
            }
        }

        private void BtBack_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 Form1 = new Form1();
            Form1.ShowDialog();
            Close();
        }

        private void btBack2_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 Form1 = new Form1();
            Form1.ShowDialog();
            Close();
        }

        private void btBron_Click(object sender, EventArgs e)
        {
            if (tbSurName.Text != "" && tbName.Text != "" && tbMiddleName.Text != "")
            {
                SQLiteCommand CMD = DB.CreateCommand();
                string FIO = tbSurName.Text + " " + tbName.Text + " " + tbMiddleName.Text;
                CMD.CommandText = "insert into Билеты(Рейс, Вагон, Место, ФИО) values('" + reis + "', '" + wagon + "', '" + mesto + "', '" + FIO + "')";
                CMD.ExecuteNonQuery();
                flowLayoutPanel1.Enabled = false;
                flowLayoutPanel2.Enabled = false;
                panel3.Enabled = false;
                panel4.Enabled = true;
                tabControl1.SelectedIndex = 3;
            }
        }

        private void BtDalee_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
            panel4.Enabled = false;
            panel5.Enabled = true;
            lbB1.Text = "Уважвемый " + tbName.Text + " " + tbMiddleName.Text + "\nРегистрация на рейс: №" + reis + " " + Form1.goroda + " → " + Form1.gorodb + ", " + Form1.kdata + " прошла успешно!";
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "select Рейсы.Рейс, Вагоны.Номер, Места.Место, Рейсы.Откуда, Рейсы.Куда, Рейсы.Отправление, Рейсы.Прибытие, Вагоны.Тип, Места.ТипМеста, Вагоны.Цена, Рейсы.Дата from Места left join Вагоны on Места.Рейс=Вагоны.Рейс and Места.Вагон=Вагоны.Номер left join Рейсы on Рейсы.Рейс = Вагоны.Рейс where Места.Рейс = '" + reis + "' and Места.Вагон = '" + wagon + "' and Места.Место = '" + mesto + "'";
            SQLiteDataReader SQL = CMD.ExecuteReader();
            if (SQL.HasRows)
            {
                while (SQL.Read())
                {
                    lbB2.Text = "Рейс: " + (SQL["Рейс"]).ToString();
                    lbB3.Text = "Вагон: " + (SQL["Номер"]).ToString();
                    lbB4.Text = "Место: " + (SQL["Место"]).ToString();
                    lbB5.Text = "Откуда: " + (SQL["Откуда"]).ToString();
                    lbB6.Text = "Куда: " + (SQL["Куда"]).ToString();
                    lbB7.Text = "Отправление: " + (SQL["Отправление"]).ToString();
                    lbB8.Text = "Прибытие: " + (SQL["Прибытие"]).ToString();
                    lbB9.Text = "Тип вагона: " + (SQL["Тип"]).ToString();
                    lbB10.Text = "Тип места: " + (SQL["ТипМеста"]).ToString();
                    lbB11.Text = "Цена: " + (SQL["Цена"]).ToString();
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printDocument1.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            var bitmap = new Bitmap(panel7.Width, panel7.Height);
            panel7.DrawToBitmap(bitmap, new Rectangle(Point.Empty, bitmap.Size));
            e.Graphics.DrawImage(bitmap, new Point(0, 0));
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
    }
}
