using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb77
{
    class Mechanizm
    {
        protected string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        protected string mass;

        public string Mass
        {
            get { return mass; }
            set { mass = value; }
        }
        protected int razmer;

        public int Razmer
        {
            get { return razmer; }
            set { razmer = value; }
        }

        class Assistant : Mechanizm, ISalSum
        {
            protected int seniority;
            // На данную строку пока не обращаем внимания 
            //(ее можно пока пропустить)
            public event EventHandler AddAssistant;

            public int Seniority
            {
                get { return seniority; }
                set { seniority = value; }
            }
            protected double salarysum;

            public double Salarysum
            {
                get { return salarysum; }
                set { salarysum = value; }
            }
            // На данную функцию пока не обращаем внимания
            // (ее можно пока пропустить)
            double ISalSum.CalcSalSum()
            {
                salarysum = this.Salary + seniority * 0.2;
                if (AddAssistant != null) AddAssistant(this, null);
                return salarysum;
            }
        }

        class Manager : Assistant, ISalSum
        {

            int subordinate;

            public int Subordinate
            {
                get { return subordinate; }
                set { subordinate = value; }
            }
            public static bool f = false;
            // На данную функцию пока не обращаем внимания
            // (ее можно пока пропустить)
            double ISalSum.CalcSalSum()
            {
                Salarysum = this.Salary + this.Seniority * 0.2 + subordinate * 0.2;
                return Salarysum;
            }
            // На данную функцию пока не обращаем внимания
            public void DoEvent(object sender, EventArgs e)
            {
                salarysum = salary + seniority * 0.2 + subordinate * 0.2;
            }

        }

    }
}
