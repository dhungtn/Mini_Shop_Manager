using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
namespace MyRMS.HeThong
{
    public partial class frmNhomChucNangUpdate : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void AddNhomChucNangDelegate(string id,  string ten);
        public AddNhomChucNangDelegate AddNhomChucNang;
        public delegate void EditNhomChucNangDelegate(string id, string ten);
        public EditNhomChucNangDelegate EditNhomChucNang;
        public delegate void GetDataTableDelegate();
        public GetDataTableDelegate LayDSNhomChucNang;
        //public delegate void GetDataDelegate();
        //public GetDataDelegate LayDSNhomChucNang2;
        public delegate void SetStringDelegate(string id);
        public SetStringDelegate setNhomChucNang;
        public Boolean issua = false;
        public string ncn_id = "";
        public string frmText = "";
        public frmNhomChucNangUpdate()
        {
            InitializeComponent();
        }

        public Boolean ThemNhomChucNang()
        {
            string[] field = { "NCN_ID", "NCN_Ten",   "NCN_GhiChu"};
            object[] value = { (object)ncn_id, (object)txtTen.Text.Trim(),  (object)txtGhiChu.Text.Trim() };
            return cls.AddRecord("NhomChucNang", field, value);
        }
        public Boolean SuaNhomChucNang()
        {
            string[] field = { "NCN_Ten", "NCN_GhiChu" };
            object[] value = { (object)txtTen.Text.Trim(), (object)txtGhiChu.Text.Trim() };
            string[] fieldwhere = { "NCN_ID" };
            object[] objwhere = { (object)ncn_id };
            return cls.EditRecord("NhomChucNang", field, value, fieldwhere, objwhere);
        }
        public void LayThongTinNhomChucNang()
        {
            DataAccess cls = new DataAccess();
            string sql = "select * from NhomChucNang where NCN_ID = '" + ncn_id + "'";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                txtTen.Text = dr["NCN_Ten"].ToString().Trim();
                txtGhiChu.Text = dr["NCN_GhiChu"].ToString().Trim();                
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
            if (issua) ok = SuaNhomChucNang();
            else
            {
                ok = ThemNhomChucNang();
            }
            if (ok)
            {
                try
                {
                    LayDSNhomChucNang();
                }
                catch (Exception)
                {


                }
                try
                {
                    AddNhomChucNang(ncn_id, txtTen.Text.Trim());
                }
                catch (Exception)
                {


                }
                try
                {
                    EditNhomChucNang(ncn_id, txtTen.Text.Trim());
                }
                catch (Exception)
                {


                }
                try
                {
                    LayDSNhomChucNang();
                }
                catch (Exception)
                {


                }
                if (issua == true)
                    this.Close();
                txtTen.Text = "";
                txtGhiChu.Text = "";
                ncn_id = DateTime.Now.ToString("yyMMddHHmmss");//.Substring(8, 6) + TTHUtils.TaoMaSoNgauNhien(4);
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

        private void frmNhomChucNangUpdate_Load(object sender, EventArgs e)
        {
            this.Text = frmText;
            if (issua)
            {
                LayThongTinNhomChucNang();
            }
            else
            {
                ncn_id = DateTime.Now.ToString("yyMMddHHmmss");
            }
        }

        

        
    }
}