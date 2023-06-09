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
    public partial class frmKhuVucUpdate : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void AddKhuVucDelegate(string id,  string ten);
        public AddKhuVucDelegate AddKhuVuc;
        public delegate void EditKhuVucDelegate(string id, string ten);
        public EditKhuVucDelegate EditKhuVuc;
        public delegate void GetDataTableDelegate();
        public GetDataTableDelegate LayDSKhuVuc;
        //public delegate void GetDataDelegate();
        //public GetDataDelegate LayDSKhuVuc2;
        public delegate void SetStringDelegate(string id);
        public SetStringDelegate setKhuVuc;
        public Boolean issua = false;
        public string kv_id = "";
        public string frmText = "";
        public frmKhuVucUpdate()
        {
            InitializeComponent();
        }

        public Boolean ThemKhuVuc()
        {
            string[] field = { "KV_ID", "KV_Ten", "KV_DonGia", "KV_PhiKhoiTao",  "KV_GhiChu", "KV_KichHoat", "KV_DV_ID", "KV_TuKhoa"};
            object[] value = { (object)kv_id, (object)txtTen.Text.Trim(), (object)double.Parse(spnDonGia.EditValue.ToString()), (object)double.Parse(spnPhiKhoiTao.EditValue.ToString()), (object)txtGhiChu.Text.Trim(), (object)chkTrangThai.Checked, (object)Info.dv_id, (object)TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim()) };
            return cls.AddRecord("KhuVuc", field, value);
        }
        public Boolean SuaKhuVuc()
        {
            string[] field = { "KV_Ten", "KV_DonGia", "KV_PhiKhoiTao", "KV_GhiChu", "KV_KichHoat", "KV_DV_ID", "KV_TuKhoa" };
            object[] value = { (object)txtTen.Text.Trim(), (object)double.Parse(spnDonGia.EditValue.ToString()), (object)double.Parse(spnPhiKhoiTao.EditValue.ToString()), (object)txtGhiChu.Text.Trim(), (object)chkTrangThai.Checked, (object)Info.dv_id, (object)TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim()) };
            string[] fieldwhere = { "KV_ID" };
            object[] objwhere = { (object)kv_id };
            return cls.EditRecord("KhuVuc", field, value, fieldwhere, objwhere);
        }
        public void LayThongTinKhuVuc()
        {
            DataAccess cls = new DataAccess();
            string sql = "select * from KhuVuc where KV_ID = '" + kv_id + "'";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                txtTen.Text = dr["KV_Ten"].ToString().Trim();
                spnDonGia.EditValue = double.Parse(dr["KV_DonGia"].ToString());
                spnPhiKhoiTao.EditValue = double.Parse(dr["KV_PhiKhoiTao"].ToString());
                txtGhiChu.Text = dr["KV_GhiChu"].ToString().Trim();
                chkTrangThai.Checked = (Boolean)dr["KV_KichHoat"];
                
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
            if (issua) ok = SuaKhuVuc();
            else
            {
                ok = ThemKhuVuc();
            }
            if (ok)
            {
                try
                {
                    LayDSKhuVuc();
                }
                catch (Exception)
                {


                }
                try
                {
                    AddKhuVuc(kv_id, txtTen.Text.Trim());
                }
                catch (Exception)
                {


                }
                try
                {
                    EditKhuVuc(kv_id, txtTen.Text.Trim());
                }
                catch (Exception)
                {


                }
                try
                {
                    LayDSKhuVuc();
                }
                catch (Exception)
                {


                }
                if (issua == true)
                    this.Close();
                txtTen.Text = "";
                txtGhiChu.Text = "";
                kv_id = DateTime.Now.ToString("yyMMddHHmmss");//.Substring(8, 6) + TTHUtils.TaoMaSoNgauNhien(4);
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

        private void frmKhuVucUpdate_Load(object sender, EventArgs e)
        {
            this.Text = frmText;
            if (issua)
            {
                LayThongTinKhuVuc();
            }
            else
            {
                kv_id = DateTime.Now.ToString("yyMMddHHmmss");
            }
        }

        
    }
}