using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 7тп
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label3.Text = "";
        }
        enterprise enterprise;
        private void BeginPr_Click(object sender, EventArgs e)
        {
            if (enterprise == null)
            { 
                enterprise = new enterprise();
                enterprise.Notify += DPM;
                enterprise.Workers(Convert.ToInt32(KoLW.Text));

                enterprise.ws.Add(new WS());
                enterprise.ws.Last().Name = "Узел";
                enterprise.ws.Last().Notify += DPM;
                enterprise.ws.Add(new WS());
                enterprise.ws.Last().Name = "Механизм";
                enterprise.ws.Last().Notify += DPM;
                Wst.Text = enterprise.kolWorkers.ToString();
            }
            else
            {
                enterprise.Workers(Convert.ToInt32(KoLW.Text));
                Wst.Text = enterprise.kolWorkers.ToString();
            }
        }

        public void DPM(string message)
        {
            label3.Text = message;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = "";
            timer1.Enabled = false;
        }

        private void ObrMet_Click(object sender, EventArgs e)
        {
            if (enterprise.kolWorkers - 5 < 0)
            {
                MessageBox.Show("Недостаточно деталей", "Сообщение");
                return;
            }
            enterprise.kolWorkers -= 5;
            enterprise.ws[0].ObrM(5);
            Wst.Text = enterprise.kolWorkers.ToString();
        }

        private void IzgMet_Click(object sender, EventArgs e)
        {
            if (enterprise.kolWorkers - 5 < 0)
            {
                MessageBox.Show("Недостаточно деталей", "Сообщение");
                return;
            }
            enterprise.kolWorkers -= 5;
            enterprise.ws[1].CreateTruba(5);
            Wst.Text = enterprise.kolWorkers.ToString();
        }
    }

    public delegate void MessageNewZ(string message);
    

    class enterprise
    {
        public List<WS> ws = new List<WS>();
        public int kolWorkers = 0;
        public event MessageNewZ Notify;



        public string Name { get; set; }
        public void Workers(int ws)
        {
            kolWorkers += ws;
            Notify?.Invoke(" Детали были изготовлены");
        }
    }

    class WS : enterprise,ICreateM, IObr
    {
        List<worker> workers = new List<worker>();
        int counter = 0;
        public event MessageNewZ Notify;
        public void ObrM(int c)
        {
            for (int i = 0; i < c; i++)
            {
                workers.Add(new worker());
                workers.Last().Name = "Деталь" + counter;
                counter++;
                Notify?.Invoke(" Изготовлен узел");
            }
            
        }

        public void CreateTruba(int c)
        {
            for (int i = 0; i < c; i++)
            {
                workers.Add(new worker());
                workers.Last().Name = "Деталь" + counter;
                counter++;
                Notify?.Invoke(" Изготовлен механизм");
            }

        }
    }

    class worker : WS
    {

    }
    
    interface ICreateM
    {
        void CreateTruba(int c);
    }

    interface IObr
    {
        void ObrM(int c);
    }







}
