using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maticsoft.Model;
using Maticsoft.BLL;

namespace MyTestMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Maticsoft.BLL.user user = new Maticsoft.BLL.user();

            Maticsoft.Model.user userObj = new Maticsoft.Model.user(){ id = 1, username = "ssssss", password = "sa123" };

            bool result = user.Add(userObj);

            Console.WriteLine(result);
            return View ();
        }
    }
}
