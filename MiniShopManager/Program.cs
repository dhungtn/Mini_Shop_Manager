using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using MyRMS.HeThong;
namespace MyRMS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            Info.skinname = "Xmas 2008 Blue";
            if (System.IO.File.Exists(Application.StartupPath + "\\skin.xml"))
            {
                XmlTextReader myXML = new XmlTextReader(Application.StartupPath + "\\skin.xml");

                while (myXML.Read())
                {
                    if (myXML.LocalName == "Skin")
                    {
                        Info.skinname = myXML.ReadString().Trim();
                    }
                }
                myXML.Close();
            }
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Info.skinname;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmStart());
            if (System.IO.File.Exists(Application.StartupPath + "\\config.xml"))
            {
                //WaitDialogForm dg = new WaitDialogForm("Đang cấu hình kết nối cơ sở dữ liệu...", "Xin chờ trong giây lát", new Size(300, 100));
                // doc thong tin trong file inv de lay thong tin server
                XmlTextReader myXML = new XmlTextReader("config.xml");
                try
                {
                    while (myXML.Read())
                    {
                        if (myXML.LocalName == "AuthenWindows")
                        {
                            DataAccessStatic.authenwindows = myXML.ReadString();
                        }
                        if (myXML.LocalName == "ServerName")
                        {
                            DataAccessStatic.servername = myXML.ReadString();
                        }
                        if (myXML.LocalName == "DatabaseName")
                        {
                            DataAccessStatic.database = myXML.ReadString();
                        }
                        if (myXML.LocalName == "UserName")
                        {
                            DataAccessStatic.username = myXML.ReadString();
                        }
                        if (myXML.LocalName == "Password")
                        {
                            //Giải mã password
                            DataAccessStatic.password = System.Text.Encoding.UTF8.GetString(TTHUtils.GiaiMaBase64(myXML.ReadString()));
                            //DataAccessStatic.password = myXML.ReadString();
                        }
                        if (myXML.LocalName == "Path")
                        {
                            DataAccessStatic.path = myXML.ReadString();
                        }
                        if (myXML.LocalName == "save")
                        {
                            DataAccessStatic.save = myXML.ReadString();
                        }
                    }
                    myXML.Close();
                    if (DataAccessStatic.authenwindows == "True")
                        DataAccessStatic.strconn = "Data Source=" + DataAccessStatic.servername + ";Initial Catalog=" + DataAccessStatic.database + ";Integrated Security=True";
                    else
                        DataAccessStatic.strconn = "Data Source=" + DataAccessStatic.servername + ";Initial Catalog=" + DataAccessStatic.database + ";User ID=" + DataAccessStatic.username + ";Password=" + DataAccessStatic.password;
                    DataAccessStatic.conn = new SqlConnection(DataAccessStatic.strconn);
                    DataAccessStatic.conn.Open();
                    Info.isconfig = true;
                    CauHinhHeThong();
                }
                catch (Exception)
                {
                    myXML.Close();
                    Info.isconfig = false;
                    frmCauHinhDuLieu frm = new frmCauHinhDuLieu();
                    frm.ShowDialog();
                }
            }
            else
            {
                frmCauHinhDuLieu frm = new frmCauHinhDuLieu();
                frm.ShowDialog();
            }
            /////////////////////////////////////////////////
            if (Info.isconfig)
            {
                //Application.Run(new Test());
                Application.Run(new frmDangNhap());
                if (Info.islogin == true)
                {
                    CauHinhHeThong();
                    //Application.Run(new frmBanLe());
                    Application.Run(new frmMain());
                }
            }
            else Application.Exit();
            //Application.Run(new frmMain());
        }
        static void CauHinhHeThong()
        {
            if (System.IO.File.Exists(Application.StartupPath + "\\info.xml"))
            {

                Form activeForm = new Form();
                // doc thong tin trong file inv de lay thong tin server
                XmlTextReader myXML = new XmlTextReader("info.xml");

                try
                {
                    while (myXML.Read())
                    {
                        if (myXML.LocalName == "IDDonVi")
                        {
                            Info.dv_id = myXML.ReadString();
                        }
                        if (myXML.LocalName == "TenDonVi")
                        {
                            Info.dv_ten = myXML.ReadString();
                        }
                        if (myXML.LocalName == "DiaChiDonVi")
                        {
                            Info.dv_diachi = myXML.ReadString();
                        }
                        if (myXML.LocalName == "DienthoaiDonVi")
                        {
                            Info.dv_dienthoai = myXML.ReadString();
                        }
                        if (myXML.LocalName == "SoFaxDonVi")
                        {
                            Info.dv_fax = myXML.ReadString();
                        }
                        if (myXML.LocalName == "EmailDonVi")
                        {
                            Info.dv_email = myXML.ReadString();
                        }
                        if (myXML.LocalName == "MaSoThueDonVi")
                        {
                            Info.dv_masothue = myXML.ReadString();
                        }
                        if (myXML.LocalName == "MayInVanBan")
                        {
                            Info.mayinvanban = myXML.ReadString();
                        }
                        if (myXML.LocalName == "MayInHoaDon")
                        {
                            Info.mayinhoadon = myXML.ReadString();
                        }
                        if (myXML.LocalName == "MayInMaVach")
                        {
                            Info.mayinmavach = myXML.ReadString();
                        }
                        if (myXML.LocalName == "MayInCheBien")
                        {
                            Info.mayinchebien = myXML.ReadString();
                        }
                        if (myXML.LocalName == "XemTruocKhiIn")
                        {
                            Info.xemtruockhiin = Boolean.Parse(myXML.ReadString());
                        }
                        if (myXML.LocalName == "SuDungMaVach")
                        {
                            Info.sudungmavach = Boolean.Parse(myXML.ReadString());
                        }
                        if (myXML.LocalName == "SuaDonGia")
                        {
                            Info.suadongia = Boolean.Parse(myXML.ReadString());
                        }
                        if (myXML.LocalName == "SuaSoLuong")
                        {
                            Info.suasoluong = Boolean.Parse(myXML.ReadString());
                        }
                        if (myXML.LocalName == "NhapGiamGia")
                        {
                            Info.nhapgiamgia = Boolean.Parse(myXML.ReadString());
                        }
                        if (myXML.LocalName == "GiamGia")
                        {
                            Info.giamgiamacdinh = double.Parse(myXML.ReadString());
                        }
                        if (myXML.LocalName == "SuDungChuongTrinh")
                        {
                            Info.sudungchuongtrinh = Boolean.Parse(myXML.ReadString());
                        }
                        if (myXML.LocalName == "DoanhSoTuongUngDiem")
                        {
                            Info.doanhsotuongungdiem = double.Parse(myXML.ReadString());
                        }
                        if (myXML.LocalName == "ChonKhoHang")
                        {
                            Info.chonkhohang = Boolean.Parse(myXML.ReadString());
                        }
                        if (myXML.LocalName == "KhoHang")
                        {
                            Info.kh_id = myXML.ReadString();
                        }
                        if (myXML.LocalName == "XuatLonHonTon")
                        {
                            Info.xuatlonhonton = Boolean.Parse(myXML.ReadString());
                        }
                        if (myXML.LocalName == "MauHoaDon")
                        {
                            Info.mauhoadon = myXML.ReadString();
                        }
                        if (myXML.LocalName == "KhachHangMacDinh")
                        {
                            Info.dt_id = myXML.ReadString();
                        }
                        if (myXML.LocalName == "TuDongSinhMa")
                        {
                            Info.tusinhma = Boolean.Parse(myXML.ReadString());
                        }
                        if (myXML.LocalName == "ThongBaoHangTon")
                        {
                            Info.thongbaohangton = Boolean.Parse(myXML.ReadString());
                        }
                        if (myXML.LocalName == "ThuTuChungTuGiam")
                        {
                            Info.thutuchungtugiam = Boolean.Parse(myXML.ReadString());
                        }
                        if (myXML.LocalName == "ChoPhepThayDoiNgay")
                        {
                            Info.chophepdoingay = Boolean.Parse(myXML.ReadString());
                        }
                        if (myXML.LocalName == "NhapNhieuLan")
                        {
                            Info.chophepnhapnhieulan = Boolean.Parse(myXML.ReadString());
                        }


                    }
                    myXML.Close();
                }
                catch (Exception ex)
                {
                    TTHMessage.ShowMessageError(ex.ToString());
                }
                //if (!KiemTraDonViTonTai(Info.dv_id))
                //{
                //    frmCauHinhHeThong frm = new frmCauHinhHeThong();
                //    frm.ShowDialog();
                //}
            }
            else
            {
                frmCauHinhHeThong frm = new frmCauHinhHeThong();
                frm.ShowDialog();
            }
        }
        static Boolean KiemTraDonViTonTai(string dv_id)
        {
            DataAccess cls = new DataAccess();
            string sql = "select DV_ID from DonVi where DV_ID = '" + dv_id + "' and DV_KichHoat = 'True' ";
            return cls.IsExist(sql);
        }
    }
}
