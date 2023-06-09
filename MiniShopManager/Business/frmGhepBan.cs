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
    public partial class frmGhepBan : DevExpress.XtraEditors.XtraForm
    {
        public string tuban_id = "";
        public string denhd_id = "";
        public delegate void GhepBanDelegate(string denhd_id);
        public GhepBanDelegate GhepBan;
        DataAccess cls = new DataAccess();
        public frmGhepBan()
        {
            InitializeComponent();
        }
        public void LayDSTuBanDropDown()
        {
            
            string sql = "select BP_ID, BP_Ten from BanPhong where BP_KichHoat = 'True' and BP_DV_ID = '" + Info.dv_id + "' ";
            sql += "order by BP_Ten ";
            glkuTuBan.Properties.DataSource = cls.GetDataTable(sql);
            glkuTuBan.Properties.ValueMember = "BP_ID";
            glkuTuBan.Properties.DisplayMember = "BP_Ten";
            glkuTuBan.Properties.PopupFormWidth = glkuTuBan.Size.Width - 4;
            glkuvTuBan.BestFitColumns();
            glkuTuBan.EditValue = tuban_id;
        }
        public void LayDSDenBanDropDown()
        {
            string sql = "select BP_ID, BP_Ten from BanPhong where BP_KichHoat = 'True' and BP_DV_ID = '" + Info.dv_id + "' and BP_ID <> '" + tuban_id + "' and BP_TrangThai <> 0 ";
            glkuDenBan.Properties.DataSource = cls.GetDataTable(sql);
            glkuDenBan.Properties.ValueMember = "BP_ID";
            glkuDenBan.Properties.DisplayMember = "BP_Ten";
            glkuDenBan.Properties.PopupFormWidth = glkuDenBan.Size.Width - 4;
            glkuvDenBan.BestFitColumns();
        }
        private void frmGhepBan_Load(object sender, EventArgs e)
        {
            LayDSTuBanDropDown();
            LayDSDenBanDropDown();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (glkuDenBan.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageConfirm("Bạn chưa chọn bàn cần ghép!");
                glkuDenBan.Focus();
                glkuDenBan.SelectAll();
                return;
            }
            string sql = "select HD_ID from HoaDon where HD_BP_ID = '" + glkuDenBan.EditValue.ToString().Trim() + "' and (HD_TrangThai = 1 or HD_TrangThai = 2) and HD_DV_ID = '" + Info.dv_id + "'";
            denhd_id = cls.GetStringValue(sql);
            if (denhd_id.Length > 0)
            {
                GhepBan(denhd_id);
                this.Close();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}