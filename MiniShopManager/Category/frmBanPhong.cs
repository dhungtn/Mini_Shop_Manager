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
    public partial class frmBanPhong : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void DisplayObject();
        public DisplayObject DisplayBackgroung;
        GridViewFilterHelper filterHelper;
        public frmBanPhong()
        {
            InitializeComponent();
            filterHelper = new GridViewFilterHelper(grvData);
        }
        public void LayDSKhuVuc()
        {
            trlKhuVuc.Nodes.Clear();
            TreeListNode node = trlKhuVuc.AppendNode(null, null);
            node.SetValue("KV_ID", "");
            node.SetValue("KV_Ten", "TẤT CẢ");
            string sql = "select KV_ID, KV_Ten from KhuVuc where KV_KichHoat = 'True' and KV_DV_ID = '" + Info.dv_id + "' order by KV_Ten ";
            DataTable dt = cls.GetDataTable(sql);
            DataTable dtlh = new DataTable();
            foreach (DataRow dr in dt.Rows)
            {
                TreeListNode childnode = trlKhuVuc.AppendNode(null, null);
                childnode.SetValue("KV_ID", dr["KV_ID"].ToString().Trim());
                childnode.SetValue("KV_Ten", dr["KV_Ten"].ToString().Trim());

            }
            trlKhuVuc.ExpandAll();
        }
        public void AddDoiTac(string BP_ID, string BP_Ten, string BP_GhiChu, Boolean BP_KichHoat, string BP_TuKhoa)
        {
            TTHWait.ShowWait();
            //WaitDialogForm dg = new WaitDialogForm("Xin chờ trong giây lát!", "Đang load dữ liệu...");
            DataTable dt = (DataTable)grcData.DataSource;
            DataRow dr = dt.NewRow();
            dr["BP_ID"] = BP_ID;
            dr["BP_Ten"] = BP_Ten;
            dr["BP_GhiChu"] = BP_GhiChu;
            dr["BP_KichHoat"] = BP_KichHoat;
            dr["BP_TuKhoa"] = BP_TuKhoa;
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
        public void EditDoiTac(string BP_ID, string BP_Ten, string BP_GhiChu, Boolean BP_KichHoat, string BP_TuKhoa)
        {
            try
            {
                //sửa loại hàng và cập nhật lại giá trị
                grvData.SetFocusedRowCellValue("BP_ID", BP_ID);
                grvData.SetFocusedRowCellValue("BP_Ten", BP_Ten);
                grvData.SetFocusedRowCellValue("BP_GhiChu", BP_GhiChu);
                grvData.SetFocusedRowCellValue("BP_KichHoat", BP_KichHoat);
                grvData.SetFocusedRowCellValue("BP_TuKhoa", BP_TuKhoa);
                grvData.BestFitColumns();
            }
            catch (Exception)
            {


            }

        }
        public Boolean XoaBanPhong(string id)
        {
            string sql = "delete BanPhong where BP_ID = '" + id + "'";
            return cls.ExecuteNonQuery(sql);
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LayDSKhuVuc();
            trlNhomDoiTac_AfterFocusNode(null, null);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void AddKhuVuc(string kv_id, string kv_ten)
        {
            TreeListNode node = trlKhuVuc.AppendNode(null, null);
            node.SetValue("KV_ID", kv_id);
            node.SetValue("KV_Ten", kv_ten);
            trlKhuVuc.FocusedNode = node;
        }
        private void barThemNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Them", "barBanPhong"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            frmKhuVucUpdate frm = new frmKhuVucUpdate();
            frm.frmText = "KHU VỰC [Thêm]";
            frm.AddKhuVuc = new frmKhuVucUpdate.AddKhuVucDelegate(AddKhuVuc);
            frm.ShowDialog();
        }
        public void EditKhuVuc(string kv_id, string kv_ten)
        {
            TreeListNode node = trlKhuVuc.FocusedNode;
            node.SetValue("KV_ID", kv_id);
            node.SetValue("KV_Ten", kv_ten);
        }
        private void barSuaNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Sua", "barBanPhong"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            try
            {
                TreeListNode node = trlKhuVuc.FocusedNode;
                string dt_id = node.GetValue("KV_ID").ToString().Trim();
                if (dt_id.Length == 0)
                {
                    TTHMessage.ShowMessageWarming("Bạn chưa chọn khu vực muốn sửa!");
                    return;
                }
                frmKhuVucUpdate frm = new frmKhuVucUpdate();
                frm.frmText = "KHU VỰC [Sửa]";
                frm.issua = true;
                frm.kv_id = dt_id;
                frm.EditKhuVuc = new frmKhuVucUpdate.EditKhuVucDelegate(EditKhuVuc);
                frm.Show();
            }
            catch (Exception)
            {
                
                
            }
            

        }
        public Boolean XoaKhuVuc(string id)
        {
            string sql = "delete KhuVuc where KV_ID = '" + id + "' ";
            return cls.ExecuteNonQuery(sql);
        }
        private void barXoaLoai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Xoa", "barBanPhong"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            TreeListNode node = trlKhuVuc.FocusedNode;

            if (TTHMessage.ShowMessageConfirm("Bạn có chắc muốn xóa không?") == DialogResult.Yes)
            {
                if (XoaKhuVuc(node.GetValue("KV_ID").ToString()))
                {
                    
                    trlKhuVuc.DeleteNode(node);
                    TTHMessage.ShowMessageInfomation("Đã xóa thành công!");
                }
                else
                {
                    TTHMessage.ShowMessageError("Không thể xóa!");
                }
            }



        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Them", "barBanPhong"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            TreeListNode node = trlKhuVuc.FocusedNode;
            frmBanPhongUpdate frm = new frmBanPhongUpdate();
            frm.frmText = "KHÁCH HÀNG [Thêm]";
            frm.kv_id = node.GetValue("KV_ID").ToString().Trim();
            frm.AddBanPhong = new frmBanPhongUpdate.AddBanPhongDelegate(AddDoiTac);
            frm.ShowDialog();
        }

        private void trlNhomDoiTac_AfterFocusNode(object sender, NodeEventArgs e)
        {
            TTHWait.ShowWait();
            TreeListNode node = trlKhuVuc.FocusedNode;
            string kv_id = node.GetValue("KV_ID").ToString().Trim();
            string sql = "";
            sql = "select BP_ID,  BP_Ten,  BP_KichHoat, BP_GhiChu,  BP_TuKhoa ";
            sql += "from BanPhong where BP_DV_ID = '" + Info.dv_id + "'    ";
            if (kv_id.Length > 0)
            {
                sql += "and BP_KV_ID = '" + kv_id + "' ";
            }
            
            sql += "order by BP_Ten ";
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





        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Sua", "barBanPhong"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            if (grvData.RowCount > 0)
            {
                frmBanPhongUpdate frm = new frmBanPhongUpdate();
                frm.issua = true;
                frm.frmText = "BÀN / PHÒNG [Sửa]";
                frm.EditBanPhong = new frmBanPhongUpdate.EditBanPhongDelegate(EditDoiTac);
                DataRow row = grvData.GetFocusedDataRow();
                frm.bp_id = row["BP_ID"].ToString().Trim();
                frm.ShowDialog();
            }
            else TTHMessage.ShowMessageWarming("Chưa có dòng nào được chọn!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Xoa", "barBanPhong"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            try
            {
                if (grvData.RowCount == 0) return;
                DataRow row = grvData.GetFocusedDataRow();
                string bp_id = row["BP_ID"].ToString().Trim();
                //Xoa mot dong
                if (TTHMessage.ShowMessageConfirm("Bạn có chắc muốn xóa dòng được chọn không?") == DialogResult.Yes)
                {

                    if (!XoaBanPhong(bp_id))
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
            if (!Info.KiemTraQuyen("Q_In", "barBanPhong"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            FastReport.Report rpt = new FastReport.Report();
            TreeListNode node = trlKhuVuc.FocusedNode;
            string kv_id = node.GetValue("KV_ID").ToString().Trim();
            string sql = "select KV_Ten, BP_Ten,  BP_GhiChu, BP_KichHoat ";
            sql += "from BanPhong a left join KhuVuc b on a.BP_KV_ID = b.KV_ID ";
            if (kv_id.Length > 0)
                sql += "and BP_KV_ID = '" + kv_id + "' ";
            sql += "order by KV_Ten, BP_Ten";
            rpt.Load(Application.StartupPath + "\\report\\DMBanPhong.frx");
            rpt.RegisterData(cls.GetDataTable(sql), "Table");
            rpt.SetParameterValue("tendoanhnghiep", Info.dv_ten);
            rpt.SetParameterValue("diachidoanhnghiep", Info.dv_diachi);
            rpt.SetParameterValue("dienthoaidoanhnghiep", Info.dv_dienthoai);
            rpt.Show();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (!Info.KiemTraQuyen("Q_Xuat", "barBanPhong"))
            {
                TTHMessage.ShowMessageWarming("Bạn không có quyền thực hiện hành động này!");
                return;
            }
            TTHUtils.ExportToExcelFile(grvData, "DMBanPhong");
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