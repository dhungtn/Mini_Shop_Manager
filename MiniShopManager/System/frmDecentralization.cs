using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MyRMS.HeThong
{
    public partial class frmPhanQuyen : DevExpress.XtraEditors.XtraForm
    {
        DataAccess cls = new DataAccess();
        public delegate void DisplayObject();
        public DisplayObject DisplayBackgroung;
        public frmPhanQuyen()
        {
            InitializeComponent();
        }
        public void LayDSNguoiDung()
        {
            string sql = "select ND_ID, ND_Ten, VT_Ten from NguoiDung left join VaiTro on ND_VT_ID = VT_ID ";
            sql += "where ND_KichHoat = 'True' ";
            grcNguoiDung.DataSource = cls.GetDataTable(sql);
            grvNguoiDung.ExpandAllGroups();
        }
        public void LayDSQuyenNguoiDung(string nd_id)
        {
            //string sql = "select NCN_Ten, Q_ID, CN_Ten, Q_TruyCap, Q_Them, Q_Sua, Q_Xoa, Q_In, Q_Nhap, Q_Xuat ";
            //sql += "from Quyen left join ChucNang on Q_CN_ID = CN_ID ";
            //sql += "left join NhomChucNang on CN_NCN_ID = NCN_ID ";
            //sql += "where Q_ND_ID = '" + nd_id + "' ";
            //sql += "order by NCN_Ten, CN_Ten ";
            string sql = "";
            sql += "select NCN_Ten,isnull(Q_ID,'') as Q_ID, CN_ID, CN_Ten, isnull(Q_TatCa, convert(bit,'false')) as Q_TatCa, isnull(Q_TruyCap, convert(bit,'false')) as Q_TruyCap, isnull(Q_Them, convert(bit,'false')) as Q_Them, isnull(Q_Sua, convert(bit,'false')) as Q_Sua, isnull(Q_Xoa, convert(bit,'false')) as Q_Xoa, isnull(Q_In, convert(bit,'false')) as Q_In, isnull(Q_Nhap, convert(bit,'false')) as Q_Nhap, isnull(Q_xuat, convert(bit,'false')) as Q_Xuat ";
            sql += "from ChucNang left join  ";
            sql += "( ";
            sql += "select Q_ID, Q_CN_ID, Q_TruyCap, Q_Them, Q_Sua, Q_Xoa, Q_In, Q_Nhap, Q_xuat, Q_TatCa ";
            sql += "from Quyen where Q_ND_ID = '" + nd_id + "' ";
            sql += ") temp on CN_ID = Q_CN_ID ";
            sql += "left join NhomChucNang on CN_NCN_ID = NCN_ID ";
            sql += "order by NCN_Ten, CN_Ten ";

            grcQuyen.DataSource = cls.GetDataTable(sql);
            grvQuyen.ExpandAllGroups();
        }
        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            LayDSNguoiDung();
        }

        private void grvNguoiDung_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow row = grvNguoiDung.GetFocusedDataRow();
                LayDSQuyenNguoiDung(row["ND_ID"].ToString().Trim());
            }
            catch (Exception)
            {
                
                
            }
        }
        public void CapNhatQuyen(string nd_id, string cn_id, string act_id, string value)
        {
            try
            {
                if (!cls.IsExist("select Q_ID from Quyen where Q_ND_ID = '" + nd_id + "' and Q_CN_ID = '" + cn_id + "'"))
                {
                    string sql = "insert into Quyen(Q_ID, Q_CN_ID, Q_ND_ID, Q_TruyCap, Q_Them, Q_Sua, Q_Xoa, Q_In, Q_Nhap, Q_Xuat, Q_TatCa) ";
                    sql += "values ('" + DateTime.Now.ToString("yyMMddHHmmss") + "', '" + cn_id + "', '" + nd_id + "', 'False', 'False', 'False', 'False', 'False', 'False', 'False', 'False') ";
                    cls.ExecuteNonQuery(sql);
                }
                cls.ExecuteNonQuery("Update Quyen set " + act_id + "='" + value + "' where Q_ND_ID = '" + nd_id + "' and Q_CN_ID = '" + cn_id + "'");
            }
            catch (Exception)
            {
                
                
            }
        }
        private void rchkThem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DataRow row_nd = grvNguoiDung.GetFocusedDataRow();
                DataRow row_q = grvQuyen.GetFocusedDataRow();
                CapNhatQuyen(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim(), "Q_Them", e.NewValue.ToString());
                //if (!IsCheckAll(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim()))
                //{
                //    CapNhatQuyen(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim(), "Q_TatCa", "false");
                //    grvQuyen.SetFocusedRowCellValue("Q_TatCa", false);
                //}
                //else
                //{
                //    CapNhatQuyen(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim(), "Q_TatCa", "true");
                //    grvQuyen.SetFocusedRowCellValue("Q_TatCa", true);
                //}
            }
            catch (Exception)
            {
                
                
            }
            
        }

        private void rchkSua_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DataRow row_nd = grvNguoiDung.GetFocusedDataRow();
                DataRow row_q = grvQuyen.GetFocusedDataRow();
                CapNhatQuyen(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim(), "Q_Sua", e.NewValue.ToString());
                //if (!IsCheckAll(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim()))
                //{
                //    CapNhatQuyen(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim(), "Q_TatCa", "false");
                //    grvQuyen.SetFocusedRowCellValue("Q_TatCa", false);
                //}
                //else
                //{
                //    CapNhatQuyen(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim(), "Q_TatCa", "true");
                //    grvQuyen.SetFocusedRowCellValue("Q_TatCa", true);
                //}
            }
            catch (Exception)
            {


            }
        }

        private void rchkXoa_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DataRow row_nd = grvNguoiDung.GetFocusedDataRow();
                DataRow row_q = grvQuyen.GetFocusedDataRow();
                CapNhatQuyen(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim(), "Q_Xoa", e.NewValue.ToString());
                //if (!IsCheckAll(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim()))
                //{
                //    CapNhatQuyen(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim(), "Q_TatCa", "false");
                //    grvQuyen.SetFocusedRowCellValue("Q_TatCa", false);
                //}
                //else
                //{
                //    CapNhatQuyen(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim(), "Q_TatCa", "true");
                //    grvQuyen.SetFocusedRowCellValue("Q_TatCa", true);
                //}
            }
            catch (Exception)
            {


            }
        }

        private void rchkIn_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DataRow row_nd = grvNguoiDung.GetFocusedDataRow();
                DataRow row_q = grvQuyen.GetFocusedDataRow();
                CapNhatQuyen(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim(), "Q_In", e.NewValue.ToString());
                //if (!IsCheckAll(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim()))
                //{
                //    CapNhatQuyen(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim(), "Q_TatCa", "false");
                //    grvQuyen.SetFocusedRowCellValue("Q_TatCa", false);
                //}
                //else
                //{
                //    CapNhatQuyen(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim(), "Q_TatCa", "true");
                //    grvQuyen.SetFocusedRowCellValue("Q_TatCa", true);
                //}
            }
            catch (Exception)
            {


            }
        }

        private void rchkNhap_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DataRow row_nd = grvNguoiDung.GetFocusedDataRow();
                DataRow row_q = grvQuyen.GetFocusedDataRow();
                CapNhatQuyen(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim(), "Q_Nhap", e.NewValue.ToString());
                //if (!IsCheckAll(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim()))
                //{
                //    CapNhatQuyen(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim(), "Q_TatCa", "false");
                //    grvQuyen.SetFocusedRowCellValue("Q_TatCa", false);
                //}
                //else
                //{
                //    CapNhatQuyen(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim(), "Q_TatCa", "true");
                //    grvQuyen.SetFocusedRowCellValue("Q_TatCa", true);
                //}
            }
            catch (Exception)
            {


            }
        }

        private void rchkXuat_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DataRow row_nd = grvNguoiDung.GetFocusedDataRow();
                DataRow row_q = grvQuyen.GetFocusedDataRow();
                CapNhatQuyen(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim(), "Q_Xuat", e.NewValue.ToString());
                //if (!IsCheckAll(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim()))
                //{
                //    CapNhatQuyen(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim(), "Q_TatCa", "false");
                //    grvQuyen.SetFocusedRowCellValue("Q_TatCa", false);
                //}
                //else
                //{
                //    CapNhatQuyen(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim(), "Q_TatCa", "true");
                //    grvQuyen.SetFocusedRowCellValue("Q_TatCa", true);
                //}
            }
            catch (Exception)
            {


            }
        }

        private void rchkTruyCap_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DataRow row_nd = grvNguoiDung.GetFocusedDataRow();
                DataRow row_q = grvQuyen.GetFocusedDataRow();
                CapNhatQuyen(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim(), "Q_TruyCap", e.NewValue.ToString());
                //if (!IsCheckAll(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim()))
                //{
                //    CapNhatQuyen(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim(), "Q_TatCa", "false");
                //    row_q["Q_TatCa"] = false;
                //}
                //else
                //{
                //    CapNhatQuyen(row_nd["ND_ID"].ToString().Trim(), row_q["CN_ID"].ToString().Trim(), "Q_TatCa", "true");
                //    row_q["Q_TatCa"] = true;
                //}
            }
            catch (Exception)
            {


            }
        }

        private void rchkTatCa_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DataRow row_nd = grvNguoiDung.GetFocusedDataRow();
                DataRow row_q = grvQuyen.GetFocusedDataRow();
                string nd_id = row_nd["ND_ID"].ToString().Trim();
                string cn_id = row_q["CN_ID"].ToString().Trim();
                if (!cls.IsExist("select Q_ID from Quyen where Q_ND_ID = '" + nd_id + "' and Q_CN_ID = '" + cn_id + "'"))
                {
                    if ((Boolean)e.NewValue == true)
                    {
                        string sql = "insert into Quyen(Q_ID, Q_CN_ID, Q_ND_ID, Q_TruyCap, Q_Them, Q_Sua, Q_Xoa, Q_In, Q_Nhap, Q_Xuat, Q_TatCa) ";
                        sql += "values ('" + DateTime.Now.ToString("yyMMddHHmmss") + "', '" + cn_id + "', '" + nd_id + "', 'True', 'True', 'True', 'True', 'True', 'True', 'True', 'True') ";
                        if(cls.ExecuteNonQuery(sql))
                        {
                            row_q["Q_TruyCap"] = true;
                            row_q["Q_Them"] = true;
                            row_q["Q_Sua"] = true;
                            row_q["Q_Xoa"] = true;
                            row_q["Q_In"] = true;
                            row_q["Q_Nhap"] = true;
                            row_q["Q_Xuat"] = true;
                        }
                    }

                }
                else
                {
                    if ((Boolean)e.NewValue == true)
                    {
                        string sql = "update Quyen set  Q_TatCa = 'True', Q_TruyCap = 'true', Q_Them = 'true', Q_Sua = 'true', Q_Xoa = 'true', Q_In = 'true', Q_Nhap = 'true', Q_xuat = 'true' ";
                        sql += "where  Q_ND_ID = '" + nd_id + "' and Q_CN_ID = '" + cn_id + "' ";
                        if (cls.ExecuteNonQuery(sql))
                        {
                            row_q["Q_TruyCap"] = true;
                            row_q["Q_Them"] = true;
                            row_q["Q_Sua"] = true;
                            row_q["Q_Xoa"] = true;
                            row_q["Q_In"] = true;
                            row_q["Q_Nhap"] = true;
                            row_q["Q_Xuat"] = true;
                        }
                    }
                    else
                    {
                        string sql = "delete Quyen where  Q_ND_ID = '" + nd_id + "' and Q_CN_ID = '" + cn_id + "' ";
                        if (cls.ExecuteNonQuery(sql))
                        {
                            row_q["Q_TruyCap"] = false;
                            row_q["Q_Them"] = false;
                            row_q["Q_Sua"] = false;
                            row_q["Q_Xoa"] = false;
                            row_q["Q_In"] = false;
                            row_q["Q_Nhap"] = false;
                            row_q["Q_Xuat"] = false;
                        }
                    }
                }
            }
            catch (Exception)
            {


            }
        }
        public Boolean IsCheckAll(string nd_id, string cn_id)
        {
            string sql = "select Q_ID from Quyen ";
            sql += "where Q_ND_ID = '" + nd_id + "' and Q_CN_ID = '" + cn_id + "' ";
            sql += "and Q_TruyCap = 'True' and Q_Them = 'True' and Q_Sua = 'True' and Q_Xoa = 'True' and Q_In = 'True' and Q_Nhap = 'True' and Q_Xuat = 'True' ";
            return cls.IsExist(sql);
        }
        private void grvQuyen_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            
        }

        private void chkChonTatCa_CheckedChanged(object sender, EventArgs e)
        {
            DataRow row_nd = grvNguoiDung.GetFocusedDataRow();
            if (chkChonTatCa.Checked)
            {
                
                if (cls.ExecuteNonQuery("delete Quyen where Q_ND_ID = '" + row_nd["ND_ID"].ToString().Trim() + "'"))
                {
                    int i = 1;
                    foreach (DataRow dr in cls.GetDataTable("select CN_ID from ChucNang").Rows)
                    {
                        string sql = "insert into Quyen(Q_ID, Q_CN_ID, Q_ND_ID, Q_TruyCap, Q_Them, Q_Sua, Q_Xoa, Q_In, Q_Nhap, Q_Xuat, Q_TatCa) ";
                        sql += "values ('" + DateTime.Now.ToString("yyMMddHHmmss") + string.Format("{0,3:000}", i) + "', '" + dr["CN_ID"].ToString().Trim() + "', '" + row_nd["ND_ID"].ToString().Trim() + "', 'True', 'True', 'True', 'True', 'True', 'True', 'True', 'True') ";
                        cls.ExecuteNonQuery(sql);
                        i = i + 1;
                    }
                    LayDSQuyenNguoiDung(row_nd["ND_ID"].ToString().Trim());
                }
            }
            else
            {
                if(cls.ExecuteNonQuery("delete Quyen where Q_ND_ID = '" + row_nd["ND_ID"].ToString().Trim() + "'"))
                    LayDSQuyenNguoiDung(row_nd["ND_ID"].ToString().Trim());
            }
        }
    }
}