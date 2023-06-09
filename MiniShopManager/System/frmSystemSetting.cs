using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using System.Net;
using System.Net.Mail;
using System.Xml;
using MyRMS.DanhMuc;
namespace MyRMS.HeThong
{
    public partial class frmCauHinhHeThong : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public Boolean issua = false;
        public string dv_id = "";
        public frmCauHinhHeThong()
        {
            InitializeComponent();
        }
        public void LayDSMayIn()
        {
            cboMayInVanBan.Properties.Items.Clear();
            cboMayInHoaDon.Properties.Items.Clear();
            cboMayInMaVach.Properties.Items.Clear();
            cboMayInCheBien.Properties.Items.Clear();
            foreach (string sPrinters in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cboMayInVanBan.Properties.Items.Add(sPrinters);
                cboMayInHoaDon.Properties.Items.Add(sPrinters);
                cboMayInMaVach.Properties.Items.Add(sPrinters);
                cboMayInCheBien.Properties.Items.Add(sPrinters);
            }
            
        }
        
        public void SaveXML(string filename)
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;

                writer.WriteStartElement("HeThong");

                writer.WriteStartElement("IDDonVi");
                writer.WriteString(dv_id);
                writer.WriteEndElement();

                writer.WriteStartElement("TenDonVi");
                writer.WriteString(txtTen.Text.Trim());
                writer.WriteEndElement();

                writer.WriteStartElement("DiaChiDonVi");
                writer.WriteString(txtDiaChi.Text.Trim());
                writer.WriteEndElement();

                writer.WriteStartElement("DienthoaiDonVi");
                writer.WriteString(txtDienThoai.Text.Trim());
                writer.WriteEndElement();

                writer.WriteStartElement("SoFaxDonVi");
                writer.WriteString(txtFax.Text.Trim());
                writer.WriteEndElement();

                writer.WriteStartElement("EmailDonVi");
                writer.WriteString(txtEmail.Text.Trim());
                writer.WriteEndElement();

                writer.WriteStartElement("MaSoThueDonVi");
                writer.WriteString(txtMaSoThue.Text.Trim());
                writer.WriteEndElement();

                writer.WriteStartElement("MayInVanBan");
                writer.WriteString(cboMayInVanBan.Text.Trim());
                writer.WriteEndElement();

                writer.WriteStartElement("MayInHoaDon");
                writer.WriteString(cboMayInHoaDon.Text.Trim());
                writer.WriteEndElement();

                writer.WriteStartElement("MayInMaVach");
                writer.WriteString(cboMayInMaVach.Text.Trim());
                writer.WriteEndElement();

                writer.WriteStartElement("MayInCheBien");
                writer.WriteString(cboMayInCheBien.Text.Trim());
                writer.WriteEndElement();

                writer.WriteStartElement("XemTruocKhiIn");
                writer.WriteString(chkXemTruoc.Checked.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("SuDungMaVach");
                writer.WriteString(chkSuDungMaVach.Checked.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("SuaDonGia");
                writer.WriteString(chkSuaDonGia.Checked.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("SuaSoLuong");
                writer.WriteString(chkSuaSoLuong.Checked.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("NhapGiamGia");
                writer.WriteString(chkNhapGiamGia.Checked.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("GiamGia");
                writer.WriteString(txtGiamGia.EditValue.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("SuDungChuongTrinh");
                writer.WriteString(chkSuDungChuongTrinh.Checked.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("DoanhSoTuongUngDiem");
                writer.WriteString(txtDoanhSo.Text.Trim());
                writer.WriteEndElement();

                writer.WriteStartElement("ChonKhoHang");
                writer.WriteString(chkChonKhoHang.Checked.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("KhoHang");
                writer.WriteString(glkuKhoHang.EditValue.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("XuatLonHonTon");
                writer.WriteString(chkXuatLonHonTon.Checked.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("MauHoaDon");
                writer.WriteString(cboMauHoaDon.Text.Trim());
                writer.WriteEndElement();

                writer.WriteStartElement("KhachHangMacDinh");
                writer.WriteString(glkuDoiTac.EditValue.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("TuDongSinhMa");
                writer.WriteString(chkTuDongSinhMa.Checked.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("ThongBaoHangTon");
                writer.WriteString(chkThongBaoTon.Checked.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("ThuTuChungTuGiam");
                writer.WriteString(chkThuTuChungTuGiam.Checked.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("ChoPhepThayDoiNgay");
                writer.WriteString(chkThayDoiNgay.Checked.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("NhapNhieuLan");
                writer.WriteString(chkNhapNhieuLan.Checked.ToString());
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
        public Boolean ThemDonVi(string dv_id, string dv_ten, string dv_diachi, string dv_dienthoai, string dv_fax, string dv_email, string dv_masothue, string dv_nguoilienhe, Boolean dv_kichhoat, DateTime dv_ngaydangky)
        {
            string[] field = { "DV_ID", "DV_Ten", "DV_DiaChi", "DV_DienThoai", "DV_Fax", "DV_Email", "DV_MaSoThue", "DV_NguoiLienHe", "DV_KichHoat", "DV_NgayDangKy" };
            object[] value = { (object)dv_id, (object)dv_ten, (object)dv_diachi, (object)dv_dienthoai, (object)dv_fax, (object)dv_email, (object)dv_masothue, (object)dv_nguoilienhe, (object)dv_kichhoat, (object)dv_ngaydangky };
            return cls.AddRecordTrans("DonVi", field, value);
        }
        public Boolean SuaDonVi(string dv_id, string dv_ten, string dv_diachi, string dv_dienthoai, string dv_fax, string dv_email, string dv_masothue, string dv_nguoilienhe)
        {
            string[] field = {"DV_Ten", "DV_DiaChi", "DV_DienThoai", "DV_Fax", "DV_Email", "DV_MaSoThue", "DV_NguoiLienHe" };
            object[] value = { (object)dv_ten, (object)dv_diachi, (object)dv_dienthoai, (object)dv_fax, (object)dv_email, (object)dv_masothue, (object)dv_nguoilienhe };
            string[] fieldwhere = { "DV_ID" };
            object[] valuewhere = { (object)dv_id };
            return cls.EditRecordTrans("DonVi", field, value, fieldwhere, valuewhere);
        }
        
        public void LayDSQuyTien()
        {
            //DataAccess cls = new DataAccess();
            //string sql = "select QT_ID, QT_Ten from QuyTien where QT_TV_ID = '" + ThanhVienInfo.tv_id + "' order by QT_Ten";
            //glkuQuyTien.Properties.DataSource = cls.GetDataTable(sql);
            //glkuQuyTien.Properties.ValueMember = "QT_ID";
            //glkuQuyTien.Properties.DisplayMember = "QT_Ten";
            //glkuQuyTien.EditValue = Info.qt_id;
        }
        public void LayDSKhoHang()
        {
            string sql = "select KH_ID, KH_Ten from KhoHang where KH_DV_ID = '" + Info.dv_id + "' and KH_KichHoat = 'true' order by KH_ID ";
            DataTable dt = cls.GetDataTable(sql);
            DataRow dr = dt.NewRow();
            dr[0] = dr[1] =  "";
            dt.Rows.InsertAt(dr, 0);
            glkuKhoHang.Properties.DataSource = dt;
            glkuKhoHang.Properties.ValueMember = "KH_ID";
            glkuKhoHang.Properties.DisplayMember = "KH_Ten";
            glkuKhoHang.Properties.PopupFormWidth = glkuKhoHang.Size.Width - 4;
        }
        public void SetKhoHang(string s)
        {
            glkuKhoHang.EditValue = s;
        }
        public void LayDSDoiTac()
        {
            string sql = "select DT_ID, DT_Ten, DT_DiaChi, DT_DienThoai, DT_Email from DoiTac ";
            sql += "where DT_Loai = 'KH' and DT_DV_ID = '" + Info.dv_id + "' ";
            sql += "order by DT_Ten ";
            DataTable dt = cls.GetDataTable(sql);
            DataRow dr = dt.NewRow();
            dr[0] = dr[1] = dr[2] = dr[3] = dr[4] = "";
            dt.Rows.InsertAt(dr, 0);
            glkuDoiTac.Properties.DataSource = dt;
            glkuDoiTac.Properties.ValueMember = "DT_ID";
            glkuDoiTac.Properties.DisplayMember = "DT_Ten";
            glkuDoiTac.Properties.PopupFormWidth = 800;
            glkuvDoiTac.BestFitColumns();
        }
        public Boolean ThemNguoiDung(string nd_id)
        {
            string[] field = { "ND_ID", "ND_Ten", "ND_TenDangNhap", "ND_MatKhau", "ND_DiaChi", "ND_DienThoai", "ND_GhiChu", "ND_KichHoat", "ND_DV_ID", "ND_VT_ID" };
            object[] value = { (object)nd_id, (object)"Administrator", (object)"admin", (object)TTHUtils.MaHoaBase64(System.Text.Encoding.UTF8.GetBytes("admin")), (object)"", (object)"", (object)"", (object)true, (object)Info.dv_id, (object)"QT" };
            return cls.AddRecordTrans("NguoiDung", field, value);
        }
        public Boolean ThemQuyenNguoiDung(string nd_id)
        {
            Boolean ok = false;
            int i = 1;
            foreach (DataRow dr in cls.GetDataTableTrans("select CN_ID from ChucNang").Rows)
            {
                string sql = "insert into Quyen(Q_ID, Q_CN_ID, Q_ND_ID, Q_TruyCap, Q_Them, Q_Sua, Q_Xoa, Q_In, Q_Nhap, Q_Xuat) ";
                sql += "values ('" + DateTime.Now.ToString("yyMMddHHmmss") + string.Format("{0,2:00}", i) + "', '" + dr["CN_ID"].ToString().Trim() + "', '" + nd_id + "', 'True', 'True', 'True', 'True', 'True', 'True', 'True') ";
                ok = cls.ExecuteNonQueryTrans(sql);
                if (!ok) break;
                i = i + 1;
            }
            return ok;
        }
        private void frmCauHinhHeThong_Load(object sender, EventArgs e)
        {
            
            LayDSMayIn();
            LayDSDoiTac();
            LayDSKhoHang();
            if (issua)
            {
                dv_id = Info.dv_id;
                txtTen.Text = Info.dv_ten;
                txtDiaChi.Text = Info.dv_diachi;
                txtDienThoai.Text = Info.dv_dienthoai;
                txtFax.Text = Info.dv_fax;
                txtEmail.Text = Info.dv_email;
                txtMaSoThue.Text = Info.dv_masothue;
                txtNguoiLienHe.Text = Info.dv_nguoilienhe;

                cboMayInVanBan.Text = Info.mayinvanban;
                cboMayInHoaDon.Text = Info.mayinhoadon;
                cboMayInMaVach.Text = Info.mayinmavach;
                cboMayInCheBien.Text = Info.mayinchebien;

                chkXemTruoc.Checked = Info.xemtruockhiin;
                chkSuDungMaVach.Checked = Info.sudungmavach;
                chkSuaDonGia.Checked = Info.suadongia;
                chkSuaSoLuong.Checked = Info.suasoluong;
                chkNhapGiamGia.Checked = Info.nhapgiamgia;
                txtGiamGia.EditValue = Info.giamgiamacdinh;
                chkSuDungChuongTrinh.Checked = Info.sudungchuongtrinh;
                txtDoanhSo.EditValue = Info.doanhsotuongungdiem;
                chkChonKhoHang.Checked = Info.chonkhohang;
                glkuKhoHang.EditValue = Info.kh_id;
                cboMauHoaDon.Text = Info.mauhoadon;
                chkXuatLonHonTon.Checked = Info.xuatlonhonton;
                glkuDoiTac.EditValue = Info.dt_id;

                chkTuDongSinhMa.Checked = Info.tusinhma;
                chkThongBaoTon.Checked = Info.thongbaohangton;
                chkThayDoiNgay.Checked = Info.chophepdoingay;
                chkThuTuChungTuGiam.Checked = Info.thutuchungtugiam;
                chkNhapNhieuLan.Checked = Info.chophepnhapnhieulan;
            }
            else
            {
                dv_id = DateTime.Now.ToString("yyMMddHHmmss");
                Info.dv_id = dv_id;
            }
        }

        private void glkuQuyTien_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //if (e.Button.Index == 1)
            //{
            //    frmQuyTienUpdate frm = new frmQuyTienUpdate();
            //    frm.LayDSQuyTienDelegate = new frmQuyTienUpdate.GetDataTable(LayDSQuyTien);
            //    frm.setQuyTien = new frmQuyTienUpdate.SetString(SetQuyTien);
            //    frm.frmText = "Quỹ tiền [Thêm]";
            //    frm.frmReq = "frmCauHinhHeThong";
            //    frm.ShowDialog();
            //}
        }

        private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TTHMessage.ShowMessageInfomation(listBoxControl1.SelectedIndex.ToString());
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (issua)
                this.Close();
            else Application.Exit();
        }
        public void SetDoiTac(string dt_id)
        {
            glkuDoiTac.EditValue = dt_id;
        }
        private void glkuDoiTac_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                frmKhachHangUpdate frm = new frmKhachHangUpdate();
                frm.frmText = "KHÁCH HÀNG [Thêm]";
                frm.LayDSDoiTac = new frmKhachHangUpdate.GetDataTableDelegate(LayDSDoiTac);
                frm.SetDoiTac = new frmKhachHangUpdate.SetDoiTacDelegate(SetDoiTac);
                frm.ShowDialog();
            }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            if (txtTen.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập tên.");
                txtTen.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập địa chỉ.");
                txtDiaChi.Focus();
                return;
            }
            if (txtDienThoai.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập điện thoại.");
                txtDienThoai.Focus();
                return;
            }
            if (txtNguoiLienHe.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập người liên hệ.");
                txtNguoiLienHe.Focus();
                return;
            }
            //if (glkuKhoHang.Text.Length == 0)
            //{
            //    TTHMessage.ShowMessageWarming("Bạn chưa chọn kho bán lẻ.");
            //    xtraTabControl1.SelectedTabPage = xtraTabPage2;
            //    glkuKhoHang.Focus();
            //    return;
            //}
            //if (glkuDoiTac.Text.Length == 0)
            //{
            //    TTHMessage.ShowMessageWarming("Bạn chưa chọn khách hàng mặc định.");
            //    xtraTabControl1.SelectedTabPage = xtraTabPage2;
            //    glkuDoiTac.Focus();
            //    return;
            //}
            Boolean ok = false;
            DataAccessStatic.sqltrans = DataAccessStatic.conn.BeginTransaction();
            if (issua) ok = SuaDonVi(Info.dv_id, txtTen.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(), txtFax.Text.Trim(), txtEmail.Text.Trim(), txtMaSoThue.Text.Trim(), txtNguoiLienHe.Text.Trim());
            else
            {
                string nd_id = DateTime.Now.ToString("yyMMddHHmmss");
                ok = ThemDonVi(Info.dv_id, txtTen.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(), txtFax.Text.Trim(), txtEmail.Text.Trim(), txtMaSoThue.Text.Trim(), txtNguoiLienHe.Text.Trim(), true, DateTime.Now);
                if (ok) ok = ThemNguoiDung(nd_id);
                if (ok) ok = ThemQuyenNguoiDung(nd_id);
            }
            if (ok)
            {
                DataAccessStatic.sqltrans.Commit();
                TTHMessage.ShowMessageInfomation("Đã lưu thành công!");
                SaveXML("info.xml");
                Info.dv_ten = txtTen.Text.Trim();
                Info.dv_diachi = txtDiaChi.Text.Trim();
                Info.dv_dienthoai = txtDienThoai.Text.Trim();
                Info.dv_fax = txtFax.Text.Trim();
                Info.dv_email = txtEmail.Text.Trim();
                Info.dv_masothue = txtMaSoThue.Text.Trim();
                Info.dv_nguoilienhe = txtNguoiLienHe.Text.Trim();

                Info.mayinvanban = cboMayInVanBan.Text.Trim();
                Info.mayinhoadon = cboMayInHoaDon.Text.Trim();
                Info.mayinmavach = cboMayInMaVach.Text.Trim();
                Info.mayinchebien = cboMayInCheBien.Text.Trim();
                Info.xemtruockhiin = chkXemTruoc.Checked;
                Info.sudungmavach = chkSuDungMaVach.Checked;
                Info.suadongia = chkSuaDonGia.Checked;
                Info.suasoluong = chkSuaSoLuong.Checked;
                Info.nhapgiamgia = chkNhapGiamGia.Checked;
                Info.giamgiamacdinh = double.Parse(txtGiamGia.EditValue.ToString());
                Info.sudungchuongtrinh = chkSuDungChuongTrinh.Checked;
                Info.doanhsotuongungdiem = double.Parse(txtDoanhSo.EditValue.ToString());
                Info.chonkhohang = chkChonKhoHang.Checked;
                Info.kh_id = glkuKhoHang.EditValue.ToString();
                Info.xuatlonhonton = chkXuatLonHonTon.Checked;
                Info.mauhoadon = cboMauHoaDon.Text.Trim();
                Info.dt_id = glkuDoiTac.EditValue.ToString();

                Info.tusinhma = chkTuDongSinhMa.Checked;
                Info.thongbaohangton = chkThongBaoTon.Checked;
                Info.chophepdoingay = chkThayDoiNgay.Checked;
                Info.thutuchungtugiam = chkThuTuChungTuGiam.Checked;
                Info.chophepnhapnhieulan = chkNhapNhieuLan.Checked;
                this.Close();
            }
            else
            {
                DataAccessStatic.sqltrans.Rollback();
                TTHMessage.ShowMessageWarming("Không thể lưu.");
            }
        }

        private void glkuKhoHang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                frmKhoHangUpdate frm = new frmKhoHangUpdate();
                frm.frmText = "KHO HÀNG [Thêm]";
                frm.LayDSKhoHang = new frmKhoHangUpdate.GetDataTableDelegate(LayDSKhoHang);
                frm.SetKhoHang = new frmKhoHangUpdate.SetKhoHangDelegate(SetKhoHang);
                frm.ShowDialog();
            }
        }

        private void lnkChinhSua_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FastReport.Report rpt = new FastReport.Report();
            rpt.Load(Application.StartupPath + "\\report\\HoaDon_K58.frx");
            rpt.Design();
            //rpt.Designer.UIStyle = FastReport.Utils.UIStyle.Office2007Blue;
        }
    }
}