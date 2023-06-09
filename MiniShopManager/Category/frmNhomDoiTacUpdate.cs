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
    public partial class frmNhomDoiTacUpdate : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void AddNhomDoiTac(string id,  string ten);
        public AddNhomDoiTac AddNhomDoiTacDelegate;
        public delegate void EditNhomDoiTac(string id, string ten);
        public EditNhomDoiTac EditNhomDoiTacDelegate;
        public delegate void GetDataTable();
        public GetDataTable LayDSNhomDoiTacDelegate;
        public delegate void SetString(string idloai);
        public SetString setNhomDoiTac;
        public Boolean issua = false;
        public string ndt_id = "";
        public string frmText = "";
        public frmNhomDoiTacUpdate()
        {
            InitializeComponent();
        }

        public Boolean ThemNhomDoiTac()
        {
            //DataAccess cls = new DataAccess();
            string[] field = { "NDT_ID", "NDT_Ten","NDT_ChietKhau", "NDT_GhiChu", "NDT_KichHoat",  "NDT_TuKhoa", "NDT_DV_ID" };
            object[] value = { (object)ndt_id, (object)txtTen.Text.Trim(), (object)double.Parse(txtChietKhau.EditValue.ToString()), (object)txtGhiChu.Text.Trim(), (object)chkKichHoat.Checked, (object)TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim()), (object)Info.dv_id };
            return cls.AddRecord("NhomDoiTac", field, value);
        }
        public Boolean SuaNhomDoiTac()
        {
            //DataAccess cls = new DataAccess();
            string[] field = { "NDT_Ten", "NDT_ChietKhau", "NDT_GhiChu", "NDT_KichHoat", "NDT_TuKhoa", "NDT_DV_ID" };
            object[] value = { (object)txtTen.Text.Trim(), (object)double.Parse(txtChietKhau.EditValue.ToString()), (object)txtGhiChu.Text.Trim(), (object)chkKichHoat.Checked, (object)TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim()), (object)Info.dv_id };
            string[] fieldwhere = { "NDT_ID" };
            object[] objwhere = { (object)ndt_id };
            return cls.EditRecord("NhomDoiTac", field, value, fieldwhere, objwhere);
        }
        public void LayThongTinNhomDoiTac()
        {
            //DataAccess cls = new DataAccess();
            string sql = "select * from NhomDoiTac where NDT_ID = '" + ndt_id + "'";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                txtTen.Text = dr["NDT_Ten"].ToString().Trim();
                txtChietKhau.EditValue = double.Parse(dr["NDT_ChietKhau"].ToString());
                txtGhiChu.Text = dr["NDT_GhiChu"].ToString().Trim();
                chkKichHoat.Checked = (Boolean)dr["NDT_KichHoat"];
                
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

       

        private void frmNhomDoiTacUpdate_Load(object sender, EventArgs e)
        {
            this.Text = frmText;
            if (issua)
            {
                LayThongTinNhomDoiTac();
            }
            else
            {
                ndt_id = DateTime.Now.ToString("yyMMddHHmmss");
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
            if (issua) ok = SuaNhomDoiTac();
            else
            {
                ok = ThemNhomDoiTac();
            }
            if (ok)
            {
                try
                {
                    LayDSNhomDoiTacDelegate();
                }
                catch (Exception)
                {


                }

                try
                {
                    AddNhomDoiTacDelegate(ndt_id, txtTen.Text.Trim());
                }
                catch (Exception)
                {


                }
                //try
                //{
                //    add(kv_id, txtTen.Text.Trim(), double.Parse(txtChietKhau.EditValue.ToString()), txtGhiChu.Text.Trim(), chkTrangThai.Checked);
                //}
                //catch (Exception)
                //{


                try
                {
                    EditNhomDoiTacDelegate(ndt_id, txtTen.Text.Trim());
                }
                catch (Exception)
                {


                }
                if (issua == true)
                    this.Close();
                txtTen.Text = "";
                txtChietKhau.EditValue = 0.0;
                txtGhiChu.Text = "";
                ndt_id = DateTime.Now.ToString("yyMMddHHmmss");
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