using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using website.Filters;

namespace website.Areas.Stuenroll.Controllers
{
    [SturegFilter]
    public class StuRegController : ControllerBase
    {
        public ActionResult Index(int ID = 1)
        {
            //System.Threading.Thread.Sleep(2000);//演示用
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }
    }
}
