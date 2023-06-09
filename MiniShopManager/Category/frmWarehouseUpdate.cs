using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
namespace MyRMS.DanhMuc
{
    public partial class frmKhoHangUpdate : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void AddKhoHangDelegate(string KH_ID, string KH_Ten, string KH_GhiChu, Boolean KH_KichHoat, string KH_TuKhoa);
        public AddKhoHangDelegate AddKhoHang;
        public delegate void EditKhoHangDelegate(string KH_ID, string KH_Ten, string KH_GhiChu, Boolean KH_KichHoat, string KH_TuKhoa);
        public EditKhoHangDelegate EditKhoHang;
        public delegate void GetDataTableDelegate();
        public GetDataTableDelegate LayDSKhoHang;
        public delegate void SetKhoHangDelegate(string s);
        public SetKhoHangDelegate SetKhoHang;
        public Boolean issua = false;
        public string kh_id = "";
        public string frmText = "";
        public frmKhoHangUpdate()
        {
            InitializeComponent();
        }

        public Boolean ThemKhoHang()
        {
            //DataAccess cls = new DataAccess();
            string[] field = { "KH_ID", "KH_Ten", "KH_GhiChu", "KH_KichHoat",  "KH_TuKhoa", "KH_DV_ID" };
            object[] value = { (object)kh_id, (object)txtTen.Text.Trim(), (object)txtGhiChu.Text.Trim(), (object)chkKichHoat.Checked, (object)TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim()), (object)Info.dv_id };
            return cls.AddRecord("KhoHang", field, value);
        }
        public Boolean SuaKhoHang()
        {
            //DataAccess cls = new DataAccess();
            string[] field = { "KH_Ten", "KH_GhiChu", "KH_KichHoat", "KH_TuKhoa", "KH_DV_ID" };
            object[] value = { (object)txtTen.Text.Trim(), (object)txtGhiChu.Text.Trim(), (object)chkKichHoat.Checked, (object)TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim()), (object)Info.dv_id };
            string[] fieldwhere = { "KH_ID" };
            object[] objwhere = { (object)kh_id };
            return cls.EditRecord("KhoHang", field, value, fieldwhere, objwhere);
        }
        public void LayThongTinKhoHang()
        {
            //DataAccess cls = new DataAccess();
            string sql = "select * from KhoHang where KH_ID = '" + kh_id + "'";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                txtTen.Text = dr["KH_Ten"].ToString().Trim();
                
                txtGhiChu.Text = dr["KH_GhiChu"].ToString().Trim();
                chkKichHoat.Checked = (Boolean)dr["KH_KichHoat"];
                
            }
        }
        

        

        private void barF6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnLuu_Click(null, null);
        }

        private void barF12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnDong_Click(null, null);
        }

       

        private void frmKhoHangUpdate_Load(object sender, EventArgs e)
        {
            this.Text = frmText;
            if (issua)
            {
                LayThongTinKhoHang();
            }
            else
            {
                kh_id = DateTime.Now.ToString("yyMMddHHmmss");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTen.Text.Trim().Equals(""))
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập tên.");
                txtTen.Focus();
                return;

            }
            Boolean ok = false;
            if (issua) ok = SuaKhoHang();
            else
            {
                ok = ThemKhoHang();
            }
            if (ok)
            {
                try
                {
                    LayDSKhoHang();
                }
                catch (Exception)
                {


                }

                try
                {
                    AddKhoHang(kh_id, txtTen.Text.Trim(), txtGhiChu.Text.Trim(), chkKichHoat.Checked, TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim()));
                }
                catch (Exception)
                {


                }

                try
                {
                    EditKhoHang(kh_id, txtTen.Text.Trim(), txtGhiChu.Text.Trim(), chkKichHoat.Checked, TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim()));
                }
                catch (Exception)
                {


                }
                if (issua == true)
                    this.Close();
                txtTen.Text = "";
                txtGhiChu.Text = "";
                kh_id = DateTime.Now.ToString("yyMMddHHmmss");
                txtTen.Focus();
            }
            else TTHMessage.ShowMessageWarming("Không thể lưu.Xin vui lòng kiểm tra lại thông tin!");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        

    }
}