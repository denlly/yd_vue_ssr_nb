using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace DLLibrary
{
    #region 针对单个单页面导出
    /// <summary>
    /// 针对单个单页面导出
    /// </summary>
    public partial class WordExport
    {

        public static void ExportHtml(string fileName, string strhtml, ControllerContext context)
        {
            if (fileName == null || fileName.Length == 0)
            {
                fileName = NewTimeStamp();//如果文件名为空，则生成一个时间戳命名文件
            }
            else
            {
                fileName += ".doc";
            }
            context.HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            context.HttpContext.Response.ContentType = "Application/msword";
            context.HttpContext.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            context.HttpContext.Response.Write(strhtml);
            context.HttpContext.Response.End();
        }
        /// <summary>
        /// mvc DataTable导出Word
        /// </summary>
        /// <param name="fileName">word的文件名，若为“”或"null"则会自动生成一个以当前时间命名的文件名</param>
        /// <param name="table">DataTable(此处为一条记录)</param>
        /// <param name="context">Controller的当前上下文</param>
        public static void Export(string fileName, DataTable table, ControllerContext context)
        {
            if (fileName == null || fileName.Length == 0)
            {
                fileName = NewTimeStamp();//如果文件名为空，则生成一个时间戳命名文件
            }
            else
            {
                fileName += ".doc";
            }
            context.HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            context.HttpContext.Response.ContentType = "Application/msword";
            context.HttpContext.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            context.HttpContext.Response.Write(GetWordData(table));
            context.HttpContext.Response.End();
        }
        /// <summary>
        /// 生成Word的数据（包括表头）
        /// </summary>
        /// <param name="header">
        /// 用英文逗号隔开的一段字符串如“编号,姓名,性别,”
        /// 表头，如果为“”或者 null 则默认为DataTable的ColumnName
        /// </param>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static StringWriter GetWordData(DataTable dt)
        {
            StringWriter sw = new StringWriter();
            sw.WriteLine("单个样品源详情如下：");
            try
            {
                #region
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string str = dt.Rows[i][j].ToString();
                        #region 处理时间
                        if (str == "1900/1/1 0:00:00")
                        {
                            str = DateTime.Now.ToString();
                        }
                        if (new TableToExcel().StrIsDate(str))
                        {
                            str = str.Substring(0, str.Length - 8);
                        }
                        #endregion
                        sb.Append(dt.Columns[j].ColumnName);
                        sb.Append("：");
                        sb.Append(dt.Rows[i][j] == null ? string.Empty : str);
                        sb.Append("\n");
                    }
                    sw.WriteLine(sb.ToString());
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            sw.Close();
            return sw;
        }

        /// <summary>
        /// 根据时间生成文件名
        /// </summary>
        /// <returns></returns>
        private static string NewTimeStamp()
        {
            string strFileName;
            //生成文件名: 当前年月日小时分钟秒+ 随机数
            Random rd = new Random(int.Parse(DateTime.Now.ToString("MMddhhmmss")));
            strFileName = DateTime.Now.ToString("yyyyMMdd")
                + DateTime.Now.Hour
                + DateTime.Now.Minute
                + DateTime.Now.Second
                + rd.Next(999999).ToString()
                + ".doc";
            return strFileName;
        }
    }
    #endregion

    #region 批量导出导出Word
    /// <summary>
    /// 批量导出导出Word
    /// </summary>
    public partial class WordExport
    {
        /// <summary>
        /// mvc DataTable导出Word
        /// </summary>
        /// <param name="fileName">word的文件名，若为“”或"null"则会自动生成一个以当前时间命名的文件名</param>
        /// <param name="table">DataTable(此处为一条记录)</param>
        /// <param name="context">Controller的当前上下文</param>
        public static void Export(string fileName, StringWriter sw, ControllerContext context)
        {
            if (fileName == null || fileName.Length == 0)
            {
                fileName = NewTimeStamp();//如果文件名为空，则生成一个时间戳命名文件
            }
            else
            {
                fileName += ".doc";
            }
            context.HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            context.HttpContext.Response.ContentType = "Application/msword";
            context.HttpContext.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            context.HttpContext.Response.Write(sw);
            context.HttpContext.Response.End();
        }

    }
    #endregion
}
