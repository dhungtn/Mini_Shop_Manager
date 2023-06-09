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
    public partial class frmChucNang : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void DisplayObject();
        public DisplayObject DisplayBackgroung;
        GridViewFilterHelper filterHelper;
        public frmChucNang()
        {
            InitializeComponent();
            filterHelper = new GridViewFilterHelper(grvData);
        }
        public void LayDSNhomChucNang()
        {
            trlNhomDoiTac.Nodes.Clear();
            TreeListNode node = trlNhomDoiTac.AppendNode(null, null);
            node.SetValue("NCN_ID", "");
            node.SetValue("NCN_Ten", "TẤT CẢ");
            string sql = "select NCN_ID, NCN_Ten from NhomChucNang order by NCN_ID ";
            DataTable dt = cls.GetDataTable(sql);
            DataTable dtlh = new DataTable();
            foreach (DataRow dr in dt.Rows)
            {
                TreeListNode childnode = trlNhomDoiTac.AppendNode(null, null);
                childnode.SetValue("NCN_ID", dr["NCN_ID"].ToString().Trim());
                childnode.SetValue("NCN_Ten", dr["NCN_Ten"].ToString().Trim());

            }
            trlNhomDoiTac.ExpandAll();
        }
        public void AddChucNang(string CN_ID, string CN_Ten, string CN_GhiChu, Boolean CN_KichHoat)
        {
            TTHWait.ShowWait();
            //WaitDialogForm dg = new WaitDialogForm("Xin chờ trong giây lát!", "Đang load dữ liệu...");
            DataTable dt = (DataTable)grcData.DataSource;
            DataRow dr = dt.NewRow();
            dr["CN_ID"] = CN_ID;
            dr["CN_Ten"] = CN_Ten;
            dr["CN_GhiChu"] = CN_GhiChu;
            dr["CN_KichHoat"] = CN_KichHoat;
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
        public void EditChucNang(string CN_ID, string CN_Ten, string CN_GhiChu, Boolean CN_KichHoat)
        {
            try
            {
                //sửa loại hàng và cập nhật lại giá trị
                grvData.SetFocusedRowCellValue("CN_ID", CN_ID);
                grvData.SetFocusedRowCellValue("CN_Ten", CN_Ten);
                grvData.SetFocusedRowCellValue("CN_GhiChu", CN_GhiChu);
                grvData.SetFocusedRowCellValue("CN_KichHoat", CN_KichHoat);
                grvData.BestFitColumns();
            }
            catch (Exception)
            {


            }

        }
        public Boolean XoaChucNang(string id)
        {
            string sql = "delete ChucNang where CN_ID = '" + id + "'";
            return cls.ExecuteNonQuery(sql);
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LayDSNhomChucNang();
            trlNhomDoiTac_AfterFocusNode(null, null);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void AddNhomChucNang(string ncn_id, string ncn_ten)
        {
            TreeListNode node = trlNhomDoiTac.AppendNode(null, null);
            node.SetValue("NCN_ID", ncn_id);
            node.SetValue("NCN_Ten", ncn_ten);
            trlNhomDoiTac.FocusedNode = node;
        }
        private void barThemNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNhomChucNangUpdate frm = new frmNhomChucNangUpdate();
            frm.frmText = "NHÓM CHỨC NĂNG [Thêm]";
            frm.AddNhomChucNang = new frmNhomChucNangUpdate.AddNhomChucNangDelegate(AddNhomChucNang);
            frm.ShowDialog();
        }
        public void EditNhomChucNang(string ncn_id, string ncn_ten)
        {
            TreeListNode node = trlNhomDoiTac.FocusedNode;
            node.SetValue("NCN_ID", ncn_id);
            node.SetValue("NCN_Ten", ncn_ten);
        }
        private void barSuaNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                TreeListNode node = trlNhomDoiTac.FocusedNode;
                string dt_id = node.GetValue("NCN_ID").ToString().Trim();
                if (dt_id.Length == 0)
                {
                    TTHMessage.ShowMessageWarming("Bạn chưa chọn nhóm chức năng muốn sửa!");
                    return;
                }
                frmNhomChucNangUpdate frm = new frmNhomChucNangUpdate();
                frm.frmText = "NHÓM CHỨC NĂNG [Sửa]";
                frm.issua = true;
                frm.ncn_id = dt_id;
                frm.EditNhomChucNang = new frmNhomChucNangUpdate.EditNhomChucNangDelegate(EditNhomChucNang);
                frm.Show();
            }
            catch (Exception)
            {
                
                
            }
            

        }
        public Boolean XoaNhomChucNang(string id)
        {
            string sql = "delete NhomChucNang where NCN_ID = '" + id + "' ";
            return cls.ExecuteNonQuery(sql);
        }
        private void barXoaLoai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode node = trlNhomDoiTac.FocusedNode;

            if (TTHMessage.ShowMessageConfirm("Bạn có chắc muốn xóa không?") == DialogResult.Yes)
            {
                if (XoaNhomChucNang(node.GetValue("NCN_ID").ToString()))
                {
                    
                    trlNhomDoiTac.DeleteNode(node);
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
            TreeListNode node = trlNhomDoiTac.FocusedNode;
            frmChucNangUpdate frm = new frmChucNangUpdate();
            frm.frmText = "CHỨC NĂNG [Thêm]";
            frm.ncn_id = node.GetValue("NCN_ID").ToString().Trim();
            frm.AddChucNang = new frmChucNangUpdate.AddChucNangDelegate(AddChucNang);
            frm.ShowDialog();
        }

        private void trlNhomDoiTac_AfterFocusNode(object sender, NodeEventArgs e)
        {
            TTHWait.ShowWait();
            TreeListNode node = trlNhomDoiTac.FocusedNode;
            string ncn_id = node.GetValue("NCN_ID").ToString().Trim();
            string sql = "";
            sql = "select CN_ID,  CN_Ten,  CN_KichHoat, CN_GhiChu ";
            sql += "from ChucNang where CN_ID <> ''    ";
            if (ncn_id.Length > 0)
            {
                sql += "and CN_NCN_ID = '" + ncn_id + "' ";
            }
            
            sql += "order by CN_ID ";
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
            if (grvData.RowCount > 0)
            {
                frmChucNangUpdate frm = new frmChucNangUpdate();
                frm.issua = true;
                frm.frmText = "CHỨC NĂNG [Sửa]";
                frm.EditChucNang = new frmChucNangUpdate.EditChucNangDelegate(EditChucNang);
                DataRow row = grvData.GetFocusedDataRow();
                frm.cn_id = row["CN_ID"].ToString().Trim();
                frm.ShowDialog();
            }
            else TTHMessage.ShowMessageWarming("Chưa có dòng nào được chọn!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData.RowCount == 0) return;
                DataRow row = grvData.GetFocusedDataRow();
                string cn_id = row["CN_ID"].ToString().Trim();
                //Xoa mot dong
                if (TTHMessage.ShowMessageConfirm("Bạn có chắc muốn xóa dòng được chọn không?") == DialogResult.Yes)
                {

                    if (!XoaChucNang(cn_id))
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
            //FastReport.Report rpt = new FastReport.Report();
            //TreeListNode node = trlNhomDoiTac.FocusedNode;
            //string kv_id = node.GetValue("KV_ID").ToString().Trim();
            //string sql = "select KV_Ten, CN_Ten,  CN_GhiChu, CN_KichHoat ";
            //sql += "from BanPhong a left join KhuVuc b on a.CN_KV_ID = b.KV_ID ";
            //if (kv_id.Length > 0)
            //    sql += "and CN_KV_ID = '" + kv_id + "' ";
            //sql += "order by KV_Ten, CN_Ten";
            //rpt.Load(Application.StartupPath + "\\report\\DMBanPhong.frx");
            //rpt.RegisterData(cls.GetDataTable(sql), "Table");
            //rpt.SetParameterValue("tendoanhnghiep", Info.dv_ten);
            //rpt.SetParameterValue("diachidoanhnghiep", Info.dv_diachi);
            //rpt.SetParameterValue("dienthoaidoanhnghiep", Info.dv_dienthoai);
            //rpt.Show();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            TTHUtils.ExportToExcelFile(grvData, "DMChucNang");
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