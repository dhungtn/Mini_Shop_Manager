using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;
namespace MyRMS.BaoCao
{
    public partial class frmBaoCaoDoanhThu : DevExpress.XtraEditors.XtraForm
    {
        public frmBaoCaoDoanhThu()
        {
            InitializeComponent();
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

        private void frmBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            this.Text = Info.tenphanmem;
            rdogrpView.EditValue = "TCT";
            cboTuyChon.Text = "Hôm nay";
            txtNam.Value = DateTime.Now.Year;
            
        }

        private void rdogrpView_EditValueChanged(object sender, EventArgs e)
        {
            //TTHUtils.thongBao(Info.tenphanmem, rdogrpView.EditValue.ToString());
            if (rdogrpView.EditValue.ToString().Trim() == "THTT")
            {
                cboTuyChon.Enabled = false;
                dateTuNgay.Enabled = false;
                dateDenNgay.Enabled = false;
                txtNam.Enabled = true;
            }
            else
            {
                if (cboTuyChon.Text == "Tùy chọn")
                {
                    cboTuyChon.Enabled = true;
                    dateTuNgay.Enabled = true;
                    dateDenNgay.Enabled = true;
                }
                else
                {
                    cboTuyChon.Enabled = true;
                    dateTuNgay.Enabled = false;
                    dateDenNgay.Enabled = false;
                }
                txtNam.Enabled = false;
            }
        }
        public void LayDoanhThuTheoChungTu()
        {
            WaitDialogForm dg = new WaitDialogForm("Xin chờ trong giây lát!", "Đang xử lý...");
            try
            {
               
                string tungay = ((DateTime)dateTuNgay.EditValue).ToString("dd/MM/yyyy");
                string denngay = ((DateTime)dateDenNgay.EditValue).ToString("dd/MM/yyyy");
                string khoangthoigian = "Từ ngày " + tungay + " đến ngày " + denngay;
                if (tungay == denngay) khoangthoigian = "Ngày " + tungay;
                string sql = "";
                sql += "select HD_KyHieu, convert(varchar(10), HD_NgayLap,103) as HD_Ngay, convert(varchar(10), HD_NgayLap,108) as HD_ThoiGian, HD_SoTien as HD_TienHang, HD_TienGiamGia, HD_SoTienCuoi as HD_TongCong, HD_GhiChu,  ";
                sql += "(select sum (HDCT_SoLuong * HDCT_DonGiaVon) from HoaDonChiTiet where HDCT_HD_ID = a.HD_ID) as HD_TienVon,  ";
                sql += "HD_SoTienCuoi - (select sum (HDCT_SoLuong * HDCT_DonGiaVon) from HoaDonChiTiet where HDCT_HD_ID = a.HD_ID) as HD_ChenhLech  ";
                sql += "from HoaDon a where HD_Loai = 'XHB' and HD_TrangThai = 3 and HD_DV_ID = '" + Info.dv_id + "'   ";
                sql += "and convert(DateTime,convert(varchar(10),HD_NgayLap,103),103) >= convert(datetime, '" + tungay + "',103) and convert(DateTime,convert(varchar(10),HD_NgayLap,103),103) <= convert(datetime, '" + denngay + "',103)      ";
                sql += "order by HD_NgayLap  ";
                DataAccess cls = new DataAccess();
                FastReport.Report rpt = new FastReport.Report();
                rpt.Load(Application.StartupPath + "\\report\\BaoCaoDoanhThuTheoChungTu.frx");
                rpt.RegisterData(cls.GetDataTable(sql), "Table");
                rpt.SetParameterValue("tendoanhnghiep", Info.dv_ten);
                rpt.SetParameterValue("diachidoanhnghiep", Info.dv_diachi);
                rpt.SetParameterValue("dienthoaidoanhnghiep", Info.dv_dienthoai);
                rpt.SetParameterValue("khoangthoigian", khoangthoigian);
                dg.Close();
                rpt.Show();
            }
            catch (Exception ex)
            {
                dg.Close();
                TTHMessage.ShowMessageError(ex.ToString());
            }
            
        }
        public void LayDoanhThuTheoKhuVuc()
        {
            WaitDialogForm dg = new WaitDialogForm("Xin chờ trong giây lát!", "Đang xử lý...");
            try
            {

                string tungay = ((DateTime)dateTuNgay.EditValue).ToString("dd/MM/yyyy");
                string denngay = ((DateTime)dateDenNgay.EditValue).ToString("dd/MM/yyyy");
                string khoangthoigian = "Từ ngày " + tungay + " đến ngày " + denngay;
                if (tungay == denngay) khoangthoigian = "Ngày " + tungay;
                string sql = "";
                sql += "select KV_Ten, HD_KyHieu, convert(varchar(10), HD_NgayLap,103) as HD_Ngay, convert(varchar(10), HD_NgayLap,108) as HD_ThoiGian, HD_SoTien as HD_TienHang, HD_TienGiamGia, HD_SoTienCuoi as HD_TongCong, HD_GhiChu,  ";
                sql += "(select sum (HDCT_SoLuong * HDCT_DonGiaVon) from HoaDonChiTiet where HDCT_HD_ID = a.HD_ID) as HD_TienVon,  ";
                sql += "HD_SoTienCuoi - (select sum (HDCT_SoLuong * HDCT_DonGiaVon) from HoaDonChiTiet where HDCT_HD_ID = a.HD_ID) as HD_ChenhLech  ";
                sql += "from HoaDon a left join BanPhong b on a.HD_BP_ID = b.BP_ID left join KhuVuc c on b.BP_KV_ID = c.KV_ID where  HD_Loai = 'XHB' and HD_TrangThai = 3 and HD_DV_ID = '" + Info.dv_id + "'   ";
                sql += "and convert(DateTime,convert(varchar(10),HD_NgayLap,103),103) >= convert(datetime, '" + tungay + "',103) and convert(DateTime,convert(varchar(10),HD_NgayLap,103),103) <= convert(datetime, '" + denngay + "',103)      ";
                sql += "order by HD_NgayLap  ";
                DataAccess cls = new DataAccess();
                FastReport.Report rpt = new FastReport.Report();
                rpt.Load(Application.StartupPath + "\\report\\BaoCaoDoanhThuTheoKhuVuc.frx");
                rpt.RegisterData(cls.GetDataTable(sql), "Table");
                rpt.SetParameterValue("tendoanhnghiep", Info.dv_ten);
                rpt.SetParameterValue("diachidoanhnghiep", Info.dv_diachi);
                rpt.SetParameterValue("dienthoaidoanhnghiep", Info.dv_dienthoai);
                rpt.SetParameterValue("khoangthoigian", khoangthoigian);
                dg.Close();
                rpt.Show();
            }
            catch (Exception ex)
            {
                dg.Close();
                TTHMessage.ShowMessageError(ex.ToString());
            }

        }
        public void LayDoanhThuTheoHangHoa()
        {
            WaitDialogForm dg = new WaitDialogForm("Xin chờ trong giây lát!", "Đang xử lý...");
            string tungay = ((DateTime)dateTuNgay.EditValue).ToString("dd/MM/yyyy");
            string denngay = ((DateTime)dateDenNgay.EditValue).ToString("dd/MM/yyyy");
            string khoangthoigian = "Từ ngày " + tungay + " đến ngày " + denngay;
            if (tungay == denngay) khoangthoigian = "Ngày " + tungay;
            string sql = "";
            sql += "select LH_Ten,MH_Ten, MH_DVT as MH_DonVi, isnull(MH_SoLuong,0) as MH_SoLuong,isnull(MH_TongCong,0) as MH_TongCong, isnull(MH_TienVon,0) as MH_TienVon,  isnull(MH_ChenhLech,0) as MH_ChenhLech ";
            sql += "from  ";
            sql += "( ";
            sql += "select MH_ID, MH_Ten, MH_DVT, MH_LH_ID from MatHang where MH_DV_ID = '" + Info.dv_id + "' ";
            sql += ") temp left join ";
            sql += "( ";
            sql += "select HDCT_MH_ID, sum(HDCT_SoLuong) as MH_SoLuong, sum(HDCT_ThanhTien * (1 - HD_GiamGia * 0.01)) as MH_TongCong, sum(HDCT_SoLuong * HDCT_DonGiaVon) as MH_TienVon,sum(HDCT_ThanhTien * (1 - HD_GiamGia * 0.01)) - sum(HDCT_SoLuong * HDCT_DonGiaVon) as MH_ChenhLech ";
            sql += "from HoaDon a left join HoaDonChiTiet b on a.HD_ID = b.HDCT_HD_ID ";
            sql += "where HD_Loai = 'XHB' and HD_TrangThai = 3 and HD_DV_ID = '" + Info.dv_id + "'  ";
            sql += "and convert(DateTime,convert(varchar(10),HD_NgayLap,103),103) >= convert(datetime, '" + tungay + "',103) and convert(DateTime,convert(varchar(10),HD_NgayLap,103),103) <= convert(datetime, '" + denngay + "',103)     ";
            sql += "group by HDCT_MH_ID  ";
            sql += ") temp1 on temp.MH_ID = temp1.HDCT_MH_ID left join  ";
            sql += "( ";
            sql += "select LH_ID, LH_Ten from LoaiHang where LH_DV_ID = '" + Info.dv_id + "'  ";
            sql += ") temp2 on temp.MH_LH_ID = temp2.LH_ID ";
            sql += "where MH_SoLuong > 0 ";
            sql += "order by LH_Ten, MH_Ten ";
            DataAccess cls = new DataAccess();
            FastReport.Report rpt = new FastReport.Report();
            rpt.Load(Application.StartupPath + "\\report\\BaoCaoDoanhThuTheoMatHang.frx");
            rpt.RegisterData(cls.GetDataTable(sql), "Table");
            rpt.SetParameterValue("tendoanhnghiep", Info.dv_ten);
            rpt.SetParameterValue("diachidoanhnghiep", Info.dv_diachi);
            rpt.SetParameterValue("dienthoaidoanhnghiep", Info.dv_dienthoai);
            rpt.SetParameterValue("khoangthoigian", khoangthoigian);
            dg.Close();
            rpt.Show();
        }
        public void LayDoanhThuTongHopTheoThang()
        {
            WaitDialogForm dg = new WaitDialogForm("Xin chờ trong giây lát!", "Đang xử lý...");
            string sql = "";
            sql += "select year(HD_NgayLap) as Nam, month(HD_NgayLap) as Thang, sum(HD_TongCong) as DoanhSo, sum(HD_ChenhLech) as ChenhLech ";
            sql += "from ";
            sql += "( ";
            sql += "select HD_KyHieu, HD_NgayLap, HD_SoTienCuoi as HD_TongCong,  ";
            sql += "HD_SoTienCuoi - (select sum (HDCT_SoLuong * HDCT_DonGiaVon) from HoaDonChiTiet where HDCT_HD_ID = a.HD_ID) as HD_ChenhLech ";
            sql += "from HoaDon a where HD_TrangThai = 3 and HD_DV_ID = '" + Info.dv_id + "'  ";
            sql += ") temp ";
            sql += "where year(HD_NgayLap) = " + double.Parse(txtNam.EditValue.ToString()) + " ";
            sql += "group by year(HD_NgayLap),month(HD_NgayLap) ";
            sql += "order by year(HD_NgayLap),month(HD_NgayLap) ";
            DataAccess cls = new DataAccess();
            FastReport.Report rpt = new FastReport.Report();
            rpt.Load(Application.StartupPath + "\\report\\BaoCaoDoanhThuTongHopTheoThang.frx");
            rpt.RegisterData(cls.GetDataTable(sql), "Table");
            rpt.SetParameterValue("tendoanhnghiep", Info.dv_ten);
            rpt.SetParameterValue("diachidoanhnghiep", Info.dv_diachi);
            rpt.SetParameterValue("dienthoaidoanhnghiep", Info.dv_dienthoai);
            rpt.SetParameterValue("nam", txtNam.EditValue.ToString());
            dg.Close();
            rpt.Show();
        }
        private void btnDongY_Click(object sender, EventArgs e)
        {
            //WaitDialogForm dg = new WaitDialogForm("Đang load dữ liệu...", "Xin chờ trong giây lát!");
           
            if (rdogrpView.EditValue.ToString().Trim() == "TCT")
            {
                //frmProgress frm = new frmProgress();
                //frm.ShowProgressBar = new frmProgress.ProgressDelegate(LayDoanhThuTheoChungTu);
                //frm.ShowDialog();
                LayDoanhThuTheoChungTu();
            }
            if (rdogrpView.EditValue.ToString().Trim() == "TKV")
            {
                //frmProgress frm = new frmProgress();
                //frm.ShowProgressBar = new frmProgress.ProgressDelegate(LayDoanhThuTheoChungTu);
                //frm.ShowDialog();
                LayDoanhThuTheoKhuVuc();
            }
            if (rdogrpView.EditValue.ToString().Trim() == "THH")
            {
                //frmProgress frm = new frmProgress();
                //frm.ShowProgressBar = new frmProgress.ProgressDelegate(LayDoanhThuTheoHangHoa);
                //frm.ShowDialog();
                LayDoanhThuTheoHangHoa();
            }
            if (rdogrpView.EditValue.ToString().Trim() == "THTT")
            {
                //frmProgress frm = new frmProgress();
                //frm.ShowProgressBar = new frmProgress.ProgressDelegate(LayDoanhThuTongHopTheoThang);
                //frm.ShowDialog();
                LayDoanhThuTongHopTheoThang();
            }
        }
    }
}