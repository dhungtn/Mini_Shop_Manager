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
    public partial class frmThanhToan : DevExpress.XtraEditors.XtraForm
    {
        public delegate void ThanhToanDelegate(double khachdua, double tienthua);
        public ThanhToanDelegate ThanhToan;
        public double phaithanhtoan = 0;
        public frmThanhToan()
        {
            InitializeComponent();
        }

       

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ThanhToan(double.Parse(txtKhachDua.EditValue.ToString()), double.Parse(txtTienThua.EditValue.ToString()));
            this.Close();
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            txtPhaiThanhToan.EditValue = phaithanhtoan;
            txtKhachDua.EditValue = phaithanhtoan;
            txtKhachDua.Focus();
            txtKhachDua.SelectAll();
        }

        private void txtKhachDua_EditValueChanged(object sender, EventArgs e)
        {
            if (double.Parse(txtKhachDua.EditValue.ToString()) > double.Parse(txtPhaiThanhToan.EditValue.ToString()))
            {
                txtTienThua.EditValue = double.Parse(txtKhachDua.EditValue.ToString()) - double.Parse(txtPhaiThanhToan.EditValue.ToString());
            }
            else txtTienThua.EditValue = 0;
        }

        private void chkTraDu_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            
        }

        private void chkTraDu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTraDu.Checked) txtKhachDua.EditValue = double.Parse(txtPhaiThanhToan.EditValue.ToString());
            else
            {
                txtKhachDua.EditValue = 0;
                txtKhachDua.Focus();
            }
        }
    }
}