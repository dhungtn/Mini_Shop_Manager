using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.Utils.Paint;
namespace MyRMS.DanhMuc
{
    public partial class frmNhaCungCap : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void DisplayObject();
        public DisplayObject DisplayBackgroung;
        GridViewFilterHelper filterHelper;
        public frmNhaCungCap()
        {
            InitializeComponent();
            filterHelper = new GridViewFilterHelper(grvData);
        }
        
        public void AddDoiTac(string DT_ID, string DT_Ma, string DT_Ten, string DT_DiaChi, string DT_DienThoai, string DT_Email, string DT_MaSoThue, string DT_GhiChu, Boolean DT_KichHoat, string DT_TuKhoa)
        {
            TTHWait.ShowWait();
            //WaitDialogForm dg = new WaitDialogForm("Xin chờ trong giây lát!", "Đang load dữ liệu...");
            DataTable dt = (DataTable)grcData.DataSource;
            DataRow dr = dt.NewRow();
            dr["DT_ID"] = DT_ID;
            dr["DT_Ma"] = DT_Ma;
            dr["DT_Ten"] = DT_Ten;
            dr["DT_DiaChi"] = DT_DiaChi;
            dr["DT_DienThoai"] = DT_DienThoai;
            dr["DT_Email"] = DT_Email;
            dr["DT_MaSoThue"] = DT_MaSoThue;
            dr["DT_GhiChu"] = DT_GhiChu;
            dr["DT_KichHoat"] = DT_KichHoat;
            dr["DT_TuKhoa"] = DT_TuKhoa;
            //dr["DT_NoDau"] = DT_KhoiTaoNo;
            int pos = -1;
            if (grvData.RowCount > 0)
            {
                try
                {
                    pos = grvData.FocusedRowHandle;
                    if (pos < 0)
                        pos = -1;
                    else grvData.UnselectRow(pos);
                }
                catch (Exception)
                {
                    pos = -1;

                }

            }
            dt.Rows.InsertAt(dr, pos + 1);
            grcData.DataSource = dt;
            grvData.ExpandAllGroups();
            grvData.FocusedRowHandle = pos + 1;
            grvData.BestFitColumns();
            //dg.Close();
            TTHWait.CloseWait();
        }
        public void EditDoiTac(string DT_ID, string DT_Ma, string DT_Ten, string DT_DiaChi, string DT_DienThoai, string DT_Email, string DT_MaSoThue, string DT_GhiChu, Boolean DT_KichHoat, string DT_TuKhoa)
        {
            try
            {
                //sửa loại hàng và cập nhật lại giá trị
                grvData.SetFocusedRowCellValue("DT_ID", DT_ID);
                grvData.SetFocusedRowCellValue("DT_Ma", DT_Ma);
                grvData.SetFocusedRowCellValue("DT_Ten", DT_Ten);
                grvData.SetFocusedRowCellValue("DT_DiaChi", DT_DiaChi);
                grvData.SetFocusedRowCellValue("DT_DienThoai", DT_DienThoai);
                grvData.SetFocusedRowCellValue("DT_Email", DT_Email);
                grvData.SetFocusedRowCellValue("DT_MaSoThue", DT_MaSoThue);
                grvData.SetFocusedRowCellValue("DT_GhiChu", DT_GhiChu);
                grvData.SetFocusedRowCellValue("DT_KichHoat", DT_KichHoat);
                grvData.SetFocusedRowCellValue("DT_TuKhoa", DT_TuKhoa);
                //grvData.SetFocusedRowCellValue("DT_NoDau", DT_KhoiTaoNo);
                grvData.BestFitColumns();
            }
            catch (Exception)
            {


            }

        }
        public Boolean XoaDoiTac(string idkhncc)
        {
            string sql = "delete DoiTac where DT_ID = '" + idkhncc + "'";
            return cls.ExecuteNonQuery(sql);
        }
        

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Them", "barNhaCungCap"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            frmNhaCungCapUpdate frm = new frmNhaCungCapUpdate();
            frm.frmText = "NHÀ CUNG CẤP [Thêm]";
            frm.AddDoiTac = new frmNhaCungCapUpdate.AddDoiTacDelegate(AddDoiTac);
            frm.ShowDialog();
        }

        

        private void txtTuKhoa_EditValueChanged(object sender, EventArgs e)
        {
            //filterHelper.ActiveFilter = txtTuKhoa.Text;
            filterHelper.ActiveFilter = TTHUtils.LoaiBoDauTiengViet( txtTuKhoa.Text);
        }

        private void grvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //GridView view = (GridView)sender;
            //if (!view.OptionsView.ShowAutoFilterRow || !view.IsDataRow(e.RowHandle))
            //    return;

            //string filterCellText = view.GetRowCellDisplayText(GridControl.AutoFilterRowHandle, e.Column);
            //if (String.IsNullOrEmpty(filterCellText))
            //    return;

            //int filterTextIndex = e.DisplayText.IndexOf(filterCellText, StringComparison.CurrentCultureIgnoreCase);
            //if (filterTextIndex == -1)
            //    return;

            //XPaint.Graphics.DrawMultiColorString(e.Cache, e.Bounds, e.DisplayText, filterCellText, e.Appearance, Color.Black, Color.Gold, false, filterTextIndex);
            //e.Handled = true;
        }

        private void rbtnSua_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            
        }

        private void rbtnSua_Click(object sender, EventArgs e)
        {
            TTHMessage.ShowMessageInfomation("aaa");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Sua", "barNhaCungCap"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            if (grvData.RowCount > 0)
            {
                frmNhaCungCapUpdate frm = new frmNhaCungCapUpdate();
                frm.issua = true;
                frm.frmText = "NHÀ CUNG CẤP [Sửa]";
                frm.EditDoiTac = new frmNhaCungCapUpdate.EditDoiTacDelegate(EditDoiTac);
                DataRow row = grvData.GetFocusedDataRow();
                frm.dt_id = row["DT_ID"].ToString().Trim();
                frm.ShowDialog();
            }
            else TTHMessage.ShowMessageWarming("Chưa có dòng nào được chọn!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Xoa", "barNhaCungCap"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            try
            {
                if (grvData.RowCount == 0) return;
                DataRow row = grvData.GetFocusedDataRow();
                string dt_id = row["DT_ID"].ToString().Trim();
                
                //Xoa mot dong
                if (TTHMessage.ShowMessageConfirm("Bạn có chắc muốn xóa dòng được chọn không?") == DialogResult.Yes)
                {

                    if (!XoaDoiTac(dt_id))
                        TTHMessage.ShowMessageWarming("Không thể xóa dòng này.");
                    else
                    {
                        row.Delete();
                        TTHMessage.ShowMessageInfomation("Đã xóa thành công.");
                        
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
            frmNhaCungCap_Load(null, null);
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(null, null);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_In", "barNhaCungCap"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            FastReport.Report rpt = new FastReport.Report();

            string sql = "select DT_Ten,DT_DiaChi,DT_DienThoai, DT_Email, DT_MaSoThue,  DT_GhiChu, DT_KichHoat ";
            sql += "from DoiTac where DT_Loai = 'NCC' and  DT_DV_ID = '" + Info.dv_id + "'    ";
            sql += "order by DT_Ten";
            rpt.Load(Application.StartupPath + "\\report\\DMNhaCungCap.frx");
            rpt.RegisterData(cls.GetDataTable(sql), "Table");
            rpt.SetParameterValue("tendoanhnghiep", Info.dv_ten);
            rpt.SetParameterValue("diachidoanhnghiep", Info.dv_diachi);
            rpt.SetParameterValue("dienthoaidoanhnghiep", Info.dv_dienthoai);
            rpt.Show();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Xuat", "barNhaCungCap"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            TTHUtils.ExportToExcelFile(grvData, "DMNhaCungCap");
        }
        public void LayDSDoiTac()
        {
            TTHWait.ShowWait();
            string sql = "";
            sql = "select DT_ID, DT_Ma, DT_Ten, DT_DiaChi, DT_DienThoai, DT_Email, DT_MaSoThue, DT_KichHoat, DT_GhiChu,  DT_TuKhoa from DoiTac where DT_Loai = 'NCC' and DT_DV_ID = '" + Info.dv_id + "'   ";
            sql += "order by DT_Ten ";
            grcData.DataSource = cls.GetDataTable(sql);
            grvData.BestFitColumns();
            grvData.ExpandAllGroups();
            TTHWait.CloseWait();
        }
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            LayDSDoiTac();
        }

        private void barThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnThem_Click(null, null);
        }

        private void barSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnSua_Click(null, null);
        }

        private void barXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnXoa_Click(null, null);
        }

        private void barTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnTaiLai_Click(null, null);
        }

        private void barIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnIn_Click(null, null);
        }

        private void barExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnExcel_Click(null, null);
        }

        private void barDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnDong_Click(null, null);
        }
    }
}