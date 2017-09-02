using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using website.Filters;
using System.Web.Mvc;
using Model;

namespace website.Areas.Stuenroll.Controllers
{
    [SturegFilter]
    public class DiplomaDBController : ControllerBase
    {
        ComonDbContext DB = new ComonDbContext();
        BLL.StuenrollDBll stubll = new BLL.StuenrollDBll();

        #region 【毕业证数据读取以及修改】

        #region ===读取数据===
        public ActionResult Index(int id)
        {
            DiplomaDB dipmodel = DB.DiplomaDBContent.Find(id);
            ViewBag.dipmodel = dipmodel;
            return View();
        }
        #endregion

        #region ===管理数据===
        [HttpPost]
        public JsonResult Index(DiplomaDB sysmodel = null, int idlist = 0)
        {
            try
            {
                string actname = Request["actname"];

                if (ModelState.IsValid)
                {
                    switch(actname)
                    {
                        case "update":
                            var upaccount = DB.DiplomaDBContent.Find(1);
                            if (upaccount != null)
                            {
                                UpdateModel(upaccount);
                            }
                            break;

                    }
                }
                else
                {
                    return Json(new ResultDTO { Success = true, Message = "对不起，请准确填写信息！", ReturnUrl = "/" });
                }
                int i = DB.SaveChanges();
                if (i > 0)
                {
                    return Json(new ResultDTO { Success = true, Message = "恭喜您，操作成功！", ReturnUrl = "/" });
                }
                else
                {
                    return Json(new ResultDTO { Success = false, Message = "对不起，操作失败！", ReturnUrl = "/" });
                }
            }
            catch (Exception ex)
            {
                //DLLibrary.SendMail.sendmail("更改用户信息出现问题", ex.ToString());
                return Json(new ResultDTO { Success = false, Message = "对不起，系统错误！", ReturnUrl = "/User/Registr" });
                throw (ex);
            }
        }
        #endregion

        #endregion

        #region 【结业证数据读取及修改】

        #region ===显示结业信息===
        public ActionResult Gradprint(int id)
        {
            DiplomaDB dipmodel = DB.DiplomaDBContent.Find(id);
            ViewBag.dipmodel = dipmodel;
            return View();
        }
        #endregion

        #region ===管理结业数据===
        [HttpPost]
        public JsonResult Gradprint(DiplomaDB sysmodel = null, int idlist = 0)
        {
            try
            {
                string actname = Request["actname"];

                if (ModelState.IsValid)
                {
                    switch (actname)
                    {
                        case "update":
                            var upaccount = DB.DiplomaDBContent.Find(2);
                            if (upaccount != null)
                            {
                                UpdateModel(upaccount);
                            }
                            break;

                    }
                }
                else
                {
                    return Json(new ResultDTO { Success = true, Message = "对不起，请准确填写信息！", ReturnUrl = "/" });
                }
                int i = DB.SaveChanges();
                if (i > 0)
                {
                    return Json(new ResultDTO { Success = true, Message = "恭喜您，操作成功！", ReturnUrl = "/" });
                }
                else
                {
                    return Json(new ResultDTO { Success = false, Message = "对不起，操作失败！", ReturnUrl = "/" });
                }
            }
            catch (Exception ex)
            {
                //DLLibrary.SendMail.sendmail("更改用户信息出现问题", ex.ToString());
                return Json(new ResultDTO { Success = false, Message = "对不起，系统错误！", ReturnUrl = "/User/Registr" });
                throw (ex);
            }
        }
        #endregion

        #endregion

        #region 【结业证打印前设置页面】
        public ActionResult Prigracard()
        {
            return View();
        }
        #endregion

        #region 【修改结业人员信息】
        public ActionResult Update(int id)
        {
            GraPersonlistDB sysmodel = DB.GraPersonlistDBContent.Find(id);
            ViewBag.accmodel = sysmodel;
            return View();
        }

        [HttpPost]
        public JsonResult Update(GraPersonlistDB sysmodel = null)
        {
            string actname = Request["actname"];
            int i = 0;
            switch (actname) 
            {
                case "update":
                    var gramodel =  DB.GraPersonlistDBContent.Find(sysmodel.id);
                    if (gramodel != null)
                    {
                        UpdateModel(gramodel);
                    }
                break;
            }
            i = DB.SaveChanges();
            if (i > 0)
            {
                return Json(new ResultDTO { Success = true, Message = "恭喜您，操作成功！", ReturnUrl = "/DiplomaDB/Index" });
            }
            else
            {
                return Json(new ResultDTO { Success = false, Message = "对不起，操作失败！", ReturnUrl = "/DiplomaDB/Index" });
            }
        }
        #endregion

        #region 【结业证学员列表】

        #region ===结业学员信息===
        public PartialViewResult PrintPersonList(int ID = 1, string contion = "", string contype="")
        {
            BLL.GraPersonlistDBll dao = new BLL.GraPersonlistDBll();
            int total = 0;
            string newcontion = "";
            string pagrhtml = "";//查询条件
            List<GraPersonlistDB> listquery = null;
            if (contion.Trim() == "1=1" || string.IsNullOrEmpty(contion))
            {
                total = dao.GetRecordCount();
                listquery = dao.GetModelList(50, ID);
                pagrhtml = DLLibrary.MvcHelper.MvcPagerHtml(ID, total, 50, "/DiplomaDB/PrintPersonList/{0}");
            }
            else
            {
                if (contype == "search")
                {
                    newcontion = Server.HtmlDecode(contion);
                    total = dao.GetRecordCount(newcontion);
                    listquery = dao.GetModelList(50, ID, newcontion);
                    pagrhtml = DLLibrary.MvcHelper.MvcPagerHtml(ID, total, 50, "/DiplomaDB/PrintPersonList/{0}/" + DLLibrary.Common.Encrypt(newcontion) + "");
                }
                else
                {
                    newcontion = DLLibrary.Common.Decrypt(Server.HtmlDecode(contion));
                    total = dao.GetRecordCount(newcontion);
                    listquery = dao.GetModelList(50, ID, newcontion);
                    pagrhtml = DLLibrary.MvcHelper.MvcPagerHtml(ID, total, 50, "/DiplomaDB/PrintPersonList/{0}/" + contion + "");
                }
            }
            ViewBag.PagerHtml = pagrhtml;
            ViewBag.ajaxurl = "/DiplomaDB/PrintPersonList/";
            ViewBag.total = total;//当前人员总记录数
            return PartialView(listquery);
        }
        #endregion

        #region ====维护结业人员信息===
        #region ===管理数据===
        [HttpPost]
        public JsonResult PrintPersonList(GraPersonlistDB sysmodel = null, int idlist = 0)
        {
            try
            {
                string actname = Request["actname"];
                if (actname == "del")
                {
                    var delaccount = DB.GraPersonlistDBContent.Find(idlist);
                    DB.GraPersonlistDBContent.Remove(delaccount);
                }
                int i = DB.SaveChanges();
                if (i > 0)
                {
                    return Json(new ResultDTO { Success = true, Message = "恭喜您，操作成功！", ReturnUrl = "/DiplomaDB/PrintPersonList" });
                }
                else
                {
                    return Json(new ResultDTO { Success = false, Message = "对不起，操作失败！", ReturnUrl = "/DiplomaDB/PrintPersonList" });
                }
            }
            catch (Exception ex)
            {
                //DLLibrary.SendMail.sendmail("更改用户信息出现问题", ex.ToString());
                return Json(new ResultDTO { Success = false, Message = "对不起，系统错误！", ReturnUrl = "/DiplomaDB/PrintPersonList" });
                throw (ex);
            }
        }
        #endregion
        #endregion

        #region 【批量删除结业人员数据】
        [HttpPost]
        public JsonResult BathDelete(string idlist)
        {
            BLL.GraPersonlistDBll dao = new BLL.GraPersonlistDBll();
            if (dao.DeleteList(idlist))
            {
                return Json(new ResultDTO { Success = true, Message = "恭喜您，批量删除成功！", ReturnUrl = "/OrderClass/Index" });
            }
            else
            {
                return Json(new ResultDTO { Success = true, Message = "对不起，批量删除失败！", ReturnUrl = "/OrderClass/Index" });
            }

        }
        #endregion 

        #endregion

    }
}
