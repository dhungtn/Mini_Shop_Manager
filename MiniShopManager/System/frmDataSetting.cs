using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Xml;
namespace MyRMS.HeThong
{
    public partial class frmCauHinhDuLieu : DevExpress.XtraEditors.XtraForm
    {
        SQLServer cls = new SQLServer();
        //Nơi lưu trữ dữ liệu
        public string noiluutru = "";
        public frmCauHinhDuLieu()
        {
            InitializeComponent();
        }
        public void SaveXml(string filename, string authenwindows, string server, string databasename, string username, string password, string path, string save)
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;

                writer.WriteStartElement("Database");

                writer.WriteStartElement("ServerName");

                writer.WriteString(server);
                writer.WriteEndElement();

                writer.WriteStartElement("AuthenWindows");
                writer.WriteString(authenwindows);
                writer.WriteEndElement();

                writer.WriteStartElement("UserName");
                writer.WriteString(username);
                writer.WriteEndElement();

                writer.WriteStartElement("Password");
                //Mã hóa password
                writer.WriteString(TTHUtils.MaHoaBase64(System.Text.Encoding.UTF8.GetBytes(password)));
                //writer.WriteString(password);
                writer.WriteEndElement();

                writer.WriteStartElement("DatabaseName");
                writer.WriteString(databasename);
                writer.WriteEndElement();
                writer.WriteStartElement("Path");
                writer.WriteString(path);
                writer.WriteEndElement();
                writer.WriteStartElement("save");
                writer.WriteString(save);
                writer.WriteEndElement();



                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
            catch (Exception ex)
            {
                TTHMessage.ShowMessageWarming(ex.ToString());
            }
            
        }
        public void LayDSMayChu()
        {
            //TTHWait.ShowWait();
            WaitDialogForm dg = new WaitDialogForm("Xin vui lòng chờ trong giây lát!","Đang dò tìm các máy chủ dữ liệu...");
            cboMayChu.Text = "";
            cboMayChu.Properties.Items.Clear();
            DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
            for (int i = 0; i < servers.Rows.Count; i++)
            {
                if (servers.Rows[i][1].ToString().Trim().Length > 0)
                    cboMayChu.Properties.Items.Add(servers.Rows[i][0].ToString() + "\\" + servers.Rows[i][1].ToString());
                else
                    cboMayChu.Properties.Items.Add(servers.Rows[i][0].ToString() + "\\SQLEXPRESS");

            }
            dg.Close();
            if (cboMayChu.Properties.Items.Count >= 1)
            {
                cboMayChu.SelectedIndex = 0;
                cboMayChu.ShowPopup();
            }
            //TTHWait.CloseWait();
            
        }
        public void LayDSDuLieu()
        {
            cboTenDuLieu.Text = "";
            cboTenDuLieu.Properties.Items.Clear();
            string strconn = "";
            if (double.Parse(rdogr.EditValue.ToString()) == 1)
                strconn = "Server=" + cboMayChu.Text.Trim() + ";integrated security=SSPI;DataBase=Master;";
            else
                strconn = "Server=" + cboMayChu.Text.Trim() + ";Uid=" + txtTaiKhoan.Text.Trim() + ";pwd=" + txtMatKhau.Text.Trim() + ";DataBase=Master;";
            if (!cls.ConnectSQLServer(strconn))
            {
                XtraMessageBox.Show("Không thể kết nối với máy chủ. Xin kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            foreach (DataRow dr in cls.GetAllDatabase().Rows)
            {
                if (dr[0].ToString().Trim() != "master" && dr[0].ToString().Trim() != "model" && dr[0].ToString().Trim() != "msdb" && dr[0].ToString().Trim() != "tempdb")
                    cboTenDuLieu.Properties.Items.Add(dr[0].ToString().Trim());

            }
            if (cboTenDuLieu.Properties.Items.Count >= 1)
            {
                cboTenDuLieu.SelectedIndex = 0;
                cboTenDuLieu.ShowPopup();
            }
        }
        public void addDuLieu(string dulieu, string noiluutru)
        {
             cboTenDuLieu.Properties.Items.Add(dulieu);
             cboTenDuLieu.SelectedIndex = cboTenDuLieu.Properties.Items.Count - 1;
        }
        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            string authenwindows = "";
            if (rdogr.EditValue.Equals(1) == true)
                authenwindows = "True";
            else authenwindows = "False";
           
            WaitDialogForm dg = new WaitDialogForm("Đang cấu hình kết nối cơ sở dữ liệu...", "Xin chờ trong giây lát", new Size(300, 100));
            string strconn = "";
            if (authenwindows == "True")
                strconn = "Data Source=" + cboMayChu.Text.Trim() + ";Initial Catalog=" + cboTenDuLieu.Text.Trim() + ";Integrated Security=True";
            else
                strconn = "Data Source=" + cboMayChu.Text.Trim() + ";Initial Catalog=" + cboTenDuLieu.Text.Trim() + ";User ID=" + txtTaiKhoan.Text.Trim() + ";Password=" + txtMatKhau.Text.Trim();
            try
            {
                if (cls.ConnectSQLServer(strconn))
                {
                    //TTHMessage.ShowMessageInfomation(cls.strconn);
                    DataAccessStatic.conn = cls.sqlconn;
                    DataAccessStatic.strconn = cls.strconn;
                    DataAccessStatic.servername = cboMayChu.Text.Trim();
                    DataAccessStatic.authenwindows = authenwindows;
                    DataAccessStatic.database = cboTenDuLieu.Text.Trim();
                    DataAccessStatic.username = txtTaiKhoan.Text.Trim();
                    DataAccessStatic.password = txtMatKhau.Text.Trim();
                    DataAccessStatic.path = noiluutru;
                    //DataAccessStatic.OpenConnection();
                    if (chkLuu.Checked == true)
                        SaveXml("config.xml", authenwindows, cboMayChu.Text, cboTenDuLieu.Text, txtTaiKhoan.Text, txtMatKhau.Text, noiluutru, chkLuu.Checked.ToString());
                    dg.Close();
                    Info.isconfig = true;
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Cấu hình kết nối không chính xác.", "Thông Báo.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dg.Close();
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Cấu hình kết nối không chính xác.", "Thông Báo.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dg.Close();

            }
        }



        private void rdogr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdogr.EditValue.Equals(1) == true)
            {
                txtTaiKhoan.Enabled = false;
                txtMatKhau.Enabled = false;
            }
            if (rdogr.EditValue.Equals(2) == true)
            {
                txtTaiKhoan.Enabled = true;
                txtMatKhau.Enabled = true;
            }
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            WaitDialogForm dg = new WaitDialogForm("Xin vui lòng chờ trong giây lát!", "Đang kiểm tra kết nối dữ liệu...");
            string strconn = "";
            if (double.Parse(rdogr.EditValue.ToString()) == 1)
                strconn = "Server=" + cboMayChu.Text.Trim() + ";integrated security=SSPI;DataBase=Master;";
            else
                strconn = "Server=" + cboMayChu.Text.Trim() + ";Uid=" + txtTaiKhoan.Text.Trim() + ";pwd=" + txtMatKhau.Text.Trim() + ";DataBase=Master;";
            if (cls.ConnectSQLServer(strconn))
            {
                dg.Close();
                XtraMessageBox.Show("Kết nối thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTenDuLieu.Text = "";
                cboTenDuLieu.Properties.Items.Clear();
                foreach (DataRow dr in cls.GetAllDatabase().Rows)
                {
                    if (dr[0].ToString().Trim() != "master" && dr[0].ToString().Trim() != "model" && dr[0].ToString().Trim() != "msdb" && dr[0].ToString().Trim() != "tempdb")
                        cboTenDuLieu.Properties.Items.Add(dr[0].ToString().Trim());

                }
                if (cboTenDuLieu.Properties.Items.Count >= 1)
                {
                    cboTenDuLieu.SelectedIndex = 0;
                    cboTenDuLieu.ShowPopup();
                }

            }
            else
            {
                dg.Close();
                XtraMessageBox.Show("Không thể kết nối với máy chủ. Xin kiểm tra lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       

        private void txtTenDuLieu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
                LayDSDuLieu();
            if(e.Button.Index == 2)
                System.Diagnostics.Process.Start(Application.StartupPath + "\\SQLEXPR32.exe");
        }

        

        private void txtMayChu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                LayDSMayChu();                
            }
            if (e.Button.Index == 2)
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\SQLEXPR32.EXE");
            }
        }
        private void frmCauHinhDuLieu_Load(object sender, EventArgs e)
        {
            this.Text = Info.tenphanmem;
            WaitDialogForm dg = new WaitDialogForm("Xin vui lòng chờ trong giây lát!", "Đang kết nối dữ liệu...");
            if (System.IO.File.Exists(Application.StartupPath + "\\config.xml"))
            {
                cboMayChu.Text = DataAccessStatic.servername;
                txtTaiKhoan.Text = DataAccessStatic.username;
                txtMatKhau.Text = DataAccessStatic.password;
                cboTenDuLieu.Text = DataAccessStatic.database;
                if (DataAccessStatic.authenwindows == "True")
                    rdogr.EditValue = 1;
                else rdogr.EditValue = 2;
                if (DataAccessStatic.save == "True")
                    chkLuu.Checked = true;
                else chkLuu.Checked = false;
                dg.Close();
            }
            else
            {
                dg.Close();
                LayDSMayChu();
            }
            //phanQuyenTrenForm();
        }

        private void frmCauHinhDuLieu_Activated(object sender, EventArgs e)
        {
            
        }

        
    }
}