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
    public partial class frmLoaiHangUpdate : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void AddLoaiHangDelegate(string id,  string ten, string ghichu, Boolean ngungtheodoi);
        public AddLoaiHangDelegate AddLoaiHang;
        public delegate void EditLoaiHangDelegate(string id, string ten, string ghichu, Boolean ngungtheodoi);
        public EditLoaiHangDelegate EditLoaiHang;
        public delegate void GetDataTableDelegate();
        public GetDataTableDelegate LayDSLoaiHang;
        //public delegate void GetDataDelegate();
        //public GetDataDelegate LayDSLoaiHang2;
        public delegate void SetStringDelegate(string id);
        public SetStringDelegate SetLoaiHang;
        public Boolean issua = false;
        public string lh_id = "";
        public string frmText = "";
        public string frmReq = "";
        public byte[] imgArray = null;
        public frmLoaiHangUpdate()
        {
            InitializeComponent();
        }

        public Boolean ThemLoaiHang()
        {
            
            string[] field = { "LH_ID", "LH_Ten", "LH_GhiChu", "LH_KichHoat", "LH_DV_ID", "LH_TuKhoa"};
            object[] value = { (object)lh_id, (object)txtTen.Text.Trim(),  (object)txtGhiChu.Text.Trim(), (object)chkTrangThai.Checked, (object)Info.dv_id, (object)TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim()) };
            return cls.AddRecord("LoaiHang", field, value);
        }
        public Boolean SuaLoaiHang()
        {
            
            string[] field = { "LH_Ten",  "LH_GhiChu", "LH_KichHoat", "LH_DV_ID", "LH_TuKhoa" };
            object[] value = { (object)txtTen.Text.Trim(),  (object)txtGhiChu.Text.Trim(), (object)chkTrangThai.Checked, (object)Info.dv_id, (object)TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim()) };
            string[] fieldwhere = { "LH_ID" };
            object[] objwhere = { (object)lh_id };
            return cls.EditRecord("LoaiHang", field, value, fieldwhere, objwhere);
        }
        public void LayThongTinLoaiHang()
        {
            DataAccess cls = new DataAccess();
            string sql = "select * from LoaiHang where LH_ID = '" + lh_id + "'";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                txtTen.Text = dr["LH_Ten"].ToString().Trim();
                
                txtGhiChu.Text = dr["LH_GhiChu"].ToString().Trim();
                chkTrangThai.Checked = (Boolean)dr["LH_KichHoat"];
                
            }
        }
        

        

        private void frmCapNhatLoaiHang_Load(object sender, EventArgs e)
        {
            this.Text = frmText; 
            if (issua)
            {
                LayThongTinLoaiHang();
            }
            else
            {
                lh_id = DateTime.Now.ToString("yyMMddHHmmss");
            }
        }

       

        private void barF12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnDong_Click(null, null);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTen.Text.Trim().Equals(""))
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập tên!");
                txtTen.Focus();
                return;

            }
            Boolean ok = false;
            if (issua) ok = SuaLoaiHang();
            else
            {
                ok = ThemLoaiHang();
            }
            if (ok)
            {
                try
                {
                    LayDSLoaiHang();
                }
                catch (Exception)
                {


                }
                try
                {
                    AddLoaiHang(lh_id, txtTen.Text.Trim(), txtGhiChu.Text.Trim(), chkTrangThai.Checked);
                }
                catch (Exception)
                {


                }
                try
                {
                    EditLoaiHang(lh_id, txtTen.Text.Trim(), txtGhiChu.Text.Trim(), chkTrangThai.Checked);
                }
                catch (Exception)
                {


                }
                try
                {
                    SetLoaiHang(lh_id);
                }
                catch (Exception)
                {


                }
                if (issua == true || frmReq.Length > 0)
                    this.Close();
                txtTen.Text = "";
                txtGhiChu.Text = "";
                lh_id = DateTime.Now.ToString("yyyyMMddHHmmss");//.Substring(8, 6) + TTHUtils.TaoMaSoNgauNhien(4);
                txtTen.Focus();
            }
            else TTHMessage.ShowMessageError("Không thể lưu. Xin kiểm tra lại thông tin.");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void barF4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnLuu_Click(null, null);
        }

        

    }
}