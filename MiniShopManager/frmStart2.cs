using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using System.Data.SqlClient;
namespace MyRMS
{
    public partial class frmStart2 : DevExpress.XtraEditors.XtraForm
    {
        public frmStart2()
        {
            InitializeComponent();
        }
        public frmStart2(string s)
        {
            InitializeComponent();
            lblTienTrinh.Text = s;
        }
        public void setValueProgressBar(int value, Boolean isshowtitle)
        {
            pbarTienTrinh.Properties.ShowTitle = isshowtitle;

            int currentpos = pbarTienTrinh.Position;
            for (int i = 1; i <= value - currentpos; i++)
            {
                pbarTienTrinh.Position = currentpos + i;
                pbarTienTrinh.Update();
                //System.Threading.Thread.Sleep(100);
            }

        }
        public int dem = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            setValueProgressBar(dem, true);
            //if (dem == 30)
            //{
            //    timer1.Enabled = false;
            //    lblTienTrinh.Text = "Đang cấu hình kết nối dữ liệu...";
            //    if (System.IO.File.Exists(Application.StartupPath + "\\config.sys"))
            //    {
            //        XmlTextReader myXML = new XmlTextReader("config.sys");
            //        try
            //        {
            //            while (myXML.Read())
            //            {
            //                if (myXML.LocalName == "AuthenWindows")
            //                {
            //                    DataAccessStatic.authenwindows = myXML.ReadString();
            //                }
            //                if (myXML.LocalName == "ServerName")
            //                {
            //                    DataAccessStatic.servername = myXML.ReadString();
            //                }
            //                if (myXML.LocalName == "DatabaseName")
            //                {
            //                    DataAccessStatic.database = myXML.ReadString();
            //                }
            //                if (myXML.LocalName == "UserName")
            //                {
            //                    DataAccessStatic.username = myXML.ReadString();
            //                }
            //                if (myXML.LocalName == "Password")
            //                {
            //                    DataAccessStatic.password = System.Text.Encoding.UTF8.GetString(TTHUtils.GiaiMaBase64(myXML.ReadString()));
            //                }
            //                if (myXML.LocalName == "Path")
            //                {
            //                    DataAccessStatic.path = myXML.ReadString();
            //                }
            //                if (myXML.LocalName == "save")
            //                {
            //                    DataAccessStatic.save = myXML.ReadString();
            //                }
            //            }
            //            myXML.Close();
            //            if (DataAccessStatic.authenwindows == "True")
            //                DataAccessStatic.strconn = "Data Source=" + DataAccessStatic.servername + ";Initial Catalog=" + DataAccessStatic.database + ";Integrated Security=True";
            //            else
            //                DataAccessStatic.strconn = "Data Source=" + DataAccessStatic.servername + ";Initial Catalog=" + DataAccessStatic.database + ";User ID=" + DataAccessStatic.username + ";Password=" + DataAccessStatic.password;
            //            DataAccessStatic.conn = new SqlConnection(DataAccessStatic.strconn);
            //            DataAccessStatic.conn.Open();
            //            Info.isconfig = true;
            //        }
            //        catch (Exception)
            //        {
            //            myXML.Close();
            //            Info.isconfig = false;
            //            frmCauHinhDuLieu frm = new frmCauHinhDuLieu();
            //            frm.ShowDialog();
            //        }
            //    }
            //    else
            //    {
            //        frmCauHinhDuLieu frm = new frmCauHinhDuLieu();
            //        frm.ShowDialog();
            //    }
            //    if (Info.isconfig)
            //    {
            //        this.Hide();
            //        //Application.Run(new frmLogin());
            //        frmLogin frm = new frmLogin();
            //        frm.ShowDialog();
            //        if (Info.islogin == true)
            //        {
            //            Application.Run(new frmMain());
            //        }
            //    }
            //    else Application.Exit();
            //    dem = dem + 5;
            //    timer1.Enabled = true;
            //}
            ////if (dem == 80) lblTienTrinh.Text = "bbb";
            if (dem == 100)
            {
                timer1.Enabled = false;
                this.Close(); 
            }
            dem = dem + 10;
        }

        private void frmStart_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            
        }
    }
}