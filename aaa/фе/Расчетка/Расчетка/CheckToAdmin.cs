using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Расчетка
{
    public partial class CheckToAdmin : Form
    {
        public CheckToAdmin()
        {
            InitializeComponent();
        }

        private void BtAuth_Click(object sender, EventArgs e)
        {
            if (tbLogin.Text == "admin" && tbPass.Text == "123456")
            {
                Hide();
                FormAdmin FormAdmin = new FormAdmin();
                FormAdmin.ShowDialog();
                Close();
            }
            else MessageBox.Show("Данные не верны!");
        }
    }
}
