using System;
using System.Web.Mvc;
using System.IO;
using System.Data;

namespace DLLibrary
{
    public static class ExcelExport
    {
        /// <summary>
        /// mvc DataTable导出Excel
        /// </summary>
        /// <param name="fileName">excel的文件名，若为“”或"null"则会自动生成一个以当前时间命名的文件名</param>
        /// <param name="table">DataTable</param>
        /// <param name="headers">excel的表头。如为“null”或“” 则表头会是DataTable的ColumnName</param>
        /// <param name="context">Controller的当前上下文</param>
        public static void Export(string fileName, DataTable table, string headers, ControllerContext context)
        {
            TableToExcel tableToExcel = new TableToExcel();
            if (fileName == null || fileName.Length == 0)
            {
                fileName = tableToExcel.NewTimeStamp();//如果文件名为空，则生成一个时间戳命名文件
            }
            else
            {
                fileName += ".xls";
            }
            context.HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            context.HttpContext.Response.ContentType = "vnd.ms-excel.numberformat:yyyy-MM-dd ";
            context.HttpContext.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            context.HttpContext.Response.Write(tableToExcel.GetExcelData(headers, table));
            context.HttpContext.Response.End();
        }
    }
    #region DataTable导出Excel
    /// <summary>
    /// DataTable导出Excel
    /// </summary>
    public class TableToExcel
    {
        /// <summary>
        /// 生成excel的数据（包括表头）
        /// </summary>
        /// <param name="header">
        /// 用英文逗号隔开的一段字符串如“编号,姓名,性别,”
        /// 表头，如果为“”或者 null 则默认为DataTable的ColumnName
        /// </param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public StringWriter GetExcelData(string header, DataTable dt)
        {
            StringWriter sw = new StringWriter();
            try
            {
                #region 标题
                //excel的标题（不是文件标题）
                string title = "";
                if (header == null || header.Length == 0)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        title += col.ColumnName.ToString() + "\t";
                    }
                }
                else
                {
                    string[] arrHeader = header.Split(',');
                    if (arrHeader.Length > 0)
                    {
                        for (int t = 0; t < arrHeader.Length; t++)
                        {
                            title += arrHeader[t].ToString() + "\t";
                        }
                    }
                }
                sw.WriteLine(title);//标头
                #endregion
                #region excel的数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string content = string.Empty;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string str = dt.Rows[i][j].ToString();
                        if (str == "1900/1/1 0:00:00")
                        {
                            str = DateTime.Now.ToString();
                        }
                        if (StrIsDate(str))
                        {
                            str = str.Substring(0, str.Length - 8);
                        }
                        content += dt.Rows[i][j] == null ? string.Empty : str + "\t";
                    }
                    sw.WriteLine(content);
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
        public bool StrIsDate(string str)
        {
            bool flag = false;
            if (str.Length >= 16 && str.Length <= 19)
            {
                if (str.IndexOf(' ') > 0)
                {
                    if (str.IndexOf('/') == 4 && (str.LastIndexOf('/') == 6 || str.LastIndexOf('/') == 7))
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// 根据时间生成文件名
        /// </summary>
        /// <returns></returns>
        public string NewTimeStamp()
        {
            string strFileName;
            //生成文件名: 当前年月日小时分钟秒+ 随机数
            Random rd = new Random(int.Parse(DateTime.Now.ToString("MMddhhmmss")));
            strFileName = DateTime.Now.ToString("yyyyMMdd")
                + DateTime.Now.Hour
                + DateTime.Now.Minute
                + DateTime.Now.Second
                + rd.Next(999999).ToString()
                + ".xls";
            return strFileName;
        }
    }
    #endregion
}
