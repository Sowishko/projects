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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }
        private SQLiteConnection DB;
        string TypeMesta;
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection("Data Source=DataBase.db; Version=3");
            DB.Open();
            cBoxType.Items.Add("Купе");
            cBoxType.Items.Add("Сидячий");
            cBoxType.Items.Add("Люкс");
            cBoxType.Items.Add("Плацкарт");
            cBoxType.SelectedIndex = 0;

        }
        private void Wagon()
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "insert into Вагоны(Рейс, Номер, Тип, Инфо, Цена) values('" + tbWReis.Text + "', '" + tbNumW.Text + "', '"+ cBoxType.SelectedItem.ToString() + "', '"+ tbReisInfo.Text + "', '"+ tbPriceBilet.Text + "')";
            CMD.ExecuteNonQuery();
        }
        private void Kupe()
        {
            Wagon();
            for (int i = 1; i < 37; i++)
            {
                if (i % 2 == 0)
                {
                    TypeMesta = "Верхнее";
                }
                else
                    TypeMesta = "Нижнее";
                SQLiteCommand CMD = DB.CreateCommand();
                CMD.CommandText = "insert into Места(Рейс, Вагон, Место, ТипМеста) values('"+ tbWReis.Text + "', '"+ tbNumW.Text + "', '"+ i +"', '"+ TypeMesta + "')";
                CMD.ExecuteNonQuery();
            }
        }
        private void Sid()
        {
            Wagon();
            for (int i = 1; i < 57; i++)
            {
                TypeMesta = "Нижнее";
                SQLiteCommand CMD = DB.CreateCommand();
                CMD.CommandText = "insert into Места(Рейс, Вагон, Место, ТипМеста) values('" + tbWReis.Text + "', '" + tbNumW.Text + "', '" + i + "', '" + TypeMesta + "')";
                CMD.ExecuteNonQuery();
            }
        }
        private void Luks()
        {
            Wagon();
            for (int i = 1; i < 19; i++)
            {
                TypeMesta = "Нижнее";
                SQLiteCommand CMD = DB.CreateCommand();
                CMD.CommandText = "insert into Места(Рейс, Вагон, Место, ТипМеста) values('" + tbWReis.Text + "', '" + tbNumW.Text + "', '" + i + "', '" + TypeMesta + "')";
                CMD.ExecuteNonQuery();
            }
        }
        private void Plac()
        {
            Wagon();
            for (int i = 1; i < 55; i++)
            {
                if (i % 2 == 0)
                {
                    TypeMesta = "Верхнее";
                }
                else
                    TypeMesta = "Нижнее";
                SQLiteCommand CMD = DB.CreateCommand();
                CMD.CommandText = "insert into Места(Рейс, Вагон, Место, ТипМеста) values('" + tbWReis.Text + "', '" + tbNumW.Text + "', '" + i + "', '" + TypeMesta + "')";
                CMD.ExecuteNonQuery();
            }
        }
        private void deleteWagon()
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "delete from Вагоны where Рейс = '"+ tbDWReis.Text + "' and Номер = '"+ tbDNumW.Text + "'";
            CMD.ExecuteNonQuery();
        }
        private void deleteWMesta()
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "delete from Места where Рейс = '" + tbDWReis.Text + "' and Вагон = '" + tbDNumW.Text + "'";
            CMD.ExecuteNonQuery();
        }

        private void FormAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Close();
        }
        string data;
        private void Button1_Click(object sender, EventArgs e)
        {
            if (tbOtkuda.Text != "" && tbKuda.Text != ""  && tbReis.Text != "")
            {
                data = dateTimePicker1.Value.ToString("dd.MM.yyyy");
                SQLiteCommand CMD = DB.CreateCommand();
                CMD.CommandText = "insert into Рейсы(Дата, Рейс, Откуда, Куда, Отправление, Прибытие) values('"+ data + "', '"+ tbReis.Text.ToUpper() + "', '"+ tbOtkuda.Text + "', '"+ tbKuda.Text + "', '"+ tbOtpravlenie.Text.ToUpper() + "', '"+ tbPribitie.Text.ToUpper() + "')";
                CMD.ExecuteNonQuery();
                lbOK.Text = "Добавен!";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (tbDelitReis.Text != "")
            {
                SQLiteCommand CMD = DB.CreateCommand();
                CMD.CommandText = "delete from Рейсы where Рейс like '"+ tbDelitReis.Text + "'";
                CMD.ExecuteNonQuery();
                lbOK.Text = "Удален!";
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (tbWReis.Text != "" && tbNumW.Text != "" && tbPriceBilet.Text != "" && tbReisInfo.Text != "") {
                if (cBoxType.SelectedItem.ToString() == "Купе")
                {
                    Kupe();
                }
                if (cBoxType.SelectedItem.ToString() == "Сидячий")
                {
                    Sid();
                }
                if (cBoxType.SelectedItem.ToString() == "Люкс")
                {
                    Luks();
                }
                if (cBoxType.SelectedItem.ToString() == "Плацкарт")
                {
                    Plac();
                }
                lbOK2.Text = "Добавен!";
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (tbDWReis.Text != "" && tbDNumW.Text != "")
            {
                deleteWagon();
                deleteWMesta();
                lbOK2.Text = "Удален!";
            }
        }

        private void FormAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {

            Hide();
            Form1 Form1 = new Form1();
            Form1.ShowDialog();
            Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if(tbBReis.Text != "" && tbNumWB.Text != "" && tbNumWM.Text != "" && tbSurNameB.Text != "" && tbNameB.Text != "" && tbMiddleNameB.Text != "")
            {
                SQLiteCommand CMD = DB.CreateCommand();
                string FIO = tbSurNameB.Text + " " + tbNameB.Text + " " + tbMiddleNameB.Text;
                CMD.CommandText = "insert into Билеты(Рейс, Вагон, Место, ФИО) values('"+ tbBReis.Text + "', '"+ tbNumWB.Text + "', '"+ tbNumWM.Text + "', '"+FIO+"')";
                CMD.ExecuteNonQuery();
                lbOK3.Text = "Добавен!";
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (tbBReisD.Text != "" && tbNumWBD.Text != "" && tbNumWMD.Text != "")
            {
                SQLiteCommand CMD = DB.CreateCommand();
                CMD.CommandText = "delete from Билеты where Рейс='"+ tbBReisD.Text + "' and Вагон='"+ tbNumWBD.Text + "' and Место='"+ tbNumWMD.Text + "'";
                CMD.ExecuteNonQuery();
                lbOK3.Text = "Удален!";
            }
        }
    }
}
