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
    public partial class frmVaiTroUpdate : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void AddVaiTro(string id,  string ten);
        public AddVaiTro AddVaiTroDelegate;
        public delegate void EditVaiTro(string id, string ten);
        public EditVaiTro EditVaiTroDelegate;
        public delegate void GetDataTable();
        public GetDataTable LayDSVaiTroDelegate;
        public delegate void SetString(string idloai);
        public SetString setVaiTro;
        public Boolean issua = false;
        public string vt_id = "";
        public string frmText = "";
        public frmVaiTroUpdate()
        {
            InitializeComponent();
        }

        public Boolean ThemVaiTro()
        {
            //DataAccess cls = new DataAccess();
            string[] field = { "VT_ID", "VT_Ten", "VT_GhiChu", "VT_KichHoat",  "VT_TuKhoa" };
            object[] value = { (object)vt_id, (object)txtTen.Text.Trim(), (object)txtGhiChu.Text.Trim(), (object)chkKichHoat.Checked, (object)TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim()) };
            return cls.AddRecord("VaiTro", field, value);
        }
        public Boolean SuaVaiTro()
        {
            //DataAccess cls = new DataAccess();
            string[] field = { "VT_Ten",  "VT_GhiChu", "VT_KichHoat", "VT_TuKhoa"};
            object[] value = { (object)txtTen.Text.Trim(), (object)txtGhiChu.Text.Trim(), (object)chkKichHoat.Checked, (object)TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim())};
            string[] fieldwhere = { "VT_ID" };
            object[] objwhere = { (object)vt_id };
            return cls.EditRecord("VaiTro", field, value, fieldwhere, objwhere);
        }
        public void LayThongTinVaiTro()
        {
            //DataAccess cls = new DataAccess();
            string sql = "select * from VaiTro where VT_ID = '" + vt_id + "'";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                txtTen.Text = dr["VT_Ten"].ToString().Trim();
                txtGhiChu.Text = dr["VT_GhiChu"].ToString().Trim();
                chkKichHoat.Checked = (Boolean)dr["VT_KichHoat"];
                
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

       

        

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTen.Text.Trim().Equals(""))
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập tên.");
                txtTen.Focus();
                return;

            }
            Boolean ok = false;
            if (issua) ok = SuaVaiTro();
            else
            {
                ok = ThemVaiTro();
            }
            if (ok)
            {
                try
                {
                    LayDSVaiTroDelegate();
                }
                catch (Exception)
                {


                }

                try
                {
                    AddVaiTroDelegate(vt_id, txtTen.Text.Trim());
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
                    EditVaiTroDelegate(vt_id, txtTen.Text.Trim());
                }
                catch (Exception)
                {


                }
                if (issua == true)
                    this.Close();
                txtTen.Text = "";
                txtGhiChu.Text = "";
                vt_id = DateTime.Now.ToString("yyMMddHHmmss");
                txtTen.Focus();
            }
            else TTHMessage.ShowMessageWarming("Không thể lưu.Xin vui lòng kiểm tra lại thông tin!");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVaiTroUpdate_Load(object sender, EventArgs e)
        {
            this.Text = frmText;
            if (issua)
            {
                LayThongTinVaiTro();
            }
            else
            {
                vt_id = DateTime.Now.ToString("yyMMddHHmmss");
            }
        }

        

    }
}