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
    public partial class frmCaLamViec : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void DisplayObject();
        public DisplayObject DisplayBackgroung;
        GridViewFilterHelper filterHelper;
        public frmCaLamViec()
        {
            InitializeComponent();
            filterHelper = new GridViewFilterHelper(grvData);
        }

        public void AddCaLamViec(string CLV_ID, string CLV_Ten, string CLV_GhiChu, Boolean CLV_KichHoat, string CLV_TuKhoa)
        {
            TTHWait.ShowWait();
            //WaitDialogForm dg = new WaitDialogForm("Xin chờ trong giây lát!", "Đang load dữ liệu...");
            DataTable dt = (DataTable)grcData.DataSource;
            DataRow dr = dt.NewRow();
            dr["CLV_ID"] = CLV_ID;
            dr["CLV_Ten"] = CLV_Ten;
            dr["CLV_GhiChu"] = CLV_GhiChu;
            dr["CLV_KichHoat"] = CLV_KichHoat;
            dr["CLV_TuKhoa"] = CLV_TuKhoa;
            //dr["CLV_NoDau"] = CLV_KhoiTaoNo;
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
        public void EditCaLamViec(string CLV_ID,  string CLV_Ten,  string CLV_GhiChu, Boolean CLV_KichHoat, string CLV_TuKhoa)
        {
            try
            {
                //sửa loại hàng và cập nhật lại giá trị
                grvData.SetFocusedRowCellValue("CLV_ID", CLV_ID);
                grvData.SetFocusedRowCellValue("CLV_Ten", CLV_Ten);
                grvData.SetFocusedRowCellValue("CLV_GhiChu", CLV_GhiChu);
                grvData.SetFocusedRowCellValue("CLV_KichHoat", CLV_KichHoat);
                grvData.SetFocusedRowCellValue("CLV_TuKhoa", CLV_TuKhoa);
                //grvData.SetFocusedRowCellValue("CLV_NoDau", CLV_KhoiTaoNo);
                grvData.BestFitColumns();
            }
            catch (Exception)
            {


            }

        }
        public Boolean XoaCaLamViec(string idkhncc)
        {
            string sql = "delete CaLamViec where CLV_ID = '" + idkhncc + "'";
            return cls.ExecuteNonQuery(sql);
        }
        

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Them", "barCaLamViec"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            frmCaLamViecUpdate frm = new frmCaLamViecUpdate();
            frm.frmText = "CA LÀM VIỆC [Thêm]";
            frm.AddCaLamViec = new frmCaLamViecUpdate.AddCaLamViecDelegate(AddCaLamViec);
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
            if (!Info.KiemTraQuyen("Q_Sua", "barCaLamViec"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            if (grvData.RowCount > 0)
            {
                frmCaLamViecUpdate frm = new frmCaLamViecUpdate();
                frm.issua = true;
                frm.frmText = "CA LÀM VIỆC [Sửa]";
                frm.EditCaLamViec = new frmCaLamViecUpdate.EditCaLamViecDelegate(EditCaLamViec);
                DataRow row = grvData.GetFocusedDataRow();
                frm.clv_id = row["CLV_ID"].ToString().Trim();
                frm.ShowDialog();
            }
            else TTHMessage.ShowMessageWarming("Chưa có dòng nào được chọn!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Xoa", "barCaLamViec"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            try
            {
                if (grvData.RowCount == 0) return;
                DataRow row = grvData.GetFocusedDataRow();
                string dt_id = row["CLV_ID"].ToString().Trim();
                
                //Xoa mot dong
                if (TTHMessage.ShowMessageConfirm("Bạn có chắc muốn xóa dòng được chọn không?") == DialogResult.Yes)
                {

                    if (!XoaCaLamViec(dt_id))
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
            frmCaLamViec_Load(null, null);
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(null, null);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_In", "barCaLamViec"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            FastReport.Report rpt = new FastReport.Report();

            string sql = "select CLV_ID, CLV_Ten,  CLV_GhiChu, CLV_KichHoat ";
            sql += "from CaLamViec where  CLV_DV_ID = '" + Info.dv_id + "'   ";
            sql += "order by CLV_Ten";
            rpt.Load(Application.StartupPath + "\\report\\DMCaLamViec.frx");
            rpt.RegisterData(cls.GetDataTable(sql), "Table");
            rpt.SetParameterValue("tendoanhnghiep", Info.dv_ten);
            rpt.SetParameterValue("diachidoanhnghiep", Info.dv_diachi);
            rpt.SetParameterValue("dienthoaidoanhnghiep", Info.dv_dienthoai);
            rpt.Show();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Xuat", "barCaLamViec"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            TTHUtils.ExportToExcelFile(grvData, "DMCaLamViec");
        }
        public void LayDSCaLamViec()
        {
            TTHWait.ShowWait();
            string sql = "";
            sql = "select CLV_ID,  CLV_Ten, CLV_KichHoat, CLV_GhiChu,  CLV_TuKhoa from CaLamViec  ";
            sql += "order by CLV_Ten ";
            grcData.DataSource = cls.GetDataTable(sql);
            grvData.BestFitColumns();
            grvData.ExpandAllGroups();
            TTHWait.CloseWait();
        }
        private void frmCaLamViec_Load(object sender, EventArgs e)
        {
            LayDSCaLamViec();
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