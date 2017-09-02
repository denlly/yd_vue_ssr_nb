using System.Web.Mvc;
using Model;
using System;
using website.Filters;

namespace website.Areas.Stuenroll.Controllers
{
    [SturegFilter]
    public class OrderClassController : ControllerBase
    {
        ComonDbContext DB = new ComonDbContext();
        BLL.OrderClassBll dao = new BLL.OrderClassBll();

        #region 【班次管理读取以及管理】

        #region ===班次数据===
        public PartialViewResult Index(int ID = 1)
        {
            ViewBag.PagerHtml = DLLibrary.MvcHelper.MvcPagerHtml(ID, dao.GetRecordCount(), 10, "/OrderClass/Index/{0}");
            
            var listquery = dao.GetModelList(10, ID);
            ViewBag.ajaxurl = "/OrderClass/Index/";
            return PartialView(listquery);
        }
        #endregion

        #region ===管理班次数据===
        [HttpPost]
        public JsonResult Index(OrderClassDB sysmodel = null, int idlist = 0)
        {
            try
            {
                sysmodel.addate = DateTime.Now.ToString("yyyy-MM-dd");
                string actname = Request["actname"];
                if (actname == "del")
                {
                    var delaccount = DB.Orderclass.Find(idlist);
                     DB.Orderclass.Remove(delaccount);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        switch (actname)
                        {
                            case "add":
                                DB.Orderclass.Add(sysmodel);
                                break;
                            case "update":
                                var upaccount =  DB.Orderclass.Find(sysmodel.id);
                                if (upaccount != null)
                                {
                                    UpdateModel(upaccount);
                                }
                                break;
                        }
                    }
                    else
                    {
                        return Json(new ResultDTO { Success = true, Message = "对不起，请准确填写信息！", ReturnUrl = "/OrderClass/Index" });
                    }
                }
                int i = DB.SaveChanges();
                if (i > 0)
                {
                    return Json(new ResultDTO { Success = true, Message = "恭喜您，操作成功！", ReturnUrl = "/OrderClass/Index" });
                }
                else
                {
                    return Json(new ResultDTO { Success = false, Message = "对不起，操作失败！", ReturnUrl = "/OrderClass/Index" });
                }
            }
            catch (Exception ex)
            {
                //DLLibrary.SendMail.sendmail("更改用户信息出现问题", ex.ToString());
                return Json(new ResultDTO { Success = false, Message = "对不起，系统错误！", ReturnUrl = "/OrderClass/Index" });
                throw (ex);
            }
        }
        #endregion

        #endregion

        #region 【批量删除班次数据】
        [HttpPost]
        public JsonResult BathDelete(string idlist)
        {
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

        #region ===通过Get读取数据===
        public ActionResult Update(int id)
        {
            Model.OrderClassDB sysmodel = dao.GetModel(id);
            ViewBag.accmodel = sysmodel;
            return View();
        }
        #endregion
    }
}