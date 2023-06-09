using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MyRMS
{
    public partial class frmDetailedRetail : DevExpress.XtraEditors.XtraForm
    {
        public string hd_id = "";
        DataAccess cls = new DataAccess();
        public frmDetailedRetail()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public DataTable LayDSHoaDonChiTiet(string hd_id)
        {
            string sql = "select HDCT_ID,  HDCT_MH_ID, HDCT_DVT, HDCT_SoLuong,  HDCT_DonGia, HDCT_DonGiaVon, HDCT_ThanhTien, HDCT_InCB, HDCT_ChonXoa from HoaDonChiTiet where HDCT_HD_ID = '" + hd_id + "' order by HDCT_ThuTu";
            return cls.GetDataTable(sql);
        }
        public void LayDSMatHangDropDown()
        {

            string sql = "select MH_ID,MH_Ma,  MH_Ten, MH_DVT, MH_GiaMua, MH_GiaBanLe, MH_TuKhoa from MatHang where MH_KichHoat = 'True' and MH_DV_ID = '" + Info.dv_id + "' order by MH_Ten";
            DataTable dt = cls.GetDataTable(sql);
            rglkuMatHang.DataSource = dt;
            rglkuMatHang.ValueMember = "MH_ID";
            rglkuMatHang.DisplayMember = "MH_Ten";
            rglkuMatHang.PopupFormWidth = 600;
            rglkuvMatHang.BestFitColumns();
        }
        private void frmBanLeChiTiet_Load(object sender, EventArgs e)
        {
            if (hd_id.Length > 0)
            {
                LayDSMatHangDropDown();
                foreach (DataRow dr in cls.GetDataTable("select * from HoaDon where HD_ID = '" + hd_id + "'").Rows)
                {
                    txtKyHieu.Text = dr["HD_KyHieu"].ToString().Trim();
                    dateNgayLap.EditValue = (DateTime)dr["HD_NgayLap"];
                    grcData.DataSource = LayDSHoaDonChiTiet(hd_id);
                    txtTienHang.EditValue = double.Parse(dr["HD_SoTien"].ToString());
                    txtGiamGia.EditValue = double.Parse(dr["HD_GiamGia"].ToString());
                    txtTienGiamGia.EditValue = double.Parse(dr["HD_TienGiamGia"].ToString());
                    txtTongCong.EditValue = double.Parse(dr["HD_SoTienCuoi"].ToString());
                }
            }
        }
        public Boolean XoaHoaDon(string hd_id)
        {
            string sql = "delete HoaDon where HD_ID = '" + hd_id + "'";
            return cls.ExecuteNonQuery(sql);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (TTHMessage.ShowMessageConfirm("Bạn có chắc muốn xóa hóa đơn này không?") == DialogResult.Yes)
                {

                    if (!XoaHoaDon(hd_id))
                        TTHMessage.ShowMessageWarming("Không thể xóa hóa đơn này.");
                    else
                    {
                        TTHMessage.ShowMessageInfomation("Đã xóa thành công.");
                        this.Close();
                    }
                }
            }
            catch (Exception)
            {

                TTHMessage.ShowMessageWarming("Bạn chưa chọn hóa đơn muốn xóa!");
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
                //rpt.SetParameterValue("DT_Ten", glkuDoiTac.Text);
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
        private void btnIn_Click(object sender, EventArgs e)
        {
            InHoaDon(hd_id);
        }
    }
}