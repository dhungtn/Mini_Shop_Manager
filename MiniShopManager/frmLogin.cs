using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using System.Xml;
using MyRMS.HeThong;
namespace MyRMS
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public frmLogin()
        {
            InitializeComponent();
        }
        public Boolean kiemTraThongTin()
        {
            if (txtTenDangNhap.Text.Trim() == "")
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập tên đăng nhập!");
                txtTenDangNhap.Focus();
                return false;
            }
            if (txtMatKhau.Text.Trim() == "")
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập tên mật khẩu!");
                txtMatKhau.Focus();
                return false;
            }

            return true;
        }
        public void saveXml(string filename, string save, string username)
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;

                writer.WriteStartElement("Info");

                writer.WriteStartElement("Save");
                writer.WriteString(save);
                writer.WriteEndElement();

                writer.WriteStartElement("UserName");
                writer.WriteString(username);
                writer.WriteEndElement();

                //writer.WriteStartElement("Password");
                //writer.WriteString(Utils.MaHoaBase64(System.Text.Encoding.UTF8.GetBytes(password)));
                //writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
            catch (Exception ex)
            {
                TTHMessage.ShowMessageWarming(ex.ToString());
            }

        }
        public DataTable LayThongTinDonVi(string id)
        {
            string sql = "select * from DonVi where DV_TrangThai = 'True' and DV_ID = '" + id + "'";
            return cls.GetDataTable(sql);
        }
        public DataTable LayThongTinNguoiDung(string tendangnhap, string matkhau)
        {
            string sql = "select ND_ID, ND_Ten, ND_TenDangNhap, ND_DV_ID ";
            sql += "from NguoiDung ";
            sql += "where ND_TenDangNhap = '" + tendangnhap + "' and ND_MatKhau = '" + TTHUtils.MaHoaBase64(System.Text.Encoding.UTF8.GetBytes(matkhau)) + "' and ND_TrangThai = 'True'";
            return cls.GetDataTable(sql);
        }
        
        private void lnkThietLapServer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Application.StartupPath + "\\userinfo.xml"))
            {
                try
                {
                    XmlTextReader myXML = new XmlTextReader("userinfo.xml");
                    while (myXML.Read())
                    {
                        if (myXML.LocalName == "UserName")
                        {
                            txtTenDangNhap.Text = myXML.ReadString().Trim();
                        }
                        if (myXML.LocalName == "Save")
                        {
                            if (myXML.ReadString().Trim() == "True")
                                chkNho.Checked = true;
                            else chkNho.Checked = false;
                        }

                    }
                    myXML.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }

            }
            txtMatKhau.Focus();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (kiemTraThongTin() == false)
                return;
            WaitDialogForm dg = new WaitDialogForm("Xin vui lòng chờ trong giây lát!", "Đang xử lý dữ liệu...");
            DataTable dt = LayThongTinNguoiDung(txtTenDangNhap.Text.Trim(), txtMatKhau.Text.Trim());

            if (dt.Rows.Count > 0)
            {
                Info.islogin = true;
                DataRow dr = dt.Rows[0];
                Info.nd_id = dr["ND_ID"].ToString();
                Info.nd_ten = dr["ND_Ten"].ToString();
                Info.nd_tendangnhap = dr["ND_TenDangNhap"].ToString();
                foreach (DataRow dr1 in LayThongTinDonVi(dr["ND_DV_ID"].ToString().Trim()).Rows)
                {
                    Info.dv_id = dr1["DV_ID"].ToString();
                    Info.dv_ten = dr1["DV_Ten"].ToString();
                    Info.dv_diachi = dr1["DV_DiaChi"].ToString();
                    Info.dv_dienthoai = dr1["DV_DienThoai"].ToString();
                    Info.dv_email = dr1["DV_Email"].ToString();
                    Info.dv_nguoilienhe = dr1["DV_NguoiLienHe"].ToString();
                }
                if (chkNho.Checked)
                    saveXml("userinfo.xml", chkNho.Checked.ToString(), txtTenDangNhap.Text.Trim());
                else saveXml("userinfo.xml", chkNho.Checked.ToString(), "");
                dg.Close();
                this.Close();
            }
            else
            {
                dg.Close();
                TTHMessage.ShowMessageWarming("Tên đăng nhập hoặc mật khẩu không chính xác");
                return;
            }
        }
    }
}