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
    public partial class frmTestMatHang : DevExpress.XtraEditors.XtraForm
    {
        public frmTestMatHang()
        {
            InitializeComponent();
        }
        DataAccess cls = new DataAccess();
        private void frmTestMatHang_Load(object sender, EventArgs e)
        {
            string sql = "select MH_ID, MH_Ma, MH_Ten, MH_DVT, MH_HinhAnh, MH_GiaMua, MH_GiaBanSi, MH_GiaBanLe, MH_GiaTraCham, MH_GhiChu, MH_KichHoat, MH_TuKhoa ";
            sql += "from MatHang ";
            grcData.DataSource = cls.GetDataTable(sql);
        }
    }
}