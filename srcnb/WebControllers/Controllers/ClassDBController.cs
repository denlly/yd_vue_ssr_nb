﻿using System.Web.Mvc;
using Model;
using System;
using website.Filters;

namespace website.Areas.Stuenroll.Controllers
{
    [SturegFilter]
    public class ClassDBController : ControllerBase
    {
        ComonDbContext DB = new ComonDbContext();
        BLL.ClassDBll dao = new BLL.ClassDBll();

        #region 【数据读取以及修改】

        #region ===读取数据===
        public PartialViewResult Index(int ID = 1)
        {
            ViewBag.PagerHtml = DLLibrary.MvcHelper.MvcPagerHtml(ID, dao.GetRecordCount(), 10, "/ClassDB/Index/{0}");
            
            var listquery = dao.GetModelList(10, ID);
            ViewBag.ajaxurl = "/ClassDB/Index/";
            return PartialView(listquery);
        }
        #endregion

        #region ===管理数据===
        [HttpPost]
        public JsonResult Index(ClassDB sysmodel = null, int idlist = 0)
        {
            try
            {
                sysmodel.addate = DateTime.Now.ToString("yyyy-MM-dd");
                string actname = Request["actname"];
                if (actname == "del")
                {
                    var delaccount = DB.ClassDBContent.Find(idlist);
                     DB.ClassDBContent.Remove(delaccount);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        switch (actname)
                        {
                            case "add":
                                DB.ClassDBContent.Add(sysmodel);
                                break;
                            case "update":
                                var upaccount =  DB.ClassDBContent.Find(sysmodel.id);
                                if (upaccount != null)
                                {
                                    UpdateModel(upaccount);
                                }
                                break;
                        }
                    }
                    else
                    {
                        return Json(new ResultDTO { Success = true, Message = "对不起，请准确填写信息！",  ReturnUrl = "/ClassDB/Index" });
                    }
                }
                int i = DB.SaveChanges();
                if (i > 0)
                {
                    return Json(new ResultDTO { Success = true, Message = "恭喜您，操作成功！",  ReturnUrl = "/ClassDB/Index" });
                }
                else
                {
                    return Json(new ResultDTO { Success = false, Message = "对不起，操作失败！", ReturnUrl = "/ClassDB/Index" });
                }
            }
            catch (Exception ex)
            {
                //DLLibrary.SendMail.sendmail("更改用户信息出现问题", ex.ToString());
                return Json(new ResultDTO { Success = false, Message = "对不起，系统错误！", ReturnUrl = "/ClassDB/Index" });
                throw (ex);
            }
        }
        #endregion

        #endregion

        #region 【批量删除数据】
        [HttpPost]
        public JsonResult BathDelete(string idlist)
        {
            if (dao.DeleteList(idlist))
            {
                return Json(new ResultDTO { Success = true, Message = "恭喜您，批量删除成功！",  ReturnUrl = "/ClassDB/Index" });
            }
            else
            {
                return Json(new ResultDTO { Success = true, Message = "对不起，批量删除失败！",  ReturnUrl = "/ClassDB/Index" });
            }

        }
        #endregion 

        #region ===通过Get读取数据===
        public ActionResult Update(int id)
        {
            Model.ClassDB sysmodel = dao.GetModel(id);
            ViewBag.accmodel = sysmodel;
            return View();
        }
        #endregion
    }
}