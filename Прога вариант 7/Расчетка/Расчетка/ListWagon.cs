using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Расчетка
{
    public partial class ListWagon : UserControl
    {
        public ListWagon()
        {
            InitializeComponent();;
        }
        private string _WgType;
        private string _WgMesta;
        private string _WgPrice;
        private string _WgNum;
        private string _WgInfo;
        public int y = Form2.y;
        public int x = Form2.x;
        private string _Data;
        private Color _DataColor;
        private int _DataRow;
        private int _DataColumn;

        private Button _button;

        [Category("Custom Props")]
        public string WgType
        {
            get { return _WgType; }
            set { _WgType = value; lbWgType.Text = value; }
        }
        [Category("Custom Props")]
        public string WgMesta
        {
            get { return _WgMesta; }
            set { _WgMesta = value; lbWgMesta.Text = value; }
        }
        [Category("Custom Props")]
        public string WgPrice
        {
            get { return _WgPrice; }
            set { _WgPrice = value; lbWgPrice.Text = value; }
        }
        [Category("Custom Props")]
        public string WgNum
        {
            get { return _WgNum; }
            set { _WgNum = value; lbWgNum.Text = value; }
        }
        [Category("Custom Props")]
        public string WgInfo
        {
            get { return _WgInfo; }
            set { _WgInfo = value; lbWgInfo.Text = value; }
        }
        [Category("Custom Props")]
        public int DataRow
        {
            get { return _DataRow; }
            set { _DataRow = value; dataGridView1.RowCount = value;}
        }
        [Category("Custom Props")]
        public int DataColumn
        {
            get { return _DataColumn; }
            set { _DataColumn = value; dataGridView1.ColumnCount = value;}
        }
        [Category("Custom Props")]
        public string Data
        {
            get { return _Data; }
            set { _Data = value; dataGridView1.Rows[y].Cells[x].Value = value;}
        }
        [Category("Custom Props")]
        public Color DataColor
        {
            get { return _DataColor; }
            set { _DataColor = value;
                dataGridView1.ClearSelection();
                dataGridView1.Rows[y].Cells[x].Style.ForeColor = value;}
        }
        public Button Button
        {
            get { return _button; }
            set { _button = value; btWg = value; }
        }
    }
}
