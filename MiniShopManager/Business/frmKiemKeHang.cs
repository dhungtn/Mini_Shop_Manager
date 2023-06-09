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
    public partial class frmKiemKeHang : DevExpress.XtraEditors.XtraForm
    {
        public delegate void DisplayBackgroungDelegate();
        public DisplayBackgroungDelegate DisplayBackgroung;
        DataAccess cls = new DataAccess();
        public Boolean issua = false;
        public string pkh_id = "";
        public void LayDSMatHangDropDown()
        {

            string sql = "select MH_ID,MH_Ma,  MH_Ten, MH_TuKhoa from MatHang where MH_KichHoat = 'True' and MH_DV_ID = '" + Info.dv_id + "' order by MH_Ten";
            DataTable dt = cls.GetDataTable(sql);
            DataRow dr = dt.NewRow();
            dr[0] = dr[1] = dr[2] = dr[3] = "";
            dt.Rows.InsertAt(dr, 0);
            glkuMatHang.Properties.DataSource = dt;
            glkuMatHang.Properties.ValueMember = "MH_ID";
            glkuMatHang.Properties.DisplayMember = "MH_Ten";
            glkuMatHang.Properties.PopupFormWidth = glkuMatHang.Size.Width - 4;
            glkuvMatHang.BestFitColumns();
        }
        public void TaoKyHieu()
        {
            string sql = "select distinct isnull(max(right(PKH_KyHieu,4)),0) from PhieuKiemHang where PKH_DV_ID = '" + Info.dv_id + "' and convert(varchar(10),PKH_NgayLap, 103) = '" + ((DateTime)dateNgayLap.EditValue).ToString("dd/MM/yyyy") + "'";
            txtKyHieu.EditValue = "KKH" + ((DateTime)dateNgayLap.EditValue).ToString("yyMMdd") + "-" + string.Format("{0,4:0000}", cls.GetNumberValue(sql) + 1);
        }
        public double LayTonHienTai(string mh_id)
        {
            string sql = "select sum(soluongnhap) - sum(soluongxuat) from TheoDoiNhapXuatHang where idmh = '" + mh_id + "'";
            return cls.GetNumberValue(sql);
        }
        public Boolean ThemPhieuKiemHang()
        {
            DataAccess cls = new DataAccess();
            string[] field = { "PKH_ID", "PKH_KyHieu", "PKH_NgayLap", "PKH_MH_ID", "PKH_TonThucTe", "PKH_TonHeThong", "PKH_ChenhLech", "PKH_GhiChu",  "PKH_ThuTu", "PKH_DV_ID" };
            object[] value = { (object)pkh_id, (object)txtKyHieu.Text.Trim(), (object)((DateTime)dateNgayLap.EditValue), (object)glkuMatHang.EditValue.ToString().Trim(), (object)double.Parse(txtTonThucTe.EditValue.ToString()), (object)double.Parse(txtTonHeThong.EditValue.ToString()), (object)double.Parse(txtChenhLech.EditValue.ToString()), (object)txtGhiChu.Text.Trim(), (object)(DateTime.Now.ToString("yyMMdd") + pkh_id + "0000" + DateTime.Now.ToString("yyMMddHHmmss")), (object)Info.dv_id };
            return cls.AddRecord("PhieuKiemHang", field, value);
        }
        public Boolean SuaPhieuKiemHang()
        {
            DataAccess cls = new DataAccess();
            string[] field = { "PKH_KyHieu", "PKH_NgayLap", "PKH_MH_ID", "PKH_TonThucTe", "PKH_TonHeThong", "PKH_ChenhLech", "PKH_GhiChu", "PKH_ThuTu", "PKH_DV_ID" };
            object[] value = { (object)txtKyHieu.Text.Trim(), (object)((DateTime)dateNgayLap.EditValue), (object)glkuMatHang.EditValue.ToString().Trim(), (object)double.Parse(txtTonThucTe.EditValue.ToString()), (object)double.Parse(txtTonHeThong.EditValue.ToString()), (object)double.Parse(txtChenhLech.EditValue.ToString()), (object)txtGhiChu.Text.Trim(), (object)(DateTime.Now.ToString("yyMMdd") + pkh_id + "0000" + DateTime.Now.ToString("yyMMddHHmmss")), (object)Info.dv_id };
            string[] fieldwhere = { "PKH_ID" };
            object[] objwhere = { (object)pkh_id };
            return cls.EditRecord("PhieuKiemHang", field, value, fieldwhere, objwhere);
        }
        public void LayThongTinPhieuKiemHang(string id)
        {
            DataAccess cls = new DataAccess();
            string sql = "select * from PhieuKiemHang where PKH_ID = '" + id + "'";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                dateNgayLap.EditValue = (DateTime)dr["PKH_NgayLap"];
                txtKyHieu.Text = dr["PKH_KyHieu"].ToString().Trim();
                glkuMatHang.EditValue = dr["PKH_MH_ID"].ToString().Trim();
                txtTonThucTe.EditValue = double.Parse(dr["PKH_TonThucTe"].ToString());
                txtTonHeThong.EditValue = double.Parse(dr["PKH_TonHeThong"].ToString());
                txtChenhLech.EditValue = double.Parse(dr["PKH_ChenhLech"].ToString());
                txtGhiChu.Text = dr["PKH_GhiChu"].ToString().Trim();
                
            }
        }
        public frmKiemKeHang()
        {
            InitializeComponent();
        }

        private void frmKiemKeHang_Load(object sender, EventArgs e)
        {
            dateNgayLap.EditValue = DateTime.Now;
            cboTuyChon.Text = "Hôm nay";
            LayDSMatHangDropDown();
            btnXem_Click(null, null);
            btnThem_Click(null, null);
        }

        private void frmKiemKeHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisplayBackgroung();
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

        private void btnXem_Click(object sender, EventArgs e)
        {
            TTHWait.ShowWait();
            try
            {

                string tungay = ((DateTime)dateTuNgay.EditValue).ToString("dd/MM/yyyy");
                string denngay = ((DateTime)dateDenNgay.EditValue).ToString("dd/MM/yyyy");
                string sql = "";
                sql += "select PKH_ID, PKH_KyHieu, PKH_NgayLap, PKH_TonHeThong, PKH_TonThucTe, PKH_ChenhLech, MH_Ten from PhieuKiemHang a left join MatHang b on a.PKH_MH_ID = b.MH_ID ";
                sql += "where convert(DateTime,convert(varchar(10),PKH_NgayLap,103),103) >= convert(datetime, '" + tungay + "',103) and convert(DateTime,convert(varchar(10),PKH_NgayLap,103),103) <= convert(datetime, '" + denngay + "',103)      ";
                sql += "order by PKH_ThuTu desc ";
                DataAccess cls = new DataAccess();
                grcData.DataSource = cls.GetDataTable(sql);
                grvData.BestFitColumns();
                TTHWait.CloseWait();
            }
            catch (Exception ex)
            {
                TTHWait.CloseWait();
                TTHMessage.ShowMessageError(ex.ToString());
            }
        }
        public Boolean XoaPhieuKiemHang(string id)
        {
            DataAccess cls = new DataAccess();
            string sql = "delete PhieuKiemHang where PKH_ID = '" + id + "'";
            return cls.ExecuteNonQuery(sql);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Xoa", "barKiemKeHang"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện chức năng này!");
                return;
            }
            try
            {
                if (grvData.RowCount == 0) return;
                DataRow row = grvData.GetFocusedDataRow();
                string id = row["PKH_ID"].ToString().Trim();
                //Xoa mot dong
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa dòng được chọn không?", Info.tenphanmem, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!XoaPhieuKiemHang(id))
                        TTHMessage.ShowMessageWarming("Không thể xóa dòng này!");
                    else
                    {
                        row.Delete();
                        TTHMessage.ShowMessageInfomation("Đã xóa thành công!");
                        btnThem_Click(null, null);
                    }
                }
            }
            catch (Exception)
            {
                TTHMessage.ShowMessageError("Xin chọn dòng muốn xóa!");

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Them", "barKiemKeHang"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện chức năng này!");
                return;
            }
            issua = false;
            pkh_id = DateTime.Now.ToString("yyMMddHHmmss");
            TaoKyHieu();
            glkuMatHang.EditValue = "";
            txtTonThucTe.EditValue = 0;
            txtTonHeThong.EditValue = 0;
            txtChenhLech.EditValue = 0;
            txtGhiChu.Text = "";
            glkuMatHang.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (issua)
            {
                if (!Info.KiemTraQuyen("Q_Sua", "barKiemKeHang"))
                {
                    TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                    return;
                }
            }
            else
            {
                if (!Info.KiemTraQuyen("Q_Them", "barKiemKeHang"))
                {
                    TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                    return;
                }
            }
            if (glkuMatHang.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa chọn mặt hàng.");
                glkuMatHang.Focus();
                return;

            }
            if (!issua) TaoKyHieu();
            Boolean ok = false;
            if (issua) ok = SuaPhieuKiemHang();
            else ok = ThemPhieuKiemHang();

            if (ok)
            {


                btnXem_Click(null, null);

                TTHMessage.ShowMessageInfomation("Đã lưu thành công!");
                btnThem_Click(null, null);
            }
            else TTHMessage.ShowMessageWarming("Không thể lưu. Xin kiểm tra lại thông tin.");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void glkuvMatHang_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            BeginInvoke(new Action(() =>
            {
                view.FocusedRowHandle = 0;
            }));
        }

        private void txtTonThucTe_MouseDown(object sender, MouseEventArgs e)
        {
            txtTonThucTe.SelectAll();
        }

        private void glkuMatHang_EditValueChanged(object sender, EventArgs e)
        {
            if (glkuMatHang.Text.Length > 0)
            {
                txtTonHeThong.EditValue = LayTonHienTai(glkuMatHang.EditValue.ToString().Trim());
                txtChenhLech.EditValue = double.Parse(txtTonThucTe.EditValue.ToString()) - double.Parse(txtTonHeThong.EditValue.ToString());
            }
        }

        private void txtTonThucTe_EditValueChanged(object sender, EventArgs e)
        {
            txtChenhLech.EditValue = double.Parse(txtTonThucTe.EditValue.ToString()) - double.Parse(txtTonHeThong.EditValue.ToString());
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            if (grvData.RowCount == 0) return;
            try
            {
                DataRow dr = grvData.GetFocusedDataRow();
                pkh_id = dr["PKH_ID"].ToString().Trim();
                LayThongTinPhieuKiemHang(pkh_id);
                issua = true;
            }
            catch (Exception ex)
            {

                TTHMessage.ShowMessageError(ex.ToString());
            }
        }
        public void SetMatHang(string s)
        {
            glkuMatHang.EditValue = s;
        }
        private void glkuMatHang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                frmMatHangUpdate frm = new frmMatHangUpdate();
                frm.frmText = "MẶT HÀNG [Thêm]";
                //frm.lh_id = lh_id;
                frm.LayDSMatHang = new frmMatHangUpdate.GetDataTableDelegate(LayDSMatHangDropDown);
                frm.SetMatHang = new frmMatHangUpdate.SetMatHangDelegate(SetMatHang);
                frm.ShowDialog();
            }
        }
    }
}