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
    public partial class frmMatHang : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void DisplayBackgroungDelegate();
        public DisplayBackgroungDelegate DisplayBackgroung;
        GridViewFilterHelper filterHelper;
        public frmMatHang()
        {
            InitializeComponent();
            filterHelper = new GridViewFilterHelper(grvData);
        }

        public void AddMatHang(string MH_ID, string MH_Ma, string MH_Ten, string MH_DVT, double MH_GiaMua, double MH_GiaBanSi, double MH_GiaBanLe, double MH_GiaTraCham, string MH_GhiChu, Boolean MH_KichHoat, string MH_TuKhoa)
        {
            TTHWait.ShowWait();
            DataTable dt = (DataTable)grcData.DataSource;
            DataRow dr = dt.NewRow();
            dr["MH_ID"] = MH_ID;
            dr["MH_Ma"] = MH_Ma;
            dr["MH_Ten"] = MH_Ten;
            dr["MH_DVT"] = MH_DVT;
            dr["MH_GiaMua"] = MH_GiaMua;
            dr["MH_GiaBanSi"] = MH_GiaBanSi;
            dr["MH_GiaBanLe"] = MH_GiaBanLe;
            dr["MH_GiaTraCham"] = MH_GiaTraCham;
            dr["MH_GhiChu"] = MH_GhiChu;
            dr["MH_KichHoat"] = MH_KichHoat;
            dr["MH_TuKhoa"] = MH_TuKhoa;
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
            TTHWait.CloseWait();
        }
        public void EditMatHang(string MH_ID, string MH_Ma, string MH_Ten, string MH_DVT, double MH_GiaMua, double MH_GiaBanSi, double MH_GiaBanLe, double MH_GiaTraCham, string MH_GhiChu, Boolean MH_KichHoat, string MH_TuKhoa)
        {
            try
            {
                grvData.SetFocusedRowCellValue("MH_ID", MH_ID);
                grvData.SetFocusedRowCellValue("MH_Ma", MH_Ma);
                grvData.SetFocusedRowCellValue("MH_Ten", MH_Ten);
                grvData.SetFocusedRowCellValue("MH_DVT", MH_DVT);
                grvData.SetFocusedRowCellValue("MH_GiaMua", MH_GiaMua);
                grvData.SetFocusedRowCellValue("MH_GiaBanSi", MH_GiaBanSi);
                grvData.SetFocusedRowCellValue("MH_GiaBanLe", MH_GiaBanLe);
                grvData.SetFocusedRowCellValue("MH_GiaTraCham", MH_GiaTraCham);
                grvData.SetFocusedRowCellValue("MH_GhiChu", MH_GhiChu);
                grvData.SetFocusedRowCellValue("MH_KichHoat", MH_KichHoat);
                grvData.SetFocusedRowCellValue("MH_TuKhoa", MH_TuKhoa);
                //grvData.BestFitColumns();
            }
            catch (Exception)
            {


            }

        }
        public Boolean XoaMatHang(string mh_id)
        {
            string sql = "delete MatHang where MH_ID = '" + mh_id + "'";
            return cls.ExecuteNonQuery(sql);
        }
        public Boolean XoaLoaiHang(string lh_id)
        {
            string sql = "delete LoaiHang where LH_ID = '" + lh_id + "'";
            return cls.ExecuteNonQuery(sql);
        }
        //public void LayDSLoaiHang()
        //{
        //    DataAccess cls = new DataAccess();
        //    lvLoaiHang.Clear();
        //    lvLoaiHang.GridLines = true;
        //    lvLoaiHang.Columns.Add("Tên", lvLoaiHang.Size.Width - 4, 0);
        //    lvLoaiHang.Columns.Add("ID", 0, 0);
        //    ListViewItem lvi;
        //    string sql = "select LH_ID, LH_Ten, LH_HinhAnh from LoaiHang ";
        //    sql += "where LH_KichHoat = 'True' and LH_DV_ID = '" + Info.dv_id + "' ";
        //    sql += "order by LH_Ten ";
        //    DataTable dt = cls.GetDataTable(sql);
        //    imgLoaiHang.Images.Clear();
        //    if (dt.Rows.Count > 0)
        //    {
        //        imgLoaiHang.Images.Add(Image.FromFile(Application.StartupPath + "\\icon\\tatca.png"));
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            System.IO.MemoryStream imgStream = new System.IO.MemoryStream((byte[])dr["LH_HinhAnh"], 0, ((byte[])dr["LH_HinhAnh"]).Length);
        //            imgStream.Write((byte[])dr["LH_HinhAnh"], 0, ((byte[])dr["LH_HinhAnh"]).Length);
        //            imgLoaiHang.Images.Add(Image.FromStream(imgStream, true));
        //        }
                
        //        lvLoaiHang.LargeImageList = imgLoaiHang;
        //        lvLoaiHang.View = View.LargeIcon;
                
        //        DataRow row = dt.NewRow();
        //        row[0] = "";
        //        row[1] = "Tất cả";
        //        dt.Rows.InsertAt(row, 0);
        //        int i = 0;
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            lvi = new ListViewItem(dr["LH_Ten"].ToString().Trim(), i);
        //            lvi.SubItems.Add(dr["LH_ID"].ToString().Trim());
        //            lvLoaiHang.Items.Add(lvi);
        //            i = i + 1;
        //        }
        //        lvLoaiHang.Items[0].Focused = true;
        //        lvLoaiHang.Items[0].Selected = true;
        //        string lh_id = lvLoaiHang.Items[0].SubItems[1].Text.Trim();
        //        LayDSMatHang(lh_id);
        //    }

        //}
        public void LayDSLoaiHang()
        {
            string sql = "select LH_ID, LH_Ten from LoaiHang ";
            sql += "where LH_KichHoat = 'True'  ";
            sql += "order by LH_Ten ";
            DataTable dt = cls.GetDataTable(sql);
            DataRow dr = dt.NewRow();
            dr[0] = "";
            dr[1] = "Tất cả";
            dt.Rows.InsertAt(dr, 0);
            grcLoaiHang.DataSource = dt;

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void AddLoaiHang(string lh_id, string hl_ten)
        {
            //TreeListNode node = trlNhomDoiTac.AppendNode(null, null);
            //node.SetValue("NDT_ID", ndt_id);
            //node.SetValue("NDT_Ten", ndt_ten);
            //trlNhomDoiTac.FocusedNode = node;
        }
        private void barThemNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLoaiHangUpdate frm = new frmLoaiHangUpdate();
            frm.frmText = "LOẠI HÀNG [Thêm]";
            frm.LayDSLoaiHang = new frmLoaiHangUpdate.GetDataTableDelegate(LayDSLoaiHang);
            //frm.LayDSLoaiHang = new frmLoaiHangUpdate.GetDataTableDelegate(LayDSLoaiHang);
            frm.ShowDialog();
        }
        public void EditNhomDoiTac(string ndt_id, string ndt_ten)
        {
            //TreeListNode node = trlNhomDoiTac.FocusedNode;
            //node.SetValue("NDT_ID", ndt_id);
            //node.SetValue("NDT_Ten", ndt_ten);
        }
        private void barSuaNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow row = grvLoaiHang.GetFocusedDataRow();
                string lh_id = row["LH_ID"].ToString().Trim();
                if (lh_id.Length == 0)
                {
                    TTHMessage.ShowMessageWarming("Bạn chưa chọn loại hàng muốn sửa!");
                    return;
                }
                frmLoaiHangUpdate frm = new frmLoaiHangUpdate();
                frm.frmText = "LOẠI HÀNG [Sửa]";
                frm.issua = true;
                frm.lh_id = lh_id;
                frm.LayDSLoaiHang = new frmLoaiHangUpdate.GetDataTableDelegate(LayDSLoaiHang);
                //LayDSMatHang(lh_id);
                frm.ShowDialog();
            }
            catch (Exception)
            {

            }

        }
       
        private void barXoaLoai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow row = grvLoaiHang.GetFocusedDataRow();
                string lh_id = row["LH_ID"].ToString().Trim();
                if (TTHMessage.ShowMessageConfirm("Bạn có chắc muốn xóa không?") == DialogResult.Yes)
                {
                    if (XoaLoaiHang(lh_id))
                    {
                        TTHMessage.ShowMessageInfomation("Đã xóa thành công!");
                        LayDSLoaiHang();

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
            try
            {
                DataRow row = grvLoaiHang.GetFocusedDataRow();
                string lh_id = row["LH_ID"].ToString().Trim();
                frmMatHangUpdate frm = new frmMatHangUpdate();
                frm.frmText = "MẶT HÀNG [Thêm]";
                frm.lh_id = lh_id;
                frm.AddMatHang = new frmMatHangUpdate.AddMatHangDelegate(AddMatHang);
                frm.ShowDialog();
            }
            catch (Exception)
            {
                
                
            }
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
            if (grvData.RowCount > 0)
            {
                frmMatHangUpdate frm = new frmMatHangUpdate();
                frm.issua = true;
                frm.frmText = "MẶT HÀNG [Sửa]";
                frm.EditMatHang = new frmMatHangUpdate.EditMatHangDelegate(EditMatHang);
                DataRow row = grvData.GetFocusedDataRow();
                frm.mh_id = row["MH_ID"].ToString().Trim();
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
                string mh_id = row["MH_ID"].ToString().Trim();
               
                //Xoa mot dong
                if (TTHMessage.ShowMessageConfirm("Bạn có chắc muốn xóa dòng được chọn không?") == DialogResult.Yes)
                {

                    if (!XoaMatHang(mh_id))
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
            frmMatHang_Load(null, null);
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(null, null);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData.RowCount == 0) return;
                DataRow row = grvData.GetFocusedDataRow();
                frmInMaVach frm = new frmInMaVach();
                frm.mavach = row["MH_Ma"].ToString().Trim();
                frm.dongia = double.Parse(row["MH_GiaBanLe"].ToString());
                //frm.soluong = double.Parse(row["soluong"].ToString());
                frm.tenhang = row["MH_Ten"].ToString().Trim();
                frm.ShowDialog();
            }
            catch (Exception)
            {


            }
            //try
            //{
            //    FastReport.Report rpt = new FastReport.Report();
            //    rpt.Load(Application.StartupPath + "\\report\\DMMatHang.frx");
            //    string sql = "select LH_Ten,  MH_Ten, MH_DVT,MH_GiaMua, MH_GiaBanSi, MH_GiaBanLe, MH_GhiChu,MH_KichHoat ";
            //    sql += "from MatHang, LoaiHang where MH_LH_ID = LH_ID and  MH_DV_ID = '" + Info.dv_id + "'  ";
            //    ListViewItem lvi = lvLoaiHang.FocusedItem;
            //    string lh_id = lvi.SubItems[1].Text.Trim();
            //    if (lh_id.Length > 0)
            //        sql += "and MH_LH_ID = '" + lh_id + "' ";
            //    sql += "order by LH_Ten, MH_Ten ";
            //    DataTable dt = cls.GetDataTable(sql);
            //    rpt.RegisterData(dt, "Table");
            //    rpt.SetParameterValue("tendoanhnghiep", Info.dv_ten);
            //    rpt.SetParameterValue("diachidoanhnghiep", Info.dv_diachi);
            //    rpt.SetParameterValue("dienthoaidoanhnghiep", Info.dv_dienthoai);
            //    rpt.Show();
            //}
            //catch (Exception ex)
            //{

            //    TTHMessage.ShowMessageWarming(ex.ToString());
            //}
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            TTHUtils.ExportToExcelFile(grvData, "DMMatHang");
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
        public void LayDSMatHang(string lh_id)
        {
            string sql = "select MH_ID, MH_Ma, MH_Ten, MH_DVT, MH_GiaMua, MH_GiaBanSi, MH_GiaBanLe, MH_GiaTraCham, MH_GhiChu, MH_KichHoat, MH_TuKhoa ";
            sql += "from MatHang ";
            if(lh_id.Length > 0)
                sql += "where MH_LH_ID = '" + lh_id + "' ";
            sql += "order by MH_Ten ";
            grcData.DataSource = cls.GetDataTable(sql);
        }
        

        private void frmMatHang_Load(object sender, EventArgs e)
        {
            LayDSLoaiHang();
            grvLoaiHang_Click(null, null);
        }

        private void grvData_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle % 2 == 1)
            {
                e.Appearance.BackColor = Color.WhiteSmoke;
            }
            else e.Appearance.BackColor = Color.White;
        }

        private void frmMatHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisplayBackgroung();
        }

        private void grvLoaiHang_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow row = grvLoaiHang.GetFocusedDataRow();
                string lh_id = row["LH_ID"].ToString().Trim();
                LayDSMatHang(lh_id);
            }
            catch (Exception)
            {

            }
        }

        private void grvLoaiHang_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle % 2 == 1)
            {
                e.Appearance.BackColor = Color.WhiteSmoke;
            }
            else e.Appearance.BackColor = Color.White;
        }
    }
}