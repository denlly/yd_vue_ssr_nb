using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Web;

namespace DLLibrary
{
    public static class UplodFile
    {

        /// <summary>
        /// file upload server
        /// </summary>
        /// <param name="uploadFile"></param>
        /// <param name="error"></param>
        /// <param name="message"></param>
        /// <param name="url"></param>
        /// <param name="file_Name"></param>
        public static void ProcessUpload(HttpPostedFileBase uploadFile, HttpContextBase httpContext, out int error, out string message, out string url, out string file_Name)
        {
            HttpContextBase context = httpContext;

            //allow extinsion
            Dictionary<string, string> extTable = new Dictionary<string, string>();
            //extTable.Add("image", ".gif,.jpg,.jpeg,.png,.bmp");
            //extTable.Add("word", ".doc,.docx,.ppt,.pptx,.txt,.pdf");
            //extTable.Add("excel", ".xls,.xlsx");
            //get dir
            string fileName = uploadFile.FileName;
            file_Name = fileName; //用于前台图片展示 alt属性
            string fileExt = Path.GetExtension(fileName).ToLower();
            string dirName = context.Request.QueryString["dir"];
            int maxSize = 1024*1024*10; //Byte
            if (uploadFile == null)
            {
                error = 1;
                message = "请选择文件。";
                url = "";
                return;
            }
            //if (extTable["image"].Contains(fileExt))
            //{
            //    dirName = "image";
            //}
            //else if (extTable["word"].Contains(fileExt))
            //{
            //    dirName = "word";
            //}
            //else if (extTable["excel"].Contains(fileExt))
            //{
            //    dirName = "excel";
            //}
            //else
            //{
            //    dirName = "default";
            //}

            //set path
            //relative path
            string filePath = string.Empty;
            filePath = "Upload/default/";
            //if (dirName == "image")
            //{
            //    filePath = "Upload/uploadImg/";
            //}
            //else
            //{
            //    filePath = "Upload/uploadFile/";
            //}
            string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            //absolute path
            string savePath = rootPath + filePath;

            //check upload file
            if (uploadFile.InputStream == null || uploadFile.InputStream.Length > maxSize)
            {
                error = 3;
                message = "上传文件大小超过限制。";
                url = "";
                return;
            }
            //if (string.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable[dirName]).Split(','), fileExt.ToLower()) == -1)
            //{
            //    error = 4;
            //    message = "上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable[dirName]) + "格式。";
            //    url = "";
            //    return;
            //}

            //create dir
            string ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            filePath += ymd + "/";
            savePath += ymd + "/";
            try
            {
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
            }
            catch (Exception ex)
            {
                //log
                throw new Exception(ex.Message);
            }
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + "^" + fileName;
            filePath += newFileName;
            savePath += newFileName;
            uploadFile.SaveAs(savePath);

            error = 0;
            message = "";
            url = filePath;
        }
        /// <summary>
        /// 删除磁盘上的文件
        /// </summary>
        /// <param name="path">当前附件的路径</param>
        /// <returns></returns>
        public static int  DeleteUploadFile(string  path)
        {
            int result = 0;
            string rootPath =System.Web.HttpContext.Current.Server.MapPath(path);
            string _path = rootPath;

            if (File.Exists(_path))
            {
                File.Delete(_path);
                result = 1;
            }
            return result;
        }
    }
}
