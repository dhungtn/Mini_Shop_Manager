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
    public partial class frmNhaCungCapUpdate : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void SetDoiTacDelegate(string value);
        public SetDoiTacDelegate SetDoiTac;
        public delegate void GetDataTableDelegate();
        public GetDataTableDelegate LayDSDoiTac;
        public delegate void AddDoiTacDelegate(string DT_ID, string DT_Ma, string DT_Ten, string DT_DiaChi, string DT_DienThoai, string DT_Email, string DT_MasoThue, string DT_GhiChu, Boolean DT_TrangThai, string DT_TuKhoa);
        public AddDoiTacDelegate AddDoiTac;
        public delegate void EditDoiTacDelegate(string DT_ID, string DT_Ma, string DT_Ten, string DT_DiaChi, string DT_DienThoai, string DT_Email, string DT_MaSoThue, string DT_GhiChu, Boolean DT_TrangThai, string DT_TuKhoa);
        public EditDoiTacDelegate EditDoiTac;
        public string dt_id = "";
        public Boolean issua = false;
        public string frmReq = "";
        public string frmText = "";
        public string loai = "";
        public string ndt_id = "";
        public frmNhaCungCapUpdate()
        {
            InitializeComponent();
        }
        
        public Boolean ThemDoiTac()
        {
            
            string[] field = { "DT_ID", "DT_Ma", "DT_Ten", "DT_DiaChi", "DT_DienThoai", "DT_Email", "DT_MaSoThue", "DT_GhiChu",  "DT_KichHoat", "DT_Loai", "DT_NDT_ID", "DT_TuKhoa", "DT_DV_ID", "DT_NoBanDau" };
            object[] value = { (object)dt_id, (object)txtMa.Text.Trim(), (object)txtTen.Text.Trim(), (object)txtDiaChi.Text.Trim(), (object)txtDienThoai.Text.Trim(), (object)txtEmail.Text.Trim(), (object)txtMaSoThue.Text.Trim(), (object)txtGhiChu.Text.Trim(), (object)chkTrangThai.Checked, (object)"NCC", (object)"", (object)TTHUtils.LoaiBoDauTiengViet(txtMa.Text.Trim()+txtTen.Text.Trim()+txtDiaChi.Text.Trim()+txtDienThoai.Text.Trim()+txtEmail.Text.Trim()+txtMaSoThue.Text.Trim()), (object)Info.dv_id, (object)double.Parse(spnNoBanDau.EditValue.ToString()) };
            return cls.AddRecord("DoiTac", field, value);
        }
        public Boolean SuaDoiTac()
        {

            string[] field = { "DT_Ma", "DT_Ten", "DT_DiaChi", "DT_DienThoai", "DT_Email", "DT_MaSoThue", "DT_GhiChu", "DT_KichHoat", "DT_Loai", "DT_NDT_ID", "DT_TuKhoa", "DT_DV_ID", "DT_NoBanDau" };
            object[] value = { (object)txtMa.Text.Trim(), (object)txtTen.Text.Trim(), (object)txtDiaChi.Text.Trim(), (object)txtDienThoai.Text.Trim(), (object)txtEmail.Text.Trim(), (object)txtMaSoThue.Text.Trim(), (object)txtGhiChu.Text.Trim(), (object)chkTrangThai.Checked, (object)"NCC", (object)"", (object)TTHUtils.LoaiBoDauTiengViet(txtMa.Text.Trim() + txtTen.Text.Trim() + txtDiaChi.Text.Trim() + txtDienThoai.Text.Trim() + txtEmail.Text.Trim() + txtMaSoThue.Text.Trim()), (object)Info.dv_id, (object)double.Parse(spnNoBanDau.EditValue.ToString()) };
            string[] fieldwhere = { "DT_ID"};
            object[] objwhere = { (object)dt_id };
            return cls.EditRecord("DoiTac", field, value, fieldwhere, objwhere);
        }
        public void LayThongTinDoiTac()
        {
            string sql = "select * from DoiTac where DT_ID = '" + dt_id + "'";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                txtMa.Text = dr["DT_Ma"].ToString().Trim();
                txtTen.Text = dr["DT_Ten"].ToString().Trim();
                txtDiaChi.Text = dr["DT_DiaChi"].ToString().Trim();
                txtDienThoai.Text = dr["DT_DienThoai"].ToString().Trim();
                
                txtMaSoThue.Text = dr["DT_MaSoThue"].ToString().Trim();
                txtGhiChu.Text = dr["DT_GhiChu"].ToString().Trim();
                chkTrangThai.Checked = (bool)dr["DT_KichHoat"];
                txtEmail.Text = dr["DT_Email"].ToString().Trim();
                spnNoBanDau.EditValue = double.Parse(dr["DT_NoBanDau"].ToString());
            }
        }
        private void frmCapNhatHangHoa_Load(object sender, EventArgs e)
        {
            this.Text = frmText;
            if (issua)
            {
                LayThongTinDoiTac();

            }
            else
            {
                dt_id = DateTime.Now.ToString("yyMMddHHmmss");//.Substring(8, 6) + TTHUtils.TaoMaSoNgauNhien(2);//TTHUtils.TaoMaSoNgauNhien(8);
                if (Info.tusinhma)
                {
                    txtMa.Text = TTHUtils.TaoMaSoNgauNhien(Info.dodaimadoitac);
                    txtMa.Enabled = false;
                    txtTen.Focus();
                }
                else
                {
                    txtMa.Enabled = true;
                    txtMa.Focus();
                }
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
            if (e.Button.Index == 0)
            {
                txtMa.Text = TTHUtils.TaoMaSoNgauNhien(Info.dodaimadoitac);
                txtMa.SelectAll();
                txtMa.Focus();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMa.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập mã.");
                txtMa.Focus();
                return;
            }
            if (txtTen.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập tên.");
                txtTen.Focus();
                return;
            }
            
            Boolean ok = false;
            if (issua)
                ok = SuaDoiTac();
            else
            {
                ok = ThemDoiTac();
            }
            if (ok)
            {

                try
                {
                    AddDoiTac(dt_id, txtMa.Text.Trim(), txtTen.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(), txtEmail.Text.Trim(), txtMaSoThue.Text.Trim(), txtGhiChu.Text.Trim(), chkTrangThai.Checked, TTHUtils.LoaiBoDauTiengViet(txtMa.Text.Trim() + txtTen.Text.Trim() + txtDiaChi.Text.Trim() + txtDienThoai.Text.Trim() + txtEmail.Text.Trim() + txtMaSoThue.Text.Trim()));
                }
                catch (Exception)
                {


                }
                try
                {
                    EditDoiTac(dt_id, txtMa.Text.Trim(), txtTen.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(), txtEmail.Text.Trim(), txtMaSoThue.Text.Trim(), txtGhiChu.Text.Trim(), chkTrangThai.Checked, TTHUtils.LoaiBoDauTiengViet(txtMa.Text.Trim() + txtTen.Text.Trim() + txtDiaChi.Text.Trim() + txtDienThoai.Text.Trim() + txtEmail.Text.Trim() + txtMaSoThue.Text.Trim()));
                }
                catch (Exception)
                {


                }
                try
                {
                    LayDSDoiTac();
                }
                catch (Exception)
                {


                }
                try
                {
                    SetDoiTac(dt_id);
                }
                catch (Exception)
                {


                }
                if (issua == true || frmReq.Trim().Length > 0)
                    this.Close();
                issua = false;
                dt_id = DateTime.Now.ToString("yyMMddHHmmss");//.Substring(8, 6) + TTHUtils.TaoMaSoNgauNhien(2);
                if (Info.tusinhma)
                {
                    txtMa.Text = TTHUtils.TaoMaSoNgauNhien(Info.dodaimadoitac);
                    txtMa.Enabled = false;
                    txtTen.Focus();
                }
                else
                {
                    txtMa.Text = "";
                    txtMa.Enabled = true;
                    txtMa.Focus();
                }
                txtTen.Text = "";
                txtDiaChi.Text = "";
                txtDienThoai.Text = "";
                txtEmail.Text = "";
                txtMaSoThue.Text = "";
                txtGhiChu.Text = "";
                spnNoBanDau.EditValue = 0;
                //chkTrangThai.Checked = false;
                //txtKhoiTaoNo.EditValue = 0.0;

            }
            else TTHMessage.ShowMessageWarming("Không thể lưu. Xin kiểm tra lại thông tin!");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}