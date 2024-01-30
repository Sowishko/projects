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
    public partial class ListItem : UserControl
    {
        public ListItem()
        {
            InitializeComponent();
        }

        #region Properties
        private string _Timea;
        private string _Timeb;
        private string _Goroda;
        private string _Gorodb;
        private string _Otpravlenie;

        private string _Sid;
        private string _SidPlace;
        private string _SidPrice;

        private string _Kupe;
        private string _KupePlace;
        private string _KupePrice;

        private string _Plac;
        private string _PlacPlace;
        private string _PlacPrice;

        private string _Luks;
        private string _LuksPlace;
        private string _LuksPrice;

        private string _Rubl1;
        private string _Rubl2;
        private string _Rubl3;
        private string _Rubl4;

        private string _Ot1;
        private string _Ot2;
        private string _Ot3;
        private string _Ot4;

        private bool _SidPriceVisible = true;
        private bool _KupePriceVisible = true;
        private bool _PlacPriceVisible = true;
        private bool _LuksPriceVisible = true;

        private string _NumbersReis;


        private Button _button;

        [Category("Custom Props")]
        public string Timea
        {
            get { return _Timea; }
            set { _Timea = value; lbTimea.Text = value; }
        }

        [Category("Custom Props")]
        public string Timeb
        {
            get { return _Timeb; }
            set { _Timeb = value; lbTimeb.Text = value; }
        }

        [Category("Custom Props")]
        public string Goroda
        {
            get { return _Goroda; }
            set { _Goroda = value; lbGoroda.Text = value; }
        }
        [Category("Custom Props")]
        public string Gorodb
        {
            get { return _Gorodb; }
            set { _Gorodb = value; lbGorodb.Text = value; }
        }
        [Category("Custom Props")]
        public string Otpravlenie
        {
            get { return _Otpravlenie; }
            set { _Otpravlenie = value; lbOtpravlenie.Text = value; }
        }
        [Category("Custom Props")]
        public string Sid
        {
            get { return _Sid; }
            set { _Sid = value; lbSid.Text = value; }
        }
        [Category("Custom Props")]
        public string SidPlace
        {
            get { return _SidPlace; }
            set { _SidPlace = value; lbSidPlace.Text = value; }
        }
        [Category("Custom Props")]
        public string SidPrice
        {
            get { return _SidPrice; }
            set { _SidPrice = value; lbSidPrice.Text = value; }
        }
        [Category("Custom Props")]
        public string Kupe
        {
            get { return _Kupe; }
            set { _Kupe = value; lbKupe.Text = value; }
        }
        [Category("Custom Props")]
        public string KupePlace
        {
            get { return _KupePlace; }
            set { _KupePlace = value; lbKupePlace.Text = value; }
        }
        [Category("Custom Props")]
        public string KupePrice
        {
            get { return _KupePrice; }
            set { _KupePrice = value; lbKupePrice.Text = value; }
        }
        [Category("Custom Props")]
        public string Plac
        {
            get { return _Plac; }
            set { _Plac = value; lbPlac.Text = value; }
        }
        [Category("Custom Props")]
        public string PlacPlace
        {
            get { return _PlacPlace; }
            set { _PlacPlace = value; lbPlacPlace.Text = value; }
        }
        [Category("Custom Props")]
        public string PlacPrice
        {
            get { return _PlacPrice; }
            set { _PlacPrice = value; lbPlacPrice.Text = value; }
        }
        [Category("Custom Props")]
        public string Luks
        {
            get { return _Luks; }
            set { _Luks = value; lbLuks.Text = value; }
        }
        [Category("Custom Props")]
        public string LuksPlace
        {
            get { return _LuksPlace; }
            set { _LuksPlace = value; lbLuksPlace.Text = value; }
        }
        [Category("Custom Props")]
        public string LuksPrice
        {
            get { return _LuksPrice; }
            set { _LuksPrice = value; lbLuksPrice.Text = value; }
        }
        [Category("Custom Props")]
        public string Rubl1
        {
            get { return _Rubl1; }
            set { _Rubl1 = value; lbRubl1.Text = value; }
        }
        [Category("Custom Props")]
        public string Rubl2
        {
            get { return _Rubl2; }
            set { _Rubl2 = value; lbRubl2.Text = value; }
        }
        [Category("Custom Props")]
        public string Rubl3
        {
            get { return _Rubl3; }
            set { _Rubl3 = value; lbRubl3.Text = value; }
        }
        [Category("Custom Props")]
        public string Rubl4
        {
            get { return _Rubl4; }
            set { _Rubl4 = value; lbRubl4.Text = value; }
        }
        [Category("Custom Props")]
        public string Ot1
        {
            get { return _Ot1; }
            set { _Ot1 = value; lbOt1.Text = value; }
        }
        [Category("Custom Props")]
        public string Ot2
        {
            get { return _Ot2; }
            set { _Ot2 = value; lbOt2.Text = value; }
        }
        [Category("Custom Props")]
        public string Ot3
        {
            get { return _Ot3; }
            set { _Ot3 = value; lbOt3.Text = value; }
        }
        [Category("Custom Props")]
        public string Ot4
        {
            get { return _Ot4; }
            set { _Ot4 = value; lbOt4.Text = value; }
        }
        [Category("Custom Props")]
        public bool SidPriceVisible
        {
            get { return _SidPriceVisible; }
            set { _SidPriceVisible = value; lbSidPrice.Visible = value; }
        }
        [Category("Custom Props")]
        public bool KupePriceVisible
        {
            get { return _KupePriceVisible; }
            set { _KupePriceVisible = value; lbKupePrice.Visible = value; }
        }
        [Category("Custom Props")]
        public bool PlacPriceVisible
        {
            get { return _PlacPriceVisible; }
            set { _PlacPriceVisible = value; lbPlacPrice.Visible = value; }
        }
        [Category("Custom Props")]
        public bool LuksPriceVisible
        {
            get { return _LuksPriceVisible; }
            set { _LuksPriceVisible = value; lbLuksPrice.Visible = value; }
        }
        [Category("Custom Props")]
        public string NumbersReis
        {
            get { return _Rubl4; }
            set { _NumbersReis = value; lbNumbersReis.Text = value; }
        }

        [Category("Custom Props")]
        public Button Button
        {
            get { return _button; }
            set { _button = value; btMest = value; }
        }
        #endregion
    }
}
