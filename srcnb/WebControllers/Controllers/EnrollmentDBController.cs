using System.Web.Mvc;
using Model;
using System;
using DLLibrary;
using System.Data;
using website.Filters;

namespace website.Areas.Stuenroll.Controllers
{
    [SturegFilter]
    public class EnrollmentDBController : ControllerBase
    {
        ComonDbContext DB = new ComonDbContext();
        BLL.EnrollmentDBll dao = new BLL.EnrollmentDBll();

        #region 【数据读取以及修改】

        #region ===读取数据===
        public PartialViewResult Index(int ID = 1, string contion = "")
        {
            int total = dao.GetRecordCount(contion);
            ViewBag.PagerHtml = DLLibrary.MvcHelper.MvcPagerHtml(ID, total, 10, "/EnrollmentDB/Index/{0}");
            var listquery = dao.GetModelList(50, ID,contion);
            ViewBag.ajaxurl = "/EnrollmentDB/Index/";
            ViewBag.total = total;//当前学员总记录数
            return PartialView(listquery);
        }
        #endregion

        #region ===管理数据ORM版本===
        //[HttpPost]
        //public JsonResult Index(EnrollmentDB sysmodel = null, int idlist = 0)
        //{
        //    try
        //    {
        //        string actname = Request["actname"];
        //        if (actname == "del")
        //        {
        //            var delaccount = DB.EnrollmentDBContent.Find(idlist);
        //             DB.EnrollmentDBContent.Remove(delaccount);
        //        }
        //        else
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                switch (actname)
        //                {
        //                    case "add":
        //                        if (string.IsNullOrEmpty(sysmodel.Wage.ToString()))
        //                        {
        //                            sysmodel.Wage = 0;
        //                        }
        //                        if (string.IsNullOrEmpty(sysmodel.Politheoryscore.ToString()))
        //                        {
        //                            sysmodel.Politheoryscore = 0;
        //                        }
        //                        if (string.IsNullOrEmpty(sysmodel.Journalscore.ToString()))
        //                        {
        //                            sysmodel.Journalscore = 0;
        //                        }
        //                        if (string.IsNullOrEmpty(sysmodel.Englishscore.ToString()))
        //                        {
        //                            sysmodel.Englishscore = 0;
        //                        }
        //                        if (string.IsNullOrEmpty(sysmodel.Eqscores.ToString()))
        //                        {
        //                            sysmodel.Eqscores = 0;
        //                        }
        //                        sysmodel.Eqscores = sysmodel.Englishscore / 2;
        //                        sysmodel.Totalscore = sysmodel.Politheoryscore + sysmodel.Journalscore + sysmodel.Eqscores;
        //                        DB.EnrollmentDBContent.Add(sysmodel);
        //                        break;
        //                    case "update":
        //                        var upaccount =  DB.EnrollmentDBContent.Find(sysmodel.id);
        //                        if (upaccount != null)
        //                        {
        //                            if (string.IsNullOrEmpty(upaccount.Wage.ToString()))
        //                            {
        //                                upaccount.Wage = 0;
        //                            }
        //                            if (string.IsNullOrEmpty(upaccount.Politheoryscore.ToString()))
        //                            {
        //                                upaccount.Politheoryscore = 0;
        //                            }
        //                            if (string.IsNullOrEmpty(upaccount.Journalscore.ToString()))
        //                            {
        //                                upaccount.Journalscore = 0;
        //                            }
        //                            if (string.IsNullOrEmpty(upaccount.Englishscore.ToString()))
        //                            {
        //                                upaccount.Englishscore = 0;
        //                            }
        //                            if (string.IsNullOrEmpty(upaccount.Eqscores.ToString()))
        //                            {
        //                                upaccount.Eqscores = 0;
        //                            }
        //                            upaccount.Eqscores = upaccount.Englishscore / 2;
        //                            upaccount.Totalscore = upaccount.Politheoryscore + upaccount.Journalscore + upaccount.Eqscores;
        //                            UpdateModel(upaccount);
        //                        }
        //                        break;
        //                }
        //            }
        //            else
        //            {
        //                return Json(new ResultDTO { Success = true, Message = "对不起，请准确填写信息！", ReturnUrl = "/EnrollmentDB/Index" });
        //            }
        //        }
        //        int i = DB.SaveChanges();
        //        if (i > 0)
        //        {
        //            return Json(new ResultDTO { Success = true, Message = "恭喜您，操作成功！", ReturnUrl = "/EnrollmentDB/Index" });
        //        }
        //        else
        //        {
        //            return Json(new ResultDTO { Success = false, Message = "对不起，操作失败！", ReturnUrl = "/EnrollmentDB/Index" });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //DLLibrary.SendMail.sendmail("更改用户信息出现问题", ex.ToString());
        //        return Json(new ResultDTO { Success = false, Message = "对不起，系统错误！", ReturnUrl = "/EnrollmentDB/Index" });
        //        throw (ex);
        //    }
        //}
        #endregion

        #region ===管理数据===
        [HttpPost]
        public JsonResult Index(EnrollmentDB sysmodel = null, int idlist = 0)
        {
            try
            {
                string actname = Request["actname"];
                int i = 0;
                if (actname == "del")
                {
                    if (dao.Delete(idlist))
                    {
                        i = 1;
                    }
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        if (string.IsNullOrEmpty(sysmodel.Wage.ToString()))
                        {
                            sysmodel.Wage = 0;
                        }
                        if (string.IsNullOrEmpty(sysmodel.Politheoryscore.ToString()))
                        {
                            sysmodel.Politheoryscore = 0;
                        }
                        if (string.IsNullOrEmpty(sysmodel.Journalscore.ToString()))
                        {
                            sysmodel.Journalscore = 0;
                        }
                        if (string.IsNullOrEmpty(sysmodel.Englishscore.ToString()))
                        {
                            sysmodel.Englishscore = 0;
                        }
                        if (string.IsNullOrEmpty(sysmodel.Eqscores.ToString()))
                        {
                            sysmodel.Eqscores = 0;
                        }
                        sysmodel.Eqscores = sysmodel.Englishscore / 2;
                        sysmodel.Totalscore = sysmodel.Politheoryscore + sysmodel.Journalscore + sysmodel.Eqscores;
                        switch (actname)
                        {
                            case "add":
                                DB.EnrollmentDBContent.Add(sysmodel);
                                i = DB.SaveChanges();
                                break;
                            case "update":
                                if (dao.Update(sysmodel))
                                {
                                    i = 1;
                                }
                                break;
                        }
                    }
                    else
                    {
                        return Json(new ResultDTO { Success = true, Message = "对不起，请准确填写信息！", ReturnUrl = "/EnrollmentDB/Index" });
                    }
                }
                if (i > 0)
                {
                    return Json(new ResultDTO { Success = true, Message = "恭喜您，操作成功！", ReturnUrl = "/EnrollmentDB/Index" });
                }
                else
                {
                    return Json(new ResultDTO { Success = false, Message = "对不起，操作失败！", ReturnUrl = "/EnrollmentDB/Index" });
                }
            }
            catch (Exception ex)
            {
                //DLLibrary.SendMail.sendmail("更改用户信息出现问题", ex.ToString());
                return Json(new ResultDTO { Success = false, Message = "对不起，系统错误！", ReturnUrl = "/EnrollmentDB/Index" });
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
                return Json(new ResultDTO { Success = true, Message = "恭喜您，批量删除成功！", ReturnUrl = "/EnrollmentDB/Index" });
            }
            else
            {
                return Json(new ResultDTO { Success = false, Message = "对不起，批量删除失败！", ReturnUrl = "/EnrollmentDB/Index" });
            }

        }
        #endregion 

        #region ===通过Get读取数据===
        public ActionResult Update(int id)
        {
            Model.EnrollmentDB sysmodel = dao.GetModel(id);
            ViewBag.accmodel = sysmodel;
            return View();
        }
        #endregion

        #region 【返回一个对象详细信息】
        public ActionResult Details(int id = 0)
        {
            Model.EnrollmentDB sysmodel = dao.GetModel(id);
            ViewBag.accmodel = sysmodel;
            return View();
        }
        #endregion

        #region 【导出excel数据】
        [HttpGet]
        public ActionResult ExportExcel()
        {
            try
            {
                var list = dao.ExportExcel();
                DataTable dt = new DataTable();
                dt.Columns.Add("考号");
                dt.Columns.Add("姓名");
                dt.Columns.Add("性别");
                dt.Columns.Add("入党时间");
                dt.Columns.Add("工作单位");
                dt.Columns.Add("职务");
                dt.Columns.Add(" ");
                dt.Columns.Add("学历");
                dt.Columns.Add("      ");
                dt.Columns.Add("  ");
                dt.Columns.Add("   ");
                dt.Columns.Add("考试成绩");
                dt.Columns.Add("         ");
                dt.Columns.Add("     ");
                DataRow drheader = dt.NewRow();
                drheader[6] = "毕业学校";
                drheader[7] = "毕业时间";
                drheader[8] = "专业";
                drheader[9] = "政治理论";
                drheader[10] = "论文";
                drheader[11] = "英语总分";
                drheader[12] = "折合分数";
                drheader[13] = "总成绩";
                dt.Rows.Add(drheader);
                foreach (var item in list)
                {
                    DataRow drcontent = dt.NewRow();
                    drcontent[0] = item.CandNum;
                    drcontent[1] = item.stuname;
                    drcontent[2] = item.sex;
                    drcontent[3] = item.Whenerejpart;
                    drcontent[4] = item.workunit;
                    drcontent[5] = item.positions;
                    drcontent[6] = item.Graduatesch;
                    drcontent[7] = item.GraduationYear;
                    drcontent[8] = item.Professname;
                    drcontent[9] = item.Politheoryscore;
                    drcontent[10] = item.Journalscore;
                    drcontent[11] = item.Englishscore;
                    drcontent[12] = item.Englishscore;
                    drcontent[13] = item.Totalscore;
                    dt.Rows.Add(drcontent);
                }
                ExcelExport.Export("", dt, "", this.ControllerContext);
                //return Json(new ResultDTO { Success = false, Message = "恭喜您，导出成功，请下载！", ReturnUrl = "/EnrollmentDB/Index" });
            }
            catch (Exception ex)
            {
                //return Json(new ResultDTO { Success = false, Message = "对不起，导出失败！", ReturnUrl = "/EnrollmentDB/Index" });
                throw (ex);
            }
            return View();
        }
        #endregion
    }
}