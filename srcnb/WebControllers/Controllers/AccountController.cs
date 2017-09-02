using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Model;
using website.Filters;

namespace website.Areas.Stuenroll.Controllers
{
    [SturegFilter]
    public class AccountController : ControllerBase
    {
        ComonDbContext DB = new ComonDbContext();
        BLL.AccountBll accdao = new BLL.AccountBll();
        
        #region 【用户信息列表分页读取】

        #region ===Get读取用户信息数据===
        public PartialViewResult Registr(int ID = 1)
        {
            ViewBag.PagerHtml = DLLibrary.MvcHelper.MvcPagerHtml(ID, accdao.GetRecordCount(), 10, "/Account/Registr/{0}");
            var listquery = accdao.GetModelList(10, ID);
            ViewBag.ajaxurl = "/Account/Registr/";
            ViewBag.oclist = GetOClassList("");//班次数据集合
            ViewBag.classlist = GetClassList("");//班级数据集合
            return PartialView(listquery.ToList());
        }
        #endregion

        #region ===Post注册用户===
        [HttpPost]
        public JsonResult Registr(Account accmodel = null, int idlist = 0)
        {
            try
            {
                string actname = Request["actname"];
                if (actname == "del")
                {
                    var delaccount = DB.Accounts.Find(idlist);
                    DB.Accounts.Remove(delaccount);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        accmodel.Password = DLLibrary.Common.Encrypt(accmodel.Password);
                        if (string.IsNullOrEmpty(accmodel.ooderclass))
                        {
                            accmodel.ooderclass = "";
                        }
                        if (string.IsNullOrEmpty(accmodel.ownerclass))
                        {
                            accmodel.ownerclass = "";
                        }
                        switch (actname)
                        {
                            case "add":
                                DB.Accounts.Add(accmodel);
                                break;
                            case "update":
                                var upaccount = DB.Accounts.Find(accmodel.AccountID);
                                if (upaccount != null)
                                {
                                    UpdateModel(upaccount);
                                }
                                break;
                        }
                    }
                    else
                    {
                        return Json(new ResultDTO { Success = true, Message = "对不起，请准确填写信息！", ReturnUrl = "/Account/Registr" });
                    }
                }
                int i = DB.SaveChanges();
                if (i > 0)
                {
                    return Json(new ResultDTO { Success = true, Message = "恭喜您，操作成功！", ReturnUrl = "/Account/Registr" });
                }
                else
                {
                    return Json(new ResultDTO { Success = false, Message = "对不起，操作失败！", ReturnUrl = "/Account/Registr" });
                }
            }
            catch (Exception ex)
            {
                DLLibrary.SendMail.sendmail("更改用户信息出现问题", ex.ToString());
                return Json(new ResultDTO { Success = false, Message = "对不起，系统错误！", ReturnUrl = "/Account/Registr" });
            }
        }
        #endregion

        #endregion

        #region 【修改用户信息】

        #region ===通过Get读取数据===
        public ActionResult Update(int accountid)
        {
            Model.Account accmodel = accdao.GetModel(accountid);
            ViewBag.accmodel = accmodel;
            ViewBag.oclist = GetOClassList("");//班次数据集合
            ViewBag.classlist = GetClassList("");//班级数据集合
            return View();
        }
        #endregion

        #endregion

        #region 【批量删除用户】
        [HttpPost]
        public JsonResult BathDelete(string idlist)
        {
            if (accdao.DeleteList(idlist))
            {
                return Json(new ResultDTO { Success = true, Message = "删除用户成功！", ReturnUrl = "/Account/Registr" });
            }
            else {
                return Json(new ResultDTO { Success = true, Message = "删除用户失败！", ReturnUrl = "/Account/Registr" });
            }
            
        }
        #endregion

        #region 【读取班次数据】
        /// <summary>
        /// 读取班次数据
        /// </summary>
        /// <param name="contion">查询条件</param>
        /// <returns>返回一个下拉列表数据</returns>
        public SelectList GetOClassList(string contion = "")
        {
            BLL.OrderClassBll orderdao = new BLL.OrderClassBll();
            List<OrderClassDB> orderlist = orderdao.GetDropDownList(contion);
            return new SelectList(orderlist, "ordclassname", "ordclassname");
        }
        #endregion

        #region 【读取班级数据】
        public SelectList GetClassList(string contion = "")
        {
            BLL.ClassDBll orderdao = new BLL.ClassDBll();
            List<ClassDB> mylist = orderdao.GetDropDownList(contion);
            return new SelectList(mylist, "classname", "classname");
        }
        #endregion

        //[ChildActionOnly]
        public JavaScriptResult GetUsername()
        {
            return JavaScript("getUserInfo('" + CookieHelper.GetCookie("uname") + "')");
        }

        #region 【退出系统】
        //[ChildActionOnly]
        public JavaScriptResult Logout()
        {
            CookieHelper.ClearCookie("uname");
            CookieHelper.ClearCookie("urole");
            SessionHelper.Del("urole");
            SessionHelper.Del("orderlcass");
            SessionHelper.Del("ownercass");
            Session.Abandon();
            return JavaScript("window.location.href ='/';");
        }
        #endregion

    }
}
