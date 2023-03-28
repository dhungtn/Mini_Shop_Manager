using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace MyRMS
{
    public static class Info
    {
        public static string dv_id = "000001";
        public static string dv_ten = "";
        public static string dv_diachi = "";
        public static string dv_dienthoai = "";
        public static string dv_fax = "";
        public static string dv_email = "";
        public static string dv_masothue = "";
        public static string dv_nguoilienhe = "";
        public static string dv_chucvu = "";
        public static string dv_sotaikhoan = "";
        public static string dv_nganhang = "";
        public static string dv_chutaikhoan = "";
        public static DateTime dv_ngaysudung = DateTime.Now;
        
        public static string mayinmavach = "";
        public static string mayinhoadon = "";
        public static string mayinvanban = "";
        public static string mayinchebien = "";
        public static Boolean xemtruockhiin = false;
        public static Boolean sudungmavach = false;
        public static Boolean suadongia = false;
        public static Boolean suasoluong = false;
        public static Boolean nhapgiamgia = false;
        public static double giamgiamacdinh = 0;
        public static Boolean sudungchuongtrinh = false;
        public static double doanhsotuongungdiem = 0;
        public static Boolean chonkhohang = false;
        public static string kh_id = "kmd";
        public static Boolean xuatlonhonton = false;
        public static string mauhoadon = "";
        public static string dt_id = "171005052300";
        public static string clv_id = "140115090841";
        
        public static Boolean tusinhma = false;
        public static Boolean thongbaohangton = false;
        public static Boolean chophepdoingay = false;
        public static Boolean thutuchungtugiam = false;
        public static Boolean chophepnhapnhieulan = false;

        public static bool isRegister = false;
        public static double numRecord = 20;
        public static string tenphanmem = "PHẦN MỀM QUẢN LÝ BÁN HÀNG";
        public static string tendulieu = "";
        public static string skinname = "";
        public static Boolean islogin = false;
        public static Boolean isconfig = false;

        public static string nd_id = "";
        public static string nd_ten = "";
        public static string nd_tendangnhap = "";
        public static Boolean nd_dadangky = false;
        public static string nd_vt_id = "";
        public static string productkey = "";
        public static int dodaimavach = 8;
        public static int dodaimadoitac = 8;

        public static Boolean KiemTraQuyen(string quyen, string cn_id)
        {
            string sql = "select Q_ID from Quyen where " + quyen + " = 'True' and Q_ND_ID = '" + Info.nd_id + "' and Q_CN_ID = '" + cn_id + "'";
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(sql, DataAccessStatic.conn);
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                cmd.Dispose();
            }
            catch (Exception)
            {
                dt = null;
            }
            Boolean ok = false;
            try
            {
                if (dt.Rows.Count > 0) ok = true;
            }
            catch (Exception)
            {
                
                
            }
            return ok;
        }
    }
}
