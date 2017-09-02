using System.Web.Mvc;

namespace website.Filters
{
    public class SturegFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(System.Web.Mvc.ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            string uname = CookieHelper.GetCookie("uname");
            //string userole = filterContext.HttpContext.Session["urole"].ToString();
            string userole = SessionHelper.Get("urole");
            if (string.IsNullOrEmpty(uname) || string.IsNullOrEmpty(userole))
            {
                filterContext.HttpContext.Response.Redirect("/");
            }
        }

        public override void OnResultExecuted(System.Web.Mvc.ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }

        public override void OnResultExecuting(System.Web.Mvc.ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }
    }
}
