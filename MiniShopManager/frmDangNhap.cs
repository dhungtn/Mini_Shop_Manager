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
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        
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

                writer.WriteStartElement("UserInfo");

                writer.WriteStartElement("NhoTenDangNhap");
                writer.WriteString(save);
                writer.WriteEndElement();

                writer.WriteStartElement("TenDangNhap");
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
            DataAccess cls = new DataAccess();
            string sql = "select * from DonVi where DV_KichHoat = 'True' and DV_ID = '" + id + "'";
            return cls.GetDataTable(sql);
        }
        public DataTable LayThongTinNguoiDung(string tendangnhap, string matkhau)
        {
            DataAccess cls = new DataAccess();
            string sql = "select ND_ID, ND_Ten, ND_TenDangNhap, ND_DV_ID ";
            sql += "from NguoiDung ";
            sql += "where ND_TenDangNhap = '" + tendangnhap + "' and ND_MatKhau = '" + TTHUtils.MaHoaBase64(System.Text.Encoding.UTF8.GetBytes(matkhau)) + "' and ND_KichHoat = 'True'";
            return cls.GetDataTable(sql);
        }
        public frmDangNhap()
        {
            InitializeComponent();
        }
        //public void LayDSCaLamViec()
        //{
        //    DataAccess cls = new DataAccess();
        //    string sql = "select * from CaLamViec where CLV_KichHoat = 'True' ";
        //    glkuCaLamViec.Properties.DataSource = cls.GetDataTable(sql);
        //    glkuCaLamViec.Properties.DisplayMember = "CLV_Ten";
        //    glkuCaLamViec.Properties.ValueMember = "CLV_ID";
        //    glkuCaLamViec.Properties.PopupFormWidth = glkuCaLamViec.Size.Width - 4;
        //    if (glkuvCaLamViec.RowCount > 0)
        //    {
        //        DataRow row = glkuvCaLamViec.GetDataRow(0);
        //        glkuCaLamViec.EditValue = row["CLV_ID"].ToString().Trim();
        //    }
        //}
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            this.Text = Info.tenphanmem;
            if (System.IO.File.Exists(Application.StartupPath + "\\userinfo.xml"))
            {
                // doc thong tin trong file inv de lay thong tin server
                XmlTextReader myXML = new XmlTextReader("userinfo.xml");

                try
                {
                    while (myXML.Read())
                    {
                        if (myXML.LocalName == "NhoTenDangNhap")
                        {
                            chkNho.Checked = Boolean.Parse( myXML.ReadString());
                        }
                        if (myXML.LocalName == "TenDangNhap")
                        {
                           txtTenDangNhap.Text = myXML.ReadString();
                           txtMatKhau.Focus();
                        }
                        
                        
                    }
                    myXML.Close();
                    //LayDSCaLamViec();
                }
                catch (Exception)
                {

                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (Info.nd_id.Length == 0) Application.Exit();
            else this.Close();
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

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            frmCauHinhDuLieu frm = new frmCauHinhDuLieu();
            frm.ShowDialog();
        }

        private void lnkChinhSua_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCauHinhDuLieu frm = new frmCauHinhDuLieu();
            frm.ShowDialog();
        }
    }
}