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
using System.Threading;
namespace MyRMS.DanhMuc
{
    public partial class frmNhomDoiTac : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void DisplayObject();
        public DisplayObject DisplayBackgroung;
        public void LayDSNhomDoiTac()
        {
            
            WaitDialogForm dg = new WaitDialogForm("Xin chờ trong giây lát!", "Đang load dữ liệu...");
            string sql = "select NDT_ID, NDT_Ten, NDT_ChietKhau,  NDT_GhiChu, NDT_TrangThai from NhomDoiTac where NDT_ID <> 'ncc' order by NDT_Ten";
            grcData.DataSource = cls.GetDataTable(sql);
            grvData.BestFitColumns();
            grvData.ExpandAllGroups();
            dg.Close();
        }
        public Boolean XoaNhomDoiTac(string NDT_ID)
        {
            
            string sql = "delete NhomDoiTac where NDT_ID = '" + NDT_ID + "'";
            return cls.ExecuteNonQuery(sql);
        }
        public void EditNhomDoiTac(string NDT_ID, string NDT_Ten, double NDT_ChietKhau, string NDT_GhiChu, Boolean NDT_KichHoat)
        {
            //sửa loại hàng và cập nhật lại giá trị
            grvData.SetFocusedRowCellValue("NDT_ID", NDT_ID);
            grvData.SetFocusedRowCellValue("NDT_Ten", NDT_Ten);
            grvData.SetFocusedRowCellValue("NDT_ChietKhau", NDT_ChietKhau);
            grvData.SetFocusedRowCellValue("NDT_GhiChu", NDT_GhiChu);
            grvData.SetFocusedRowCellValue("NDT_KichHoat", NDT_KichHoat);
            
        }
        public void AddNhomDoiTac(string NDT_ID, string NDT_Ten, double NDT_ChietKhau, string NDT_GhiChu, Boolean NDT_KichHoat)
        {
            TTHWait.ShowWait();
            DataTable dt = (DataTable)grcData.DataSource;
            DataRow dr = dt.NewRow();
            dr["NDT_ID"] = NDT_ID;
            dr["NDT_Ten"] = NDT_Ten;
            dr["NDT_ChietKhau"] = NDT_ChietKhau;
            dr["NDT_GhiChu"] = NDT_GhiChu;
            dr["NDT_KichHoat"] = NDT_KichHoat;
            //vi tri dong dang focus
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
            dt.Rows.InsertAt(dr, pos+1);
            grcData.DataSource = dt;
            grvData.FocusedRowHandle = pos + 1;
            TTHWait.CloseWait();
        }
        
        public frmNhomDoiTac()
        {
            InitializeComponent();
        }
      

        private void barXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmNhomDoiTacUpdate frm = new frmNhomDoiTacUpdate();
                frm.frmText = "Khu vực [Thêm]";
                //frm.add = new frmNhomDoiTacUpdate.AddNhomDoiTac(AddNhomDoiTac);
                //frm.LayDSNhomDoiTacDelegate = new frmCapNhatNhomDoiTac.GetDataTable(LayDSNhomDoiTac);
                frm.ShowDialog();
            }
            catch (Exception)
            {


            }
            
        }

        private void barSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
            //    if (grvData.RowCount == 0) return;
            //    DataRow row = grvData.GetFocusedDataRow();
            //    frmNhomDoiTacUpdate frm = new frmNhomDoiTacUpdate();
            //    frm.issua = true;
            //    frm.ndt_id = row["NDT_ID"].ToString().Trim();
            //    frm.frmText = "Khu vực [Sửa]";
            //    frm.edit = new frmNhomDoiTacUpdate.EditNhomDoiTac(EditNhomDoiTac);
            //    frm.ShowDialog();
            //}
            //catch (Exception)
            //{
            //    TTHMessage.ShowMessageWarming("Bạn chưa chọn dòng muốn sửa!");

            //}
            
        }

        private void barXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (grvData.RowCount == 0) return;
                DataRow row = grvData.GetFocusedDataRow();
                string kv_id = row["NDT_ID"].ToString().Trim();
                //Xoa mot dong
                if (TTHMessage.ShowMessageConfirm("Bạn có chắc muốn xóa dòng được chọn không?") == DialogResult.Yes)
                {
                    if (!XoaNhomDoiTac(kv_id))
                        TTHMessage.ShowMessageWarming("Không thể xóa dòng này do có sự ràng buộc dữ liệu. Xin vui lòng kiểm tra lại!");
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
            frmDMNhomDoiTac_Load(null, null);
            
        }

        private void barIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WaitDialogForm dg = new WaitDialogForm("Xin chờ trong giây lát!", "Đang load dữ liệu...");
            DataAccess cls = new DataAccess();
            FastReport.Report rpt = new FastReport.Report();
            rpt.Load(Application.StartupPath + "\\report\\DMNhomDoiTac.frx");
            DataTable dt = null;
            string sql = "select NDT_ID, NDT_Ten, NDT_ChietKhau, NDT_GhiChu, NDT_TrangThai from NhomDoiTac where NDT_ID <> 'ncc' order by NDT_Ten";
            dt = cls.GetDataTable(sql);
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
            TTHUtils.ExportToExcelFile(grvData, "NhomDoiTac");
        }


        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            barSua_ItemClick(null, null);
        }

        private void frmDMNhomDoiTac_Load(object sender, EventArgs e)
        {
            LayDSNhomDoiTac();
        }

        private void grvData_DoubleClick_1(object sender, EventArgs e)
        {
            barSua_ItemClick(null, null);
        }

        private void frmNhomDoiTac_Load(object sender, EventArgs e)
        {

        }

        

        
    }
}