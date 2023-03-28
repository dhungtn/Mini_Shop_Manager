using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace MyRMS
{
    public class SQLServer
    {
        public string strconn = "";
        public SqlConnection sqlconn = null;
        public SQLServer()
        {

        }
        public SQLServer(string strconn)
        {
            try
            {
                sqlconn = new SqlConnection(strconn);
                sqlconn.Open();
            }
            catch (Exception)
            {
                sqlconn = null;
            }
        }
        public Boolean ConnectSQLServer(string strconn)
        {
            Boolean ok = false;
            try
            {
                this.strconn = strconn;
                this.sqlconn = new SqlConnection(strconn);
                this.sqlconn.Open();
                ok = true;
            }
            catch (Exception)
            {
                sqlconn = null;
                ok = false;
            }
            return ok;
        }
        public bool ExecuteSQLCommand(string query)
        {
            bool ok = false;
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand(query, sqlconn);
            try
            {
                cmd.ExecuteNonQuery();
                ok = true;
            }
            catch (Exception)
            {

                ok = false;
            }
            return ok;
        }
        public DataTable GetAllDatabase()
        {

            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT [name] FROM [master].[dbo].[sysdatabases]";
                SqlDataAdapter da = new SqlDataAdapter(sql, sqlconn);
                da.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;

            }
            return dt;
        }
        public Boolean IsExistDatabase(string databasename)
        {
            Boolean ok = false;
            DataTable dt = GetAllDatabase();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[0].ToString().Trim().Equals(databasename))
                {
                    ok = true;
                    break;
                }
            }
            return ok;
        }

        
    }
}
