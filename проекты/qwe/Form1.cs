using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qwe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

         public void Information()
         {
             OleDbEnumerator enumerator = new OleDbEnumerator();
 DataRow[] foundRows = enumerator.GetElements().Select("SOURCES_DESCRIPTION = 'Microsoft OLE DB Provider for SQL Server'");
 if (foundRows.Length > 0)
 {
    /*OLE DB провайдер установлен! Всё в порядке!*/
    }
else
{
   /*OLE DB провайдер не установлен!*/
}
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
