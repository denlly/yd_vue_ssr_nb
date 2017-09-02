using System.Web.Mvc;
using Model;
using System;
using DLLibrary;
using System.Collections.Generic;
using System.Data;

namespace website.Areas.Stuenroll.Controllers
{

    public class StuenrollDBController : ControllerBase
    {
        BLL.StuenrollDBll dao = new BLL.StuenrollDBll();

        #region 【数据读取以及修改】

        #region ===读取数据===
        public PartialViewResult Index(int ID = 1, string contion = "1=1", string contype="")
        {
            #region 【根据用户状态显示数据】
            int userrole = Convert.ToInt32(SessionHelper.Get("urole"));
            string usercontion = "";
            switch (userrole)
            { 
                case 2:
                    usercontion += " and ownerclass='" + SessionHelper.Get("ownercass") + "' and oorderclass='" + SessionHelper.Get("orderlcass") + "'";      
                    break;
                case 1:
                    //usercontion += " and ownerclass is null or oorderclass is null ";
                    break;
                 case 0:
                    usercontion += " and ownerclass is null or oorderclass is null ";
                    break;
            }
            #endregion
            int total=0;
            string newcontion="";
            List<StuenrollDB> listquery = null;
            string temp = contion;
            string pagrhtml = "";
            if (contion == "1=1" || string.IsNullOrEmpty(contion))
            {
                total = dao.GetRecordCount(contion + usercontion);
                listquery = dao.GetModelList(50, ID, contion+usercontion);
            }
            else {
                    if (contype == "search")
                    {
                        newcontion = Server.HtmlDecode(contion);
                    }
                    else
                    {
                        newcontion = DLLibrary.Common.Decrypt(Server.HtmlDecode(contion));
                    }
                    total = dao.GetRecordCount(newcontion);
                    listquery = dao.GetModelList(50, ID, newcontion);
            }
            switch (contype)
            {
                case "search":
                    pagrhtml = DLLibrary.MvcHelper.MvcPagerHtml(ID, total, 50, "/StuenrollDB/Index/{0}/" + DLLibrary.Common.Encrypt(contion) + "");
                    break;
                default:
                    pagrhtml = DLLibrary.MvcHelper.MvcPagerHtml(ID, total, 50, "/StuenrollDB/Index/{0}/" + contion + "");
                    break;
            }
            ViewBag.PagerHtml = pagrhtml;
            ViewBag.total = total;//当前学员总记录数
            ViewBag.ajaxurl = "/StuenrollDB/Index/";
            ViewBag.direlist = GetDireList(""); //研究方向数据集合
            ViewBag.oclist = GetOClassList("");//班次数据集合
            ViewBag.classlist = GetClassList("");//班级数据集合
            ViewBag.grouplist = GetGroupList("");//小组数据记恨
            return PartialView(listquery);
        }
        #endregion
          
        #region ===管理数据===
        /// <summary>
        /// 数据量大了 请采用ADO操作
        /// </summary>
        /// <param name="sysmodel">传递的数据实体层</param>
        /// <param name="idlist">要删除的ID列表</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Index(StuenrollDB sysmodel = null, int idlist = 0)
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
                        switch (actname)
                        {
                            case "add":
                                i = dao.Add(sysmodel);
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
                        return Json(new ResultDTO { Success = true, Message = "对不起，请准确填写信息！", ReturnUrl = "/StuenrollDB/Index" });
                    }
                }
                if (i > 0)
                {
                    return Json(new ResultDTO { Success = true, Message = "恭喜您，操作成功！", ReturnUrl = "/StuenrollDB/Index" });
                }
                else
                {
                    return Json(new ResultDTO { Success = false, Message = "对不起，操作失败！", ReturnUrl = "/StuenrollDB/Index" });
                }
            }
            catch (Exception ex)
            {
                //DLLibrary.SendMail.sendmail("更改用户信息出现问题", ex.ToString());
                return Json(new ResultDTO { Success = false, Message = "对不起，系统错误！", ReturnUrl = "/StuenrollDB/Index" });
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
                return Json(new ResultDTO { Success = true, Message = "恭喜您，批量删除成功！", ReturnUrl = "/StuenrollDB/Index" });
            }
            else
            {
                return Json(new ResultDTO { Success = false, Message = "对不起，批量删除失败！", ReturnUrl = "/StuenrollDB/Index" });
            }

        }
        #endregion 

        #region ===通过Get读取数据===
        public ActionResult Update(int id)
        {
            StuenrollDB sysmodel = dao.GetModel(id);
            ViewBag.accmodel = sysmodel;
            ViewBag.direlist = GetDireList(""); //研究方向数据集合
            ViewBag.oclist = GetOClassList("");//班次数据集合
            ViewBag.classlist = GetClassList("");//班级数据集合
            ViewBag.grouplist = GetGroupList("");//小组数据记恨
            return View();
        }
        #endregion

        #region 【返回一个对象详细信息】
        public ActionResult Details(int id = 0)
        {
            StuenrollDB sysmodel = dao.GetModel(id);
            ViewBag.accmodel = sysmodel;
            return View();
        }
        #endregion 

        #region 【读取方向数据】
        /// <summary>
        /// 读取方向数据
        /// </summary>
        /// <param name="contion">查询条件</param>
        /// <returns></returns>
        public SelectList GetDireList(string contion="")
        { 
            BLL.DirectionDBll dirdao=new BLL.DirectionDBll();
            List<DirectionDB> dirlist = dirdao.GetDropDownList(contion);
            return new SelectList(dirlist, "direname", "direname");
        }
        #endregion

        #region 【读取班次数据】
        /// <summary>
        /// 读取班次数据
        /// </summary>
        /// <param name="contion">查询条件</param>
        /// <returns>返回一个下拉列表数据</returns>
        public SelectList GetOClassList(string contion="")
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

        #region 【读取组数据】
        public SelectList GetGroupList(string contion = "")
        {
            BLL.GroupDBll orderdao = new BLL.GroupDBll();
            List<GroupDB> mylist = orderdao.GetDropDownList(contion);
            return new SelectList(mylist, "grouname", "grouname");
        }
        #endregion

        #region 【批量打印研究生毕业证】

        #endregion

        #region 【批量分班BathClass】
        [HttpPost]
        public JsonResult BathClass(string idlist, string setvalue)
        {
            if (dao.Update(idlist, setvalue))
            {
                return Json(new ResultDTO { Success = true, Message = "恭喜您，批量分班成功！", ReturnUrl = "/StuenrollDB/Index" });
            }
            else
            {
                return Json(new ResultDTO { Success = true, Message = "对不起，批量分班失败！", ReturnUrl = "/StuenrollDB/Index" });
            }
        }
        #endregion

        #region 【批量分组BathGroup】
        public JsonResult BathGroup(string idlist, string setvalue)
        {
            if (dao.Update(idlist, setvalue))
            {
                return Json(new ResultDTO { Success = true, Message = "恭喜您，批量分组成功！", ReturnUrl = "/StuenrollDB/Index" });
            }
            else
            {
                return Json(new ResultDTO { Success = true, Message = "对不起，批量分组失败！", ReturnUrl = "/StuenrollDB/Index" });
            }
        }
        #endregion

        #region 【按照条件导出WORD数据】
        public ActionResult ExportWord(string oorderclass = "")
        {
            DataTable dtclass = dao.GetList("ownerclass", "where oorderclass='" + oorderclass + "' group by ownerclass order by ownerclass desc").Tables[0];
            int rowsCount = dtclass.Rows.Count;
            string html = "<table width=\"500%\" border=\"0\">";
            for (int n = 0; n < rowsCount; n++)
            { 
                html+="<tr align=\"center\"><td colspan=\"5\">"+dtclass.Rows[n]["ownerclass"] +"</td></tr>";

                DataTable dtgroup = dao.GetList("ownergroup", " where oorderclass='" + oorderclass + "' and ownerclass='" + dtclass.Rows[n]["ownerclass"] + "' group by ownergroup order by ownergroup desc").Tables[0];
                int GRowsCount = dtgroup.Rows.Count;
                if (GRowsCount > 0) {
                    for (int i = 0; i < GRowsCount; i++)
                    {
                        html += " <tr align=\"left\" colspan=\"5\" valign=\"middle\"><td>" + dtgroup.Rows[i]["ownergroup"] + "</td></tr>";
                        html += "  <tr align=\"left\" valign=\"middle\"><td>姓名</td><td>单位以及职务</td><td>房号</td><td>房间电话</td><td>手机</td></tr>";
                        DataTable dtstudent = dao.GetList("stuname,Workunitpos,RoomNo,Roomtelephone,StuPhone", "   where oorderclass='" + oorderclass + "' and ownerclass='" + dtclass.Rows[n]["ownerclass"] + "' and ownergroup='" + dtgroup.Rows[i]["ownergroup"] + "'").Tables[0];
                        int SRowsCount = dtstudent.Rows.Count;
                        if (SRowsCount > 0)
                        {
                            for (int k = 0; k < SRowsCount; k++)
                            {
                                html += "<tr align=\"left\" valign=\"middle\">" +
                                    "<td>" + dtstudent.Rows[k]["stuname"] + "</td>" +
                                    "<td>" + dtstudent.Rows[k]["Workunitpos"] + "</td>" +
                                    "<td>" + dtstudent.Rows[k]["RoomNo"] + "</td>" +
                                    "<td>" + dtstudent.Rows[k]["Roomtelephone"] + "</td>" +
                                    "<td>" + dtstudent.Rows[k]["StuPhone"] + "</td></tr>";
                            }
                        }
                    }
                }
            
            }
            html += "</table>";
            //DataTable dt = new DataTable();
            //dt.Columns.Add("班次");
            //dt.Columns.Add("方向");
            //dt.Columns.Add("姓名");
            //dt.Columns.Add("性别");
            //dt.Columns.Add("出生年月");
            //dt.Columns.Add("工作单位及职务");
            //dt.Columns.Add("房号");
            //dt.Columns.Add("房话");
            //dt.Columns.Add("手机");
            //dt.Columns.Add("毕业证编号");
            //if (!string.IsNullOrEmpty(strwhere))
            //{
            //    strwhere = Server.HtmlDecode(strwhere);
            //}
            //foreach (var item in list)
            //{
            //    DataRow drcontent = dt.NewRow();
            //    drcontent[0] = item.oorderclass;
            //    drcontent[1] = item.ownerdirection;
            //    drcontent[2] = item.stuname;
            //    drcontent[3] = item.sex;
            //    drcontent[4] = item.Datebirth;
            //    drcontent[5] = item.Workunitpos;
            //    drcontent[6] = item.RoomNo;
            //    drcontent[7] = item.Roomtelephone;
            //    drcontent[8] = item.StuPhone;
            //    drcontent[9] = item.Gradcernum;
            //    dt.Rows.Add(drcontent);
            //}
            //if (dt.Rows.Count > 0)
            //{
                WordExport.ExportHtml("",html, this.ControllerContext);
            //}
            return View();
        }
        #endregion

        #region 【按照条件导出EXCEL数据】
        public ActionResult ExportExcel(string strwhere="")
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(strwhere))
            {
                strwhere = Server.HtmlDecode(strwhere);
            }
            var list = dao.ExportExcel(strwhere);
            dt.Columns.Add("班次");
            dt.Columns.Add("方向");
            dt.Columns.Add("姓名");
            dt.Columns.Add("性别");
            dt.Columns.Add("出生年月");
            dt.Columns.Add("工作单位及职务");
            dt.Columns.Add("房号");
            dt.Columns.Add("房话");
            dt.Columns.Add("手机");
            dt.Columns.Add("毕业证编号");
            foreach (var item in list)
            {
                DataRow drcontent = dt.NewRow();
                drcontent[0] = item.oorderclass;
                drcontent[1] = item.ownerdirection;
                drcontent[2] = item.stuname;
                drcontent[3] = item.sex;
                drcontent[4] = item.Datebirth;
                drcontent[5] = item.Workunitpos;
                drcontent[6] = item.RoomNo;
                drcontent[7] = item.Roomtelephone;
                drcontent[8] = item.StuPhone;
                drcontent[9] = item.Gradcernum;
                dt.Rows.Add(drcontent);
            }
            ExcelExport.Export("", dt, "", this.ControllerContext);
            return View();
        }
        #endregion
    }
}