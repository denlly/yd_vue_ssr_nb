using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Data.Entity;
using Model;
using WebControllers.AccWsRef;
using System.Threading;
using website.Filters;



namespace website.Areas.Stuenroll.Controllers
{
    public class HomeController : ControllerBase
    {
        ComonDbContext  db = new ComonDbContext();
        BLL.AccountBll accdao = new BLL.AccountBll();

        public ActionResult Index(int ID = 1)
        {
            ViewBag.Title = "电子学员报名系统--登录";
            //DLLibrary.SendMail.sendmail("Home控制器加载","<h1>系统机器人将时刻为您保驾护航！</h1>");
            //ViewBag.PagerHtml = DLLibrary.MvcHelper.MvcPagerHtml(ID, accdao.GetRecordCount(), 10, "/Home/Index/{0}");
            //var listquery = accdao.GetModelList(10, ID);

            #region ===REDIS缓存机制==
            //mutex.WaitOne();
            //var listquery=new List<Account>();
            //if (RedisHelper.Exists("SESSION", "Account-List-1"))
            //{
            //    List<Account> reslist = null;
            //    reslist = RedisHelper.GetValueFromHash<List<Account>>("SESSION", "Account-List-1", "accountlist");
            //    if (reslist != null)
            //    {
            //        listquery = reslist;
            //    }
            //}
            //else 
            //{
            //    var query = from c in db.Accounts
            //                select c;

            //    RedisHelper.SetEntryInHash("SESSION", "Account-List-1", "accountlist", query.ToList());
            //    RedisHelper.ExpireKey("SESSION", "one", new TimeSpan(0, 100, 0));
            //    listquery = query.ToList();
            //}
            #endregion

            //return View(listquery.ToList());
            return View();
        }

        [HttpPost]
        public JsonResult Index(Model.Account model)
        {
            //System.Threading.Thread.Sleep(2000);//演示用
            var res = new JsonResult();
            string rescontent = "no";
            string url = "";
            Account outmodel = new Account();
            accdao.UserExist(model, out outmodel);
            if (outmodel.AccountID > 0)
            {
                CookieHelper.SaveCookie("uname", outmodel.UserName, 0);
                CookieHelper.SaveCookie("urole", outmodel.UseRole.ToString(), 0);
                SessionHelper.Add("urole", outmodel.UseRole.ToString());
                if (outmodel.ooderclass == null || outmodel.ooderclass == "")
                {
                    SessionHelper.Add("orderlcass", "");
                }
                else
                {
                    SessionHelper.Add("orderlcass", outmodel.ooderclass.ToString());
                }
                if (outmodel.ownerclass == null || outmodel.ownerclass == "")
                {
                    SessionHelper.Add("ownercass", "");
                }
                else {
                    SessionHelper.Add("ownercass", outmodel.ownerclass.ToString());
                }
                rescontent = "ok";
                url = "/StuReg/Main";
            }
            var info = new { content = rescontent, ReturnUrl = url };
            res.Data = info;
            return res;
        }

        [SturegFilter]
        public ActionResult test()
        {
            return View();
        }
    }
}
