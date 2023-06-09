using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.Utils;
using System.Xml;
using System.Threading;
using MyRMS.DanhMuc;
using MyRMS.NghiepVu;
using MyRMS.HeThong;
using MyRMS.TienIch;
using MyRMS.BaoCao;
namespace MyRMS
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public void DisplayForm(Form frm)
        {

            foreach (Form item in this.MdiChildren)
            {
                if (item.Name == frm.Name)
                {
                    item.Close();
                }

            }
            frm.MdiParent = this;
            pnMain.Visible = false;
            frm.Show();
        }
        public void DisplayBackgroung()
        {
            if (this.MdiChildren.Length == 1)
                pnMain.Visible = true;
        }
        public void SaveSkin(string skin)
        {
            XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "\\skin.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;

            writer.WriteStartElement("SkinStyle");

            writer.WriteStartElement("Skin");
            writer.WriteString(skin);
            writer.WriteEndElement();



            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }
        //Luu 1 khi click
        void OnPaintStyleClick(object sender, ItemClickEventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = e.Item.Tag.ToString();
            //defaultLookAndFeel1.LookAndFeel.SetSkinStyle(e.Item.Tag.ToString());
            SaveSkin(e.Item.Tag.ToString());
        }
        public frmMain()
        {
            InitializeComponent();
        }
        public void PhanQuyen()
        {
            DataAccess cls = new DataAccess();
            string sql = "select Q_CN_ID as CN_ID from Quyen where Q_ND_ID = '" + Info.nd_id + "' and Q_TruyCap = 'True' ";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                
                //if (dr["CN_ID"].ToString().Trim() == "barChucNang")
                //    barChucNang.Enabled = true;
                if (dr["CN_ID"].ToString().Trim() == "barNguoiDung")
                    barNguoiDung.Enabled = true;
                if (dr["CN_ID"].ToString().Trim() == "barPhanQuyen")
                    barPhanQuyen.Enabled = true;
                if (dr["CN_ID"].ToString().Trim() == "barDoiMatKhau")
                    barDoiMatKhau.Enabled = true;
                if (dr["CN_ID"].ToString().Trim() == "barCauHinhHeThong")
                    barCauHinhHeThong.Enabled = true;
                if (dr["CN_ID"].ToString().Trim() == "barChinhSuaReport")
                    barChinhSuaReport.Enabled = true;
                //if (dr["CN_ID"].ToString().Trim() == "barKhachHang")
                //    barKhachHang.Enabled = true;
                //if (dr["CN_ID"].ToString().Trim() == "barNhaCungCap")
                //    barNhaCungCap.Enabled = true;
                if (dr["CN_ID"].ToString().Trim() == "barMatHang")
                    barMatHang.Enabled = true;
                //if (dr["CN_ID"].ToString().Trim() == "barKhoHang")
                //    barKhoHang.Enabled = true;
                //if (dr["CN_ID"].ToString().Trim() == "barBanPhong")
                //    barBanPhong.Enabled = true;
                //if (dr["CN_ID"].ToString().Trim() == "barCaLamViec")
                //    barCaLamViec.Enabled = true;
                if (dr["CN_ID"].ToString().Trim() == "barKiemKeHang")
                    barKiemKeHang.Enabled = true;
                if (dr["CN_ID"].ToString().Trim() == "barMuaHang")
                    barMuaHang.Enabled = true;
                if (dr["CN_ID"].ToString().Trim() == "barBanHang")
                    barBanHang.Enabled = true;
                if (dr["CN_ID"].ToString().Trim() == "barThuTien")
                    barThuTien.Enabled = true;
                if (dr["CN_ID"].ToString().Trim() == "barChiTien")
                    barChiTien.Enabled = true;
                if (dr["CN_ID"].ToString().Trim() == "barBaoCaoBanHang")
                    barBaoCaoBanHang.Enabled = true;
                if (dr["CN_ID"].ToString().Trim() == "barBaoCaoMuaHang")
                    barBaoCaoMuaHang.Enabled = true;
                if (dr["CN_ID"].ToString().Trim() == "barBaoCaoTonKho")
                    barBaoCaoTonKho.Enabled = true;
                if (dr["CN_ID"].ToString().Trim() == "barBaoCaoThuChi")
                    barBaoCaoThuChi.Enabled = true;
                if (dr["CN_ID"].ToString().Trim() == "barCongNoKhachHang")
                    barCongNoKhachHang.Enabled = true;
                if (dr["CN_ID"].ToString().Trim() == "barCongNoNhaCungCap")
                    barCongNoNhaCungCap.Enabled = true;
                if (dr["CN_ID"].ToString().Trim() == "barBaoCaoDoanhThu")
                    barBaoCaoDoanhThu.Enabled = true;
                if (dr["CN_ID"].ToString().Trim() == "barTongQuan")
                    barTongQuan.Enabled = true;
            }
        }

        public void LayThongTinDonVi(string dv_id)
        {
            DataAccess cls = new DataAccess();
            string sql = "select * from DonVi where DV_ID = '" + dv_id + "'";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                Info.dv_ten = dr["DV_Ten"].ToString().Trim();
                Info.dv_diachi = dr["DV_DiaChi"].ToString().Trim();
                Info.dv_dienthoai = dr["DV_DienThoai"].ToString().Trim();
                Info.dv_email = dr["DV_Email"].ToString().Trim();
                Info.dv_masothue = dr["DV_MaSoThue"].ToString().Trim();
                Info.dv_nguoilienhe = dr["DV_NguoiLienHe"].ToString().Trim();
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            LayThongTinDonVi(Info.dv_id);
            barDonViSuDung.Caption = "Đơn vị sử dụng: " + Info.dv_ten;
            //Thread t = new Thread(new ThreadStart(Initialize));
            //t.Start();
            foreach (DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins)
            {
                BarCheckItem item = ribbon.Items.CreateCheckItem(skin.SkinName, false);
                item.Tag = skin.SkinName;
                item.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(OnPaintStyleClick);
                barMenu.ItemLinks.Add(item);
                //DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = SkinStyle.AppSettings.Settings["Skin"].Value;
            }
            if (Info.nd_id.Length > 0)
            {
                barHoTen.Caption = Info.nd_ten;
                barDangNhap.Visibility = BarItemVisibility.Never;
                PhanQuyen();
                
            }
            
        }
        
        private void barLoaiHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLoaiHang frm = new frmLoaiHang();
            frm.DisplayBackgroung = new frmLoaiHang.DisplayObject(DisplayBackgroung);
            DisplayForm(frm);
            
        }

        private void barCauHinhDuLieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmCauHinhDuLieu frm = new frmCauHinhDuLieu();
            //frm.ShowDialog();
        }

        private void barSaoLuuDuLieu_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barPhucHoiDuLieu_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barMatHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_TruyCap", "barMatHang"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            frmMatHang frm = new frmMatHang();
            //frm.ShowDialog();
            frm.DisplayBackgroung = new frmMatHang.DisplayBackgroungDelegate(DisplayBackgroung);
            DisplayForm(frm);
        }

       

        private void barChiNhanh_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmDMChiNhanh frm = new frmDMChiNhanh();
            //frm.DisplayBackgroung = new frmDMChiNhanh.DisplayObject(DisplayBackgroung);
            //DisplayForm(frm);
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_TruyCap", "barChinhSuaReport"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            pnMain.Visible = false;
            FastReport.Report rpt = new FastReport.Report();
            rpt.Load(Application.StartupPath + "\\report\\HoaDon_K58.frx");
            rpt.Design(this);
            rpt.Designer.UIStyle = FastReport.Utils.UIStyle.Office2007Blue;
        }

        private void barKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            //frm.ShowDialog();
            frm.DisplayBackgroung = new frmKhachHang.DisplayObject(DisplayBackgroung);
            DisplayForm(frm);
        }

        private void barNhaCungCap_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNhaCungCap frm = new frmNhaCungCap();
            //frm.ShowDialog();
            frm.DisplayBackgroung = new frmNhaCungCap.DisplayObject(DisplayBackgroung);
            DisplayForm(frm);
        }

        private void barQuyTien_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmDMQuyTien frm = new frmDMQuyTien();
            //frm.DisplayBackgroung = new frmDMQuyTien.DisplayObject(DisplayBackgroung);
            //DisplayForm(frm);
        }

        private void barKhoHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmDMKhoHang frm = new frmDMKhoHang();
            //frm.DisplayBackgroung = new frmDMKhoHang.DisplayObject(DisplayBackgroung);
            //DisplayForm(frm);
        }

        private void barDonVi_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmDMDonVi frm = new frmDMDonVi();
            //frm.DisplayBackgroung = new frmDMDonVi.DisplayObject(DisplayBackgroung);
            //DisplayForm(frm);
        }

        

        private void barCauHinhHeThong_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_TruyCap", "barCauHinhHeThong"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            frmCauHinhHeThong frm = new frmCauHinhHeThong();
            frm.issua = true;
            frm.ShowDialog();
        }

        private void barXuatBanHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_TruyCap", "barBanHang"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            frmRetail frm = new frmRetail();
            frm.DisplayBackgroung = new frmRetail.DisplayBackgroungDelegate(DisplayBackgroung);
            DisplayForm(frm);
            //frmXuatBanBuon frm = new frmXuatBanBuon();
            //frm.DisplayBackgroung = new frmXuatBanBuon.DisplayBackgroungDelegate(DisplayBackgroung);
            //DisplayForm(frm);
        }

        private void barXuatBanLe_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmBanLe frm = new frmBanLe();
            //DisplayForm(frm);
        }


        

        private void barThuTien_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThuTien frm = new frmThuTien();
            frm.ShowDialog();
            //frmThuTien frm = new frmThuTien();
            //frm.DisplayBackgroung = new frmThuTien.DisplayBackgroungDelegate(DisplayBackgroung);
            //DisplayForm(frm);
        }

        

        private void barNhapTraHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmNhapTraHang frm = new frmNhapTraHang();
            //frm.DisplayBackgroung = new frmNhapTraHang.DisplayBackgroungDelegate(DisplayBackgroung);
            //DisplayForm(frm);
        }

        private void barNhapMuaHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_TruyCap", "barMuaHang"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            frmImport frm = new frmImport();
            frm.DisplayBackgroung = new frmImport.DisplayBackgroungDelegate(DisplayBackgroung);
            DisplayForm(frm);
        }

        private void barXuatTraHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmXuatTraHang frm = new frmXuatTraHang();
            //frm.DisplayBackgroung = new frmXuatTraHang.DisplayBackgroungDelegate(DisplayBackgroung);
            //DisplayForm(frm);
        }

        private void barKhoHang_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmKhoHang frm = new frmKhoHang();
            frm.DisplayBackgroung = new frmKhoHang.DisplayObject(DisplayBackgroung);
            DisplayForm(frm);
        }

        private void barNhomKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNhomDoiTac frm = new frmNhomDoiTac();
            frm.DisplayBackgroung = new frmNhomDoiTac.DisplayObject(DisplayBackgroung);
            DisplayForm(frm);
        }

        private void barBanPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBanPhong frm = new frmBanPhong();
            frm.ShowDialog();
            //frm.DisplayBackgroung = new frmBanPhong.DisplayObject(DisplayBackgroung);
            //DisplayForm(frm);
        }

        private void barLienHe_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBrowser frm = new frmBrowser();
            frm.DisplayBackgroung = new frmBrowser.DisplayObject(DisplayBackgroung);
            DisplayForm(frm);
        }

        private void barChucNang_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmChucNang frm = new frmChucNang();
            frm.DisplayBackgroung = new frmChucNang.DisplayObject(DisplayBackgroung);
            DisplayForm(frm);
        }

        private void barNguoiDung_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_TruyCap", "barNguoiDung"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            frmNguoiDung frm = new frmNguoiDung();
            frm.DisplayBackgroung = new frmNguoiDung.DisplayObject(DisplayBackgroung);
            DisplayForm(frm);
        }

        private void barPhanQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_TruyCap", "barPhanQuyen"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            frmPhanQuyen frm = new frmPhanQuyen();
            frm.ShowDialog();
        }

        private void barDoiMatKhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_TruyCap", "barDoiMatKhau"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.ShowDialog();
        }
        public void DangXuat()
        {
            
                   
                
                    barCauHinhHeThong.Enabled = false;
                
                    //barChucNang.Enabled = false;
                
                    barNguoiDung.Enabled = false;
                
                    barPhanQuyen.Enabled = false;
                
                    barDoiMatKhau.Enabled = false;
                
                    //barKhachHang.Enabled = false;
                
                    //barNhaCungCap.Enabled = false;
                
                    barMatHang.Enabled = false;
               
                    //barKhoHang.Enabled = false;
                
                    //barBanPhong.Enabled = false;
                
                    barKiemKeHang.Enabled = false;
                
                    barMuaHang.Enabled = false;
                
                    barBanHang.Enabled = false;
                
                    barThuTien.Enabled = false;
                
                    barChiTien.Enabled = false;
               
                    barBaoCaoBanHang.Enabled = false;
                
                    barBaoCaoMuaHang.Enabled = false;
                
                    barBaoCaoTonKho.Enabled = false;
               
                    barBaoCaoThuChi.Enabled = false;
                
                    barCongNoKhachHang.Enabled = false;
                
                    barCongNoNhaCungCap.Enabled = false;
                
                    barBaoCaoDoanhThu.Enabled = false;
                    //barCaLamViec.Enabled = false;
            
        }

        private void barDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TTHMessage.ShowMessageConfirm("Bạn có muốn đăng xuất khỏi hệ thống không?") == DialogResult.Yes)
            {
                barDangXuat.Visibility = BarItemVisibility.Never;
                DangXuat();
                barHoTen.Caption = "Bạn chưa đăng nhập";
                Info.nd_id = "";
                frmDangNhap frm = new frmDangNhap();
                frm.ShowDialog();
                if (Info.nd_id.Length > 0)
                {
                    PhanQuyen();
                    barHoTen.Caption = Info.nd_ten;
                    barDangXuat.Visibility = BarItemVisibility.Always;
                }
            }
        }

        private void barMayTinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("Calc"); 
        }

        private void barDangKySuDung_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barBaoCaoDoanhThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_TruyCap", "barBaoCaoDoanhThu"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            frmBaoCaoDoanhThu frm = new frmBaoCaoDoanhThu();
            frm.ShowDialog();
        }

        private void barBaoCaoThuChi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_TruyCap", "barBaoCaoThuChi"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            frmBaoCaoThuChi frm = new frmBaoCaoThuChi();
            frm.ShowDialog();
        }

        private void barBaoCaoTonKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_TruyCap", "barBaoCaoTonKho"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            frmBaoCaoTonKho frm = new frmBaoCaoTonKho();
            frm.ShowDialog();
        }

        private void barChiTien_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_TruyCap", "barChiTien"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            frmChiTien frm = new frmChiTien();
            frm.DisplayBackgroung = new frmChiTien.DisplayBackgroungDelegate(DisplayBackgroung);
            DisplayForm(frm);
        }

        private void barLinkWeb_ItemClick(object sender, ItemClickEventArgs e)
        {
           // System.Diagnostics.Process.Start(barLinkWeb.Caption); 
        }

        private void barCaLamViec_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCaLamViec frm = new frmCaLamViec();
            frm.ShowDialog();
        }

        private void barKiemKeHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_TruyCap", "barKiemKeHang"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            frmKiemKeHang frm = new frmKiemKeHang();
            frm.DisplayBackgroung = new frmKiemKeHang.DisplayBackgroungDelegate(DisplayBackgroung);
            DisplayForm(frm);
        }

        private void barInMaVach_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barTongQuan_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_TruyCap", "barTongQuan"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            frmTongQuan frm = new frmTongQuan();
            DisplayForm(frm);
        }
        
        
    }
}