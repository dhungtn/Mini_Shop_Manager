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
    public partial class frmChuyenBan : DevExpress.XtraEditors.XtraForm
    {
        public string tuban_id = "";
        public delegate void ChuyenBanDelegate(string denban_id);
        public ChuyenBanDelegate ChuyenBan;
        DataAccess cls = new DataAccess();
        public frmChuyenBan()
        {
            InitializeComponent();
        }
        public void LayDSTuBanDropDown()
        {
            
            string sql = "select BP_ID, BP_Ten from BanPhong where BP_KichHoat = 'True' and BP_DV_ID = '" + Info.dv_id + "'";
            glkuTuBan.Properties.DataSource = cls.GetDataTable(sql);
            glkuTuBan.Properties.ValueMember = "BP_ID";
            glkuTuBan.Properties.DisplayMember = "BP_Ten";
            glkuTuBan.Properties.PopupFormWidth = glkuTuBan.Size.Width - 4;
            glkuvTuBan.BestFitColumns();
            glkuTuBan.EditValue = tuban_id;
        }
        public void LayDSDenBanDropDown()
        {
            string sql = "select BP_ID, BP_Ten from BanPhong where BP_KichHoat = 'True'  and BP_DV_ID = '" + Info.dv_id + "' and BP_TrangThai = 0  ";
            sql += "order by BP_Ten ";
            glkuDenBan.Properties.DataSource = cls.GetDataTable(sql);
            glkuDenBan.Properties.ValueMember = "BP_ID";
            glkuDenBan.Properties.DisplayMember = "BP_Ten";
            glkuDenBan.Properties.PopupFormWidth = glkuDenBan.Size.Width - 4;
            glkuvDenBan.BestFitColumns();
        }
        private void frmChuyenBan_Load(object sender, EventArgs e)
        {
            LayDSTuBanDropDown();
            LayDSDenBanDropDown();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (glkuDenBan.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageConfirm("Bạn chưa chọn bàn cần chuyển đến!");
                glkuDenBan.Focus();
                glkuDenBan.SelectAll();
                return;
            }
            try
            {
                ChuyenBan(glkuDenBan.EditValue.ToString().Trim());
                this.Close();
            }
            catch (Exception)
            {
                
                
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}