using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MyRMS.NghiepVu
{
    public partial class frmThuTien : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void DisplayBackgroungDelegate();
        public DisplayBackgroungDelegate DisplayBackgroung;
        public frmThuTien()
        {
            InitializeComponent();
        }

        private void frmThuTien_Load(object sender, EventArgs e)
        {

        }
    }
}