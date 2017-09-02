using System.Web.Mvc;
using System.IO;
using System.Collections.Generic;
using System.Web;
using System;
using DLLibrary;
namespace website.Areas.Stuenroll.Controllers
{
    public class IcoUploadController : ControllerBase
    {
        #region ===上传图片===
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            HttpPostedFileBase file = Request.Files["file"];
            if (file.ContentLength != 0)
            {
                string fileContentType = file.ContentType;
                Dictionary<string, string> extTable = new Dictionary<string, string>();
                extTable.Add("image", ".gif,.jpg,.jpeg,.png,.bmp");
                string type = Path.GetExtension(file.FileName).ToLower();
                if (extTable["image"].Contains(type))
                {
                    System.Drawing.Image bmp = System.Drawing.Image.FromStream(file.InputStream);//读取图片
                    int width = bmp.Width;
                    int height = bmp.Height;
                    if (width > 500 || height > 500)
                    {
                        ModelState.AddModelError("err", "您上传的文件大小超过500*500");
                    }
                    else
                    {
                        string filename = DateTime.Now.ToString("yyMMddHHmmss") + type;
                        string realpath = AppDomain.CurrentDomain.BaseDirectory + @"\Upload\images\" + filename + "";
                        file.SaveAs(realpath);
                        ViewBag.ICOPATH = "/Upload/images/" + filename;
                        ViewBag.html = "<a href=\"/IcoUpload/DeliconImg?filepath=/Upload/images/" + filename + "\">删除 " + filename + "</a><img src=\"/Upload/images/sample/" + filename + "\"/>";
                        ModelState.AddModelError("err", "上传成功！");
                    }
                }
                else
                {
                    ModelState.AddModelError("err", "对不起，您上传的不是图片类型！");
                }
            }
            else
            {
                ModelState.AddModelError("err", "对不起，请选择上传图标！");
            }
            return View();
        }
        #endregion

        #region ===删除图片===
        public ActionResult DeliconImg(string filepath)
        {
            UplodFile.DeleteUploadFile(filepath);
            return View();
        }
        #endregion
    }
}
