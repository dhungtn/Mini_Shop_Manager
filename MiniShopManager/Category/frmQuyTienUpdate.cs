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
    public partial class frmQuyTienUpdate : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void AddQuyTien(string idloai,  string tenloai, string ghichuloai, Boolean ngungtheodoi);
        public AddQuyTien add;
        public delegate void EditQuyTien(string idloai, string tenloai, string ghichuloai, Boolean ngungtheodoi);
        public EditQuyTien edit;
        public delegate void GetDataTable();
        public GetDataTable LayDSQuyTienDelegate;
        public delegate void SetString(string idloai);
        public SetString setQuyTien;
        public Boolean issua = false;
        public string qt_id = "";
        public string frmReq = "";
        public string frmText = "";
        public frmQuyTienUpdate()
        {
            InitializeComponent();
        }

        public Boolean ThemQuyTien()
        {
            //DataAccess cls = new DataAccess();
            string[] field = { "QT_ID", "QT_Ten", "QT_GhiChu", "QT_TrangThai",  "QT_TuKhoa"};
            object[] value = { (object)qt_id, (object)txtTen.Text.Trim(), (object)txtGhiChu.Text.Trim(), (object)chkTrangThai.Checked, (object)TTHUtils.RejectMarks1(txtTen.Text.Trim()) };
            return cls.AddRecord("QuyTien", field, value);
        }
        public Boolean SuaQuyTien()
        {
            //DataAccess cls = new DataAccess();
            string[] field = { "QT_Ten", "QT_GhiChu", "QT_TrangThai",  "QT_TuKhoa" };
            object[] value = { (object)txtTen.Text.Trim(), (object)txtGhiChu.Text.Trim(), (object)chkTrangThai.Checked, (object)TTHUtils.RejectMarks1(txtTen.Text.Trim()) };
            string[] fieldwhere = { "QT_ID" };
            object[] objwhere = { (object)qt_id };
            return cls.EditRecord("QuyTien", field, value, fieldwhere, objwhere);
        }
        public void LayThongTinQuyTien()
        {
            //DataAccess cls = new DataAccess();
            string sql = "select * from QuyTien where QT_ID = '" + qt_id + "'";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                txtTen.Text = dr["QT_Ten"].ToString().Trim();
                txtGhiChu.Text = dr["QT_GhiChu"].ToString().Trim();
                chkTrangThai.Checked = (Boolean)dr["QT_TrangThai"];
                
            }
        }
        

        


        private void barF6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtTen.Text.Trim().Equals(""))
            {
                TTHMessage.ShowMessageWarming( "Bạn chưa nhập tên.");
                txtTen.Focus();
                return;

            }
            Boolean ok = false;
            if (issua) ok = SuaQuyTien();
            else
            {
                ok = ThemQuyTien();
            }
            if (ok)
            {
                try
                {
                    LayDSQuyTienDelegate();
                }
                catch (Exception)
                {
                    
                   
                }
                try
                {
                    setQuyTien(qt_id);
                }
                catch (Exception)
                {
                    
                    
                }
                try
                {
                    add(qt_id, txtTen.Text.Trim(), txtGhiChu.Text.Trim(), chkTrangThai.Checked);
                }
                catch (Exception)
                {


                }
                try
                {
                    edit(qt_id, txtTen.Text.Trim(), txtGhiChu.Text.Trim(), chkTrangThai.Checked);
                }
                catch (Exception)
                {


                }
                if (issua == true || frmReq.Trim().Length > 0)
                    this.Close();
                txtTen.Text = "";
                txtGhiChu.Text = "";
                //chkTrangThai.Checked = false;
                qt_id = DateTime.Now.ToString("yyMMddHHmmss");
                txtTen.Focus();
            }
            else TTHMessage.ShowMessageWarming("Không thể lưu. Xin kiểm tra lại thông tin.");
        }

        private void barF12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void frmCapNhatQuyTien_Load(object sender, EventArgs e)
        {
            this.Text = frmText;
            if (issua)
            {
                LayThongTinQuyTien();
            }
            else
            {
                qt_id = DateTime.Now.ToString("yyMMddHHmmss");
            }
        }

    }
}