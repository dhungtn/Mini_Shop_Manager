using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
namespace MyRMS.HeThong
{
    public partial class frmNguoiDungUpdate : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void SetNguoiDungDelegate(string value);
        public SetNguoiDungDelegate SetNguoiDung;
        public delegate void GetDataTableDelegate();
        public GetDataTableDelegate LayDSNguoiDung;
        public delegate void AddNguoiDungDelegate(string ND_ID,  string ND_Ten, string ND_DiaChi, string ND_DienThoai, string ND_GhiChu, Boolean ND_TrangThai, string ND_TuKhoa);
        public AddNguoiDungDelegate AddNguoiDung;
        public delegate void EditNguoiDungDelegate(string ND_ID,  string ND_Ten, string ND_DiaChi, string ND_DienThoa, string ND_GhiChu, Boolean ND_TrangThai, string ND_TuKhoa);
        public EditNguoiDungDelegate EditNguoiDung;
        public string nd_id = "";
        public Boolean issua = false;
        public string frmReq = "";
        public string frmText = "";
        public string loai = "";
        public string vt_id = "";
        public frmNguoiDungUpdate()
        {
            InitializeComponent();
        }
        public void LayDSDonVi()
        {
            DataAccess cls = new DataAccess();
            string sql = "select DV_ID, DV_Ten from DonVi where DV_KichHoat = 'True' order by DV_Ten";
            glkuDonVi.Properties.DataSource = cls.GetDataTable(sql);
            glkuDonVi.Properties.ValueMember = "DV_ID";
            glkuDonVi.Properties.DisplayMember = "DV_Ten";
            glkuDonVi.Properties.PopupFormWidth = glkuDonVi.Size.Width - 4;
            glkuvDonVi.BestFitColumns();
            glkuDonVi.EditValue = Info.dv_id;
        }
        public void LayDSVaiTro()
        {
            DataAccess cls = new DataAccess();
            string sql = "select VT_ID, VT_Ten from VaiTro where VT_KichHoat = 'True' order by VT_Ten";
            glkuVaiTro.Properties.DataSource = cls.GetDataTable(sql);
            glkuVaiTro.Properties.ValueMember = "VT_ID";
            glkuVaiTro.Properties.DisplayMember = "VT_Ten";
            glkuVaiTro.Properties.PopupFormWidth = glkuVaiTro.Size.Width - 4;
            glkuvVaiTro.BestFitColumns();
            if (glkuvVaiTro.RowCount > 0)
            {
                DataRow row = glkuvVaiTro.GetDataRow(0);
                glkuVaiTro.EditValue = row["VT_ID"].ToString().Trim();
            }
            if (vt_id.Trim().Length > 0) glkuVaiTro.EditValue = vt_id;
        }
        public Boolean ThemNguoiDung()
        {
            
            string[] field = { "ND_ID",  "ND_Ten", "ND_DiaChi", "ND_DienThoai", "ND_GhiChu",  "ND_KichHoat", "ND_VT_ID", "ND_TuKhoa", "ND_DV_ID", "ND_TenDangNhap", "ND_MatKhau" };
            object[] value = { (object)nd_id, (object)txtTen.Text.Trim(), (object)txtDiaChi.Text.Trim(), (object)txtDienThoai.Text.Trim(), (object)txtGhiChu.Text.Trim(), (object)chkTrangThai.Checked, (object)glkuVaiTro.EditValue.ToString().Trim(), (object)TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim() + txtDiaChi.Text.Trim() + txtDienThoai.Text.Trim()), (object)glkuDonVi.EditValue.ToString(), (object)txtTenDangNhap.Text.Trim(), (object)TTHUtils.MaHoaBase64(System.Text.Encoding.UTF8.GetBytes(txtMatKhau.Text.Trim())) };
            return cls.AddRecord("NguoiDung", field, value);
        }
        public Boolean ThemQuyenNguoiDung(string nd_id)
        {
            Boolean ok = false;
            int i = 1;
            foreach (DataRow dr in cls.GetDataTableTrans("select CN_ID from ChucNang").Rows)
            {
                string sql = "insert into Quyen(Q_ID, Q_CN_ID, Q_ND_ID, Q_TruyCap, Q_Them, Q_Sua, Q_Xoa, Q_In, Q_Nhap, Q_Xuat) ";
                sql += "values ('" + DateTime.Now.ToString("yyMMddHHmmss") + string.Format("{0,3:000}", i) + "', '" + dr["CN_ID"].ToString().Trim() + "', '" + nd_id + "', 'True', 'True', 'True', 'True', 'True', 'True', 'True') ";
                ok = cls.ExecuteNonQueryTrans(sql);
                if (!ok) break;
                i = i + 1;
            }
            return ok;
        }
        public Boolean SuaNguoiDung()
        {

            string[] field = { "ND_Ten", "ND_DiaChi", "ND_DienThoai", "ND_GhiChu", "ND_KichHoat", "ND_VT_ID", "ND_TuKhoa", "ND_DV_ID", "ND_TenDangNhap", "ND_MatKhau" };
            object[] value = { (object)txtTen.Text.Trim(), (object)txtDiaChi.Text.Trim(), (object)txtDienThoai.Text.Trim(), (object)txtGhiChu.Text.Trim(), (object)chkTrangThai.Checked, (object)glkuVaiTro.EditValue.ToString().Trim(), (object)TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim() + txtDiaChi.Text.Trim() + txtDienThoai.Text.Trim()), (object)glkuDonVi.EditValue.ToString(), (object)txtTenDangNhap.Text.Trim(), (object)TTHUtils.MaHoaBase64(System.Text.Encoding.UTF8.GetBytes(txtMatKhau.Text.Trim())) };
            string[] fieldwhere = { "ND_ID"};
            object[] objwhere = { (object)nd_id };
            return cls.EditRecord("NguoiDung", field, value, fieldwhere, objwhere);
        }

        public void LayThongTinNguoiDung()
        {
            string sql = "select * from NguoiDung where ND_ID = '" + nd_id + "'";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                glkuDonVi.EditValue = dr["ND_DV_ID"].ToString().Trim();
                glkuVaiTro.EditValue = dr["ND_VT_ID"].ToString().Trim();
                txtTen.Text = dr["ND_Ten"].ToString().Trim();
                txtDiaChi.Text = dr["ND_DiaChi"].ToString().Trim();
                txtDienThoai.Text = dr["ND_DienThoai"].ToString().Trim();
                txtTenDangNhap.Text = dr["ND_TenDangNhap"].ToString().Trim();
                txtMatKhau.Text = dr["ND_MatKhau"].ToString().Trim();
                txtGhiChu.Text = dr["ND_GhiChu"].ToString().Trim();
                chkTrangThai.Checked = (bool)dr["ND_KichHoat"];
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

        private void txtMa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
            if (txtTen.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập tên.");
                txtTen.Focus();
                return;
            }
            if (glkuVaiTro.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa chọn khu vực.");
                glkuVaiTro.Focus();
                return;
            }
            Boolean ok = false;
            //DataAccessStatic.sqltrans = DataAccessStatic.conn.BeginTransaction();
            if (issua)
            {
                ok = SuaNguoiDung();
                //if (ok) ok = ThemQuyenNguoiDung(nd_id);
            }
            else
            {
                ok = ThemNguoiDung();
                //if (ok) ok = ThemQuyenNguoiDung(nd_id);
            }
            if (ok)
            {
                //DataAccessStatic.sqltrans.Commit();
                try
                {
                    AddNguoiDung(nd_id, txtTen.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(), txtGhiChu.Text.Trim(), chkTrangThai.Checked, TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim() + txtDiaChi.Text.Trim() + txtDienThoai.Text.Trim()));
                }
                catch (Exception)
                {


                }
                try
                {
                    EditNguoiDung(nd_id, txtTen.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(), txtGhiChu.Text.Trim(), chkTrangThai.Checked, TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim() + txtDiaChi.Text.Trim() + txtDienThoai.Text.Trim()));
                }
                catch (Exception)
                {


                }
                try
                {
                    LayDSNguoiDung();
                }
                catch (Exception)
                {


                }
                try
                {
                    SetNguoiDung(nd_id);
                }
                catch (Exception)
                {


                }
                if (issua == true || frmReq.Trim().Length > 0)
                    this.Close();
                issua = false;
                nd_id = DateTime.Now.ToString("yyMMddHHmmss");//.Substring(8, 6) + TTHUtils.TaoMaSoNgauNhien(2);
                txtTen.Text = "";
                txtDiaChi.Text = "";
                txtDienThoai.Text = "";
                txtGhiChu.Text = "";
                txtTen.Focus();
                //chkTrangThai.Checked = false;
                //txtKhoiTaoNo.EditValue = 0.0;

            }
            else
            {
                //DataAccessStatic.sqltrans.Rollback();
                TTHMessage.ShowMessageWarming("Không thể lưu. Xin kiểm tra lại thông tin!");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNguoiDungUpdate_Load(object sender, EventArgs e)
        {
            this.Text = frmText;
            LayDSDonVi();
            LayDSVaiTro();
            if (issua)
            {
                LayThongTinNguoiDung();

            }
            else
            {
                nd_id = DateTime.Now.ToString("yyMMddHHmmss");//.Substring(8, 6) + TTHUtils.TaoMaSoNgauNhien(2);//TTHUtils.TaoMaSoNgauNhien(8);
                txtTen.Focus();
            }
        }
    }
}