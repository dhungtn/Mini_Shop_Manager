using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MyRMS.BaoCao;
using MyRMS.HeThong;
using MyRMS.DanhMuc;
using MyRMS.NghiepVu;
namespace MyRMS
{
    public partial class frmRetail : DevExpress.XtraEditors.XtraForm
    {
        public delegate void DisplayBackgroungDelegate();
        public DisplayBackgroungDelegate DisplayBackgroung;
        GridViewFilterHelper filterHelper;
        DataAccess cls = new DataAccess();
        public string lh_id = "";
        public string hd_id = "";
        public int trangthai = 0;
        public Boolean issua = false;
        public Boolean ThemHoaDon(string hd_id, string hd_kyhieu, DateTime hd_ngaylap, double hd_sotien, double hd_giamgia, double tiengiamgia, double hd_tiengio, double hd_giamgiagio, double hd_tiengiamgiagio, double hd_sotiencuoi, string hd_sotiencuoichu, double hd_thanhtoan, string hd_ghichu, string hd_thutu, double hd_trangthai, Boolean hd_daxoa, string hd_dv_id, string hd_bp_id,  string hd_nd_id, string hd_loai, DateTime hd_batdau, string hd_dt_id, Boolean hd_datinhgio)
        {
            string[] field = { "HD_ID", "HD_KyHieu", "HD_NgayLap", "HD_SoTien", "HD_GiamGia", "HD_TienGiamGia", "HD_TienGio", "HD_GiamGiaGio", "HD_TienGiamGiaGio", "HD_SoTienCuoi", "HD_SoTienCuoiChu", "HD_ThanhToan", "HD_GhiChu", "HD_ThuTu", "HD_TrangThai", "HD_DaXoa", "HD_DV_ID", "HD_BP_ID",  "HD_ND_ID", "HD_Loai", "HD_GioVao", "HD_DT_ID", "HD_DaTinhGio", "HD_CLV_ID" };
            object[] value = { (object)hd_id, (object)hd_kyhieu, (object)hd_ngaylap, (object)hd_sotien, (object)hd_giamgia, (object)tiengiamgia, (object)hd_tiengio, (object)hd_giamgiagio, (object)hd_tiengiamgiagio, (object)hd_sotiencuoi, (object)hd_sotiencuoichu, (object)hd_thanhtoan, (object)hd_ghichu, (object)hd_thutu, (object)hd_trangthai, (object)hd_daxoa, (object)hd_dv_id, (object)hd_bp_id, (object)hd_nd_id, (object)hd_loai, (object)hd_batdau, (object)hd_dt_id, (object)hd_datinhgio, (object)Info.clv_id };
            return cls.AddRecordTrans("HoaDon", field, value);
        }
        public Boolean XoaHoaDon(string hd_id)
        {
            string sql = "delete HoaDon where HD_ID = '" + hd_id + "'";
            return cls.ExecuteNonQuery(sql);
        }
        public Boolean XoaHoaDonTrans(string hd_id)
        {
            string sql = "delete HoaDon where HD_ID = '" + hd_id + "'";
            return cls.ExecuteNonQueryTrans(sql);
        }
        public void LayThongTinHoaDon(string hd_id)
        {
            string sql = "select * from HoaDon where HD_ID = '" + hd_id + "'";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                this.hd_id = hd_id;
                txtKyHieu.Text = dr["HD_KyHieu"].ToString();
                dateNgayLap.EditValue = (DateTime)dr["HD_NgayLap"];
                grcData.DataSource = LayDSHoaDonChiTiet(hd_id);
                txtTienHang.EditValue = double.Parse(dr["HD_SoTien"].ToString());
                txtGiamGia.EditValue = dr["HD_GiamGia"].ToString();
                txtTienGiamGia.EditValue = double.Parse(dr["HD_TienGiamGia"].ToString());
                txtTongCong.EditValue = double.Parse(dr["HD_SoTienCuoi"].ToString());
            }
        }
        public Boolean ThemHoaDonChiTiet(string hdct_id, string hdct_hd_id, string hdct_mh_id, string hdct_dvt, double hdct_soluong, double hdct_dongia, double hdct_dongiavon, double hdct_thanhtien, double hdct_chietkhau, double hdct_tienchietkhau, double hdct_tongcong, string hdct_thutu, Boolean hdct_incb, Boolean hdct_chonxoa, DateTime hdct_ngaylap, string hdct_loai)
        {
            DataAccess cls = new DataAccess();
            string[] field = { "HDCT_ID", "HDCT_HD_ID", "HDCT_MH_ID", "HDCT_DVT", "HDCT_SoLuong", "HDCT_DonGia", "HDCT_DonGiaVon", "HDCT_ThanhTien", "HDCT_ChietKhau", "HDCT_TienChietKhau", "HDCT_TongCong", "HDCT_ThuTu", "HDCT_DV_ID", "HDCT_InCB", "HDCT_ChonXoa", "HDCT_NgayLap", "HDCT_Loai" };
            object[] obj = { (object)hdct_id, (object)hdct_hd_id, (object)hdct_mh_id, (object)hdct_dvt, (object)hdct_soluong, (object)hdct_dongia, (object)hdct_dongiavon, (object)hdct_thanhtien, (object)hdct_chietkhau, (object)hdct_tienchietkhau, (object)hdct_tongcong, (object)hdct_thutu, (object)Info.dv_id, (object)hdct_incb, (object)hdct_chonxoa, (object)hdct_ngaylap.ToString("yyyy/MM/dd"), (object)hdct_loai };
            return cls.AddRecordTrans("HoaDonChiTiet", field, obj);
        }
        public DataTable LayDSHoaDonChiTiet(string hd_id)
        {
            string sql = "select HDCT_ID,  HDCT_MH_ID, HDCT_DVT, HDCT_SoLuong,  HDCT_DonGia, HDCT_DonGiaVon, HDCT_ThanhTien, HDCT_InCB, HDCT_ChonXoa, HDCT_ThuTu from HoaDonChiTiet where HDCT_HD_ID = '" + hd_id + "' order by HDCT_ThuTu";
            return cls.GetDataTable(sql);
        }
        public void TaoSoHoaDon(string loai)
        {
            string sql = "select distinct isnull(max(right(HD_KyHieu,4)),0) from HoaDon where HD_Loai = '" + loai + "' and HD_TrangThai = 3 and HD_DV_ID = '" + Info.dv_id + "' and convert(varchar(10),HD_NgayLap, 103) = '" + ((DateTime)dateNgayLap.EditValue).ToString("dd/MM/yyyy") + "'";
            txtKyHieu.EditValue = loai + ((DateTime)dateNgayLap.EditValue).ToString("yyMMdd") + "-" + string.Format("{0,4:0000}", cls.GetNumberValue(sql) + 1);
        }
        public void LayDSNguoiDung()
        {
            string sql = "select ND_ID, ND_Ten from NguoiDung ";
            sql += "order by ND_Ten ";
            glkuNhanVien.Properties.DataSource = cls.GetDataTable(sql);
            glkuNhanVien.Properties.ValueMember = "ND_ID";
            glkuNhanVien.Properties.DisplayMember = "ND_Ten";
            glkuNhanVien.Properties.PopupFormWidth = glkuNhanVien.Size.Width - 4;
        }
        public void LayDSCaLamViec()
        {
            string sql = "select CLV_ID, CLV_Ten from CaLamViec ";
            sql += "order by CLV_ID ";
            glkuCaLamViec.Properties.DataSource = cls.GetDataTable(sql);
            glkuCaLamViec.Properties.ValueMember = "CLV_ID";
            glkuCaLamViec.Properties.DisplayMember = "CLV_Ten";
            glkuCaLamViec.Properties.PopupFormWidth = glkuCaLamViec.Size.Width - 4;
            glkuCaLamViec.EditValue = Info.clv_id;
        }
        public void LayDSMatHangDropDown()
        {

            //string sql = "select MH_ID,MH_Ma,  MH_Ten, MH_DVT, MH_GiaMua, MH_GiaBanLe, MH_TuKhoa from MatHang where MH_KichHoat = 'True' and MH_DV_ID = '" + Info.dv_id + "' order by MH_Ten";
            string sql = "select MH_ID,MH_Ma,  MH_Ten, MH_DVT, MH_GiaMua, MH_GiaBanLe, MH_TuKhoa, isnull((select sum(soluongnhap) - sum(soluongxuat) from TheoDoiNhapXuatHang where idmh = a.MH_ID),0) as soluongton ";
            sql += "from MatHang a ";
            DataTable dt = cls.GetDataTable(sql);
            rglkuMatHang.DataSource = dt;
            rglkuMatHang.ValueMember = "MH_ID";
            rglkuMatHang.DisplayMember = "MH_Ten";
            rglkuMatHang.PopupFormWidth = 600;
            rglkuvMatHang.BestFitColumns();
            grcMatHang.DataSource = dt;
            pceMaVach.Properties.PopupControl.Size = new Size(500, 250);
        }
        public frmRetail()
        {
            InitializeComponent();
            filterHelper = new GridViewFilterHelper(grvMatHang);
        }

        

        private void rchkXoa_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DataRow row = grvData.GetFocusedDataRow();
                row.Delete();
                TinhTong();
            }
            catch (Exception)
            {
                
                
            }
            
        }
        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            frmBaoCaoDoanhThu frm = new frmBaoCaoDoanhThu();
            frm.ShowDialog();
        }

        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            frmCauHinhHeThong frm = new frmCauHinhHeThong();
            frm.issua = true;
            frm.ShowDialog();
        }

        private void btnNguoiDung_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.ShowDialog();
        }
       
       
        public void TinhTong()
        {
            try
            {
                txtTienHang.EditValue = double.Parse(grvData.Columns["HDCT_ThanhTien"].SummaryText);
                txtTienGiamGia.EditValue = 0.01 * double.Parse(txtGiamGia.EditValue.ToString()) * double.Parse(txtTienHang.EditValue.ToString());
                txtTongCong.EditValue = double.Parse(txtTienHang.EditValue.ToString()) - double.Parse(txtTienGiamGia.EditValue.ToString());
            }
            catch (Exception ex)
            {
                TTHMessage.ShowMessageWarming(ex.ToString());
            }

        }
        public void AddHoaDonChiTiet(string hdct_mh_id, string hdct_donvi, double hdct_soluong, double hdct_dongia, double hdct_dongiavon, double hdct_thanhtien)
        {
            try
            {
                DataTable dt = (DataTable)grcData.DataSource;
                DataRow row = dt.NewRow();
                row["HDCT_ID"] = DateTime.Now.ToString("yyMMdd") + hd_id + string.Format("{0,4:0000}", grvData.RowCount) + DateTime.Now.ToString("yyMMddHHmmss");
                row["HDCT_MH_ID"] = hdct_mh_id;
                row["HDCT_DVT"] = hdct_donvi;
                row["HDCT_SoLuong"] = hdct_soluong;
                row["HDCT_DonGia"] = hdct_dongia;
                row["HDCT_DonGiaVon"] = hdct_dongiavon;
                row["HDCT_ThanhTien"] = hdct_thanhtien;
                row["HDCT_ThuTu"] = DateTime.Now.ToString("yyMMdd") + hd_id + string.Format("{0,4:0000}", grvData.RowCount) + DateTime.Now.ToString("yyMMddHHmmss");
                
                dt.Rows.InsertAt(row, dt.Rows.Count);
                grcData.DataSource = dt;

                grcData.Focus();
                grvData.FocusedRowHandle = grvData.RowCount - 1;
                TinhTong();
            }
            catch (Exception ex)
            {
                TTHMessage.ShowMessageWarming(ex.ToString());
            }
            
        }
        
        private void frmBanLe_Load(object sender, EventArgs e)
        {
            LayDSMatHangDropDown();
            cboTuyChon.Text = "Hôm nay";
            btnXem_Click(null, null);
            TaoMoiHoaDon();
        }

       

       

       

       

        

       

        private void flpMatHang_Click(object sender, EventArgs e)
        {
           
        }

        private void txtGiamGia_KeyUp(object sender, KeyEventArgs e)
        {
            txtTienGiamGia.EditValue = 0.01 * double.Parse(txtGiamGia.EditValue.ToString()) * double.Parse(txtTienHang.EditValue.ToString());
            txtTongCong.EditValue = double.Parse(txtTienHang.EditValue.ToString()) - double.Parse(txtTienGiamGia.EditValue.ToString());
        }

        private void txtTienGiamGia_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                txtGiamGia.EditValue = System.Math.Round(double.Parse(txtTienGiamGia.EditValue.ToString()) / double.Parse(txtTienHang.EditValue.ToString()), 2) * 100;
                txtTongCong.EditValue = double.Parse(txtTienHang.EditValue.ToString()) - double.Parse(txtTienGiamGia.EditValue.ToString());
            }
            catch (Exception)
            {
                
                
            }
            
        }
        public void InHoaDon(string id)
        {
            try
            {
                string thoigian = ((DateTime)dateNgayLap.EditValue).ToString("dd/MM/yyyy HH:mm:ss");
                string sql = "select HD_KyHieu, HD_NgayLap, convert(varchar(10), HD_NgayLap,103) + ' ' + convert(varchar(10), HD_NgayLap,108) as HD_ThoiGianLap, HD_ThoiGian, ";
                sql += "N'Ngày ' + case when len(convert(char(2),day(convert(datetime,HD_NgayLap,103)))) = 1 then '0' + convert(char(2),day(convert(datetime,HD_NgayLap,103))) else convert(char(2),day(convert(datetime,HD_NgayLap,103))) end + N' tháng ' + case when len(convert(char(2),month(convert(datetime,HD_NgayLap,103)))) = 1 then '0' + convert(char(2),month(convert(datetime,HD_NgayLap,103))) else convert(char(2),month(convert(datetime,HD_NgayLap,103))) end  + N' năm ' + convert(char(4),year(HD_NgayLap)) as HD_NgayLapchu, ";
                sql += "HD_TienGio,HD_SoTien,HD_GiamGiaGio,HD_TienGiamGiaGio,HD_GiamGia, HD_TienGiamGia, HD_SoTienCuoi, HD_SoTienCuoiChu, HD_KhachDua, HD_TienThua, HD_GhiChu, (select BP_Ten from BanPhong where BP_ID = HD_BP_ID) as HD_TenBan, ";
                sql += "MH_Ten as HDCT_MH_Ten, HDCT_DVT, HDCT_SoLuong, HDCT_DonGia, HDCT_ThanhTien	 ";
                sql += "from ";
                sql += "( ";
                sql += "select HDCT_HD_ID,HDCT_MH_ID,HDCT_DVT, sum(HDCT_SoLuong) as HDCT_SoLuong, HDCT_DonGia, sum(HDCT_SoLuong) * HDCT_DonGia as HDCT_ThanhTien ";
                sql += "from HoaDonChiTiet where HDCT_HD_ID = '" + id + "' ";
                sql += "group by HDCT_HD_ID,HDCT_MH_ID,HDCT_DVT, HDCT_DonGia ";
                sql += ") temp left join HoaDon on HDCT_HD_ID = HD_ID ";
                sql += "left join MatHang on HDCT_MH_ID = MH_ID ";
                sql += "where HDCT_HD_ID = '" + id + "' ";
                sql += "order by HDCT_MH_Ten";
                FastReport.Report rpt = new FastReport.Report();
                if (Info.mauhoadon == "K58")
                    rpt.Load(Application.StartupPath + "\\report\\HoaDon_K58.frx");
                if (Info.mauhoadon == "K80")
                    rpt.Load(Application.StartupPath + "\\report\\HoaDon_K80.frx");
                rpt.RegisterData(cls.GetDataTable(sql), "Table");
                rpt.SetParameterValue("tendoanhnghiep", Info.dv_ten);
                rpt.SetParameterValue("diachidoanhnghiep", Info.dv_diachi);
                rpt.SetParameterValue("dienthoaidoanhnghiep", Info.dv_dienthoai);
                if (Info.xemtruockhiin)
                {
                    rpt.Show();
                }
                else
                {
                    rpt.PrintSettings.Printer = Info.mayinhoadon;
                    rpt.PrintSettings.ShowDialog = false;
                    rpt.Print();
                }
            }
            catch (Exception ex)
            {
                TTHMessage.ShowMessageError(ex.ToString());

            }

        }
       
        public void SetDonGia(string idct, double dongiamoi, double dongiavonmoi)
        {
            int vitri = grvData.FocusedRowHandle;
            DataRow row = grvData.GetFocusedDataRow();
            double thanhtien = double.Parse(row["HDCT_SoLuong"].ToString()) * dongiamoi;
            row["HDCT_ThanhTien"] = thanhtien;
            row["HDCT_DonGia"] = dongiamoi;
            row["HDCT_DonGiaVon"] = dongiavonmoi;
            grvData.FocusedRowHandle = vitri;
            TinhTong();
        }
        public void SetSoLuong(string idct, double soluong)
        {
            int vitri = grvData.FocusedRowHandle;
            DataRow row = grvData.GetFocusedDataRow();
            double thanhtien = double.Parse(row["HDCT_DonGia"].ToString()) * soluong;
            row["HDCT_ThanhTien"] = thanhtien;
            row["HDCT_SoLuong"] = soluong;
            grvData.FocusedRowHandle = vitri;
            TinhTong();
        }
        private void grvData_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount == 0) return;
            
            try
            {
                string col = grvData.FocusedColumn.FieldName.ToString();
                if (col == "HDCT_DonGia")
                {
                    if (Info.suadongia)
                    {
                        frmUpdateDonGia frm = new frmUpdateDonGia();
                        DataRow row = grvData.GetFocusedDataRow();
                        frm.idct = row["HDCT_ID"].ToString().Trim();
                        frm.mh_id = row["HDCT_MH_ID"].ToString().Trim();
                        frm.number = double.Parse(row["HDCT_DonGia"].ToString());
                        frm.SetDonGia = new frmUpdateDonGia.SetDonGiaDelegate(SetDonGia);
                        frm.ShowDialog();
                    }
                }
                if (col == "HDCT_SoLuong")
                {
                    if (Info.suadongia)
                    {
                        frmUpdateSoLuong frm = new frmUpdateSoLuong();
                        DataRow row = grvData.GetFocusedDataRow();
                        frm.idct = row["HDCT_ID"].ToString().Trim();
                        frm.mh_id = row["HDCT_MH_ID"].ToString().Trim();
                        frm.number = double.Parse(row["HDCT_SoLuong"].ToString());
                        frm.SetSoLuong = new frmUpdateSoLuong.SetSoLuongDelegate(SetSoLuong);
                        frm.ShowDialog();
                    }
                }
            }
            catch (Exception)
            {


            }
        }

       

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void barF1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnMoi_Click(null, null);
        }

        private void barF12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnDong_Click(null, null);
        }

       

       

       

        

        private void frmBanLe_Activated(object sender, EventArgs e)
        {
            //txtTenHang.Focus();
        }

        private void btnDMHangHoa_Click(object sender, EventArgs e)
        {
            frmMatHang frm = new frmMatHang();
            frm.ShowDialog();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            TTHWait.ShowWait();
            string tungay = ((DateTime)dateTuNgay.EditValue).ToString("dd/MM/yyyy");
            string denngay = ((DateTime)dateDenNgay.EditValue).ToString("dd/MM/yyyy");
            string sql = "";
            sql += "select HD_ID, HD_KyHieu, HD_NgayLap, HD_SoTien, HD_TienGiamGia, HD_SoTienCuoi, HD_GhiChu from HoaDon where  HD_Loai = 'XHB' and HD_TrangThai = 3  ";
            sql += "and convert(DateTime,convert(varchar(10),HD_NgayLap,103),103) >= convert(datetime, '" + tungay + "',103) and convert(DateTime,convert(varchar(10),HD_NgayLap,103),103) <= convert(datetime, '" + denngay + "',103)    ";
            grcBangKe.DataSource = cls.GetDataTable(sql);
            TTHWait.CloseWait();
        }

        private void cboTuyChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTuyChon.EditValue.ToString() == "Tùy chọn")
            {
                dateTuNgay.Enabled = true;
                dateDenNgay.Enabled = true;
                dateTuNgay.EditValue = DateTime.Now;
                dateDenNgay.EditValue = DateTime.Now;
            }
            else
            {
                dateTuNgay.Enabled = false;
                dateDenNgay.Enabled = false;
                if (cboTuyChon.EditValue.ToString() == "Hôm nay")
                {
                    dateTuNgay.EditValue = DateTime.Today;
                    dateDenNgay.EditValue = DateTime.Today;
                }
                if (cboTuyChon.EditValue.ToString() == "Tuần này")
                {
                    DateTime d = DateTime.Now;
                    while (d.DayOfWeek != DayOfWeek.Monday) d = d.AddDays(-1); // tìm đầu tuần
                    dateTuNgay.EditValue = d;//DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = d.AddDays(6);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng này")
                {
                    dateTuNgay.EditValue = TTHUtils.LayNgayDauThang();
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)) + "/" + string.Format("{0,2:00}", DateTime.Now.Month) + "/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Quý này")
                {

                    int m = DateTime.Now.Month;
                    DateTime d = DateTime.Now;
                    DateTime d1 = DateTime.Now;
                    if (m <= 3)
                    {
                        d = DateTime.ParseExact("01/01/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                        d1 = DateTime.ParseExact("31/03/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    }
                    else if (m <= 6)
                    {
                        d = DateTime.ParseExact("01/04/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                        d1 = DateTime.ParseExact("30/06/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    }
                    else if (m <= 9)
                    {
                        d = DateTime.ParseExact("01/07/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                        d1 = DateTime.ParseExact("30/09/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    }
                    else
                    {
                        d = DateTime.ParseExact("01/10/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                        d1 = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 12)) + "/12/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    }
                    dateTuNgay.EditValue = d;
                    dateDenNgay.EditValue = d1;
                }
                if (cboTuyChon.EditValue.ToString() == "Năm nay")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/01/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 12)) + "/12/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 1")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/01/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 1)) + "/01/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 2")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/02/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 2)) + "/02/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 3")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/03/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 3)) + "/03/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 4")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/04/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 4)) + "/04/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 5")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/05/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 5)) + "/05/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 6")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/06/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 6)) + "/06/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 7")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/07/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 7)) + "/07/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 8")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/08/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 8)) + "/08/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 9")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/09/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 9)) + "/09/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 10")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/10/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 10)) + "/10/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 11")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/11/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 11)) + "/11/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Tháng 12")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/12/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 12)) + "/12/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Quý 1")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/01/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact("31/03/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Quý 2")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/04/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact("30/06/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Quý 3")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/07/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact("30/09/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
                if (cboTuyChon.EditValue.ToString() == "Quý 4")
                {
                    dateTuNgay.EditValue = DateTime.ParseExact("01/10/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                    dateDenNgay.EditValue = DateTime.ParseExact(string.Format("{0,2:00}", DateTime.DaysInMonth(DateTime.Now.Year, 12)) + "/12/" + string.Format("{0,4:0000}", DateTime.Now.Year), "dd/MM/yyyy", null);
                }
            }
        }

        private void pceMaVach_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                pceMaVach.ClosePopup();
                pceMaVach.Text = "";
                pceMaVach.Focus();
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (pceMaVach.Text.Trim().Length > 0)
                {
                    try
                    {
                        string s = "";
                        if (grvMatHang.RowCount > 0)
                        {
                            DataRow row = grvMatHang.GetFocusedDataRow();
                            s = row["MH_ID"].ToString().Trim();
                        }
                        if (s.Length > 0)
                        {
                            double giaban = 0;
                            double giavon = 0;
                            string sql = "select distinct MH_GiaMua, MH_GiaBanLe from MatHang where MH_ID = '" + s + "'";
                            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
                            {
                                giaban = double.Parse(dr["MH_GiaBanLe"].ToString());
                                giavon = double.Parse(dr["MH_GiaMua"].ToString());
                            }
                            AddHoaDonChiTiet(s, "", 1, giaban, giavon, giaban);
                            TinhTong();
                            pceMaVach.Text = "";
                            pceMaVach.Focus();
                            //Boolean daco = false;
                            //double soluong = 1;
                            //double dongia = 0;
                            //for (int i = 0; i < grvData.RowCount; i++)
                            //{
                            //    DataRow dr = grvData.GetDataRow(i);
                            //    if (dr["HDCT_MH_ID"].ToString().Trim() == s)
                            //    {
                            //        soluong = double.Parse(dr["HDCT_SoLuong"].ToString()) + soluong;
                            //        dongia = double.Parse(dr["HDCT_DonGia"].ToString());
                            //        grvData.SetFocusedRowCellValue(colThanhTien, soluong * dongia);
                            //        grcData.DataSource = LayDSHoaDonChiTiet(hd_id);
                            //        TinhTong();
                            //        pceMaVach.Text = "";
                            //        pceMaVach.Focus();
                            //        daco = true;
                            //        break;
                            //    }
                            //}
                            //if (!daco)
                            //{
                            //    double giaban = 0;
                            //    double giavon = 0;
                            //    string sql = "select distinct MH_GiaMua, MH_GiaBanLe from MatHang where MH_ID = '" + s + "'";
                            //    foreach (DataRow dr in cls.GetDataTable(sql).Rows)
                            //    {
                            //        giaban = double.Parse(dr["MH_GiaBanLe"].ToString());
                            //        giavon = double.Parse(dr["MH_GiaMua"].ToString());
                            //    }
                            //    AddHoaDonChiTiet(s, "", 1, giaban, giavon, giaban);
                            //    pceMaVach.Text = "";
                            //    pceMaVach.Focus();
                            //}
                        }
                        else
                        {
                            frmMatHangThem frm = new frmMatHangThem();
                            frm.mh_id = pceMaVach.Text.Trim();
                            frm.frmText = "MẶT HÀNG [Thêm]";
                            frm.frmReq = "frmBanHang";
                            frm.LayDSMatHang = new frmMatHangThem.GetDataTableDelegate(LayDSMatHangDropDown);
                            frm.AddHoaDonChiTiet = new frmMatHangThem.AddHoaDonChiTietDelegate(AddHoaDonChiTiet);
                            frm.ShowDialog();
                            pceMaVach.Text = "";
                            pceMaVach.Focus();
                        }
                    }
                    catch (Exception)
                    {


                    }
                }
                
            }
            if (pceMaVach.Text.Length == 0)
            {
                filterHelper.ActiveFilter = TTHUtils.LoaiBoDauTiengViet(pceMaVach.Text.Trim());
                pceMaVach.ClosePopup();
            }
            else
            {
                filterHelper.ActiveFilter = TTHUtils.LoaiBoDauTiengViet(pceMaVach.Text.Trim());
                pceMaVach.ShowPopup();
                pceMaVach.Focus();
                if (e.KeyCode == Keys.Down)
                {
                    grvMatHang.Focus();
                }
            }
        }

        private void grcMatHang_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (grvMatHang.FocusedRowHandle == 0)
                {
                    pceMaVach.Focus();
                    return;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (grvMatHang.RowCount > 0)
                {
                    DataRow row = grvMatHang.GetFocusedDataRow();
                    AddHoaDonChiTiet(row["MH_ID"].ToString().Trim(), row["MH_DVT"].ToString().Trim(), 1, double.Parse(row["MH_GiaBanLe"].ToString()), double.Parse(row["MH_GiaMua"].ToString()), double.Parse(row["MH_GiaBanLe"].ToString()));
                    pceMaVach.EditValue = "";
                    filterHelper.ActiveFilter = TTHUtils.LoaiBoDauTiengViet(pceMaVach.Text.Trim());
                    pceMaVach.ClosePopup();
                    pceMaVach.Focus();
                }

            }
        }

        private void grvMatHang_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvMatHang.RowCount > 0)
                {
                    DataRow row = grvMatHang.GetFocusedDataRow();
                    AddHoaDonChiTiet(row["MH_ID"].ToString().Trim(), row["MH_DVT"].ToString().Trim(), 1, double.Parse(row["MH_GiaBanLe"].ToString()), double.Parse(row["MH_GiaMua"].ToString()), double.Parse(row["MH_GiaBanLe"].ToString()));
                    pceMaVach.EditValue = "";
                    filterHelper.ActiveFilter = TTHUtils.LoaiBoDauTiengViet(pceMaVach.Text.Trim());
                    pceMaVach.ClosePopup();
                    pceMaVach.Focus();
                }
            }
            catch (Exception)
            {
                
                
            }
        }

        private void pceMaVach_MouseUp(object sender, MouseEventArgs e)
        {
            pceMaVach.SelectAll();
        }
        public void TaoMoiHoaDon()
        {
            try
            {
                pceMaVach.Text = "";
                trangthai = 1;
                dateNgayLap.EditValue = DateTime.Now;
                
                txtTienHang.EditValue = 0;
                txtGiamGia.EditValue = 0;
                txtTienGiamGia.EditValue = 0;
                txtTongCong.EditValue = 0;
                hd_id = DateTime.Now.ToString("yyMMddHHmmss");
                TaoSoHoaDon("XHB");
                grcData.DataSource = LayDSHoaDonChiTiet(hd_id);
                pceMaVach.Focus();
            }
            catch (Exception)
            {
                

            }
        }
        

        private void btnLuuIn_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount == 0)
            {
                TTHMessage.ShowMessageWarming("Chưa có mặt hàng nào trong hóa đơn!");
                return;
            }
            Boolean ok = false;
            if (!issua) TaoSoHoaDon("XHB");
            DataAccessStatic.sqltrans = DataAccessStatic.conn.BeginTransaction();
            if (issua) ok = XoaHoaDonTrans(hd_id);
            ok = ThemHoaDon(hd_id, txtKyHieu.Text.Trim(), (DateTime)dateNgayLap.EditValue, double.Parse(txtTienHang.EditValue.ToString()), double.Parse(txtGiamGia.EditValue.ToString()), double.Parse(txtTienGiamGia.EditValue.ToString()), 0, 0, 0, double.Parse(txtTongCong.EditValue.ToString()), TTHUtils.ConvertNumberToText(txtTongCong.EditValue.ToString()), double.Parse(txtTongCong.EditValue.ToString()), "", ((DateTime)dateNgayLap.EditValue).ToString("yyMMdd") + hd_id, 3, false, Info.dv_id, "", "", "XHB", (DateTime)dateNgayLap.EditValue, "", false);
            if (ok)
            {
                for (int i = 0; i < grvData.RowCount; i++)
                {
                    string idct = DateTime.Now.ToString("yyMMdd") + hd_id + string.Format("{0,4:0000}", i + 1) + DateTime.Now.ToString("yyMMddHHmmss");
                    DataRow row = grvData.GetDataRow(i);
                    ok = ThemHoaDonChiTiet(idct, hd_id, row["HDCT_MH_ID"].ToString().Trim(), row["HDCT_DVT"].ToString().Trim(), double.Parse(row["HDCT_SoLuong"].ToString()), double.Parse(row["HDCT_DonGia"].ToString()), double.Parse(row["HDCT_DonGiaVon"].ToString()), double.Parse(row["HDCT_ThanhTien"].ToString()), 0, 0, double.Parse(row["HDCT_ThanhTien"].ToString()), DateTime.Now.ToString("yyMMdd") + hd_id + string.Format("{0,4:0000}", i + 1) + DateTime.Now.ToString("yyMMddHHmmss"), false, false, DateTime.Now, "XHB");
                    if (!ok)
                        break;
                }

            }
            if (ok)
            {
                DataAccessStatic.sqltrans.Commit();
                TTHMessage.ShowMessageInfomation("Đã lưu thành công!");
                InHoaDon(hd_id);
                btnXem_Click(null, null);
                TaoMoiHoaDon();
            }
            else
            {
                DataAccessStatic.sqltrans.Rollback();
                TTHMessage.ShowMessageWarming("Không thể lưu!");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount == 0)
            {
                TTHMessage.ShowMessageWarming("Chưa có mặt hàng nào trong hóa đơn!");
                return;
            }
            Boolean ok = false;
            if (!issua) TaoSoHoaDon("XHB");
            DataAccessStatic.sqltrans = DataAccessStatic.conn.BeginTransaction();
            if (issua) ok = XoaHoaDonTrans(hd_id);
            ok = ThemHoaDon(hd_id, txtKyHieu.Text.Trim(), (DateTime)dateNgayLap.EditValue, double.Parse(txtTienHang.EditValue.ToString()), double.Parse(txtGiamGia.EditValue.ToString()), double.Parse(txtTienGiamGia.EditValue.ToString()), 0, 0, 0, double.Parse(txtTongCong.EditValue.ToString()), TTHUtils.ConvertNumberToText(txtTongCong.EditValue.ToString()), double.Parse(txtTongCong.EditValue.ToString()), "", ((DateTime)dateNgayLap.EditValue).ToString("yyMMdd") + hd_id, 3, false, Info.dv_id, "", "", "XHB", (DateTime)dateNgayLap.EditValue, "", false);
            if (ok)
            {
                for (int i = 0; i < grvData.RowCount; i++)
                {
                    string idct = DateTime.Now.ToString("yyMMdd") + hd_id + string.Format("{0,4:0000}", i + 1) + DateTime.Now.ToString("yyMMddHHmmss");
                    DataRow row = grvData.GetDataRow(i);
                    ok = ThemHoaDonChiTiet(idct, hd_id, row["HDCT_MH_ID"].ToString().Trim(), row["HDCT_DVT"].ToString().Trim(), double.Parse(row["HDCT_SoLuong"].ToString()), double.Parse(row["HDCT_DonGia"].ToString()), double.Parse(row["HDCT_DonGiaVon"].ToString()), double.Parse(row["HDCT_ThanhTien"].ToString()), 0, 0, double.Parse(row["HDCT_ThanhTien"].ToString()), DateTime.Now.ToString("yyMMdd") + hd_id + string.Format("{0,4:0000}", i + 1) + DateTime.Now.ToString("yyMMddHHmmss"), false, false, DateTime.Now, "XHB");
                    if (!ok)
                        break;
                }

            }
            if (ok)
            {
                DataAccessStatic.sqltrans.Commit();
                TTHMessage.ShowMessageInfomation("Đã lưu thành công!");
                btnXem_Click(null, null);
                TaoMoiHoaDon();
            }
            else
            {
                DataAccessStatic.sqltrans.Rollback();
                TTHMessage.ShowMessageWarming("Không thể lưu!");
            }
        }

        private void grvBangKe_Click(object sender, EventArgs e)
        {
            //if (grvBangKe.RowCount > 0)
            //{
            //    DataRow row = grvBangKe.GetFocusedDataRow();
            //    hd_id = row["HD_ID"].ToString().Trim();
            //    foreach (DataRow dr in cls.GetDataTable("select * from HoaDon where HD_ID = '" + hd_id + "'").Rows)
            //    {
            //        txtKyHieu.Text = dr["HD_KyHieu"].ToString().Trim();
            //        dateNgayLap.EditValue = (DateTime)dr["HD_NgayLap"];
            //        grcData.DataSource = LayDSHoaDonChiTiet(hd_id);                  
            //        txtTienHang.EditValue = double.Parse(dr["HD_SoTien"].ToString());
            //        txtGiamGia.EditValue = double.Parse(dr["HD_GiamGia"].ToString());
            //        txtTienGiamGia.EditValue = double.Parse(dr["HD_TienGiamGia"].ToString());
            //        txtTongCong.EditValue = double.Parse(dr["HD_SoTienCuoi"].ToString());
            //        pceMaVach.Focus();
            //    }
            //}
        }

        private void dateNgayLap_EditValueChanged(object sender, EventArgs e)
        {

        }
        //MH_ID,  MH_Ten, MH_DVT, MH_GiaMua, MH_GiaBanLe, MH_TuKhoa
        public void AddMatHang(string MH_ID, string MH_Ma, string MH_Ten, string MH_DVT, double MH_GiaMua, double MH_GiaBanSi, double MH_GiaBanLe, double MH_GiaTraCham, string MH_GhiChu, Boolean MH_KichHoat, string MH_TuKhoa)
        {
            TTHWait.ShowWait();
            DataTable dt = (DataTable)grcMatHang.DataSource;
            DataRow dr = dt.NewRow();
            dr["MH_ID"] = MH_ID;
            dr["MH_Ma"] = MH_Ma;
            dr["MH_Ten"] = MH_Ten;
            dr["MH_DVT"] = MH_DVT;
            dr["MH_GiaMua"] = MH_GiaMua;
            //dr["MH_GiaBanSi"] = MH_GiaBanSi;
            dr["MH_GiaBanLe"] = MH_GiaBanLe;
            //dr["MH_GiaTraCham"] = MH_GiaTraCham;
            //dr["MH_GhiChu"] = MH_GhiChu;
            //dr["MH_KichHoat"] = MH_KichHoat;
            dr["MH_TuKhoa"] = MH_TuKhoa;
            int pos = -1;
            if (grvMatHang.RowCount > 0)
            {
                try
                {
                    pos = grvMatHang.FocusedRowHandle;
                    if (pos < 0)
                        pos = -1;
                    else grvMatHang.UnselectRow(pos);
                }
                catch (Exception)
                {
                    pos = -1;

                }

            }
            dt.Rows.InsertAt(dr, pos + 1);
            grcMatHang.DataSource = dt;
            grvMatHang.ExpandAllGroups();
            grvMatHang.FocusedRowHandle = pos + 1;
            grvMatHang.BestFitColumns();
            TTHWait.CloseWait();
        }
        public void EditMatHang(string MH_ID, string MH_Ma, string MH_Ten, string MH_DVT, double MH_GiaMua, double MH_GiaBanSi, double MH_GiaBanLe, double MH_GiaTraCham, string MH_GhiChu, Boolean MH_KichHoat, string MH_TuKhoa)
        {
            try
            {
                grvMatHang.SetFocusedRowCellValue("MH_ID", MH_ID);
                grvMatHang.SetFocusedRowCellValue("MH_Ma", MH_Ma);
                grvMatHang.SetFocusedRowCellValue("MH_Ten", MH_Ten);
                grvMatHang.SetFocusedRowCellValue("MH_DVT", MH_DVT);
                grvMatHang.SetFocusedRowCellValue("MH_GiaMua", MH_GiaMua);
                //grvData.SetFocusedRowCellValue("MH_GiaBanSi", MH_GiaBanSi);
                grvMatHang.SetFocusedRowCellValue("MH_GiaBanLe", MH_GiaBanLe);
                //grvData.SetFocusedRowCellValue("MH_GiaTraCham", MH_GiaTraCham);
                //.SetFocusedRowCellValue("MH_GhiChu", MH_GhiChu);
                //grvData.SetFocusedRowCellValue("MH_KichHoat", MH_KichHoat);
                grvMatHang.SetFocusedRowCellValue("MH_TuKhoa", MH_TuKhoa);
            }
            catch (Exception)
            {


            }

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmMatHangThem frm = new frmMatHangThem();
            frm.frmText = "MẶT HÀNG [Thêm]";
            frm.lh_id = lh_id;
            frm.AddMatHang = new frmMatHangThem.AddMatHangDelegate(AddMatHang);
            frm.ShowDialog();
        }
        
        

        private void btnSua_Click(object sender, EventArgs e)
        {
            //if (grvMatHang.RowCount > 0)
            //{
            //    frmMatHangUpdate frm = new frmMatHangUpdate();
            //    frm.issua = true;
            //    frm.frmText = "MẶT HÀNG [Sửa]";
            //    frm.EditMatHang = new frmMatHangUpdate.EditMatHangDelegate(EditMatHang);
            //    DataRow row = grvMatHang.GetFocusedDataRow();
            //    frm.mh_id = row["MH_ID"].ToString().Trim();
            //    frm.ShowDialog();
            //}
            //else TTHMessage.ShowMessageWarming("Chưa có dòng nào được chọn!");
        }

        private void grvData_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle % 2 == 1)
            {
                e.Appearance.BackColor = Color.WhiteSmoke;
            }
            else e.Appearance.BackColor = Color.White;
        }

        private void grvMatHang_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle % 2 == 1)
            {
                e.Appearance.BackColor = Color.WhiteSmoke;
            }
            else e.Appearance.BackColor = Color.White;
        }

        

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvBangKe.RowCount == 0) return;
                DataRow row = grvBangKe.GetFocusedDataRow();
                string id = row["HD_ID"].ToString().Trim();
                if (TTHMessage.ShowMessageConfirm("Bạn có chắc muốn xóa dòng được chọn không?") == DialogResult.Yes)
                {

                    if (!XoaHoaDon(id))
                        TTHMessage.ShowMessageWarming("Không thể xóa dòng này.");
                    else
                    {
                        row.Delete();
                        //TaoMoiHoaDon();
                        TTHMessage.ShowMessageInfomation("Đã xóa thành công.");
                        btnMoi_Click(null, null);
                    }
                }
            }
            catch (Exception)
            {

                TTHMessage.ShowMessageWarming("Bạn chưa chọn dòng muốn xóa!");
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LayDSMatHangDropDown();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            frmImport frm = new frmImport();
            frm.ShowDialog();
        }

        private void grvBangKe_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grvBangKe.RowCount > 0)
                {
                    DataRow row = grvBangKe.GetFocusedDataRow();
                    issua = true;
                    hd_id = row["HD_ID"].ToString().Trim();
                    LayThongTinHoaDon(hd_id);
                }
            }
            catch (Exception)
            {


            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            TaoMoiHoaDon();
            //try
            //{
            //    if (TTHMessage.ShowMessageConfirm("Bạn có chắc muốn hủy bỏ hóa đơn này?") == DialogResult.Yes)
            //    {
            //        if (XoaHoaDon(hd_id))
            //        {
            //            btnXem_Click(null, null);
            //            TaoMoiHoaDon();
            //        }
            //        else
            //            TTHMessage.ShowMessageError("Không thể xóa hóa đơn này!");
            //    }

            //}
            //catch (Exception)
            //{


            //}
        }

        private void frmBanLe_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisplayBackgroung();
        }

        private void barF2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnLuu_Click(null, null);
        }

        private void barF3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnLuuIn_Click(null, null);
        }

        private void grvBangKe_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle % 2 == 1)
            {
                e.Appearance.BackColor = Color.WhiteSmoke;
            }
            else e.Appearance.BackColor = Color.White;
        }

       

        
       

        
    }
}