using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
namespace MyRMS
{
    public partial class frmInMaVach : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public string mavach = "";
        public string tenhang = "";
        public double dongia = 0;
        public frmInMaVach()
        {
            InitializeComponent();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (double.Parse(txtSoLuongIn.EditValue.ToString()) == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập số lượng!");
                txtSoLuongIn.Focus();
                txtSoLuongIn.SelectAll();
                return;
            }
            string sql = "";
            for (int i = 0; i < double.Parse(txtSoLuongIn.EditValue.ToString()); i++)
            {

                if (i != (double.Parse(txtSoLuongIn.EditValue.ToString()) - 1))
                {
                    sql += "select distinct MH_Ma, MH_Ten, MH_GiaBanLe from MatHang where MH_Ma = '" + txtMaVach.Text.Trim() + "' ";
                    sql += " union all ";
                }
                else
                    sql += "select distinct  MH_Ma, MH_Ten, MH_GiaBanLe from MatHang where MH_Ma = '" + txtMaVach.Text.Trim() + "' ";
            }
            try
            {
                FastReport.Report rpt = new FastReport.Report();
                rpt.Load(Application.StartupPath + "\\report\\Mavach.frx");
                rpt.RegisterData(cls.GetDataTable(sql), "Table");
                rpt.Show();
                //rpt.PrintSettings.Printer = Info.mayinmavach;
                //rpt.PrintSettings.ShowDialog = false;
                //rpt.Print();
            }
            catch (Exception ex)
            {
                TTHMessage.ShowMessageError("Xảy ra lỗi:" + ex.ToString());
            }
        }

        private void frmInMaVach_Load(object sender, EventArgs e)
        {
            txtMaVach.Text = mavach;
            txtHangHoa.Text = tenhang;
            txtDonGia.EditValue = dongia;
            //txtSoLuongIn.EditValue = 
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}