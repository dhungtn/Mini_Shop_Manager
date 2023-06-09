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
    public partial class frmDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        public DataTable LayThongTinNguoiDung()
        {
            DataAccess cls = new DataAccess();
            string sql = "select * from NguoiDung ";
            sql += "where ND_TenDangNhap = '" + txtTenDangNhap.Text.Trim() + "' and ND_MatKhau = '" + TTHUtils.MaHoaBase64(System.Text.Encoding.UTF8.GetBytes(txtMatKhau.Text.Trim())) + "'";
            return cls.GetDataTable(sql);

        }
        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập mật khẩu cũ!");
                txtMatKhau.Focus();
                return;
            }
            if (txtMatKhauMoi.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập mật khẩu mới!");
                txtMatKhauMoi.Focus();
                return;
            }
            if (txtXacNhanMatKhauMoi.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa xác nhận lại mật khẩu mới!");
                txtXacNhanMatKhauMoi.Focus();
                return;
            }
            if (txtMatKhauMoi.Text.Trim() != txtXacNhanMatKhauMoi.Text.Trim())
            {
                TTHMessage.ShowMessageWarming("Bạn xác nhận mật khẩu mới không chính xác!");
                txtXacNhanMatKhauMoi.Focus();
                return;
            }
            if (LayThongTinNguoiDung().Rows.Count > 0)
            {
                DataAccess cls = new DataAccess();
                string sql = "update NguoiDung set ND_MatKhau = '" + TTHUtils.MaHoaBase64(System.Text.Encoding.UTF8.GetBytes(txtMatKhauMoi.Text.Trim())) + "' where ND_TenDangNhap = '" + txtTenDangNhap.Text.Trim() + "' and ND_MatKhau = '" + TTHUtils.MaHoaBase64(System.Text.Encoding.UTF8.GetBytes(txtMatKhau.Text.Trim())) + "'";
                if (cls.ExecuteNonQuery(sql))
                {
                    TTHMessage.ShowMessageInfomation("Đã đổi mật khẩu thành công!");
                    this.Close();
                }
                else
                {
                    TTHMessage.ShowMessageWarming("Không thể đổi mật khẩu này!");
                }
            }
            else
            {
                TTHMessage.ShowMessageWarming("Tên đăng nhập hoặc mật khẩu không chính xác!");
                txtMatKhau.Focus();
                txtMatKhau.SelectAll();
            }
        }
        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = Info.nd_tendangnhap;
        }

        private void btnDongLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}