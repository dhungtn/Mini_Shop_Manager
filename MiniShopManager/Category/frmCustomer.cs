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
    public partial class frmKhachHang : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void DisplayObject();
        public DisplayObject DisplayBackgroung;
        GridViewFilterHelper filterHelper;
        public frmKhachHang()
        {
            InitializeComponent();
            filterHelper = new GridViewFilterHelper(grvData);
        }
        public void LayDSNhomDoiTac()
        {
            trlNhomDoiTac.Nodes.Clear();
            TreeListNode node = trlNhomDoiTac.AppendNode(null, null);
            node.SetValue("NDT_ID", "");
            node.SetValue("NDT_Ten", "TẤT CẢ");
            string sql = "select NDT_ID, NDT_Ten from NhomDoiTac where NDT_KichHoat = 'True' and NDT_DV_ID = '" + Info.dv_id + "' order by NDT_Ten ";
            DataTable dt = cls.GetDataTable(sql);
            DataTable dtlh = new DataTable();
            foreach (DataRow dr in dt.Rows)
            {
                TreeListNode childnode = trlNhomDoiTac.AppendNode(null, null);
                childnode.SetValue("NDT_ID", dr["NDT_ID"].ToString().Trim());
                childnode.SetValue("NDT_Ten", dr["NDT_Ten"].ToString().Trim());

            }
            trlNhomDoiTac.ExpandAll();
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
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LayDSNhomDoiTac();
            trlNhomDoiTac_AfterFocusNode(null, null);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void AddNhomDoiTac(string ndt_id, string ndt_ten)
        {
            TreeListNode node = trlNhomDoiTac.AppendNode(null, null);
            node.SetValue("NDT_ID", ndt_id);
            node.SetValue("NDT_Ten", ndt_ten);
            trlNhomDoiTac.FocusedNode = node;
        }
        private void barThemNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Them", "barKhachHang"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            frmNhomDoiTacUpdate frm = new frmNhomDoiTacUpdate();
            frm.frmText = "NHÓM KHÁCH HÀNG [Thêm]";
            frm.AddNhomDoiTacDelegate = new frmNhomDoiTacUpdate.AddNhomDoiTac(AddNhomDoiTac);
            frm.ShowDialog();
        }
        public void EditNhomDoiTac(string ndt_id, string ndt_ten)
        {
            TreeListNode node = trlNhomDoiTac.FocusedNode;
            node.SetValue("NDT_ID", ndt_id);
            node.SetValue("NDT_Ten", ndt_ten);
        }
        private void barSuaNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Sua", "barKhachHang"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            try
            {
                TreeListNode node = trlNhomDoiTac.FocusedNode;
                string dt_id = node.GetValue("NDT_ID").ToString().Trim();
                if (dt_id.Length == 0)
                {
                    TTHMessage.ShowMessageWarming("Bạn chưa chọn nhóm khách hàng muốn sửa!");
                    return;
                }
                frmNhomDoiTacUpdate frm = new frmNhomDoiTacUpdate();
                frm.frmText = "KHÁCH HÀNG [Sửa]";
                frm.issua = true;
                frm.ndt_id = dt_id;
                frm.EditNhomDoiTacDelegate = new frmNhomDoiTacUpdate.EditNhomDoiTac(EditNhomDoiTac);
                frm.Show();
            }
            catch (Exception)
            {
                
                
            }
            

        }
        public Boolean XoaNhomDoiTac(string id)
        {
            string sql = "delete NhomDoiTac where NDT_ID = '" + id + "' ";
            return cls.ExecuteNonQuery(sql);
        }
        private void barXoaLoai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Xoa", "barKhachHang"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            TreeListNode node = trlNhomDoiTac.FocusedNode;

            if (TTHMessage.ShowMessageConfirm("Bạn có chắc muốn xóa không?") == DialogResult.Yes)
            {
                if (XoaNhomDoiTac(node.GetValue("NDT_ID").ToString()))
                {
                    TTHMessage.ShowMessageInfomation("Đã xóa thành công!");
                    trlNhomDoiTac.DeleteNode(node);
                }
                else
                {
                    TTHMessage.ShowMessageError("Không thể xóa!");
                }
            }



        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Them", "barKhachHang"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            TreeListNode node = trlNhomDoiTac.FocusedNode;
            frmKhachHangUpdate frm = new frmKhachHangUpdate();
            frm.frmText = "KHÁCH HÀNG [Thêm]";
            frm.ndt_id = node.GetValue("NDT_ID").ToString().Trim();
            frm.AddDoiTac = new frmKhachHangUpdate.AddDoiTacDelegate(AddDoiTac);
            frm.ShowDialog();
        }

        private void trlNhomDoiTac_AfterFocusNode(object sender, NodeEventArgs e)
        {
            TTHWait.ShowWait();
            TreeListNode node = trlNhomDoiTac.FocusedNode;
            string ndt_id = node.GetValue("NDT_ID").ToString().Trim();
            string sql = "";
            sql = "select DT_ID, DT_Ma, DT_Ten, DT_DiaChi, DT_DienThoai, DT_Email, DT_MaSoThue, DT_KichHoat, DT_GhiChu,  DT_TuKhoa from DoiTac where DT_Loai = 'KH' and DT_DV_ID = '" + Info.dv_id + "'   ";
            if (ndt_id.Length > 0)
            {
                sql += "and DT_NDT_ID = '" + ndt_id + "' ";
            }
            
            sql += "order by DT_Ten ";
            grcData.DataSource = cls.GetDataTable(sql);
            grvData.BestFitColumns();
            grvData.ExpandAllGroups();
            TTHWait.CloseWait();
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



        private void rbtnSua_Click(object sender, EventArgs e)
        {
            TTHMessage.ShowMessageInfomation("aaa");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Sua", "barKhachHang"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            if (grvData.RowCount > 0)
            {
                frmKhachHangUpdate frm = new frmKhachHangUpdate();
                frm.issua = true;
                frm.frmText = "KHÁCH HÀNG [Sửa]";
                frm.EditDoiTac = new frmKhachHangUpdate.EditDoiTacDelegate(EditDoiTac);
                DataRow row = grvData.GetFocusedDataRow();
                frm.dt_id = row["DT_ID"].ToString().Trim();
                frm.ShowDialog();
            }
            else TTHMessage.ShowMessageWarming("Chưa có dòng nào được chọn!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Xoa", "barKhachHang"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            try
            {
                if (grvData.RowCount == 0) return;
                DataRow row = grvData.GetFocusedDataRow();
                string dt_id = row["DT_ID"].ToString().Trim();
                if (dt_id == "kl")
                {
                    TTHMessage.ShowMessageWarming("Đây là khách hàng mặc định nên không thể xóa!");
                    return;
                }
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
            frmKhachHang_Load(null, null);
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(null, null);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_In", "barKhachHang"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            FastReport.Report rpt = new FastReport.Report();
            TreeListNode node = trlNhomDoiTac.FocusedNode;
            string ndt_id = node.GetValue("NDT_ID").ToString().Trim();
            string sql = "select NDT_Ten, DT_Ten,DT_DiaChi,DT_DienThoai, DT_Email, DT_MaSoThue,  DT_GhiChu, DT_KichHoat ";
            sql += "from DoiTac a left join NhomDoiTac b on a.DT_NDT_ID = b.NDT_ID ";
            sql += "where DT_Loai = 'KH' and DT_DV_ID = '" + Info.dv_id + "'   ";
            if (ndt_id.Length > 0)
                sql += "and DT_NDT_ID = '" + ndt_id + "' ";
            sql += "order by NDT_Ten, DT_Ten";
            rpt.Load(Application.StartupPath + "\\report\\DMKhachHang.frx");
            rpt.RegisterData(cls.GetDataTable(sql), "Table");
            rpt.SetParameterValue("tendoanhnghiep", Info.dv_ten);
            rpt.SetParameterValue("diachidoanhnghiep", Info.dv_diachi);
            rpt.SetParameterValue("dienthoaidoanhnghiep", Info.dv_dienthoai);
            rpt.Show();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Xuat", "barKhachHang"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            TTHUtils.ExportToExcelFile(grvData, "DMKhachHang");
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