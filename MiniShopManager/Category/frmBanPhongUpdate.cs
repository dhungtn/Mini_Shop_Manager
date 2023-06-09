using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
namespace MyRMS.DanhMuc
{
    public partial class frmBanPhongUpdate : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void SetBanPhongDelegate(string value);
        public SetBanPhongDelegate SetBanPhong;
        public delegate void GetDataTableDelegate();
        public GetDataTableDelegate LayDSBanPhong;
        public delegate void AddBanPhongDelegate(string BP_ID, string BP_Ten, string BP_GhiChu, Boolean BP_KichHoat, string BP_TuKhoa);
        public AddBanPhongDelegate AddBanPhong;
        public delegate void EditBanPhongDelegate(string BP_ID, string BP_Ten, string BP_GhiChu, Boolean BP_KichHoat, string BP_TuKhoa);
        public EditBanPhongDelegate EditBanPhong;
        public string bp_id = "";
        public Boolean issua = false;
        public string frmReq = "";
        public string frmText = "";
        public string loai = "";
        public string kv_id = "";
        public frmBanPhongUpdate()
        {
            InitializeComponent();
        }
        public void LayDSKhuVuc()
        {
            DataAccess cls = new DataAccess();
            string sql = "select KV_ID, KV_Ten from KhuVuc where KV_KichHoat = 'True' and KV_DV_ID = '" + Info.dv_id + "' order by KV_Ten";
            glkuKhuVuc.Properties.DataSource = cls.GetDataTable(sql);
            glkuKhuVuc.Properties.ValueMember = "KV_ID";
            glkuKhuVuc.Properties.DisplayMember = "KV_Ten";
            glkuKhuVuc.Properties.PopupFormWidth = glkuKhuVuc.Size.Width - 4;
            glkuvKhuVuc.BestFitColumns();
            if (glkuvKhuVuc.RowCount > 0)
            {
                DataRow row = glkuvKhuVuc.GetDataRow(0);
                glkuKhuVuc.EditValue = row["KV_ID"].ToString().Trim();
            }
            if (kv_id.Trim().Length > 0) glkuKhuVuc.EditValue = kv_id;
        }
        public Boolean ThemBanPhong()
        {

            string[] field = { "BP_ID", "BP_Ten", "BP_GhiChu", "BP_KichHoat", "BP_KV_ID", "BP_TuKhoa", "BP_DV_ID", "BP_TrangThai" };
            object[] value = { (object)bp_id, (object)txtTen.Text.Trim(), (object)txtGhiChu.Text.Trim(), (object)chkKichHoat.Checked, (object)glkuKhuVuc.EditValue.ToString().Trim(), (object)TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim()), (object)Info.dv_id, (object)0 };
            return cls.AddRecord("BanPhong", field, value);
        }
        public Boolean SuaBanPhong()
        {

            string[] field = { "BP_Ten", "BP_GhiChu", "BP_KichHoat", "BP_KV_ID", "BP_TuKhoa", "BP_DV_ID", "BP_TrangThai" };
            object[] value = {  (object)txtTen.Text.Trim(),  (object)txtGhiChu.Text.Trim(), (object)chkKichHoat.Checked,  (object)glkuKhuVuc.EditValue.ToString().Trim(), (object)TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim()), (object)Info.dv_id, (object)0 };
            string[] fieldwhere = { "BP_ID"};
            object[] objwhere = { (object)bp_id };
            return cls.EditRecord("BanPhong", field, value, fieldwhere, objwhere);
        }
        public void LayThongTinBanPhong()
        {
            string sql = "select * from BanPhong where BP_ID = '" + bp_id + "'";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                glkuKhuVuc.EditValue = dr["BP_KV_ID"].ToString().Trim();
                txtTen.Text = dr["BP_Ten"].ToString().Trim();

                txtGhiChu.Text = dr["BP_GhiChu"].ToString().Trim();
                chkKichHoat.Checked = (bool)dr["BP_KichHoat"];
            }
        }
        private void frmCapNhatHangHoa_Load(object sender, EventArgs e)
        {
            this.Text = frmText;
            LayDSKhuVuc();
            if (issua)
            {
                LayThongTinBanPhong();

            }
            else
            {
                bp_id = DateTime.Now.ToString("yyMMddHHmmss");
                txtTen.Focus();
            }
        }
        

        private void barF12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnLuu_Click(null, null);
            
        }

        private void barDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnDong_Click(null, null);
        }

       

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            if (txtTen.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập tên khách hàng.");
                txtTen.Focus();
                return;
            }
            if (glkuKhuVuc.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa chọn khu vực.");
                txtTen.Focus();
                return;
            }
            Boolean ok = false;
            if (issua)
                ok = SuaBanPhong();
            else
            {
                ok = ThemBanPhong();
            }
            if (ok)
            {

                try
                {
                    AddBanPhong(bp_id, txtTen.Text.Trim(), txtGhiChu.Text.Trim(), chkKichHoat.Checked, TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim()));
                }
                catch (Exception)
                {


                }
                try
                {
                    EditBanPhong(bp_id, txtTen.Text.Trim(), txtGhiChu.Text.Trim(), chkKichHoat.Checked, TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim()));
                }
                catch (Exception)
                {


                }
                try
                {
                    LayDSBanPhong();
                }
                catch (Exception)
                {


                }
                try
                {
                    SetBanPhong(bp_id);
                }
                catch (Exception)
                {


                }
                if (issua == true || frmReq.Trim().Length > 0)
                    this.Close();
                issua = false;
                bp_id = DateTime.Now.ToString("yyMMddHHmmss");
                if (chkSaoChep.Checked)
                {
                    txtTen.Focus();
                    txtTen.SelectAll();
                }
                else
                {
                    txtTen.Text = "";
                    txtGhiChu.Text = "";
                    txtTen.Focus();
                }
            }
            else TTHMessage.ShowMessageWarming("Không thể lưu. Xin kiểm tra lại thông tin!");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}