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
    public partial class frmLoaiHang : DevExpress.XtraEditors.XtraForm
    {
        public delegate void DisplayObject();
        public DisplayObject DisplayBackgroung;
        public void LayDSLoaiHang()
        {
            DataAccess cls = new DataAccess();
            WaitDialogForm dg = new WaitDialogForm("Xin chờ trong giây lát!", "Đang load dữ liệu...");
            string sql = "select LH_ID, LH_Ten, LH_GhiChu, LH_KichHoat from LoaiHang where LH_DV_ID = '" + Info.dv_id + "' order by LH_Ten";
            grcData.DataSource = cls.GetDataTable(sql);
            grvData.BestFitColumns();
            grvData.ExpandAllGroups();
            dg.Close();
        }
        public Boolean XoaLoaiHang(string LH_ID)
        {
            DataAccess cls = new DataAccess();
            string sql = "delete LoaiHang where LH_ID = '" + LH_ID + "'";
            return cls.ExecuteNonQuery(sql);
        }
        public void EditLoaiHang(string LH_ID, string LH_Ten, string LH_GhiChu, Boolean LH_KichHoat)
        {
            //sửa loại hàng và cập nhật lại giá trị
            grvData.SetFocusedRowCellValue("LH_ID", LH_ID);
            grvData.SetFocusedRowCellValue("LH_Ten", LH_Ten);
            grvData.SetFocusedRowCellValue("LH_GhiChu", LH_GhiChu);
            grvData.SetFocusedRowCellValue("LH_KichHoat", LH_KichHoat);
            
        }
        public void AddLoaiHang(string LH_ID, string LH_Ten, string LH_GhiChu, Boolean LH_KichHoat)
        {
            WaitDialogForm dg = new WaitDialogForm("Xin chờ trong giây lát!", "Đang load dữ liệu...");
            DataTable dt = (DataTable)grcData.DataSource;
            DataRow dr = dt.NewRow();
            dr["LH_ID"] = LH_ID;
            dr["LH_Ten"] = LH_Ten;
            dr["LH_GhiChu"] = LH_GhiChu;
            dr["LH_KichHoat"] = LH_KichHoat;
            //vi tri dong dang focus
            int pos = -1;
            if (grvData.RowCount > 0)
            {
                pos = grvData.FocusedRowHandle;
                if (pos < 0)
                    pos = -1;
                else grvData.UnselectRow(pos);
            }
            dt.Rows.InsertAt(dr, pos+1);
            grcData.DataSource = dt;
            grvData.FocusedRowHandle = pos+1;
            dg.Close();
        }
        
        public frmLoaiHang()
        {
            InitializeComponent();
        }
        

       

        private void barSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (grvData.RowCount == 0) return;
                DataRow row = grvData.GetFocusedDataRow();
                frmLoaiHangUpdate frm = new frmLoaiHangUpdate();
                frm.issua = true;
                frm.lh_id = row["LH_ID"].ToString().Trim();
                frm.frmText = "Loại hàng [Sửa]";
                frm.LayDSLoaiHang = new frmLoaiHangUpdate.GetDataTableDelegate(LayDSLoaiHang);
                frm.ShowDialog();
            }
            catch (Exception)
            {
                TTHMessage.ShowMessageWarming("Xin chọn dòng muốn sửa!");

            }
            
        }

        private void barXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (grvData.RowCount == 0) return;
                DataRow row = grvData.GetFocusedDataRow();
                string lh_id = row["LH_ID"].ToString().Trim();
                //Xoa mot dong
                if (TTHMessage.ShowMessageConfirm("Bạn có chắc muốn xóa dòng được chọn không?") == DialogResult.Yes)
                {
                    if (!XoaLoaiHang(lh_id))
                        TTHMessage.ShowMessageError( "Không thể xóa dòng này!");
                    else
                    {
                        row.Delete();
                    }
                }
            }
            catch (Exception)
            {
                TTHMessage.ShowMessageWarming("Xin chọn dòng muốn xóa!");

            }
            
        }

        private void barTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLoaiHang_Load(null, null);
        }

        private void barIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WaitDialogForm dg = new WaitDialogForm("Xin chờ trong giây lát!", "Đang load dữ liệu...");
            DataAccess cls = new DataAccess();
            FastReport.Report rpt = new FastReport.Report();
            rpt.Load(Application.StartupPath + "\\report\\DMLoaiHang.frx");
            DataTable dt = null;
            string sql = "select LH_ID, LH_Ten, LH_GhiChu, LH_KichHoat from LoaiHang where LH_DV_ID = '" + Info.dv_id + "' order by LH_Ten";
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
            TTHUtils.ExportToExcelFile(grvData, "LoaiHang");
        }


        private void grvLoaiHang_DoubleClick(object sender, EventArgs e)
        {
            barSua_ItemClick(null, null);
        }

        private void frmLoaiHang_Load(object sender, EventArgs e)
        {
            LayDSLoaiHang();
        }

        private void barThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmLoaiHangUpdate frm = new frmLoaiHangUpdate();
                frm.frmText = "Loại hàng [Thêm]";
                frm.AddLoaiHang = new frmLoaiHangUpdate.AddLoaiHangDelegate(AddLoaiHang);
                frm.ShowDialog();
            }
            catch (Exception)
            {


            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
                TTHMessage.ShowMessageInfomation("aaa");
        }

        
    }
}