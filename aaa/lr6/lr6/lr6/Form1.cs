using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lr6
{
    public partial class Form1 : Form
    {
        private int n1, n2;
        private int d1, d2;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBoxChanged(object sender, EventArgs e)
        {
            int tmp;

            if (int.TryParse(num1.Text, out tmp))
                n1 = tmp;
            if (int.TryParse(den1.Text, out tmp))
                d1 = tmp;
            if (int.TryParse(num2.Text, out tmp))
                n2 = tmp;
            if (int.TryParse(den2.Text, out tmp))
                d2 = tmp;
        }

        private bool verifyTextBoxes(out string msg)
        {
            if (String.IsNullOrEmpty(num1.Text) ||
                String.IsNullOrEmpty(num2.Text) ||
                String.IsNullOrEmpty(den1.Text) ||
                String.IsNullOrEmpty(den2.Text))
            {
                msg = ("И где тут дробь?Поля нужно заполнять!)");
                return false;
            }

            bool checkTextBox(TextBox tb)
            {
                if (!Regex.IsMatch(num1.Text, @"^\d*$"))
                    return false;
                return true;
            }

            if (!(
                checkTextBox(num1) &&
                checkTextBox(num2) &&
                checkTextBox(den1) &&
                checkTextBox(den2)))
            {
                msg = ("Надо писать цифры!!!");
                return false;
            }

            textBoxChanged(null, null);
            if (d1 == 0)
            {
                msg = ("Так писать нельзя!!!!!Ноль в знаменателе");
                return false;
            }
            msg = "";
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string msg;
            if (!verifyTextBoxes(out msg))
            {
                MessageBox.Show(msg, "Error!");
                return;
            }

            NewFrunction a = new NewFrunction(n1, d1);
            NewFrunction b = new NewFrunction(n2, d2);

            Frunction res = a + b;
            num3.Text = res.numerator.ToString();
            den3.Text = res.denominator.ToString();
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            string msg;
            if (!verifyTextBoxes(out msg))
            {
                MessageBox.Show(msg, "Error!");
                return;
            }

            NewFrunction a = new NewFrunction(n1, d1);
            NewFrunction b = new NewFrunction(n2, d2);

            Frunction res = a - b;
            num3.Text = res.numerator.ToString();
            den3.Text = res.denominator.ToString();
        }
        private void btnDiv_Click(object sender, EventArgs e)
        {
            string msg;
            if (!verifyTextBoxes(out msg))
            {
                MessageBox.Show(msg, "Error!");
                return;
            }

            NewFrunction a = new NewFrunction(n1, d1);
            NewFrunction b = new NewFrunction(n2, d2);

            Frunction res = a / b;
            num3.Text = res.numerator.ToString();
            den3.Text = res.denominator.ToString();
        }
        private void btnMul_Click(object sender, EventArgs e)
        {
            string msg;
            if (!verifyTextBoxes(out msg))
            {
                MessageBox.Show(msg, "Error!");
                return;
            }

            NewFrunction a = new NewFrunction(n1, d1);
            NewFrunction b = new NewFrunction(n2, d2);

            Frunction res = a * b;
            num3.Text = res.numerator.ToString();
            den3.Text = res.denominator.ToString();
        }
    }
}
