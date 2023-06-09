using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MyRMS.NghiepVu
{
    public partial class frmThongKeBanHang : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void LayThongTinHoaDonDelegate(string id);
        public LayThongTinHoaDonDelegate LayThongTinHoaDon;
        public frmThongKeBanHang()
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
        //public void LayDSCaLamViec()
        //{
        //    DataAccess cls = new DataAccess();
        //    string sql = "select CLV_ID, CLV_Ten from CaLamViec";
        //    DataTable dt = cls.GetDataTable(sql);
        //    DataRow dr = dt.NewRow();
        //    dr[0] = "";
        //    dr[1] = "Tất cả";
        //    dt.Rows.InsertAt(dr, 0);

        //    glkuCaLamViec.Properties.DataSource = dt;
        //    glkuCaLamViec.Properties.DisplayMember = "CLV_Ten";
        //    glkuCaLamViec.Properties.ValueMember = "CLV_ID";
        //    glkuCaLamViec.EditValue = Info.clv_id;
        //}
        private void frmThongKeBanHang_Load(object sender, EventArgs e)
        {
            cboTuyChon.Text = "Hôm nay";
            //LayDSCaLamViec();
            btnXem_Click(null, null);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            TTHWait.ShowWait();
            string tungay = ((DateTime)dateTuNgay.EditValue).ToString("dd/MM/yyyy");
            string denngay = ((DateTime)dateDenNgay.EditValue).ToString("dd/MM/yyyy");
            string sql = "";
            sql += "select HD_ID, HD_KyHieu, HD_NgayLap, HD_SoTien, HD_TienGiamGia, HD_SoTienCuoi, HD_GhiChu from HoaDon where  HD_TrangThai = 3  ";
            sql += "and convert(DateTime,convert(varchar(10),HD_NgayLap,103),103) >= convert(datetime, '" + tungay + "',103) and convert(DateTime,convert(varchar(10),HD_NgayLap,103),103) <= convert(datetime, '" + denngay + "',103)    ";
            grcBangKe.DataSource = cls.GetDataTable(sql);
            TTHWait.CloseWait();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (grvBangKe.RowCount == 0) return;
                DataRow row = grvBangKe.GetFocusedDataRow();
                string hd_id = row["HD_ID"].ToString().Trim();
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa dòng được chọn không?", Info.tenphanmem, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!cls.ExecuteNonQuery("delete HoaDon where HD_ID = '" + hd_id + "'"))
                        TTHMessage.ShowMessageWarming("Không thể xóa dòng này!");
                    else
                    {
                        row.Delete();
                        TTHMessage.ShowMessageInfomation("Đã xóa thành công!");
                    }
                }
            }
            catch (Exception)
            {
                TTHMessage.ShowMessageError("Xin chọn dòng muốn xóa!");

            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvBangKe.RowCount == 0) return;
                DataRow row = grvBangKe.GetFocusedDataRow();
                string sql = "select HD_KyHieu, HD_NgayLap, convert(varchar(10), HD_NgayLap,103) + ' ' + convert(varchar(10), HD_NgayLap,108) as HD_ThoiGianLap, HD_ThoiGian, ";
                sql += "N'Ngày ' + case when len(convert(char(2),day(convert(datetime,HD_NgayLap,103)))) = 1 then '0' + convert(char(2),day(convert(datetime,HD_NgayLap,103))) else convert(char(2),day(convert(datetime,HD_NgayLap,103))) end + N' tháng ' + case when len(convert(char(2),month(convert(datetime,HD_NgayLap,103)))) = 1 then '0' + convert(char(2),month(convert(datetime,HD_NgayLap,103))) else convert(char(2),month(convert(datetime,HD_NgayLap,103))) end  + N' năm ' + convert(char(4),year(HD_NgayLap)) as HD_NgayLapchu, ";
                sql += "HD_TienGio,HD_SoTien,HD_GiamGiaGio,HD_TienGiamGiaGio,HD_GiamGia, HD_TienGiamGia, HD_SoTienCuoi, HD_SoTienCuoiChu, HD_KhachDua, HD_TienThua, HD_GhiChu, (select BP_Ten from BanPhong where BP_ID = HD_BP_ID) as HD_TenBan, ";
                sql += "MH_Ten as HDCT_MH_Ten, HDCT_DVT, HDCT_SoLuong, HDCT_DonGia, HDCT_ThanhTien	 ";
                sql += "from ";
                sql += "( ";
                sql += "select HDCT_HD_ID,HDCT_MH_ID,HDCT_DVT, sum(HDCT_SoLuong) as HDCT_SoLuong, HDCT_DonGia, sum(HDCT_SoLuong) * HDCT_DonGia as HDCT_ThanhTien ";
                sql += "from HoaDonChiTiet where HDCT_HD_ID = '" + row["HD_ID"].ToString().Trim() + "' ";
                sql += "group by HDCT_HD_ID,HDCT_MH_ID,HDCT_DVT, HDCT_DonGia ";
                sql += ") temp left join HoaDon on HDCT_HD_ID = HD_ID ";
                sql += "left join MatHang on HDCT_MH_ID = MH_ID ";
                sql += "where HDCT_HD_ID = '" + row["HD_ID"].ToString().Trim() + "' ";
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvBangKe.RowCount == 0) return;
                DataRow row = grvBangKe.GetFocusedDataRow();
                LayThongTinHoaDon(row["HD_ID"].ToString().Trim());
                this.Close();
            }
            catch (Exception ex)
            {
                TTHMessage.ShowMessageError(ex.ToString());

            }
        }

        
    }
}