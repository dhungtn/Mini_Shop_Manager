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
    public partial class frmCaLamViecUpdate : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void AddCaLamViecDelegate(string CLV_ID, string CLV_Ten, string CLV_GhiChu, Boolean CLV_KichHoat, string CLV_TuKhoa);
        public AddCaLamViecDelegate AddCaLamViec;
        public delegate void EditCaLamViecDelegate(string CLV_ID, string CLV_Ten, string CLV_GhiChu, Boolean CLV_KichHoat, string CLV_TuKhoa);
        public EditCaLamViecDelegate EditCaLamViec;
        public delegate void GetDataTableDelegate();
        public GetDataTableDelegate LayDSCaLamViec;
        public delegate void SetCaLamViecDelegate(string s);
        public SetCaLamViecDelegate SetCaLamViec;
        public Boolean issua = false;
        public string clv_id = "";
        public string frmText = "";
        public frmCaLamViecUpdate()
        {
            InitializeComponent();
        }

        public Boolean ThemCaLamViec()
        {
            //DataAccess cls = new DataAccess();
            string[] field = { "CLV_ID", "CLV_Ten", "CLV_GhiChu", "CLV_KichHoat",  "CLV_TuKhoa" };
            object[] value = { (object)clv_id, (object)txtTen.Text.Trim(), (object)txtGhiChu.Text.Trim(), (object)chkKichHoat.Checked, (object)TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim()) };
            return cls.AddRecord("CaLamViec", field, value);
        }
        public Boolean SuaCaLamViec()
        {
            //DataAccess cls = new DataAccess();
            string[] field = { "CLV_Ten", "CLV_GhiChu", "CLV_KichHoat", "CLV_TuKhoa" };
            object[] value = { (object)txtTen.Text.Trim(), (object)txtGhiChu.Text.Trim(), (object)chkKichHoat.Checked, (object)TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim()) };
            string[] fieldwhere = { "CLV_ID" };
            object[] objwhere = { (object)clv_id };
            return cls.EditRecord("CaLamViec", field, value, fieldwhere, objwhere);
        }
        public void LayThongTinCaLamViec()
        {
            //DataAccess cls = new DataAccess();
            string sql = "select * from CaLamViec where CLV_ID = '" + clv_id + "'";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                txtTen.Text = dr["CLV_Ten"].ToString().Trim();
                
                txtGhiChu.Text = dr["CLV_GhiChu"].ToString().Trim();
                chkKichHoat.Checked = (Boolean)dr["CLV_KichHoat"];
                
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

       

        private void frmCaLamViecUpdate_Load(object sender, EventArgs e)
        {
            this.Text = frmText;
            if (issua)
            {
                LayThongTinCaLamViec();
            }
            else
            {
                clv_id = DateTime.Now.ToString("yyMMddHHmmss");
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
            if (issua) ok = SuaCaLamViec();
            else
            {
                ok = ThemCaLamViec();
            }
            if (ok)
            {
                try
                {
                    LayDSCaLamViec();
                }
                catch (Exception)
                {


                }

                try
                {
                    AddCaLamViec(clv_id, txtTen.Text.Trim(), txtGhiChu.Text.Trim(), chkKichHoat.Checked, TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim()));
                }
                catch (Exception)
                {


                }

                try
                {
                    EditCaLamViec(clv_id, txtTen.Text.Trim(), txtGhiChu.Text.Trim(), chkKichHoat.Checked, TTHUtils.LoaiBoDauTiengViet(txtTen.Text.Trim()));
                }
                catch (Exception)
                {


                }
                if (issua == true)
                    this.Close();
                txtTen.Text = "";
                txtGhiChu.Text = "";
                clv_id = DateTime.Now.ToString("yyMMddHHmmss");
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