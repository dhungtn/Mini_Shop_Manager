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
    public partial class frmChiTien : DevExpress.XtraEditors.XtraForm
    {
        public delegate void DisplayBackgroungDelegate();
        public DisplayBackgroungDelegate DisplayBackgroung;
        DataAccess cls = new DataAccess();
        public Boolean issua = false;
        public string ptc_id = "";
        public frmChiTien()
        {
            InitializeComponent();
        }
        public void TaoKyHieu(string loai)
        {
            string sql = "select distinct isnull(max(right(PTC_KyHieu,4)),0) from PhieuThuChi where PTC_DV_ID = '" + Info.dv_id + "' and PTC_Loai = '" + loai + "' and convert(varchar(10),PTC_NgayLap, 103) = '" + ((DateTime)dateNgayLap.EditValue).ToString("dd/MM/yyyy") + "'";
            txtKyHieu.EditValue = loai + ((DateTime)dateNgayLap.EditValue).ToString("yyMMdd") + "-" + string.Format("{0,4:0000}", cls.GetNumberValue(sql) + 1);
        }
        private void frmChiTien_Load(object sender, EventArgs e)
        {
            dateNgayLap.EditValue = DateTime.Now;
            cboTuyChon.Text = "Hôm nay";
            btnXem_Click(null, null);
            btnThem_Click(null, null);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Them", "barChiTien"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện chức năng này!");
                return;
            }
            issua = false;
            //dateNgayLap.EditValue = DateTime.ParseExact(((DateTime)dateNgayLap.EditValue).ToString("yyyyMMdd") + string.Format("{0,2:00}", DateTime.Now.Hour) + string.Format("{0,2:00}", DateTime.Now.Minute) + string.Format("{0,2:00}", DateTime.Now.Second), "yyyyMMddHHmmss", null);
            ptc_id = DateTime.Now.ToString("yyMMddHHmmss");
            TaoKyHieu("PCT");
            txtLyDo.Text = "";
            txtSoTien.EditValue = 0;
            txtGhiChu.Text = "";
            txtLyDo.Focus();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            TTHWait.ShowWait();
            try
            {

                string tungay = ((DateTime)dateTuNgay.EditValue).ToString("dd/MM/yyyy");
                string denngay = ((DateTime)dateDenNgay.EditValue).ToString("dd/MM/yyyy");
                string sql = "";
                sql += "select * from PhieuThuChi ";
                sql += "where convert(DateTime,convert(varchar(10),PTC_NgayLap,103),103) >= convert(datetime, '" + tungay + "',103) and convert(DateTime,convert(varchar(10),PTC_NgayLap,103),103) <= convert(datetime, '" + denngay + "',103)      ";
                sql += "order by PTC_ThuTu desc ";
                DataAccess cls = new DataAccess();
                grcData.DataSource = cls.GetDataTable(sql);
                grvData.BestFitColumns();
                TTHWait.CloseWait();
            }
            catch (Exception ex)
            {
                TTHWait.CloseWait();
                TTHMessage.ShowMessageError( ex.ToString());
            }
        }
        public Boolean ThemPhieuThuChi()
        {
            DataAccess cls = new DataAccess();
            string[] field = { "PTC_ID", "PTC_KyHieu", "PTC_NgayLap", "PTC_LyDo", "PTC_SoTien", "PTC_SoTienThu", "PTC_SoTienChi", "PTC_GhiChu", "PTC_Loai", "PTC_ThuTu", "PTC_DV_ID" };
            object[] value = { (object)ptc_id, (object)txtKyHieu.Text.Trim(), (object)((DateTime)dateNgayLap.EditValue), (object)txtLyDo.Text.Trim(), (object)double.Parse(txtSoTien.EditValue.ToString()), 0, (object)double.Parse(txtSoTien.EditValue.ToString()), (object)txtGhiChu.Text.Trim(), (object)"PCT", (object)(((DateTime)dateNgayLap.EditValue).ToString("yyMMddHHmmss") + ptc_id), (object)Info.dv_id };
            return cls.AddRecord("PhieuThuChi", field, value);
        }
        public Boolean SuaPhieuThuChi()
        {
            DataAccess cls = new DataAccess();
            string[] field = { "PTC_KyHieu", "PTC_NgayLap", "PTC_LyDo", "PTC_SoTien", "PTC_SoTienThu", "PTC_SoTienChi", "PTC_GhiChu", "PTC_Loai", "PTC_ThuTu", "PTC_DV_ID" };
            object[] value = { (object)txtKyHieu.Text.Trim(), (object)((DateTime)dateNgayLap.EditValue), (object)txtLyDo.Text.Trim(), (object)double.Parse(txtSoTien.EditValue.ToString()), 0, (object)double.Parse(txtSoTien.EditValue.ToString()), (object)txtGhiChu.Text.Trim(), (object)"PCT", (object)(((DateTime)dateNgayLap.EditValue).ToString("yyMMddHHmmss") + ptc_id), (object)Info.dv_id };
            string[] fieldwhere = { "PTC_ID" };
            object[] objwhere = { (object)ptc_id };
            return cls.EditRecord("PhieuThuChi", field, value, fieldwhere, objwhere);
        }
        public void LayThongTinPhieuThuChi(string ptc_id)
        {
            DataAccess cls = new DataAccess();
            string sql = "select * from PhieuThuChi where PTC_ID = '" + ptc_id + "'";
            foreach (DataRow dr in cls.GetDataTable(sql).Rows)
            {
                dateNgayLap.EditValue = (DateTime)dr["PTC_NgayLap"];
                txtKyHieu.Text = dr["PTC_KyHieu"].ToString().Trim();
                txtLyDo.Text = dr["PTC_LyDo"].ToString().Trim();
                txtSoTien.EditValue = double.Parse(dr["PTC_SoTien"].ToString());
                txtGhiChu.Text = dr["PTC_GhiChu"].ToString().Trim();
                txtLyDo.Focus();
                txtLyDo.SelectAll();
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (issua)
            {
                if (!Info.KiemTraQuyen("Q_Sua", "barChiTien"))
                {
                    TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                    return;
                }
            }
            else
            {
                if (!Info.KiemTraQuyen("Q_Them", "barChiTien"))
                {
                    TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                    return;
                }
            }
            if (txtLyDo.Text.Trim().Length == 0)
            {
                TTHMessage.ShowMessageWarming( "Bạn chưa nhập lý do.");
                txtLyDo.Focus();
                return;

            }
            if (double.Parse(txtSoTien.EditValue.ToString()) == 0)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa nhập số tiền.");
                txtSoTien.Focus();
                return;

            }
            if (!issua) TaoKyHieu("PCT");
            Boolean ok = false;
            if (issua) ok = SuaPhieuThuChi();
            else ok = ThemPhieuThuChi();

            if (ok)
            {

                
                btnXem_Click(null, null);
                
                TTHMessage.ShowMessageInfomation("Đã lưu thành công!");
                btnThem_Click(null, null);
            }
            else TTHMessage.ShowMessageWarming( "Không thể lưu. Xin kiểm tra lại thông tin.");
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            if (grvData.RowCount == 0) return;
            try
            {
                DataRow dr = grvData.GetFocusedDataRow();
                ptc_id = dr["PTC_ID"].ToString().Trim();
                LayThongTinPhieuThuChi(ptc_id);
                issua = true;
            }
            catch (Exception ex)
            {

                TTHMessage.ShowMessageError(ex.ToString());
            }
           
            
            
        }
        private void dateNgayLap_EditValueChanged(object sender, EventArgs e)
        {
            TaoKyHieu("PCT");
        }
        public Boolean XoaPhieuThuChi(string ptc_id)
        {
            DataAccess cls = new DataAccess();
            string sql = "delete PhieuThuChi where PTC_ID = '" + ptc_id + "'";
            return cls.ExecuteNonQuery(sql);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Xoa", "barChiTien"))
            {
                TTHMessage.ShowMessageWarming( "Bạn không có quyền thực hiện chức năng này!");
                return;
            }
            try
            {
                if (grvData.RowCount == 0) return;
                DataRow row = grvData.GetFocusedDataRow();
                string ptc_id = row["PTC_ID"].ToString().Trim();
                //Xoa mot dong
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa dòng được chọn không?", Info.tenphanmem, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!XoaPhieuThuChi(ptc_id))
                        TTHMessage.ShowMessageWarming( "Không thể xóa dòng này!");
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
               TTHMessage.ShowMessageError( "Xin chọn dòng muốn xóa!");

            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void barF1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnThem_Click(null, null);
        }

        private void barF2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnLuu_Click(null, null);
        }

        private void barF12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnDong_Click(null, null);
        }
    }
}