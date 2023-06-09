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
    public partial class frmChucNangUpdate : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void SetChucNangDelegate(string value);
        public SetChucNangDelegate SetChucNang;
        public delegate void GetDataTableDelegate();
        public GetDataTableDelegate LayDSChucNang;
        public delegate void AddChucNangDelegate(string CN_ID, string CN_Ten, string CN_GhiChu, Boolean CN_KichHoat);
        public AddChucNangDelegate AddChucNang;
        public delegate void EditChucNangDelegate(string CN_ID, string CN_Ten, string CN_GhiChu, Boolean CN_KichHoat);
        public EditChucNangDelegate EditChucNang;
        public string cn_id = "";
        //public string cn_idcu = "";
        public Boolean issua = false;
        public string frmReq = "";
        public string frmText = "";
        public string loai = "";
        public string ncn_id = "";
        public frmChucNangUpdate()
        {
            InitializeComponent();
        }
        public void LayDSNhomChucNang()
        {
            DataAccess cls = new DataAccess();
            string sql = "select NCN_ID, NCN_Ten from NhomChucNang  order by NCN_ID";
            glkuNhomChucNang.Properties.DataSource = cls.GetDataTable(sql);
            glkuNhomChucNang.Properties.ValueMember = "NCN_ID";
            glkuNhomChucNang.Properties.DisplayMember = "NCN_Ten";
            glkuNhomChucNang.Properties.PopupFormWidth = glkuNhomChucNang.Size.Width - 4;
            glkuvNhomChucNang.BestFitColumns();
            if (glkuvNhomChucNang.RowCount > 0)
            {
                DataRow row = glkuvNhomChucNang.GetDataRow(0);
                glkuNhomChucNang.EditValue = row["NCN_ID"].ToString().Trim();
            }
            if (ncn_id.Trim().Length > 0) glkuNhomChucNang.EditValue = ncn_id;
        }
        public Boolean ThemChucNang()
        {

            string[] field = { "CN_ID", "CN_Ten", "CN_GhiChu", "CN_KichHoat", "CN_NCN_ID" };
            object[] value = { (object)txtID.Text.Trim(), (object)txtTen.Text.Trim(), (object)txtGhiChu.Text.Trim(), (object)chkKichHoat.Checked, (object)glkuNhomChucNang.EditValue.ToString().Trim() };
            return cls.AddRecord("ChucNang", field, value);
            
        }
        public Boolean SuaChucNang()
        {
            string sql = "update ChucNang set CN_ID = '" + txtID.Text.Trim() + "', CN_Ten = N'" + txtTen.Text.Trim() + "', CN_GhiChu = N'" + txtGhiChu.Text.Trim() + "', ";
            sql += "CN_KichHoat = '" + chkKichHoat.Checked.ToString() + "', CN_NCN_ID = '" + glkuNhomChucNang.EditValue.ToString() + "' ";
            sql += "where CN_ID = '" + cn_id + "' ";
            return cls.ExecuteNonQuery(sql);
            //string[] field = {"CN_ID", "CN_Ten", "CN_GhiChu", "CN_KichHoat", "CN_NCN_ID"};
            //object[] value = {  (object)txtID.Text.Trim(), (object)txtTen.Text.Trim(),  (object)txtGhiChu.Text.Trim(), (object)chkKichHoat.Checked,  (object)glkuNhomChucNang.EditValue.ToString().Trim() };
            //string[] fieldwhere = { "CN_ID"};
            //object[] objwhere = { (object)cn_id };
            //return cls.EditRecord("ChucNang", field, value, fieldwhere, objwhere);
        }
        public void LayThongTinChucNang()
        {
            string sql = "select * from ChucNang where CN_ID = '" + cn_id + "'";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                glkuNhomChucNang.EditValue = dr["CN_NCN_ID"].ToString().Trim();
                txtID.Text = dr["CN_ID"].ToString().Trim();
                txtTen.Text = dr["CN_Ten"].ToString().Trim();
                txtGhiChu.Text = dr["CN_GhiChu"].ToString().Trim();
                chkKichHoat.Checked = (bool)dr["CN_KichHoat"];
            }
        }
        private void frmCapNhatHangHoa_Load(object sender, EventArgs e)
        {
            this.Text = frmText;
            LayDSNhomChucNang();
            if (issua)
            {
                LayThongTinChucNang();

            }
            else
            {
                cn_id = DateTime.Now.ToString("yyMMddHHmmss");
                txtID.Focus();
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
            if (txtID.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập ID.");
                txtID.Focus();
                return;
            }
            if (txtTen.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập tên khách hàng.");
                txtTen.Focus();
                return;
            }
            if (glkuNhomChucNang.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa chọn khu vực.");
                txtTen.Focus();
                return;
            }
            Boolean ok = false;
            if (issua)
                ok = SuaChucNang();
            else
            {
                ok = ThemChucNang();
            }
            if (ok)
            {

                try
                {
                    AddChucNang(txtID.Text.Trim(), txtTen.Text.Trim(), txtGhiChu.Text.Trim(), chkKichHoat.Checked);
                }
                catch (Exception)
                {


                }
                try
                {
                    EditChucNang(txtID.Text.Trim(), txtTen.Text.Trim(), txtGhiChu.Text.Trim(), chkKichHoat.Checked);
                }
                catch (Exception)
                {


                }
                try
                {
                    LayDSChucNang();
                }
                catch (Exception)
                {


                }
                try
                {
                    SetChucNang(cn_id);
                }
                catch (Exception)
                {


                }
                if (issua == true || frmReq.Trim().Length > 0)
                    this.Close();
                issua = false;
                cn_id = DateTime.Now.ToString("yyMMddHHmmss");
                if (chkSaoChep.Checked)
                {
                    txtID.Focus();
                    txtID.SelectAll();
                }
                else
                {
                    txtID.Text = "";
                    txtTen.Text = "";
                    txtGhiChu.Text = "";
                    txtID.Focus();
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