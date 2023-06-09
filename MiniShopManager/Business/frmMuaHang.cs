using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using MyRMS.DanhMuc;
namespace MyRMS.NghiepVu
{
    public partial class frmMuaHang : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void DisplayObject();
        public DisplayObject DisplayBackgroung;
        public string pnx_id = "";
        public Boolean issua = false;
        public string lh_id = "";
        public frmMuaHang()
        {
            InitializeComponent();
        }
        public Boolean XoaPhieuNhapXuatChiTiet(string id)
        {
            string sql = "delete PhieuNhapXuatChiTiet where PNXCT_PNX_ID = '" + id + "'";
            return cls.ExecuteNonQueryTrans(sql);
        }
        public Boolean ThemPhieuNhapXuat(string pnx_id, string pnx_kyhieu, DateTime pnx_ngaylap, double pnx_sotien, double pnx_giamgia, double tiengiamgia, double pnx_sotiencuoi, string pnx_sotiencuoichu, double pnx_thanhtoan, string pnx_ghichu, string pnx_thutu, string pnx_nd_id, string pnx_loai, string pnx_dt_id, string pnx_diachi, string pnx_dienthoai, double pnx_thue, double pnx_tienthue, Boolean pnx_daxoa, string pnx_dv_id)
        {
            string[] field = { "PNX_ID", "PNX_KyHieu", "PNX_NgayLap", "PNX_SoTien", "PNX_GiamGia", "PNX_TienGiamGia", "PNX_SoTienCuoi", "PNX_SoTienCuoiChu", "PNX_ThanhToan", "PNX_GhiChu", "PNX_ThuTu", "PNX_ND_ID", "PNX_Loai", "PNX_DT_ID", "PNX_DiaChi", "PNX_DienThoai", "PNX_Thue", "PNX_TienThue", "PNX_DaXoa", "PNX_DV_ID" };
            object[] value = { (object)pnx_id, (object)pnx_kyhieu, (object)pnx_ngaylap, (object)pnx_sotien, (object)pnx_giamgia, (object)tiengiamgia, (object)pnx_sotiencuoi, (object)pnx_sotiencuoichu, (object)pnx_thanhtoan, (object)pnx_ghichu, (object)pnx_thutu, (object)pnx_nd_id, (object)pnx_loai, (object)pnx_dt_id, (object)pnx_diachi, (object)pnx_dienthoai, (object)pnx_thue, (object)pnx_tienthue, (object)pnx_daxoa, (object)pnx_dv_id };
            return cls.AddRecordTrans("PhieuNhapXuat", field, value);
        }
        public Boolean SuaPhieuNhapXuat(string pnx_id, string pnx_kyhieu, DateTime pnx_ngaylap, double pnx_sotien, double pnx_giamgia, double tiengiamgia, double pnx_sotiencuoi, string pnx_sotiencuoichu, double pnx_thanhtoan, string pnx_ghichu, string pnx_thutu, string pnx_nd_id, string pnx_loai, string pnx_dt_id, string pnx_diachi, string pnx_dienthoai, double pnx_thue, double pnx_tienthue)
        {
            string[] field = { "PNX_KyHieu", "PNX_NgayLap", "PNX_SoTien", "PNX_GiamGia", "PNX_TienGiamGia", "PNX_SoTienCuoi", "PNX_SoTienCuoiChu", "PNX_ThanhToan", "PNX_GhiChu", "PNX_ThuTu", "PNX_ND_ID", "PNX_Loai", "PNX_DT_ID", "PNX_DiaChi", "PNX_DienThoai", "PNX_Thue", "PNX_TienThue" };
            object[] value = { (object)pnx_kyhieu, (object)pnx_ngaylap, (object)pnx_sotien, (object)pnx_giamgia, (object)tiengiamgia, (object)pnx_sotiencuoi, (object)pnx_sotiencuoichu, (object)pnx_thanhtoan, (object)pnx_ghichu, (object)pnx_thutu, (object)pnx_nd_id, (object)pnx_loai, (object)pnx_dt_id, (object)pnx_diachi, (object)pnx_dienthoai, (object)pnx_thue, (object)pnx_tienthue };
            string[] fieldwhere = { "PNX_ID" };
            object[] valuewhere = { (object)pnx_id };
            return cls.EditRecordTrans("PhieuNhapXuat", field, value, fieldwhere, valuewhere);
        }
        public void LayThongTinPhieuNhapXuat(string pnx_id)
        {
            string sql = "select * from PhieuNhapXuat where PNX_ID = '" + pnx_id + "'";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                
                dateNgayLap.EditValue = (DateTime)dr["PNX_NgayLap"];
                txtKyHieu.Text = dr["PNX_KyHieu"].ToString();
                glkuDoiTac.EditValue = dr["PNX_DT_ID"].ToString();
                txtDienThoai.Text = dr["PNX_DienThoai"].ToString().Trim();
                txtDiaChi.Text = dr["PNX_DiaChi"].ToString().Trim();
                txtGhiChu.Text = dr["PNX_GhiChu"].ToString().Trim();
                grcPhieuNhapXuatChiTiet.DataSource = LayDSPhieuNhapXuatChiTiet(pnx_id);
                txtTienHang.EditValue = double.Parse(dr["PNX_SoTien"].ToString());
                cboGiamGia.Text = dr["PNX_GiamGia"].ToString();
                txtTienGiamGia.EditValue = double.Parse(dr["PNX_TienGiamGia"].ToString());
                txtTongCong.EditValue = double.Parse(dr["PNX_SoTienCuoi"].ToString());

            }
        }
        public Boolean ThemPhieuNhapXuatChiTiet(string pnxct_id, string pnxct_pnx_id, string pnxct_mh_id, string pnxct_dvt, double pnxct_soluong, double pnxct_dongia, double pnxct_dongiavon, double pnxct_thanhtien, double pnxct_chietkhau, double pnxct_tienchietkhau, double pnxct_tongcong, string pnxct_thutu,  Boolean pnxct_chonxoa, DateTime pnxct_ngaylap, string pnxct_loai, string pnxct_chuthich, int pnxct_stt )
        {
            DataAccess cls = new DataAccess();
            string[] field = { "PNXCT_ID", "PNXCT_PNX_ID", "PNXCT_MH_ID", "PNXCT_DVT", "PNXCT_SoLuong", "PNXCT_DonGia", "PNXCT_DonGiaVon", "PNXCT_ThanhTien", "PNXCT_ChietKhau", "PNXCT_TienChietKhau", "PNXCT_TongCong", "PNXCT_ThuTu", "PNXCT_DV_ID", "PNXCT_ChonXoa", "PNXCT_NgayLap", "PNXCT_Loai", "PNXCT_ChuThich", "PNXCT_STT" };
            object[] obj = { (object)pnxct_id, (object)pnxct_pnx_id, (object)pnxct_mh_id, (object)pnxct_dvt, (object)pnxct_soluong, (object)pnxct_dongia, (object)pnxct_dongiavon, (object)pnxct_thanhtien, (object)pnxct_chietkhau, (object)pnxct_tienchietkhau, (object)pnxct_tongcong, (object)pnxct_thutu, (object)Info.dv_id,  (object)pnxct_chonxoa, (object)pnxct_ngaylap, (object)pnxct_loai, (object)pnxct_chuthich, (object)pnxct_stt };
            return cls.AddRecordTrans("PhieuNhapXuatChiTiet", field, obj);
        }
        public DataTable LayDSPhieuNhapXuatChiTiet(string pnx_id)
        {
            string sql = "select PNXCT_ID,  PNXCT_MH_ID, PNXCT_DVT, PNXCT_SoLuong,  PNXCT_DonGia, PNXCT_DonGiaVon, PNXCT_ThanhTien,PNXCT_ChietKhau,PNXCT_TienChietKhau,PNXCT_TongCong, PNXCT_ChonXoa, PNXCT_ChuThich from PhieuNhapXuatChiTiet where PNXCT_PNX_ID = '" + pnx_id + "' order by PNXCT_ThuTu";
            return cls.GetDataTable(sql);
        }
        public void TaoSoPhieuNhapXuat()
        {
            
            string sql = "select distinct max(right(PNX_KyHieu,4)) from PhieuNhapXuat where PNX_DV_ID = '" + Info.dv_id + "' and convert(varchar(10),PNX_NgayLap, 103) = '" + ((DateTime)dateNgayLap.EditValue).ToString("dd/MM/yyyy") + "'";
            txtKyHieu.EditValue = "NHM" + ((DateTime)dateNgayLap.EditValue).ToString("yyMMdd") + "-" + string.Format("{0,4:0000}", cls.GetNumberValue(sql) + 1);
        }
        public void LayDSDoiTac()
        {
            string sql = "select DT_ID, DT_Ten, DT_DiaChi, DT_DienThoai, DT_Email from DoiTac ";
            sql += "where DT_Loai = 'NCC' ";
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
        public void LayDSMatHangDropDown()
        {
            DataAccess cls = new DataAccess();
            string sql = "select MH_ID, MH_Ma,  MH_Ten, MH_Ma + ' - ' + MH_Ten as MH_ThongTinChinh, MH_DVT, MH_GiaMua, MH_GiaBanSi, MH_GiaBanLe, MH_GiaTraCham from MatHang where MH_KichHoat = 'True' and MH_DV_ID = '" + Info.dv_id + "' order by MH_Ten";
            DataTable dt = cls.GetDataTable(sql);
            DataRow dr = dt.NewRow();
            dr[0] = dr[1] = dr[2] = dr[3] = dr[4] = "";
            dr[5] = dr[6] = dr[7] = dr[8] = 0;
            dt.Rows.InsertAt(dr, 0);
            rglkuMatHang.DataSource = dt;
            rglkuMatHang.ValueMember = "MH_ID";
            rglkuMatHang.DisplayMember = "MH_Ten";
            rglkuMatHang.PopupFormWidth = 600;
            rglkuvMatHang.BestFitColumns();

            glkuMatHang.Properties.DataSource = dt;
            glkuMatHang.Properties.ValueMember = "MH_ID";
            glkuMatHang.Properties.DisplayMember = "MH_Ten";
            glkuMatHang.Properties.PopupFormWidth = 800;
            glkuvMatHang.BestFitColumns();
        }
        public void TaoKyHieu()
        {
            //pnx_id = ((DateTime)dateNgayLap.EditValue).ToString("yyMMddHHmmss");
            string sql = "select distinct max(right(PNX_KyHieu,4)) from PhieuNhapXuat where PNX_DV_ID = '" + Info.dv_id + "' and convert(varchar(10),PNX_NgayLap, 103) = '" + ((DateTime)dateNgayLap.EditValue).ToString("dd/MM/yyyy") + "'";
            txtKyHieu.EditValue = "NHM" + ((DateTime)dateNgayLap.EditValue).ToString("yyMMdd") + "-" + string.Format("{0,4:0000}", cls.GetNumberValue(sql) + 1);
        }
        public void LayDSLoaiHang(int kieuhienthi)
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
                if (kieuhienthi == 1)
                {
                    lvLoaiHang.SmallImageList = imgLoaiHang;
                    lvLoaiHang.View = View.Details;
                }
                else if (kieuhienthi == 2)
                {
                    lvLoaiHang.LargeImageList = imgLoaiHang;
                    lvLoaiHang.View = View.LargeIcon;
                }
                else if (kieuhienthi == 3)
                {
                    lvLoaiHang.SmallImageList = imgLoaiHang;
                    lvLoaiHang.View = View.List;
                }
                else if (kieuhienthi == 4)
                {
                    lvLoaiHang.SmallImageList = imgLoaiHang;
                    lvLoaiHang.View = View.SmallIcon;
                }
                else
                {
                    lvLoaiHang.SmallImageList = imgLoaiHang;
                    lvLoaiHang.View = View.Tile;
                }
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
                sql = "select MH_ID,MH_Ma,MH_Ten,MH_DVT,MH_GiaMua,MH_HinhAnh from MatHang where  MH_TuKhoa like N'%" + TTHUtils.LoaiBoDauTiengViet(btneMatHang.Text.Trim()) + "%' and  MH_KichHoat = 'true' and MH_LH_ID = '" + lh_id + "' and MH_DV_ID = '" + Info.dv_id + "'  order by MH_Ten";
            else sql = "select MH_ID,MH_Ma,MH_Ten,MH_DVT,MH_GiaMua,MH_HinhAnh from MatHang where  MH_TuKhoa like N'%" + TTHUtils.LoaiBoDauTiengViet(btneMatHang.Text.Trim()) + "%' and   MH_KichHoat = 'true' and MH_DV_ID = '" + Info.dv_id + "'  order by MH_Ten";
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
                    lvi.SubItems.Add(string.Format("{0:0,#}", double.Parse(dr["MH_GiaMua"].ToString())));
                    lvi.SubItems.Add(dr["MH_ID"].ToString().Trim());
                    lvMatHang.Items.Add(lvi);
                    i = i + 1;
                }
                lvMatHang.Items[0].Focused = true;
                lvMatHang.Items[0].Selected = true;
            }

        }
        private void frmMuaHang_Load(object sender, EventArgs e)
        {

            dateTuNgay.EditValue = DateTime.Now;
            dateDenNgay.EditValue = DateTime.Now;
            LayDSLoaiHang(2);
            LayDSMatHangDropDown();
            LayDSDoiTac();
            LayDSNguoiDung();
            glkuNhanVien.EditValue = Info.nd_id;
            dateNgayLap.EditValue = DateTime.Now;
            btnTimKiem_Click(null, null);
            btnThem_Click(null, null);
        }

        private void glkuDoiTac_EditValueChanged(object sender, EventArgs e)
        {
            if(glkuDoiTac.Text.Length > 0)
            {
                string sql = "select DT_ID, DT_Ten, DT_DiaChi, DT_DienThoai from DoiTac where DT_ID = '" + glkuDoiTac.EditValue.ToString() + "' ";
                foreach (DataRow dr in cls.GetDataTable(sql).Rows)
                {
                    txtDiaChi.Text = dr["DT_DiaChi"].ToString().Trim();
                    txtDienThoai.Text = dr["DT_DienThoai"].ToString().Trim();
                }
            }
            else
            {
                txtDiaChi.Text = "";
                txtDienThoai.Text = "";
            }
        }
        //public void LayDSDVT(string mh_id)
        //{
        //    string sql = ""
        //}
        private void glkuMatHang_EditValueChanged(object sender, EventArgs e)
        {
            if (glkuMatHang.Text.Length > 0)
            {
                string sql = "select MH_DVT, MH_GiaMua from MatHang where MH_ID = '" + glkuMatHang.EditValue.ToString() + "' ";
                foreach (DataRow dr in cls.GetDataTable(sql).Rows)
                {
                    cboDVT.Properties.Items.Clear();
                    cboDVT.Properties.Items.Add(dr["MH_DVT"].ToString().Trim());
                    cboDVT.Text = dr["MH_DVT"].ToString().Trim();
                    spnDonGia.EditValue = double.Parse(dr["MH_GiaMua"].ToString());
                    spnThanhTien.EditValue = double.Parse(spnSoLuong.EditValue.ToString()) * double.Parse(spnDonGia.EditValue.ToString());
                    spnTongCong.EditValue = (1-0.01*double.Parse(spnChietKhau.EditValue.ToString())) * double.Parse(spnThanhTien.EditValue.ToString());
                }
            }
            else
            {
                cboDVT.Text = "";
                spnDonGia.EditValue = 0;
                spnSoLuong.EditValue = 0.0;
                spnThanhTien.EditValue = 0;
                spnChietKhau.EditValue = 0;
                spnTongCong.EditValue = 0;
            }
        }
        public void TaoID()
        {
            dateNgayLap.EditValue = DateTime.ParseExact(((DateTime)dateNgayLap.EditValue).ToString("yyyyMMdd") + string.Format("{0,2:00}", DateTime.Now.Hour) + string.Format("{0,2:00}", DateTime.Now.Minute) + string.Format("{0,2:00}", DateTime.Now.Second), "yyyyMMddHHmmss", null);
            pnx_id = ((DateTime)dateNgayLap.EditValue).ToString("yyMMddHHmmss");
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Them", "barMuaHang"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            issua = false;
            TaoID();
            //TaoKyHieu();
            grcPhieuNhapXuatChiTiet.DataSource = LayDSPhieuNhapXuatChiTiet(pnx_id);
            glkuDoiTac.EditValue = "";
            txtDiaChi.Text = "";
            txtGhiChu.Text = "";
            glkuMatHang.EditValue = "";
            cboDVT.Text = "";
            spnSoLuong.EditValue = 0.0;
            spnDonGia.EditValue = 0;
            spnThanhTien.EditValue = 0;
            spnChietKhau.EditValue = 0;
            spnTongCong.EditValue = 0;
            txtTienHang.EditValue = 0;
            cboGiamGia.SelectedIndex = 0;
            txtTienGiamGia.EditValue = 0;
            txtTongCong.EditValue = 0;
            txtThanhToan.EditValue = 0;
            glkuDoiTac.Focus();
        }

        private void glkuMatHang_Enter(object sender, EventArgs e)
        {
            //cboDVT.Focus();
            //cboDVT.SelectAll();
        }

        private void glkuvDoiTac_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            BeginInvoke(new Action(() =>
            {
                view.FocusedRowHandle = 0;
            }));
        }

        private void glkuvMatHang_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            BeginInvoke(new Action(() =>
            {
                view.FocusedRowHandle = 0;
            }));
        }

        private void glkuMatHang_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (glkuMatHang.Text.Length == 0) return;
                cboDVT.Focus();
                cboDVT.SelectAll();
            }
        }

        private void cboDVT_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboDVT.Text.Length == 0) return;
                spnSoLuong.Focus();
                spnSoLuong.SelectAll();
            }
        }

        private void spnSoLuong_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (spnSoLuong.EditValue.ToString() == "0") return;
                spnDonGia.Focus();
                spnDonGia.SelectAll();
            }
        }

        private void spnDonGia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                spnChietKhau.Focus();
                spnChietKhau.SelectAll();
            }
        }

        private void spnChietKhau_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(null, null);
                
                //  PNXCT_ChonXoa from PhieuNhapXuatChiTiet where PNXCT_PNX_ID = '" + pnx_id + "' order by PNXCT_ThuTu";
            }
        }
        public void TinhThanhTien()
        {
            spnThanhTien.EditValue = double.Parse(spnSoLuong.EditValue.ToString()) * double.Parse(spnDonGia.EditValue.ToString());
            spnTongCong.EditValue = (1 - 0.01 * double.Parse(spnChietKhau.EditValue.ToString())) * double.Parse(spnThanhTien.EditValue.ToString());
        }
        public void TinhTongToa()
        {
            txtTienHang.EditValue = double.Parse(grvPhieuNhapXuatChiTiet.Columns["PNXCT_TongCong"].SummaryText);
            txtTienGiamGia.EditValue = 0.01 * double.Parse(cboGiamGia.Text) * double.Parse(txtTienHang.EditValue.ToString());
            txtTongCong.EditValue = double.Parse(txtTienHang.EditValue.ToString()) - double.Parse(txtTienGiamGia.EditValue.ToString());
        }
        private void spnSoLuong_EditValueChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void spnDonGia_EditValueChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void spnChietKhau_EditValueChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void rchkXoa_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Xoa", "barMuaHang"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            DataRow row = grvPhieuNhapXuatChiTiet.GetFocusedDataRow();
            row.Delete();
            TinhTongToa();
        }

        private void spnChietKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (double.Parse(spnSoLuong.EditValue.ToString()) == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập số lượng!");
                spnSoLuong.Focus();
                spnSoLuong.SelectAll();
                return;
            }
            try
            {
                DataTable dt = (DataTable)grcPhieuNhapXuatChiTiet.DataSource;
                DataRow dr = dt.NewRow();
                dr["PNXCT_ID"] = pnx_id + DateTime.Now.ToString("yyMMddHHmmss") + string.Format("{0,4:0000}", grvPhieuNhapXuatChiTiet.RowCount.ToString());
                dr["PNXCT_MH_ID"] = glkuMatHang.EditValue.ToString();
                dr["PNXCT_DVT"] = cboDVT.Text;
                dr["PNXCT_SoLuong"] = double.Parse(spnSoLuong.EditValue.ToString());
                dr["PNXCT_DonGia"] = double.Parse(spnDonGia.EditValue.ToString());
                dr["PNXCT_DonGiaVon"] = double.Parse(spnDonGia.EditValue.ToString());
                dr["PNXCT_ThanhTien"] = double.Parse(spnThanhTien.EditValue.ToString());
                dr["PNXCT_ChietKhau"] = double.Parse(spnChietKhau.EditValue.ToString());
                dr["PNXCT_TienChietKhau"] = 0.01 * double.Parse(spnChietKhau.EditValue.ToString()) * double.Parse(spnThanhTien.EditValue.ToString());
                dr["PNXCT_TongCong"] = (1 - 0.01 * double.Parse(spnChietKhau.EditValue.ToString())) * double.Parse(spnThanhTien.EditValue.ToString());
                dr["PNXCT_ChonXoa"] = false;
                dt.Rows.InsertAt(dr, dt.Rows.Count);
                grcPhieuNhapXuatChiTiet.DataSource = dt;
                grvPhieuNhapXuatChiTiet.FocusedRowHandle = grvPhieuNhapXuatChiTiet.RowCount - 1;
                TinhTongToa();
                glkuMatHang.EditValue = "";
                glkuMatHang.Focus();
            }
            catch (Exception)
            {


            }
        }

        private void grvPhieuNhapXuatChiTiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow row = grvPhieuNhapXuatChiTiet.GetFocusedDataRow();
            double thanhtien = double.Parse(row["PNXCT_SoLuong"].ToString()) * double.Parse(row["PNXCT_DonGia"].ToString());
            double chietkhau = double.Parse(row["PNXCT_ChietKhau"].ToString());
            row["PNXCT_ThanhTien"] = thanhtien;
            row["PNXCT_TienChietKhau"] = 0.01 * chietkhau * thanhtien;
            row["PNXCT_TongCong"] = (1 - 0.01 * chietkhau) * thanhtien;
            grvPhieuNhapXuatChiTiet.UpdateCurrentRow();
            TinhTongToa();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (issua)
            {
                if (!Info.KiemTraQuyen("Q_Sua", "barMuaHang"))
                {
                    TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                    return;
                }
            }
            else
            {
                if (!Info.KiemTraQuyen("Q_Them", "barMuaHang"))
                {
                    TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                    return;
                }
            }
            if (grvPhieuNhapXuatChiTiet.RowCount == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập hàng hóa cần mua!");
                return;
            }
            if (!issua) TaoID();
            DataAccessStatic.sqltrans = DataAccessStatic.conn.BeginTransaction();
            Boolean ok = false;
            if (issua)
            {
                ok = SuaPhieuNhapXuat(pnx_id, txtKyHieu.Text.Trim(), (DateTime)dateNgayLap.EditValue, double.Parse(txtTienHang.EditValue.ToString()), double.Parse(cboGiamGia.Text), double.Parse(txtTienGiamGia.EditValue.ToString()), double.Parse(txtTongCong.EditValue.ToString()), TTHUtils.ConvertNumberToText(txtTongCong.EditValue.ToString()), double.Parse(txtThanhToan.EditValue.ToString()), txtGhiChu.Text.Trim(), ((DateTime)dateNgayLap.EditValue).ToString("yyMMdd") + pnx_id, glkuNhanVien.EditValue.ToString(), "NHM", glkuDoiTac.EditValue.ToString(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(), 0, 0);
                if (ok) ok = XoaPhieuNhapXuatChiTiet(pnx_id);
            }
            else ok = ThemPhieuNhapXuat(pnx_id, txtKyHieu.Text.Trim(), (DateTime)dateNgayLap.EditValue, double.Parse(txtTienHang.EditValue.ToString()), double.Parse(cboGiamGia.Text), double.Parse(txtTienGiamGia.EditValue.ToString()), double.Parse(txtTongCong.EditValue.ToString()), TTHUtils.ConvertNumberToText(txtTongCong.EditValue.ToString()), double.Parse(txtThanhToan.EditValue.ToString()), txtGhiChu.Text.Trim(), ((DateTime)dateNgayLap.EditValue).ToString("yyMMdd") + pnx_id, glkuNhanVien.EditValue.ToString(), "NHM", glkuDoiTac.EditValue.ToString(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(), 0, 0, false, Info.dv_id);
            if (ok)
            {
                for (int i = 0; i < grvPhieuNhapXuatChiTiet.RowCount; i++)
                {
                    string pnxct_id = ((DateTime)dateNgayLap.EditValue).ToString("yyMMdd") + pnx_id + string.Format("{0,4:0000}", i + 1);
                    DataRow row = grvPhieuNhapXuatChiTiet.GetDataRow(i);
                    //double dongiavon = System.Math.Round(System.Math.Round(double.Parse(row["tongcong"].ToString()) / double.Parse(row["soluong"].ToString()), 0) / double.Parse(row["tile"].ToString()));
                    //foreach (DataRow dr in layDonGiaVon(row["idhh"].ToString().Trim(), idct).Rows)
                    //{
                    //    dongiavon = (double.Parse(dr["slton"].ToString()) * double.Parse(dr["dongiavon"].ToString()) + double.Parse(row["tongcong"].ToString())) / (double.Parse(dr["slton"].ToString()) + double.Parse(row["soluong"].ToString()) * double.Parse(row["tile"].ToString()));
                    //}
                    ok = ThemPhieuNhapXuatChiTiet(pnxct_id, pnx_id, row["PNXCT_MH_ID"].ToString().Trim(), row["PNXCT_DVT"].ToString().Trim(), double.Parse(row["PNXCT_SoLuong"].ToString()), double.Parse(row["PNXCT_DonGia"].ToString()), double.Parse(row["PNXCT_DonGia"].ToString()), double.Parse(row["PNXCT_ThanhTien"].ToString()), double.Parse(row["PNXCT_ChietKhau"].ToString()), double.Parse(row["PNXCT_TienChietKhau"].ToString()), double.Parse(row["PNXCT_TongCong"].ToString()), pnxct_id, false, (DateTime)dateNgayLap.EditValue, "NHM", "", i + 1);
                    //if (ok)
                    //{
                    //    ok = CapNhatGiaMua(row["idhh"].ToString().Trim(), dongiavon);
                    //    if (ok)
                    //    {
                    //        //Tinh lại giá vốn của các đơn hàng nhập sau đó
                    //        string sql1 = "select distinct idct,tongcong, dongiavon, soluong, tile from v_TheoDoiHangTon a where idhh = '" + row["idhh"].ToString().Trim() + "' and idct  > '" + idct + "' and (loai = 'NMH' OR loai = 'PNK') order by idct";
                    //        foreach (DataRow dr in cls.GetDataTableTrans(sql1).Rows)
                    //        {
                    //            foreach (DataRow dr1 in layDonGiaVon(row["idhh"].ToString().Trim(), dr["idct"].ToString().Trim()).Rows)
                    //            {
                    //                dongiavon = (double.Parse(dr1["slton"].ToString()) * double.Parse(dr1["dongiavon"].ToString()) + double.Parse(dr["tongcong"].ToString())) / (double.Parse(dr1["slton"].ToString()) + double.Parse(dr["soluong"].ToString()) * double.Parse(dr["tile"].ToString()));
                    //                string sql2 = "update ChungTuChiTiet set dongiavon = '" + dongiavon + "' where idct = '" + dr["idct"].ToString().Trim() + "'";
                    //                ok = cls.ExecuteNonQueryTrans(sql2);
                    //            }
                    //        }
                    //    }
                    //}
                    if (!ok)
                        break;
                }

            }
            if (ok)
            {
                DataAccessStatic.sqltrans.Commit();
                TTHMessage.ShowMessageInfomation("Đã lưu thành công!");
                issua = true;

                btnTimKiem_Click(null, null);
                if (chkInSauKhiLuu.Checked) btnIn_Click(null, null);
                if (chkTaoMoiSauKhiLuu.Checked) btnThem_Click(null, null);
                
            }
            else
            {
                DataAccessStatic.sqltrans.Rollback();
                TTHMessage.ShowMessageWarming("Không thể lưu. Xin kiểm tra lại thông tin!");
            }
        }

        private void dateNgayLap_EditValueChanged(object sender, EventArgs e)
        {
            TaoKyHieu();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tungay = ((DateTime)dateTuNgay.EditValue).ToString("dd/MM/yyyy");
            string denngay = ((DateTime)dateDenNgay.EditValue).ToString("dd/MM/yyyy");
            string sql = "select PNX_ID, PNX_KyHieu, convert(varchar(10),PNX_NgayLap, 103) as PNX_NgayLap, DT_Ten as PNX_KhachHang, PNX_SoTienCuoi, PNX_ThanhToan, PNX_GhiChu, PNX_DT_ID ";
            sql += "from PhieuNhapXuat left join DoiTac on PNX_DT_ID = DT_ID ";
            sql += "where PNX_Loai = 'NHM' ";
            sql += "and convert(DateTime,convert(varchar(10), PNX_NgayLap, 103),103) >= convert(DateTime, '" + tungay + "', 103) ";
            sql += "and convert(DateTime,convert(varchar(10), PNX_NgayLap, 103),103) <= convert(DateTime, '" + denngay + "', 103) ";
            if (Info.thutuchungtugiam)
                sql += "order by PNX_ThuTu desc ";
            else sql += "order by PNX_ThuTu ";
            grcBangKeChungTu.DataSource = cls.GetDataTable(sql);
            grvBangKeChungTu.BestFitColumns();
        }

        private void grvBangKeChungTu_DoubleClick(object sender, EventArgs e)
        {
            if (grvBangKeChungTu.RowCount == 0) return;
            try
            {
                issua = true;
                DataRow row = grvBangKeChungTu.GetFocusedDataRow();
                LayThongTinPhieuNhapXuat(row["PNX_ID"].ToString().Trim());
                glkuDoiTac.Focus();
                glkuDoiTac.SelectAll();
            }
            catch (Exception)
            {

            }
           
        }

       

        

        private void cboGiamGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTienGiamGia.EditValue = 0.01 * double.Parse(cboGiamGia.Text) * double.Parse(txtTienHang.EditValue.ToString());
            TinhTongToa();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_In", "barMuaHang"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            TTHWait.ShowWait();
            string sql = "select PNX_ID, PNX_KyHieu, convert(varchar(10),PNX_NgayLap, 103) as PNX_NgayLap,  ";
            sql += "PNX_SoTien, PNX_GiamGia, PNX_TienGiamGia, PNX_SoTienCuoi, PNX_SoTienCuoiChu, PNX_Thue, PNX_TienThue, PNX_SoTienSauThue, PNX_SoTienSauThueChu, PNX_ThanhToan, PNX_GhiChu, ";
            sql += "DT_Ten as PNX_KhachHang, PNX_DiaChi, PNX_DienThoai, ";
            sql += "N'Ngày ' + case when len(convert(char(2),day(convert(datetime,PNX_NgayLap,103)))) = 1 then '0' + convert(char(2),day(convert(datetime,PNX_NgayLap,103))) else convert(char(2),day(convert(datetime,PNX_NgayLap,103))) end + N' tháng ' + case when len(convert(char(2),month(convert(datetime,PNX_NgayLap,103)))) = 1 then '0' + convert(char(2),month(convert(datetime,PNX_NgayLap,103))) else convert(char(2),month(convert(datetime,PNX_NgayLap,103))) end  + N' năm ' + convert(char(4),year(PNX_NgayLap)) as PNX_NgayLapchu, ";
            sql += "MH_Ma, MH_Ten, PNXCT_DVT, PNXCT_SoLuong, PNXCT_DonGia, PNXCT_ThanhTien, PNXCT_ChietKhau, PNXCT_TienChietKhau, PNXCT_TongCong ";
            sql += "from PhieuNhapXuat left join PhieuNhapXuatChiTiet on PNX_ID = PNXCT_PNX_ID  left join DoiTac on PNX_DT_ID = DT_ID ";
            sql += "left join MatHang on PNXCT_MH_ID = MH_ID ";
            sql += "where PNX_ID = '" + pnx_id + "' ";
            sql += "order by PNX_ThuTu ";
            FastReport.Report rpt = new FastReport.Report();
            rpt.Load(Application.StartupPath + "\\report\\NhapHangMua_A5.frx");
            rpt.RegisterData(cls.GetDataTable(sql), "Table");
            rpt.SetParameterValue("tendoanhnghiep", Info.dv_ten);
            rpt.SetParameterValue("diachidoanhnghiep", Info.dv_diachi);
            rpt.SetParameterValue("dienthoaidoanhnghiep", Info.dv_dienthoai);
            TTHWait.CloseWait();
            rpt.Show();
            //rpt.PrintSettings.Printer = Info.mayinhoadon;
            //rpt.PrintSettings.ShowDialog = false;
            
            //rpt.Print();
        }

        private void btnSaoChep_Click(object sender, EventArgs e)
        {
            if (grvBangKeChungTu.RowCount == 0) return;
            try
            {
                issua = false;
                TaoID();
                DataRow row = grvBangKeChungTu.GetFocusedDataRow();
                grcPhieuNhapXuatChiTiet.DataSource = LayDSPhieuNhapXuatChiTiet(row["PNX_ID"].ToString().Trim());
                glkuDoiTac.EditValue = row["PNX_DT_ID"].ToString().Trim();
                glkuDoiTac.Focus();
                glkuDoiTac.SelectAll();
            }
            catch (Exception)
            {

            }
           
            
        }

        private void grvPhieuNhapXuatChiTiet_ShownEditor(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() =>
            {

                grvPhieuNhapXuatChiTiet.ActiveEditor.SelectAll();

            }));
        }

        private void lvLoaiHang_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem lvi = lvLoaiHang.FocusedItem;
                lh_id = lvi.SubItems[1].Text.Trim();
                LayDSMatHangTheoLoaiHang(1);
            }
            catch (Exception)
            {

            }
        }

        private void lvMatHang_Click(object sender, EventArgs e)
        {
            
            try
            {
                double dongia = double.Parse(lvMatHang.FocusedItem.SubItems[3].Text.Replace(",", ""));
                DataTable dt = (DataTable)grcPhieuNhapXuatChiTiet.DataSource;
                DataRow dr = dt.NewRow();
                dr["PNXCT_ID"] = pnx_id + DateTime.Now.ToString("yyMMddHHmmss") + string.Format("{0,4:0000}", grvPhieuNhapXuatChiTiet.RowCount.ToString());
                dr["PNXCT_MH_ID"] = lvMatHang.FocusedItem.SubItems[4].Text;
                dr["PNXCT_DVT"] = lvMatHang.FocusedItem.SubItems[2].Text;
                dr["PNXCT_SoLuong"] = 1;
                dr["PNXCT_DonGia"] = dongia;
                dr["PNXCT_DonGiaVon"] = dongia;
                dr["PNXCT_ThanhTien"] = dongia;
                dr["PNXCT_ChietKhau"] = 0;
                dr["PNXCT_TienChietKhau"] = 0;
                dr["PNXCT_TongCong"] = dongia;
                dr["PNXCT_ChonXoa"] = false;
                dt.Rows.InsertAt(dr, dt.Rows.Count);
                grcPhieuNhapXuatChiTiet.DataSource = dt;
                grvPhieuNhapXuatChiTiet.FocusedRowHandle = grvPhieuNhapXuatChiTiet.RowCount - 1;
                TinhTongToa();
                glkuMatHang.EditValue = "";
                glkuMatHang.Focus();
            }
            catch (Exception)
            {


            }
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

        private void btneMatHang_EditValueChanged(object sender, EventArgs e)
        {
            LayDSMatHangTheoLoaiHang(1);
        }
        public Boolean XoaPhieuNhapXuat(string pnx_id)
        {
            DataAccess cls = new DataAccess();
            string sql = "delete PhieuNhapXuat where PNX_ID = '" + pnx_id + "'";
            return cls.ExecuteNonQuery(sql);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Xoa", "barMuaHang"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            try
            {
                if (grvBangKeChungTu.RowCount == 0) return;
                DataRow row = grvBangKeChungTu.GetFocusedDataRow();
                string pnx_id = row["PNX_ID"].ToString().Trim();
                //Xoa mot dong
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa dòng được chọn không?", Info.tenphanmem, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!XoaPhieuNhapXuat(pnx_id))
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

        private void rchkXoa_CheckedChanged(object sender, EventArgs e)
        {

        }
        public void SetDoiTac(string dt_id)
        {
            glkuDoiTac.EditValue = dt_id;
        }
        private void glkuDoiTac_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                frmNhaCungCapUpdate frm = new frmNhaCungCapUpdate();
                frm.frmText = "NHÀ CUNG CẤP [Thêm]";
                frm.LayDSDoiTac = new frmNhaCungCapUpdate.GetDataTableDelegate(LayDSDoiTac);
                frm.SetDoiTac = new frmNhaCungCapUpdate.SetDoiTacDelegate(SetDoiTac);
                frm.ShowDialog();
            }
        }

        private void spnDonGia_MouseUp(object sender, MouseEventArgs e)
        {
            spnDonGia.SelectAll();
        }

        private void spnSoLuong_MouseUp(object sender, MouseEventArgs e)
        {
            spnSoLuong.SelectAll();
        }
    }
}