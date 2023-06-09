using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MyRMS.DanhMuc;
namespace MyRMS.NghiepVu
{
    public partial class frmBanHang : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public string hd_id = "";
        public string lh_id = "";
        public frmBanHang()
        {
            InitializeComponent();
        }
        public double LayTrangThaiBanPhong(string bp_id)
        {
            string sql = "select BP_TrangThai from BanPhong ";
            sql += "where BP_ID = '" + bp_id + "' ";
            return cls.GetNumberValue(sql);
        }
        public Boolean CapNhapTrangThaiBanPhong(string bp_id, double bp_trangthai)
        {
            string sql = "update BanPhong set BP_TrangThai = " + bp_trangthai + " ";
            sql += "where BP_ID = '" + bp_id + "' ";
            return cls.ExecuteNonQueryTrans(sql);
        }

        
        public Boolean ThemHoaDon(string hd_id, string hd_kyhieu, DateTime hd_ngaylap, double hd_sotien, double hd_giamgia, double tiengiamgia, double hd_tiengio, double hd_giamgiagio, double hd_tiengiamgiagio, double hd_sotiencuoi, string hd_sotiencuoichu, double hd_thanhtoan, string hd_ghichu, string hd_thutu, double hd_trangthai, Boolean hd_daxoa, string hd_dv_id, string hd_bp_id,  string hd_nd_id, string hd_loai, DateTime hd_batdau, string hd_dt_id, Boolean hd_datinhgio)
        {
            string[] field = { "HD_ID", "HD_KyHieu", "HD_NgayLap", "HD_SoTien", "HD_GiamGia", "HD_TienGiamGia", "HD_TienGio", "HD_GiamGiaGio", "HD_TienGiamGiaGio", "HD_SoTienCuoi", "HD_SoTienCuoiChu", "HD_ThanhToan", "HD_GhiChu", "HD_ThuTu", "HD_TrangThai", "HD_DaXoa", "HD_DV_ID", "HD_BP_ID",  "HD_ND_ID", "HD_Loai", "HD_GioVao", "HD_DT_ID", "HD_DaTinhGio", "HD_CLV_ID" };
            object[] value = { (object)hd_id, (object)hd_kyhieu, (object)hd_ngaylap, (object)hd_sotien, (object)hd_giamgia, (object)tiengiamgia, (object)hd_tiengio, (object)hd_giamgiagio, (object)hd_tiengiamgiagio, (object)hd_sotiencuoi, (object)hd_sotiencuoichu, (object)hd_thanhtoan, (object)hd_ghichu, (object)hd_thutu, (object)hd_trangthai, (object)hd_daxoa, (object)hd_dv_id, (object)hd_bp_id, (object)hd_nd_id, (object)hd_loai, (object)hd_batdau, (object)hd_dt_id, (object)hd_datinhgio, (object)Info.clv_id };
            return cls.AddRecordTrans("HoaDon", field, value);
        }
        public Boolean SuaHoaDon(string hd_id, string hd_kyhieu, DateTime hd_ngaylap, double hd_sotien, double hd_giamgia, double tiengiamgia,  double hd_sotiencuoi, string hd_sotiencuoichu,  string hd_ghichu, string hd_thutu,  string hd_bp_id,  string hd_loai, string hd_dt_id, double hd_khachdua, double hd_tienthua)
        {
            string[] field = { "HD_KyHieu", "HD_NgayLap", "HD_SoTien", "HD_GiamGia", "HD_TienGiamGia", "HD_SoTienCuoi", "HD_SoTienCuoiChu", "HD_GhiChu", "HD_ThuTu",  "HD_BP_ID",  "HD_Loai", "HD_DT_ID", "HD_KhachDua", "HD_TienThua" };
            object[] value = { (object)hd_kyhieu, (object)hd_ngaylap, (object)hd_sotien, (object)hd_giamgia, (object)tiengiamgia,  (object)hd_sotiencuoi, (object)hd_sotiencuoichu,  (object)hd_ghichu, (object)hd_thutu,  (object)hd_bp_id,   (object)hd_loai, (object)hd_dt_id, (object)hd_khachdua, (object)hd_tienthua};
            string[] fieldwhere = { "HD_ID"};
            object[] valuewhere = { (object)hd_id };
            return cls.EditRecord("HoaDon", field, value, fieldwhere, valuewhere);
        }
        public Boolean SuaHoaDonTrans(string hd_id, string hd_kyhieu, DateTime hd_ngaylap, double hd_sotien, double hd_giamgia, double tiengiamgia, double hd_sotiencuoi, string hd_sotiencuoichu, string hd_ghichu, string hd_thutu, string hd_bp_id, string hd_loai, string hd_dt_id, double hd_trangthai, double hd_khachdua, double hd_tienthua)
        {
            string[] field = { "HD_KyHieu", "HD_NgayLap", "HD_SoTien", "HD_GiamGia", "HD_TienGiamGia", "HD_SoTienCuoi", "HD_SoTienCuoiChu", "HD_GhiChu", "HD_ThuTu", "HD_BP_ID", "HD_Loai", "HD_DT_ID", "HD_TrangThai", "HD_KhachDua", "HD_TienThua" };
            object[] value = { (object)hd_kyhieu, (object)hd_ngaylap, (object)hd_sotien, (object)hd_giamgia, (object)tiengiamgia, (object)hd_sotiencuoi, (object)hd_sotiencuoichu, (object)hd_ghichu, (object)hd_thutu, (object)hd_bp_id, (object)hd_loai, (object)hd_dt_id, (object)hd_trangthai, (object)hd_khachdua, (object)hd_tienthua };
            string[] fieldwhere = { "HD_ID" };
            object[] valuewhere = { (object)hd_id };
            return cls.EditRecordTrans("HoaDon", field, value, fieldwhere, valuewhere);
        }
        public Boolean XoaHoaDon(string hd_id)
        {
            string sql = "delete HoaDon where HD_ID = '" + hd_id + "'";
            return cls.ExecuteNonQueryTrans(sql);
        }
        public void LayThongTinHoaDon(string hd_id)
        {
            string sql = "select * from HoaDon where HD_ID = '" + hd_id + "'";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                txtKyHieu.Text = dr["HD_KyHieu"].ToString();
                dateNgayLap.EditValue = (DateTime)dr["HD_NgayLap"];
                
                glkuDoiTac.EditValue = dr["HD_DT_ID"].ToString();
                txtGhiChu.Text = dr["HD_GhiChu"].ToString().Trim();
                grcHoaDonChiTiet.DataSource = LayDSHoaDonChiTiet(hd_id);
                
                txtTienHang.EditValue = double.Parse(dr["HD_SoTien"].ToString());
                cboGiamGia.Text = dr["HD_GiamGia"].ToString();
                txtTienGiamGia.EditValue = double.Parse(dr["HD_TienGiamGia"].ToString());
                txtTongCong.EditValue = double.Parse(dr["HD_SoTienCuoi"].ToString());
                //txtKhachDua.EditValue = double.Parse(dr["HD_KhachDua"].ToString());
                
                //txtTienThua.EditValue = double.Parse(dr["HD_TienThua"].ToString());
            }
        }
        public Boolean ThemHoaDonChiTiet(string hdct_id, string hdct_hd_id, string hdct_mh_id, string hdct_dvt, double hdct_soluong, double hdct_dongia, double hdct_dongiavon, double hdct_thanhtien, string hdct_thutu, Boolean hdct_incb, Boolean hdct_chonxoa, DateTime hdct_ngaylap, string hdct_loai)
        {
            DataAccess cls = new DataAccess();
            string[] field = { "HDCT_ID", "HDCT_HD_ID", "HDCT_MH_ID", "HDCT_DVT", "HDCT_SoLuong", "HDCT_DonGia", "HDCT_DonGiaVon", "HDCT_ThanhTien", "HDCT_ThuTu", "HDCT_DV_ID", "HDCT_InCB", "HDCT_ChonXoa", "HDCT_NgayLap", "HDCT_Loai" };
            object[] obj = { (object)hdct_id, (object)hdct_hd_id, (object)hdct_mh_id, (object)hdct_dvt, (object)hdct_soluong, (object)hdct_dongia, (object)hdct_dongiavon, (object)hdct_thanhtien, (object)hdct_thutu, (object)Info.dv_id, (object)hdct_incb, (object)hdct_chonxoa, (object)hdct_ngaylap, (object)hdct_loai };
            return cls.AddRecord("HoaDonChiTiet", field, obj);
        }
        public DataTable LayDSHoaDonChiTiet(string hd_id)
        {
            string sql = "select HDCT_ID,  HDCT_MH_ID, HDCT_DVT, HDCT_SoLuong,  HDCT_DonGia, HDCT_DonGiaVon, HDCT_ThanhTien, HDCT_InCB, HDCT_ChonXoa from HoaDonChiTiet where HDCT_HD_ID = '" + hd_id + "' order by HDCT_ThuTu";
            return cls.GetDataTable(sql);
        }
        public void TaoSoHoaDon()
        {
            hd_id = ((DateTime)dateNgayLap.EditValue).ToString("yyMMddHHmmss");
            string sql = "select distinct max(right(HD_KyHieu,4)) from HoaDon where HD_DV_ID = '" + Info.dv_id + "' and convert(varchar(10),HD_NgayLap, 103) = '" + ((DateTime)dateNgayLap.EditValue).ToString("dd/MM/yyyy") + "'";
            txtKyHieu.EditValue = "XBL" + ((DateTime)dateNgayLap.EditValue).ToString("yyMMdd") + "-" + string.Format("{0,4:0000}", cls.GetNumberValue(sql) + 1);
        }
        public void LayDSDoiTac()
        {
            string sql = "select DT_ID, DT_Ten, DT_DiaChi, DT_DienThoai, DT_Email from DoiTac ";
            sql += "where DT_Loai = 'KH' ";
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
        public void LayDSLoaiHang()
        {
            DataAccess cls = new DataAccess();
            lvLoaiHang.Clear();
            lvLoaiHang.GridLines = true;
            lvLoaiHang.Columns.Add("Tên", lvLoaiHang.Size.Width - 4, 0);
            lvLoaiHang.Columns.Add("ID", 0, 0);
            ListViewItem lvi;
            string sql = "select LH_ID, LH_Ten, LH_HinhAnh from LoaiHang ";
            sql += "where LH_KichHoat = 'True' and LH_DV_ID = '" + Info.dv_id + "' ";
            sql += "order by LH_Ten ";
            //sql += "where LH_ID in (select distinct MH_LH_ID from MatHang where MH_TrangThai = 'true'  )";
            DataTable dt = cls.GetDataTable(sql);
            imgLoaiHang.Images.Clear();
            if (dt.Rows.Count > 0)
            {
                imgLoaiHang.Images.Add(Image.FromFile(Application.StartupPath + "\\icon\\tatca.png"));
                foreach (DataRow dr in dt.Rows)
                {
                    System.IO.MemoryStream imgStream = new System.IO.MemoryStream((byte[])dr["LH_HinhAnh"], 0, ((byte[])dr["LH_HinhAnh"]).Length);
                    imgStream.Write((byte[])dr["LH_HinhAnh"], 0, ((byte[])dr["LH_HinhAnh"]).Length);
                    imgLoaiHang.Images.Add(Image.FromStream(imgStream, true));
                }
                //if (kieuhienthi == 1)
                //{
                    lvLoaiHang.SmallImageList = imgLoaiHang;
                    lvLoaiHang.View = View.Details;
                //}
                //else if (kieuhienthi == 2)
                //{
                //    lvLoaiHang.LargeImageList = imgLoaiHang;
                //    lvLoaiHang.View = View.LargeIcon;
                //}
                //else if (kieuhienthi == 3)
                //{
                //    lvLoaiHang.SmallImageList = imgLoaiHang;
                //    lvLoaiHang.View = View.List;
                //}
                //else if (kieuhienthi == 4)
                //{
                //    lvLoaiHang.SmallImageList = imgLoaiHang;
                //    lvLoaiHang.View = View.SmallIcon;
                //}
                //else
                //{
                //    lvLoaiHang.SmallImageList = imgLoaiHang;
                //    lvLoaiHang.View = View.Tile;
                //}
                DataRow row = dt.NewRow();
                row[0] = "";
                row[1] = "Tất cả";
                dt.Rows.InsertAt(row, 0);
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    lvi = new ListViewItem(dr["LH_Ten"].ToString().Trim(), i);
                    lvi.SubItems.Add(dr["LH_ID"].ToString().Trim());
                    lvLoaiHang.Items.Add(lvi);
                    i = i + 1;
                }
                lvLoaiHang.Items[0].Focused = true;
                lvLoaiHang.Items[0].Selected = true;
                lh_id = lvLoaiHang.Items[0].SubItems[1].Text.Trim();
                LayDSMatHangTheoLoaiHang(1);
            }

        }
        public void LayDSMatHangTheoLoaiHang(int kieuhienthi)
        {
            DataAccess cls = new DataAccess();
            lvMatHang.Clear();
            lvMatHang.GridLines = true;
            lvMatHang.Columns.Add("Tên", 190, 0);
            lvMatHang.Columns.Add("Mã", 0, 0);
            lvMatHang.Columns.Add("ĐVT", 40, 0);
            lvMatHang.Columns.Add("Đơn giá", 60, 0);
            lvMatHang.Columns.Add("ID", 0, 0);
            ListViewItem lvi;
            string sql = "";
            if (lh_id.Length > 0)
                sql = "select MH_ID,MH_Ma,MH_Ten,MH_DVT,MH_GiaBanLe,MH_HinhAnh from MatHang where  MH_TuKhoa like N'%" + TTHUtils.LoaiBoDauTiengViet(btneMatHang.Text.Trim()) + "%' and   MH_KichHoat = 'true' and MH_LH_ID = '" + lh_id + "' and MH_DV_ID = '" + Info.dv_id + "'  order by MH_Ten";
            else sql = "select MH_ID,MH_Ma,MH_Ten,MH_DVT,MH_GiaBanLe,MH_HinhAnh from MatHang where  MH_TuKhoa like N'%" + TTHUtils.LoaiBoDauTiengViet(btneMatHang.Text.Trim()) + "%' and   MH_KichHoat = 'true' and MH_DV_ID = '" + Info.dv_id + "'  order by MH_Ten";
            DataTable dt = cls.GetDataTable(sql);
            imgMatHang.Images.Clear();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    System.IO.MemoryStream imgStream = new System.IO.MemoryStream((byte[])dr["MH_HinhAnh"], 0, ((byte[])dr["MH_HinhAnh"]).Length);
                    imgStream.Write((byte[])dr["MH_HinhAnh"], 0, ((byte[])dr["MH_HinhAnh"]).Length);
                    imgMatHang.Images.Add(Image.FromStream(imgStream, true));
                }
                if (kieuhienthi == 1)
                {
                    lvMatHang.SmallImageList = imgMatHang;
                    lvMatHang.View = View.Details;
                }
                else if (kieuhienthi == 2)
                {
                    lvMatHang.LargeImageList = imgMatHang;
                    lvMatHang.View = View.LargeIcon;
                }
                else if (kieuhienthi == 3)
                {
                    lvMatHang.SmallImageList = imgMatHang;
                    lvMatHang.View = View.List;

                }
                else if (kieuhienthi == 4)
                {
                    lvMatHang.SmallImageList = imgMatHang;
                    lvMatHang.View = View.SmallIcon;
                }
                else
                {
                    lvMatHang.SmallImageList = imgMatHang;
                    lvMatHang.View = View.Tile;
                }
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    lvi = new ListViewItem(dr["MH_Ten"].ToString().Trim(), i);
                    lvi.SubItems.Add(dr["MH_Ma"].ToString().Trim());
                    lvi.SubItems.Add(dr["MH_DVT"].ToString().Trim());
                    lvi.SubItems.Add(string.Format("{0:0,#}", double.Parse(dr["MH_GiaBanLe"].ToString())));
                    lvi.SubItems.Add(dr["MH_ID"].ToString().Trim());
                    lvMatHang.Items.Add(lvi);
                    i = i + 1;
                }
                lvMatHang.Items[0].Focused = true;
                lvMatHang.Items[0].Selected = true;
            }

        }
        public void LayDSMatHangDropDown()
        {
            DataAccess cls = new DataAccess();
            string sql = "select MH_ID,  MH_Ten from MatHang where MH_KichHoat = 'True' and MH_DV_ID = '" + Info.dv_id + "' order by MH_Ten";
            rglkuMatHang.DataSource = cls.GetDataTable(sql);
            rglkuMatHang.ValueMember = "MH_ID";
            rglkuMatHang.DisplayMember = "MH_Ten";
            rglkuMatHang.PopupFormWidth = 600;
            rglkuvMatHang.BestFitColumns();
        }
        private void frmBanHang_Load(object sender, EventArgs e)
        {
            LayDSMatHangDropDown();
            LayDSCaLamViec();
            LayDSDoiTac();
            glkuDoiTac.EditValue = Info.dt_id;
            LayDSNguoiDung();
            glkuNhanVien.EditValue = Info.nd_id;
            LayDSLoaiHang();
            dateNgayLap.EditValue = DateTime.Now;
            TaoSoHoaDon();
            grpHoaDon.Enabled = false;
        }
        
        public void TinhTong()
        {
            txtTienHang.EditValue = double.Parse(grvHoaDonChiTiet.Columns["HDCT_ThanhTien"].SummaryText);
            txtTienGiamGia.EditValue = 0.01 * double.Parse(cboGiamGia.Text) * double.Parse(txtTienHang.EditValue.ToString());
            txtTongCong.EditValue = double.Parse(txtTienHang.EditValue.ToString()) - double.Parse(txtTienGiamGia.EditValue.ToString());
            //if (double.Parse(txtKhachDua.EditValue.ToString()) > double.Parse(txtTongCong.EditValue.ToString()))
            //{
            //    txtTienThua.EditValue = double.Parse(txtKhachDua.EditValue.ToString()) - double.Parse(txtTongCong.EditValue.ToString());
            //}
            //else txtTienThua.EditValue = 0;
        }
        
        public string LayHD_IDChuaThanhToan(string bp_id)
        {
            string sql = "select top 1 HD_ID from HoaDon ";
            sql += "where (HD_TrangThai = 1 or HD_TrangThai = 2) and HD_BP_ID = '" + bp_id + "'";// and HD_BP_ID in (select BP_ID from BanPhong where BP_ID = '" + bp_id + "' and  BP_TrangThai = " + bp_trangthai + ") ";
            return cls.GetStringValue(sql);
        }
       
        public Boolean XoaHoaDonChiTiet(string id)
        {
            string sql = "delete HoaDonChiTiet where HDCT_HD_ID = '" + id + "'";
            return cls.ExecuteNonQueryTrans(sql);
        }
        private void btnHuyBan_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Xoa", "barBanHang"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            try
            {
                if (TTHMessage.ShowMessageConfirm("Bạn có chắc muốn hủy bàn này không?") == DialogResult.Yes)
                {

                    DataAccessStatic.sqltrans = DataAccessStatic.conn.BeginTransaction();
                    Boolean ok = true;
                    ok = XoaHoaDon(hd_id);
                    if (ok) ok = XoaHoaDonChiTiet(hd_id);
                    if (ok)
                    {
                        DataAccessStatic.sqltrans.Commit();
                        TTHMessage.ShowMessageInfomation("Đã hủy thành công!");
                    }
                    else
                    {
                        DataAccessStatic.sqltrans.Rollback();
                        TTHMessage.ShowMessageWarming("Không thể hủy bàn này!");
                    }
                }
            }
            catch (Exception)
            {

                //DataAccessStatic.sqltrans.Rollback();
            }
        }

        
        private void btnInBill_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_In", "barBanHang"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            
        }
        private void btnThuTien_Click(object sender, EventArgs e)
        {
            
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
                rpt.SetParameterValue("DT_Ten", glkuDoiTac.Text);
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
                TTHMessage.ShowMessageError( ex.ToString());

            }

        }
        




        
        private void timer1_Tick(object sender, EventArgs e)
        {
            //timeKetThuc.EditValue = DateTime.Now;
            //TinhGio();
        }

        private void btnDongLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        //private void btnBatDau_Click(object sender, EventArgs e)
        //{
        //    TinhGio();
        //    txtTienGio.EditValue = System.Math.Round(phut * dongiagio / 60, 0) + phikhoitao;
        //    string[] field = { "HD_GioVao", "HD_ThoiGian" };
        //    object[] value = { (object)((DateTime)timeBatDau.EditValue), (object)thoigian };
        //    string[] fieldwhere = { "HD_ID" };
        //    object[] valuewhere = { (object)hd_id };
        //    cls.EditRecord("HoaDon", field, value, fieldwhere, valuewhere);
        //    TinhTong();
        //    //if (cls.EditRecord("HoaDon", field, value, fieldwhere, valuewhere))
        //    //    TinhGio();
        //}

        //private void btnKetThuc_Click(object sender, EventArgs e)
        //{
        //    TinhGio();
        //    txtTienGio.EditValue = System.Math.Round(phut * dongiagio / 60, 0) + phikhoitao;
        //    string[] field = { "HD_GioRa", "HD_ThoiGian" };
        //    object[] value = { (object)((DateTime)timeKetThuc.EditValue), (object)thoigian };
        //    string[] fieldwhere = { "HD_ID" };
        //    object[] valuewhere = { (object)hd_id };
        //    cls.EditRecord("HoaDon", field, value, fieldwhere, valuewhere);
        //    TinhTong();
        //}

        private void lvLoaiHang_Click(object sender, EventArgs e)
        {
            try
            {
                //btneMatHang.Text = "";
                //btneLoaiHang.Text = "";
                ListViewItem lvi = lvLoaiHang.FocusedItem;
                lh_id = lvi.SubItems[1].Text.Trim();
               
                LayDSMatHangTheoLoaiHang(1);
            }
            catch (Exception)
            {

            }
        }
        //public void AddHoaDonChiTiet(string hdct_mh_id, string hdct_donvi, double hdct_soluong, double hdct_dongia, double hdct_dongiavon, double hdct_thanhtien)
        //{
            
        //    if (hd_trangthai == 1 || hd_trangthai == 2)
        //    {
                
        //        SuaHoaDon();
        //    }
        //}
        
        public void SetDonGia(string idct, double dongiamoi, double dongiavonmoi)
        {
            int vitri = grvHoaDonChiTiet.FocusedRowHandle;
            DataRow row = grvHoaDonChiTiet.GetFocusedDataRow();
            double thanhtien = double.Parse(row["HDCT_SoLuong"].ToString()) * dongiamoi;
            string sql = "update HoaDonChiTiet set HDCT_ID = '" + idct + "', HDCT_DonGia = " + dongiamoi + ", ";
            sql += "HDCT_DonGiaVon = " + dongiavonmoi + ", HDCT_ThanhTien = " + thanhtien + " ";
            sql += "where HDCT_ID = '" + idct + "' ";
            cls.ExecuteNonQuery(sql);
            grcHoaDonChiTiet.DataSource = LayDSHoaDonChiTiet(hd_id);
            grvHoaDonChiTiet.FocusedRowHandle = vitri;
            TinhTong();
        }
        public void SetSoLuong(string idct, double soluong)
        {
            int vitri = grvHoaDonChiTiet.FocusedRowHandle;
            DataRow row = grvHoaDonChiTiet.GetFocusedDataRow();
            double thanhtien = double.Parse(row["HDCT_DonGia"].ToString()) * soluong;
            string sql = "update HoaDonChiTiet set HDCT_ID = '" + idct + "', HDCT_SoLuong = " + soluong + ", ";
            sql += "HDCT_ThanhTien = " + thanhtien + " ";
            sql += "where HDCT_ID = '" + idct + "' ";
            cls.ExecuteNonQuery(sql);
            grcHoaDonChiTiet.DataSource = LayDSHoaDonChiTiet(hd_id);
            grvHoaDonChiTiet.FocusedRowHandle = vitri;
            TinhTong();
        }
        private void grvHoaDonChiTiet_Click(object sender, EventArgs e)
        {
            if (grvHoaDonChiTiet.RowCount == 0) return;
           
            try
            {
                string col = grvHoaDonChiTiet.FocusedColumn.FieldName.ToString();
                if (col == "HDCT_DonGia")
                {
                    if (Info.suadongia)
                    {
                        frmUpdateDonGia frm = new frmUpdateDonGia();
                        DataRow row = grvHoaDonChiTiet.GetFocusedDataRow();
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
                        DataRow row = grvHoaDonChiTiet.GetFocusedDataRow();
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

        

        private void cboGiamGiaGio_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhTong();
        }

        private void cboGiamGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhTong();
        }

        

        private void rchkXoa_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Xoa", "barBanHang"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            
            DataRow row = grvHoaDonChiTiet.GetFocusedDataRow();
            if (cls.ExecuteNonQuery("delete HoaDonChiTiet where HDCT_ID = '" + row["HDCT_ID"].ToString().Trim() + "'"))
                row.Delete();
            TinhTong();
        }

        
        //public void LayDSDoiTac()
        //{
        //    string sql = "select DT_ID, DT_Ten, DT_DiaChi, DT_DienThoai, DT_Email from DoiTac ";
        //    sql += "where DT_Loai = 'KH' and DT_DV_ID = '" + Info.dv_id + "' ";
        //    sql += "order by DT_Ten ";
        //    DataTable dt = cls.GetDataTable(sql);
        //    DataRow dr = dt.NewRow();
        //    dr[0] = dr[1] = dr[2] = dr[3] = dr[4] = "";
        //    dt.Rows.InsertAt(dr, 0);
        //    glkuDoiTac.Properties.DataSource = dt;
        //    glkuDoiTac.Properties.ValueMember = "DT_ID";
        //    glkuDoiTac.Properties.DisplayMember = "DT_Ten";
        //    glkuDoiTac.Properties.PopupFormWidth = 800;
        //    glkuvDoiTac.BestFitColumns();
        //}
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

        private void glkuDoiTac_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnThuTienInBill_Click(object sender, EventArgs e)
        {
            //if (!Info.KiemTraQuyen("Q_In", "barBanHang"))
            //{
            //    TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
            //    return;
            //}
            //if (grvHoaDonChiTiet.RowCount == 0)
            //{
            //    TTHMessage.ShowMessageWarming("Không có mặt hàng nào trong hóa đơn nên không thể thực hiện hành động này!");
            //    return;
            //}
            //try
            //{
            //    if (trangthai == 1 || trangthai == 2)
            //    {
            //        DataAccessStatic.sqltrans = DataAccessStatic.conn.BeginTransaction();
            //        Boolean ok = CapNhapTrangThaiBanPhong(bp_id, 0);
            //        if (ok) ok = SuaHoaDonTrans(hd_id, txtKyHieu.Text.Trim(), (DateTime)dateNgayLap.EditValue, double.Parse(txtTienHang.EditValue.ToString()), double.Parse(cboGiamGia.Text), double.Parse(txtTienGiamGia.EditValue.ToString()), double.Parse(txtTongCong.EditValue.ToString()), TTHUtils.ConvertNumberToText(txtTongCong.EditValue.ToString()), txtGhiChu.Text.Trim(), DateTime.Now.ToString("yyMMddHHmmss"), glkuBanPhong.EditValue.ToString().Trim(), "XBL", glkuDoiTac.EditValue.ToString().Trim(), 3, double.Parse(txtKhachDua.EditValue.ToString()), double.Parse(txtTienThua.EditValue.ToString()));
            //        if (ok)
            //        {
            //            DataAccessStatic.sqltrans.Commit();
            //            trangthai = 0;
            //            LayDSBanPhong(2);
            //            TTHMessage.ShowMessageInfomation("Đã lưu thành công!");
            //            InHoaDon(hd_id);
            //        }
            //        else
            //            DataAccessStatic.sqltrans.Rollback();
            //    }
            //}
            //catch (Exception)
            //{


            //}
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            frmThongKeBanHang frm = new frmThongKeBanHang();
            frm.ShowDialog();
        }
        
        private void btneMatHang_EditValueChanged(object sender, EventArgs e)
        {
            LayDSMatHangTheoLoaiHang(1);
        }

        private void rchkXoa_Click(object sender, EventArgs e)
        {

        }
        private void lvMatHang_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    if (trangthai == 0) return;
            //    else
            //    {
            //        string mh_id = lvMatHang.FocusedItem.SubItems[4].Text;
            //        string mh_dvt = "";//lvMatHang.FocusedItem.SubItems[0].Text;
            //        double mh_dongia = 0;//double.Parse(lvMatHang.FocusedItem.SubItems[3].Text);
            //        double mh_dongiavon = 0;
            //        string sql = "select MH_DVT, MH_GiaMua, MH_GiaBanLe, MH_GiaBanSi from MatHang where MH_ID = '" + mh_id + "'";
            //        foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            //        {
            //            mh_dvt = dr["MH_DVT"].ToString().Trim();
            //            mh_dongia = double.Parse(dr["MH_GiaBanLe"].ToString().Trim());
            //            mh_dongiavon = double.Parse(dr["MH_GiaMua"].ToString().Trim());
            //        }
            //        ThemHoaDonChiTiet(hd_id + DateTime.Now.ToString("yyMMddHHmmss") + string.Format("{0,4:0000}", grvHoaDonChiTiet.RowCount.ToString()), hd_id, mh_id, mh_dvt, 1, mh_dongia, mh_dongiavon, mh_dongia, hd_id + DateTime.Now.ToString("yyMMddHHmmss") + string.Format("{0,4:0000}", grvHoaDonChiTiet.RowCount.ToString()), false, false, DateTime.Now, "XBL");
            //        DataTable dt = LayDSHoaDonChiTiet(hd_id);
            //        grcHoaDonChiTiet.DataSource = dt;
            //        grvHoaDonChiTiet.FocusedRowHandle = dt.Rows.Count - 1;
            //        TinhTong();
            //    }
            //}
            //catch (Exception)
            //{


            //}
            
        }
        public void AddHoaDonChiTiet(string hdct_mh_id, string hdct_donvi, double hdct_soluong, double hdct_dongia, double hdct_dongiavon, double hdct_thanhtien)
        {
            //if (trangthai == 1 || trangthai == 2)
            //{
            //    ThemHoaDonChiTiet(hd_id + DateTime.Now.ToString("yyMMddHHmmss") + string.Format("{0,4:0000}", grvHoaDonChiTiet.RowCount.ToString()), hd_id, hdct_mh_id, hdct_donvi, hdct_soluong, hdct_dongia, hdct_dongiavon, hdct_thanhtien, hd_id + DateTime.Now.ToString("yyMMddHHmmss") + string.Format("{0,4:0000}", grvHoaDonChiTiet.RowCount.ToString()), false, false, DateTime.Now, "XBL");
            //    DataTable dt = LayDSHoaDonChiTiet(hd_id);
            //    grcHoaDonChiTiet.DataSource = dt;
            //    grvHoaDonChiTiet.FocusedRowHandle = dt.Rows.Count - 1;
            //    TinhTong();
            //}
        }
        private void lvMatHang_DoubleClick(object sender, EventArgs e)
        {
            //if (trangthai == 1 || trangthai == 2)
            //{
            //    frmThemHoaDonChiTiet frm = new frmThemHoaDonChiTiet();
            //    frm.hd_id = hd_id;
            //    frm.hd_thutu = hd_id + DateTime.Now.ToString("yyMMddHHmmss") + string.Format("{0,4:0000}", grvHoaDonChiTiet.RowCount.ToString());
            //    frm.mh_id = lvMatHang.FocusedItem.SubItems[4].Text;
            //    frm.mh_ten = lvMatHang.FocusedItem.SubItems[0].Text;
            //    frm.mh_dongia = double.Parse(lvMatHang.FocusedItem.SubItems[3].Text);
            //    frm.add = new frmThemHoaDonChiTiet.AddMatHangDelegate(AddHoaDonChiTiet);
            //    frm.ShowDialog();
            //}
        }

        private void txtKhachDua_KeyUp(object sender, KeyEventArgs e)
        {
            //if (double.Parse(txtKhachDua.EditValue.ToString()) > double.Parse(txtTongCong.EditValue.ToString()))
            //{
            //    txtTienThua.EditValue = double.Parse(txtKhachDua.EditValue.ToString()) - double.Parse(txtTongCong.EditValue.ToString());
            //}
            //else txtTienThua.EditValue = 0;
            //TinhTong();
        }

        private void grvHoaDonChiTiet_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle % 2 == 1)
            {
                e.Appearance.BackColor = Color.WhiteSmoke;
            }
            else e.Appearance.BackColor = Color.White;
        }

        
        
    }
}