using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DevExpress.Utils;
namespace MyRMS
{
    public class DataAccess
    {
        ~DataAccess()
        {
        }
        //public SqlConnection conn = null;
        //public string strconn = "";
        //public DataAccess()
        //{

        //    strconn = DataAccessStatic.strconn;
        //    //conn = new SqlConnection(strconn);
            
        //}
        public DataTable GetDataTable(string sql)
        {
            DataAccessStatic.ReOpenConnection();
            DataTable dt = new DataTable();
            try
            {
                //conn = new SqlConnection(strconn);
                //conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand(sql, DataAccessStatic.conn);
                cmd.CommandTimeout = 30000;
                da.SelectCommand = cmd;
                da.Fill(dt);
                //conn.Close();
                //conn.Dispose();
            }
            catch (Exception ex)
            {
                dt = null;
                TTHMessage.ShowMessageWarming("Đã xảy ra lỗi: " + ex.ToString());
            }
            //dg.Close();
            return dt;
        }
        public string GetStringValue(string sql)
        {
            DataAccessStatic.ReOpenConnection();
            string str = "";
            DataTable dt = new DataTable();
            dt = GetDataTable(sql);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str = dr[0].ToString().Trim();
                    break;
                }
            }
            return str;
        }
        public bool ExecuteNonQuery(string sql)
        {
            DataAccessStatic.ReOpenConnection();
            bool ok = false;

            try
            {
                //conn = new SqlConnection(strconn);
                //conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(sql, DataAccessStatic.conn);

                cmd.ExecuteNonQuery();
                ok = true;
                //conn.Close();
                //conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception)
            {
                
                ok = false;
                //TTHMessage.ShowMessageWarming("Đã xảy ra lỗi: " + ex.ToString());
            }
            return ok;
        }
        public bool AddRecord(string table, string[] field, object[] obj)
        {
            DataAccessStatic.ReOpenConnection();
            Boolean ok = false;

            try
            {
                string sfield = "";
                string sfield1 = "";
                for (int i = 0; i < field.Length; i++)
                {
                    sfield = sfield + field[i] + ",";
                    sfield1 = sfield1 + "@" + field[i] + ",";

                }
                sfield = sfield.Substring(0, sfield.Length - 1);
                sfield1 = sfield1.Substring(0, sfield1.Length - 1);
                string sql = "insert into " + table + "(" + sfield + ") values (" + sfield1 + ")";
                //conn = new SqlConnection(strconn);
                //conn.Open();
                SqlCommand cmd = new SqlCommand(sql, DataAccessStatic.conn);
                for (int i = 0; i < field.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter("@" + field[i], obj[i]));
                }
                cmd.ExecuteNonQuery();

                ok = true;
                //conn.Close();
                //conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception)
            {
                ok = false;
            }
            return ok;
        }
        public bool EditRecord(string table, string[] fieldedit, object[] objedit, string[] fieldwhere, object[] objwhere)
        {
            DataAccessStatic.ReOpenConnection();
            bool ok = false;
            try
            {
                string sfieldedit = "";
                string sfieldwhere = "";
                for (int i = 0; i < fieldedit.Length; i++)
                {
                    sfieldedit = sfieldedit + fieldedit[i] + "=" + "@" + fieldedit[i] + ",";
                }
                sfieldedit = sfieldedit.Substring(0, sfieldedit.Length - 1);
                for (int i = 0; i < fieldwhere.Length; i++)
                {
                    sfieldwhere = sfieldwhere + fieldwhere[i] + " = @" + fieldwhere[i] + " and ";


                }

                sfieldwhere = sfieldwhere.Substring(0, sfieldwhere.Length - 5);

                string sql = "update  " + table + " set " + sfieldedit + " where " + sfieldwhere + "";
                //conn = new SqlConnection(strconn);
                //conn.Open();
                SqlCommand cmd = new SqlCommand(sql, DataAccessStatic.conn);
                for (int i = 0; i < fieldedit.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter("@" + fieldedit[i], objedit[i]));
                }
                for (int i = 0; i < fieldwhere.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter("@" + fieldwhere[i], objwhere[i]));
                }
                
                cmd.ExecuteNonQuery();
                ok = true;
                //conn.Close();
                //conn.Dispose();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                TTHMessage.ShowMessageError(ex.ToString());
                ok = false;
            }
            return ok;
        }
        public DataTable GetDataTableSP(string strSP)
        {
            DataAccessStatic.ReOpenConnection();
            DataTable dt = new DataTable();


            try
            {
                //conn = new SqlConnection(strconn);
                //conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DataAccessStatic.conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30000;
                cmd.CommandText = strSP;
                SqlDataAdapter myData = new SqlDataAdapter(cmd);
                myData.Fill(dt);
                //conn.Close();
                //conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }
        public DataTable GetDataTableSP(string strSP, string[] strPara, object[] strValue)
        {
            DataAccessStatic.ReOpenConnection();
            DataTable dt = new DataTable();
            try
            {
                //conn = new SqlConnection(strconn);
                //conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DataAccessStatic.conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30000;
                cmd.CommandText = strSP;
                SqlParameter myPara = null;
                for (int i = 0; i < strPara.Length; i++)
                {
                    myPara = new SqlParameter(strPara[i], strValue[i]);
                    cmd.Parameters.Add(myPara);
                }
                SqlDataAdapter myData = new SqlDataAdapter(cmd);
                myData.Fill(dt);
                //conn.Close();
                //conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }
        public bool ExecuteNonQuerySP(string strSP, string[] strPara, string[] strValue)
        {
            DataAccessStatic.ReOpenConnection();
            Boolean ok = true;

            try
            {
                //conn = new SqlConnection(strconn);
                //conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DataAccessStatic.conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = strSP;
                SqlParameter myPara = null;
                for (int i = 0; i < strValue.Length; i++)
                {
                    myPara = new SqlParameter(strPara[i], strValue[i]);
                    cmd.Parameters.Add(myPara);
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception)
            {
                ok = false;
            }
            return ok;
        }

        public double GetNumberValueSP(string strSP, string[] strPara, object[] strValue)
        {
            double value = 0;
            DataTable dt = new DataTable();
            dt = GetDataTableSP(strSP, strPara, strValue);
            if (dt != null)
            {
                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        value = double.Parse(dr[0].ToString());
                    }
                }
                catch (Exception)
                {
                    value = 0;
                }

            }
            return value;
        }
        public string GetStringValueSP(string strSP)
        {
            string str = "";
            DataTable dt = new DataTable();
            dt = GetDataTableSP(strSP);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str = dr[0].ToString().Trim();
                    break;
                }
            }
            return str;
        }
        public string GetStringValueSP(string strSP, string[] strPara, object[] strValue)
        {
            string str = "";
            DataTable dt = new DataTable();
            dt = GetDataTableSP(strSP, strPara, strValue);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str = dr[0].ToString().Trim();
                    break;
                }
            }
            return str;
        }
        public Boolean GetBooleanValueSP(string strSP, string[] strPara, object[] strValue)
        {
            Boolean bo = false;
            DataTable dt = new DataTable();
            dt = GetDataTableSP(strSP, strPara, strValue);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    bo = (Boolean)dr[0];
                    break;
                }
            }
            return bo;
        }
        public double GetNumberValue(string sql)
        {
            double value = 0;
            DataTable dt = new DataTable();
            dt = GetDataTable(sql);
            if (dt != null)
            {
                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        value = double.Parse(dr[0].ToString());
                    }
                }
                catch (Exception)
                {
                    value = 0;
                }

            }
            return value;
        }
        public bool IsExist(string sql)
        {

            DataTable dt = new DataTable();
            dt = GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }


        ///SU DUNG TRANSACTION
        public DataTable GetDataTableTrans(string query)
        {
            //DataAccessStatic.ReOpenConnection();
            DataTable dt = new DataTable();
            //if (DataAccessStatic.conn.State == ConnectionState.Closed)
            //{
            //    try
            //    {
            //        DataAccessStatic.conn = new SqlConnection(DataAccessStatic.strconn);
            //        DataAccessStatic.conn.Open();
            //    }
            //    catch (Exception)
            //    {
            //        TTHMessage.ShowMessageWarming("Lỗi kết nối dữ liệu!");
            //        dt = null;
            //        return dt;
            //    }

            //}
            
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = DataAccessStatic.conn.CreateCommand();
            cmd.CommandText = query;
            cmd.Transaction = DataAccessStatic.sqltrans;
            cmd.CommandTimeout = 30000;
            da.SelectCommand = cmd;
            try
            {
                da.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }
            
            return dt;
        }
        //Thuc thi cau lenh sql trong mot Transaction
        public Boolean ExecuteNonQueryTrans(string sql)
        {
            //DataAccessStatic.ReOpenConnection();
            Boolean ok = false;
            SqlCommand cmd = DataAccessStatic.conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Transaction = DataAccessStatic.sqltrans;
            try
            {
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                ok = true;
            }
            catch (Exception)
            {
                ok = false;
            }
            return ok;

        }
        public bool ExecuteNonQuerySPTrans(string strSP, string[] strPara, string[] strValue)
        {
            //DataAccessStatic.ReOpenConnection();
            Boolean ok = true;
            try
            {
                SqlCommand cmd = DataAccessStatic.conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = strSP;

                cmd.Transaction = DataAccessStatic.sqltrans;
                SqlParameter myPara = null;
                for (int i = 0; i < strValue.Length; i++)
                {
                    myPara = new SqlParameter(strPara[i], strValue[i]);
                    cmd.Parameters.Add(myPara);
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception)
            {
                ok = false;
            }
            return ok;
        }
        public bool AddRecordTrans(string table, string[] field, object[] obj)
        {
            //DataAccessStatic.ReOpenConnection();
            bool ok = false;
            try
            {
                string sfield = "";
                string sfield1 = "";
                for (int i = 0; i < field.Length; i++)
                {
                    sfield = sfield + field[i] + ",";
                    sfield1 = sfield1 + "@" + field[i] + ",";

                }

                sfield = sfield.Substring(0, sfield.Length - 1);
                sfield1 = sfield1.Substring(0, sfield1.Length - 1);
                string sql = "insert into " + table + "(" + sfield + ") values (" + sfield1 + ")";
                SqlCommand cmd = DataAccessStatic.conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Transaction = DataAccessStatic.sqltrans;
                for (int i = 0; i < field.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter("@" + field[i], obj[i]));
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                ok = true;
            }
            catch (Exception ex)
            {
                TTHMessage.ShowMessageWarming(ex.ToString());
                ok = false;
            }
            return ok;
        }
        public bool EditRecordTrans(string table, string[] fieldedit, object[] objedit, string[] fieldwhere, object[] objwhere)
        {
            //DataAccessStatic.ReOpenConnection();
            bool ok = false;
            try
            {
                string sfieldedit = "";
                string sfieldwhere = "";
                for (int i = 0; i < fieldedit.Length; i++)
                {
                    sfieldedit = sfieldedit + fieldedit[i] + "=" + "@" + fieldedit[i] + ",";
                }
                sfieldedit = sfieldedit.Substring(0, sfieldedit.Length - 1);
                for (int i = 0; i < fieldwhere.Length; i++)
                {
                    sfieldwhere = sfieldwhere + fieldwhere[i] + " = @" + fieldwhere[i] + " and ";
                }
                sfieldwhere = sfieldwhere.Substring(0, sfieldwhere.Length - 5);
                string sql = "update  " + table + " set " + sfieldedit + " where " + sfieldwhere + "";
                SqlCommand cmd = DataAccessStatic.conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Transaction = DataAccessStatic.sqltrans;
                for (int i = 0; i < fieldedit.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter("@" + fieldedit[i], objedit[i]));
                }
                for (int i = 0; i < fieldwhere.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter("@" + fieldwhere[i], objwhere[i]));
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                ok = true;
            }
            catch (Exception)
            {

                ok = false;
            }
            return ok;
        }
    }
}
