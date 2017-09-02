using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace website.Areas.Stuenroll.Controllers
{
    public class ErrorController : ControllerBase
    {

        public ActionResult PageNotFound()
        {
            ViewBag.info = "从前有个山，山里有个庙！";
            return View();
        }

    }
}