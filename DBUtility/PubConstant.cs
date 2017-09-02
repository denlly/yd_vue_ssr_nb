using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
namespace DBUtility
{
    public class PubConstant
    {
        #region ===获取连接字符串===
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                //string _connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                //string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                string _connectionString = ConfigurationManager.ConnectionStrings["StudentDB_ConnString"].ToString();
                string ConStringEncrypt = ConfigurationManager.ConnectionStrings["StudentDB_ConnString"].ToString(); 
                if (ConStringEncrypt == "true")
                {

                    _connectionString = DLLibrary.Common.Decrypt(_connectionString);
                }
                return _connectionString;
            }
        }
        #endregion

        #region ===利用链接字符串链接EXCEL2003===
        public static string ConnExcelString(string mypath)
        {
            //string strConn ="Provider=Microsoft.Jet.OLEDB.4.0;"+"DataSource="+Path+";"+"ExtendedProperties=Excel8.0;";
            string oleDBConnString = String.Empty;
            oleDBConnString = "Provider=Microsoft.Jet.OLEDB.4.0;";
            oleDBConnString += "Data Source=";
            oleDBConnString += mypath;
            oleDBConnString += ";Extended Properties=Excel 8.0;";
            return oleDBConnString;
        }
        #endregion

        #region 得到web.config里配置项的数据库连接字符串。
        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = ConfigurationManager.AppSettings[configName];
            string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
            if (ConStringEncrypt == "true")
            {
                connectionString = DLLibrary.Common.Decrypt(connectionString);
            }
            return connectionString;
        }
        #endregion

    }
}
