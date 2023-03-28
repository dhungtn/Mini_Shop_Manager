using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MyRMS
{
    public static class DataAccessStatic
    {
        public static SqlConnection conn = null;
        public static SqlTransaction sqltrans;
        public static string authenwindows = "True";
        public static string servername = "";
        public static string username = "";
        public static string password = "";
        public static string database = "";
        public static string path = "";
        public static string save = "False";
        public static string strconn = "";
        static DataAccessStatic()
        {
            conn = new SqlConnection();
        }
        
        public static void OpenConnection()
        {
            try
            {
                conn = new SqlConnection(strconn);
                conn.Open();
                //TTHMessage.ShowMessageInfomation(conn.State.ToString());
            }
            catch (Exception ex)
            {
                TTHMessage.ShowMessageInfomation(ex.ToString());
                
            }
            
        }
        public static void ReOpenConnection()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    //conn = new SqlConnection(strconn);                        
                    //TTHMessage.ShowMessageInfomation("aaa");
                    conn.Open();
                }
                //TTHMessage.ShowMessageInfomation(conn.State.ToString());
            }
            catch (Exception ex)
            {
                TTHMessage.ShowMessageInfomation(ex.ToString());

            }
        }
        public static void CloseConnection()
        {
            try
            {
                if (conn.State != ConnectionState.Closed)
                {
                    //TTHMessage.ShowMessageInfomation("aaa");
                    conn.Close();
                    conn.Dispose();
                }
                //TTHMessage.ShowMessageInfomation(conn.State.ToString());
            }
            catch (Exception ex)
            {
                TTHMessage.ShowMessageInfomation(ex.ToString());

            }
        }
    }
}
