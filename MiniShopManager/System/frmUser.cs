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
namespace MyRMS.HeThong
{
    public partial class frmNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void DisplayObject();
        public DisplayObject DisplayBackgroung;
        GridViewFilterHelper filterHelper;
        public frmNguoiDung()
        {
            InitializeComponent();
            filterHelper = new GridViewFilterHelper(grvData);
        }
        public void LayDSVaiTro()
        {
            trlVaiTro.Nodes.Clear();
            TreeListNode node = trlVaiTro.AppendNode(null, null);
            node.SetValue("VT_ID", "");
            node.SetValue("VT_Ten", "TẤT CẢ");
            string sql = "select VT_ID, VT_Ten from VaiTro where VT_KichHoat = 'True' order by VT_Ten ";
            DataTable dt = cls.GetDataTable(sql);
            DataTable dtlh = new DataTable();
            foreach (DataRow dr in dt.Rows)
            {
                TreeListNode childnode = trlVaiTro.AppendNode(null, null);
                childnode.SetValue("VT_ID", dr["VT_ID"].ToString().Trim());
                childnode.SetValue("VT_Ten", dr["VT_Ten"].ToString().Trim());

            }
            trlVaiTro.ExpandAll();
        }
        public void AddNguoiDung(string ND_ID,  string ND_Ten, string ND_DiaChi, string ND_DienThoai, string ND_GhiChu, Boolean ND_KichHoat, string ND_TuKhoa)
        {
            TTHWait.ShowWait();
            //WaitDialogForm dg = new WaitDialogForm("Xin chờ trong giây lát!", "Đang load dữ liệu...");
            DataTable dt = (DataTable)grcData.DataSource;
            DataRow dr = dt.NewRow();
            dr["ND_ID"] = ND_ID;
            dr["ND_Ten"] = ND_Ten;
            dr["ND_DiaChi"] = ND_DiaChi;
            dr["ND_DienThoai"] = ND_DienThoai;
            dr["ND_GhiChu"] = ND_GhiChu;
            dr["ND_KichHoat"] = ND_KichHoat;
            dr["ND_TuKhoa"] = ND_TuKhoa;
            //dr["ND_NoDau"] = ND_KhoiTaoNo;
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
        public void EditNguoiDung(string ND_ID, string ND_Ten, string ND_DiaChi, string ND_DienThoai, string ND_GhiChu, Boolean ND_KichHoat, string ND_TuKhoa)
        {
            try
            {
                //sửa loại hàng và cập nhật lại giá trị
                grvData.SetFocusedRowCellValue("ND_ID", ND_ID);
                grvData.SetFocusedRowCellValue("ND_Ten", ND_Ten);
                grvData.SetFocusedRowCellValue("ND_DiaChi", ND_DiaChi);
                grvData.SetFocusedRowCellValue("ND_DienThoai", ND_DienThoai);
                grvData.SetFocusedRowCellValue("ND_GhiChu", ND_GhiChu);
                grvData.SetFocusedRowCellValue("ND_KichHoat", ND_KichHoat);
                grvData.SetFocusedRowCellValue("ND_TuKhoa", ND_TuKhoa);
                //grvData.SetFocusedRowCellValue("ND_NoDau", ND_KhoiTaoNo);
                grvData.BestFitColumns();
            }
            catch (Exception)
            {


            }

        }
        public Boolean XoaNguoiDung(string idnd)
        {
            string sql = "delete NguoiDung where ND_ID = '" + idnd + "'";
            return cls.ExecuteNonQuery(sql);
        }
      

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void AddVaiTro(string vt_id, string vt_ten)
        {
            TreeListNode node = trlVaiTro.AppendNode(null, null);
            node.SetValue("VT_ID", vt_id);
            node.SetValue("VT_Ten", vt_ten);
            trlVaiTro.FocusedNode = node;
        }
        private void barThemNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmVaiTroUpdate frm = new frmVaiTroUpdate();
            frm.frmText = "NHÓM NGƯỜI DÙNG [Thêm]";
            frm.AddVaiTroDelegate = new frmVaiTroUpdate.AddVaiTro(AddVaiTro);
            frm.ShowDialog();
        }
        public void EditVaiTro(string vt_id, string vt_ten)
        {
            TreeListNode node = trlVaiTro.FocusedNode;
            node.SetValue("VT_ID", vt_id);
            node.SetValue("VT_Ten", vt_ten);
        }
        private void barSuaNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                TreeListNode node = trlVaiTro.FocusedNode;
                string dt_id = node.GetValue("VT_ID").ToString().Trim();
                if (dt_id.Length == 0)
                {
                    TTHMessage.ShowMessageWarming("Bạn chưa chọn nhóm khách hàng muốn sửa!");
                    return;
                }
                frmVaiTroUpdate frm = new frmVaiTroUpdate();
                frm.frmText = "NGƯỜI DÙNG [Sửa]";
                frm.issua = true;
                frm.vt_id = dt_id;
                frm.EditVaiTroDelegate = new frmVaiTroUpdate.EditVaiTro(EditVaiTro);
                frm.Show();
            }
            catch (Exception)
            {
                
                
            }
            

        }
        public Boolean XoaVaiTro(string id)
        {
            string sql = "delete VaiTro where VT_ID = '" + id + "' ";
            return cls.ExecuteNonQuery(sql);
        }
        private void barXoaLoai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                TreeListNode node = trlVaiTro.FocusedNode;
                if(node.GetValue("VT_ID").ToString() == "system")
                {
                    TTHMessage.ShowMessageWarming("Không thể xóa vai trò này!");
                    return;
                }
                if (TTHMessage.ShowMessageConfirm("Bạn có chắc muốn xóa không?") == DialogResult.Yes)
                {
                    if (XoaVaiTro(node.GetValue("VT_ID").ToString()))
                    {
                        TTHMessage.ShowMessageInfomation("Đã xóa thành công!");
                        trlVaiTro.DeleteNode(node);
                    }
                    else
                    {
                        TTHMessage.ShowMessageError("Không thể xóa!");
                    }
                }
            }
            catch (Exception)
            {
                
               
            }
            



        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Them", "barNguoiDung"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            TreeListNode node = trlVaiTro.FocusedNode;
            frmNguoiDungUpdate frm = new frmNguoiDungUpdate();
            frm.frmText = "NGƯỜI DÙNG [Thêm]";
            frm.vt_id = node.GetValue("VT_ID").ToString().Trim();
            frm.AddNguoiDung = new frmNguoiDungUpdate.AddNguoiDungDelegate(AddNguoiDung);
            frm.ShowDialog();
        }

        private void trlVaiTro_AfterFocusNode(object sender, NodeEventArgs e)
        {
            TTHWait.ShowWait();
            TreeListNode node = trlVaiTro.FocusedNode;
            string vt_id = node.GetValue("VT_ID").ToString().Trim();
            string sql = "";
            sql = "select ND_ID,  ND_Ten, ND_DiaChi, ND_DienThoai, ND_KichHoat, ND_GhiChu,  ND_TuKhoa from NguoiDung   ";
            if (vt_id.Length > 0)
            {
                sql += "where ND_VT_ID = '" + vt_id + "' ";
            }
            
            sql += "order by ND_Ten ";
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
            if (!Info.KiemTraQuyen("Q_Sua", "barNguoiDung"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            if (grvData.RowCount > 0)
            {
                frmNguoiDungUpdate frm = new frmNguoiDungUpdate();
                frm.issua = true;
                frm.frmText = "NGƯỜI DÙNG [Sửa]";
                frm.EditNguoiDung = new frmNguoiDungUpdate.EditNguoiDungDelegate(EditNguoiDung);
                DataRow row = grvData.GetFocusedDataRow();
                frm.nd_id = row["ND_ID"].ToString().Trim();
                frm.ShowDialog();
            }
            else TTHMessage.ShowMessageWarming("Chưa có dòng nào được chọn!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Xoa", "barNguoiDung"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            try
            {
                if (grvData.RowCount == 0) return;

                DataRow row = grvData.GetFocusedDataRow();

                string nd_id = row["ND_ID"].ToString().Trim();
                if (nd_id == "admin")
                {
                    TTHMessage.ShowMessageWarming("Đây là người dùng mặc định nên không thể xóa!");
                    return;
                }
                //Xoa mot dong
                if (TTHMessage.ShowMessageConfirm("Bạn có chắc muốn xóa dòng được chọn không?") == DialogResult.Yes)
                {

                    if (!XoaNguoiDung(nd_id))
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
            frmNguoiDung_Load(null, null);
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(null, null);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_In", "barNguoiDung"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            FastReport.Report rpt = new FastReport.Report();
            TreeListNode node = trlVaiTro.FocusedNode;
            string vt_id = node.GetValue("VT_ID").ToString().Trim();
            string sql = "select VT_Ten, ND_Ten,ND_DiaChi,ND_DienThoai,  ND_GhiChu, ND_KichHoat ";
            sql += "from NguoiDung left join VaiTro on ND_VT_ID = VT_ID ";
            sql += "where ND_DV_ID = '" + Info.dv_id + "'   ";
            if (vt_id.Length > 0)
                sql += "and ND_VT_ID = '" + vt_id + "' ";
            sql += "order by VT_Ten, ND_Ten";
            rpt.Load(Application.StartupPath + "\\report\\NguoiDung.frx");
            rpt.RegisterData(cls.GetDataTable(sql), "Table");
            rpt.SetParameterValue("tendoanhnghiep", Info.dv_ten);
            rpt.SetParameterValue("diachidoanhnghiep", Info.dv_diachi);
            rpt.SetParameterValue("dienthoaidoanhnghiep", Info.dv_dienthoai);
            rpt.Show();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Xuat", "barNguoiDung"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            TTHUtils.ExportToExcelFile(grvData, "DMNguoiDung");
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

        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            LayDSVaiTro();
            trlVaiTro_AfterFocusNode(null, null);
        }

    }
}