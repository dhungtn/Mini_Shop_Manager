using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraPrinting;


namespace MyRMS.DanhMuc
{
    public partial class frmQuyTien : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void DisplayObject();
        public DisplayObject DisplayBackgroung;
        public void LayDSQuyTien()
        {
            
            TTHWait.ShowWait();
            string sql = "select QT_ID, QT_Ten, QT_GhiChu, QT_TrangThai from QuyTien order by QT_Ten";
            grcQuyTien.DataSource = cls.GetDataTable(sql);
            grvQuyTien.BestFitColumns();
            grvQuyTien.ExpandAllGroups();
            TTHWait.CloseWait();
        }
        public Boolean XoaQuyTien(string qt_id)
        {
            
            string sql = "delete QuyTien where QT_ID = '" + qt_id + "'";
            return cls.ExecuteNonQuery(sql);
        }
        public void EditQuyTien(string QT_ID, string QT_Ten, string QT_GhiChu, Boolean QT_TrangThai)
        {
            //sửa loại hàng và cập nhật lại giá trị
            grvQuyTien.SetFocusedRowCellValue("QT_ID", QT_ID);
            grvQuyTien.SetFocusedRowCellValue("QT_Ten", QT_Ten);
            grvQuyTien.SetFocusedRowCellValue("QT_GhiChu", QT_GhiChu);
            grvQuyTien.SetFocusedRowCellValue("QT_TrangThai", QT_TrangThai);
            
        }
        public void AddQuyTien(string QT_ID,  string QT_Ten,  string QT_GhiChu, Boolean QT_TrangThai)
        {
            WaitDialogForm dg = new WaitDialogForm("Xin chờ trong giây lát!", "Đang load dữ liệu...");
            DataTable dt = (DataTable)grcQuyTien.DataSource;
            DataRow dr = dt.NewRow();
            dr["QT_ID"] = QT_ID;
            dr["QT_Ten"] = QT_Ten;
            dr["QT_GhiChu"] = QT_GhiChu;
            dr["QT_TrangThai"] = QT_TrangThai;
            //vi tri dong dang focus
            int pos = -1;
            if (grvQuyTien.RowCount > 0)
            {
                try
                {
                    pos = grvQuyTien.FocusedRowHandle;
                    if (pos < 0)
                        pos = -1;
                    else grvQuyTien.UnselectRow(pos);
                }
                catch (Exception)
                {
                    pos = -1;
                   
                }
                
            }
            dt.Rows.InsertAt(dr, pos+1);
            grcQuyTien.DataSource = dt;
            grvQuyTien.FocusedRowHandle = pos+1;
            dg.Close();
        }
        
        public frmQuyTien()
        {
            InitializeComponent();
        }


        private void barXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmQuyTienUpdate frm = new frmQuyTienUpdate();
                frm.add = new frmQuyTienUpdate.AddQuyTien(AddQuyTien);
                frm.frmText = "Quỹ tiền [Thêm]";
                //frm.LayDSQuyTienDelegate = new frmCapNhatQuyTien.GetDataTable(LayDSQuyTien);
                frm.ShowDialog();
            }
            catch (Exception)
            {


            }
            
        }

        private void barSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (grvQuyTien.RowCount == 0) return;
                DataRow row = grvQuyTien.GetFocusedDataRow();
                if (row["QT_ID"].ToString().Trim() == "tm")
                {
                    TTHMessage.ShowMessageWarming("Đây là quỹ tiền mặc định của hệ thống nên không thể sửa!");
                    return;
                }
                frmQuyTienUpdate frm = new frmQuyTienUpdate();
                frm.issua = true;
                frm.qt_id = row["QT_ID"].ToString().Trim();
                
                frm.frmText = "Quỹ tiền [Sửa]";
                frm.edit = new frmQuyTienUpdate.EditQuyTien(EditQuyTien);
                //frm.LayDSQuyTienDelegate = new frmCapNhatQuyTien.GetDataTable(LayDSQuyTien);
                frm.ShowDialog();
            }
            catch (Exception)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa chọn dòng muốn sửa!");

            }
            
        }

        private void barXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (grvQuyTien.RowCount == 0) return;
                DataRow row = grvQuyTien.GetFocusedDataRow();
                string qt_id = row["QT_ID"].ToString().Trim();
                if (qt_id == "tm")
                {
                    TTHMessage.ShowMessageWarming("Đây là quỹ tiền mặc định của hệ thống nên không thể xóa!");
                    return;
                }
                //Xoa mot dong
                if (TTHMessage.ShowMessageConfirm("Bạn có chắc muốn xóa dòng được chọn không?") == DialogResult.Yes)
                {
                    if (!XoaQuyTien(qt_id))
                        TTHMessage.ShowMessageWarming("Không thể xóa dòng này. \nXin vui lòng kiểm tra lại sự ràng buộc dữ liệu!");
                    else
                    {
                        row.Delete();
                    }
                }
            }
            catch (Exception)
            {
                TTHMessage.ShowMessageWarming("Bạn chưa chọn dòng muốn xóa!");
                
            }
            
        }

        private void barTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDMQuyTien_Load(null, null);
        }

        private void barIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WaitDialogForm dg = new WaitDialogForm("Xin chờ trong giây lát!", "Đang load dữ liệu...");
            DataAccess cls = new DataAccess();
            FastReport.Report rpt = new FastReport.Report();
            rpt.Load(Application.StartupPath + "\\report\\DMQuyTien.frx");
            DataTable dt = null;
            string sql = "select QT_ID, QT_Ten, QT_GhiChu, QT_TrangThai from QuyTien order by QT_Ten";
            dt = cls.GetDataTable(sql);
            //foreach (DataRow dr in cls.GetDataTable("select QT_ID, QT_Ten, QT_GhiChu, QT_TrangThai from QuyTien where  QT_IDParent = '' order by QT_ID").Rows)
            //{
            //    DataRow row = dt.NewRow();
            //    row["QT_ID"] = dr["QT_ID"];
            //    row["QT_Ten"] = dr["QT_Ten"];
            //    row["QT_GhiChu"] = dr["QT_GhiChu"];
            //    row["QT_TrangThai"] = dr["QT_TrangThai"];
            //    dt.Rows.InsertAt(row, dt.Rows.Count);
            //    foreach (DataRow dr1 in cls.GetDataTable("select QT_ID, QT_Ten, QT_GhiChu, QT_TrangThai from QuyTien where QT_IDParent = '" + dr["QT_ID"].ToString().Trim() + "' order by QT_ID").Rows)
            //    {
            //        DataRow row1 = dt.NewRow();
            //        row1["QT_ID"] = dr1["QT_ID"];
            //        row1["QT_Ten"] = "-----" + dr1["QT_Ten"].ToString().Trim();
            //        row1["QT_GhiChu"] = dr1["QT_GhiChu"];
            //        row1["QT_TrangThai"] = dr1["QT_TrangThai"];
            //        dt.Rows.InsertAt(row1, dt.Rows.Count);
            //    }
            //}
            rpt.RegisterData(dt, "Table");
            rpt.SetParameterValue("tendoanhnghiep", Info.dv_ten);
            rpt.SetParameterValue("diachidoanhnghiep", Info.dv_diachi);
            rpt.SetParameterValue("dienthoaidoanhnghiep", Info.dv_dienthoai);
            dg.Close();
            rpt.Show();
        }

        

        private void barDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TTHUtils.ExportToExcelFile(grvQuyTien, "QuyTien");
        }


        private void grvQuyTien_DoubleClick(object sender, EventArgs e)
        {
            barSua_ItemClick(null, null);
        }

        private void frmDMQuyTien_Load(object sender, EventArgs e)
        {
            LayDSQuyTien();
        }

        private void grvQuyTien_DoubleClick_1(object sender, EventArgs e)
        {
            barSua_ItemClick(null, null);
        }

       

        
    }
}