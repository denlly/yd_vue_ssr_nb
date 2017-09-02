using website.Filters;
using Model;
using System.Web.Mvc;
using System.Text;
using System;

namespace website.Areas.Stuenroll.Controllers
{
    [SturegFilter]
    public class PrintdiplomaController : ControllerBase
    {
        ComonDbContext DB = new ComonDbContext();

        #region ===打印毕业证===
        public ActionResult Index(string uname = "暂无姓名",string granum="", string actname = "", string idlist = "")
        {
            DiplomaDB dipmodel = DB.DiplomaDBContent.Find(1);
            BLL.StuenrollDBll stubll = new BLL.StuenrollDBll();
            StringBuilder sb = new StringBuilder();
            bool result = false;
            ViewBag.dipmodel = dipmodel;
            int grunum = Convert.ToInt32(dipmodel.startgrdnum.ToString());//起始编号
            if (!string.IsNullOrEmpty(actname))
            {
                switch (actname)
                {
                    case "stu":
                        if (!string.IsNullOrEmpty(idlist))
                        {
                            string[] idarr = idlist.Split(',');
                            for (int i = 0; i < idarr.Length; i++)
                            {
                                Model.StuenrollDB stumodel = DB.StuenrollDBContent.Find(Convert.ToInt32(idarr[i]));
                                grunum = grunum + 1;
                                stumodel.Gradcernum = grunum.ToString();
                                result = stubll.Update(stumodel);
                                if (result)
                                {
                                    //returnstr += idarr[i] + "," + stumodel.stuname + "#";
                                    sb.Append("<div class=\"box\">");
                                    sb.Append("<div class=\"box-border\">");
                                    sb.Append("<div class=\"left\">");
                                    sb.Append("<span class=\"uptitle\">毕业证书</span>");
                                    sb.Append("<span class=\"left-mid-title\">（无山东省委党校钢印无效）</span>");
                                    sb.Append("<span class=\"left-down-title\">");
                                    sb.Append("鲁党校毕字第 " + grunum + " 号");
                                    sb.Append("</span>");
                                    sb.Append("</div>");
                                    sb.Append("<div class=\"right\">");
                                    sb.Append("<div class=\"right-up\">");
                                    sb.Append("<span class=\"right-top-title\">	<strong>" + stumodel.stuname + " </strong>" + dipmodel.Gradcardbody + "</span>	</div>");
                                    sb.Append("<div class=\"right-down\">");
                                    sb.Append("<span class=\"right-buttom-a\">中共山东省委党校</span>");
                                    sb.Append("<span class=\"right-buttom-b\">校长</span>");
                                    sb.Append("<span class=\"right-buttom-c\">" + dipmodel.Graduatime + "</span></div>");
                                    sb.Append("</div>");
                                    sb.Append("</div>");
                                    sb.Append("</div>");
                                    sb.Append("<div class=\"PageNext\"></div>");
                                }
                            }
                            ViewBag.pagehtml = sb.ToString();
                        }
                        break;
                    case "enroll":
                        if (!string.IsNullOrEmpty(idlist))
                        {
                            string[] idarr = idlist.Split(',');
                            BLL.EnrollmentDBll enbll = new BLL.EnrollmentDBll();
                            for (int i = 0; i < idarr.Length; i++)
                            {
                                EnrollmentDB ermodel = enbll.GetModel(Convert.ToInt32(idarr[i]));
                                grunum = grunum + 1;
                                    //returnstr += idarr[i] + "," + stumodel.stuname + "#";
                                    sb.Append("<div class=\"box\">");
                                    sb.Append("<div class=\"box-border\">");
                                    sb.Append("<div class=\"left\">");
                                    sb.Append("<span class=\"uptitle\">毕业证书</span>");
                                    sb.Append("<span class=\"left-mid-title\">（无山东省委党校钢印无效）</span>");
                                    sb.Append("<span class=\"left-down-title\">");
                                    sb.Append("鲁党校毕字第 " + grunum + " 号");
                                    sb.Append("</span>");
                                    sb.Append("</div>");
                                    sb.Append("<div class=\"right\">");
                                    sb.Append("<div class=\"right-up\">");
                                    sb.Append("<span class=\"right-top-title\">	<strong>" + ermodel.stuname + "</strong> " + dipmodel.Gradcardbody + "</span>	</div>");
                                    sb.Append("<div class=\"right-down\">");
                                    sb.Append("<span class=\"right-buttom-a\">中共山东省委党校</span>");
                                    sb.Append("<span class=\"right-buttom-b\">校长</span>");
                                    sb.Append("<span class=\"right-buttom-c\">" + dipmodel.Graduatime + "</span></div>");
                                    sb.Append("</div>");
                                    sb.Append("</div>");
                                    sb.Append("</div>");
                                    sb.Append("<div class=\"PageNext\"></div>");
                            }
                            ViewBag.pagehtml = sb.ToString();
                        }
                        break;
                    case "sinprint":
                        string realgrnum = granum;
                        if (string.IsNullOrEmpty(realgrnum))
                        {
                            realgrnum = dipmodel.startgrdnum;
                        }
                        sb.Append("<div class=\"box\">");
                        sb.Append("<div class=\"box-border\">");
                        sb.Append("<div class=\"left\">");
                        sb.Append("<span class=\"uptitle\">毕业证书</span>");
                        sb.Append("<span class=\"left-mid-title\">（无山东省委党校钢印无效）</span>");
                        sb.Append("<span class=\"left-down-title\">");
                        sb.Append("鲁党校毕字第" + realgrnum  + "号");
                        sb.Append("</span>");
                        sb.Append("</div>");
                        sb.Append("<div class=\"right\">");
                        sb.Append("<div class=\"right-up\">");
                        sb.Append("<span class=\"right-top-title\">	<strong>" + uname + "</strong> " + dipmodel.Gradcardbody + "</span>	</div>");
                        sb.Append("<div class=\"right-down\">");
                        sb.Append("<span class=\"right-buttom-a\">中共山东省委党校</span>");
                        sb.Append("<span class=\"right-buttom-b\">校长</span>");
                        sb.Append("<span class=\"right-buttom-c\">" + dipmodel.Graduatime + "</span>	</div>");
                        sb.Append("");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        ViewBag.pagehtml = sb.ToString();
                        break;
                }
            }
            return View();
        }
        #endregion

        #region 【打印结业证】
        /// <summary>
        /// 打印结业证
        /// </summary>
        /// <param name="printbatch">打印批次</param>
        /// <param name="listofper">打印人员列表以(#分割)</param>
        /// <returns></returns>
        public ActionResult Prigracard(string printbatch="", string listofper="",string idlist="",string actioname="")
        {
            GraPersonlistDB gramodel = new GraPersonlistDB();
            StringBuilder sb = new StringBuilder();
            DiplomaDB dipmodel = DB.DiplomaDBContent.Find(2);
            bool result = false;
            switch (actioname) 
            {
                case "singleprint":
                    if (!string.IsNullOrEmpty(idlist))
                        {
                            string[] idarr = idlist.Split(',');
                            BLL.EnrollmentDBll enbll = new BLL.EnrollmentDBll();
                            for (int i = 0; i < idarr.Length; i++)
                            {
                                    gramodel = DB.GraPersonlistDBContent.Find(Convert.ToInt32(idarr[i]));
                                    sb.Append("<div class=\"box\">");
                                    sb.Append("<div class=\"box-border\">");
                                    sb.Append("<div class=\"left\">");
                                    sb.Append("<span class=\"uptitle\">结业证书</span>");
                                    sb.Append("<span class=\"left-mid-title\">（无山东省委党校钢印无效）</span>");
                                    sb.Append("<span class=\"left-down-title\">");
                                    sb.Append("鲁党校结字第 " + gramodel.granum + " 号");
                                    sb.Append("</span>");
                                    sb.Append("</div>");
                                    sb.Append("<div class=\"right\">");
                                    sb.Append("<div class=\"right-up\">");
                                    sb.Append("<span class=\"right-top-title\">	<strong>" + gramodel.gname + "</strong> " + dipmodel.Gradcardbody + "</span>	</div>");
                                    sb.Append("<div class=\"right-down\">");
                                    sb.Append("<span class=\"right-buttom-a\">中共山东省委党校</span>");
                                    sb.Append("<span class=\"right-buttom-b\">校长</span>");
                                    sb.Append("<span class=\"right-buttom-c\">" + dipmodel.Graduatime + "</span></div>");
                                    sb.Append("</div>");
                                    sb.Append("</div>");
                                    sb.Append("</div>");
                                    sb.Append("<div class=\"PageNext\"></div>");
                            }
                        }
                    break;
                case "batchprint":
                     int grunum = Convert.ToInt32(dipmodel.startgrdnum.ToString());//起始编号
                     string[] strarr = listofper.Split('，');
                for (int i = 0; i < strarr.Length; i++)
                {
                    grunum = grunum + 1;
                    gramodel.gname = strarr[i];//学员姓名
                    gramodel.granum = grunum.ToString();//毕业证号
                    gramodel.printbatch = printbatch;//打印批次
                    DB.GraPersonlistDBContent.Add(gramodel);
                    result = DB.SaveChanges() > 0 ? true : false;
                    if (result)
                    {
                        sb.Append("<div class=\"box\">");
                        sb.Append("<div class=\"box-border\">");
                        sb.Append("<div class=\"left\">");
                        sb.Append("<span class=\"uptitle\">结业证书</span>");
                        sb.Append("<span class=\"left-mid-title\">（无山东省委党校钢印无效）</span>");
                        sb.Append("<span class=\"left-down-title\">");
                        sb.Append("鲁党校结字第 " + grunum + " 号");
                        sb.Append("</span>");
                        sb.Append("</div>");
                        sb.Append("<div class=\"right\">");
                        sb.Append("<div class=\"right-up\">");
                        sb.Append("<span class=\"right-top-title\">	<strong>" + strarr[i] + " </strong>" + dipmodel.Gradcardbody + "</span>	</div>");
                        sb.Append("<div class=\"right-down\">");
                        sb.Append("<span class=\"right-buttom-a\">中共山东省委党校</span>");
                        sb.Append("<span class=\"right-buttom-b\">校长</span>");
                        sb.Append("<span class=\"right-buttom-c\">" + dipmodel.Graduatime + "</span></div>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("<div class=\"PageNext\"></div>");
                    }
                }
                break;
            }
            ViewBag.pagehtml = sb.ToString();
            return View();
        }
        #endregion

    }
}
