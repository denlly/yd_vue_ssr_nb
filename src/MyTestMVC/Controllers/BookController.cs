using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maticsoft.BLL;
namespace MyTestMVC.Controllers
{
    public class Book
    {
        public int Id
        {
            get;
            set;
        }
        public string BookNO
        {
            get;
            set;
        }
        public string BookName
        {
            get;
            set;
        }
        public string BookDesc
        {
            get;
            set;
        }
        public string BookImg
        {
            get;
            set;
        }

    }
    public class Result{
        public string code
        {
            get;
            set;
        }
        public string content
        {
            get;
            set;
        }
        public object data{
            get;set;

        }
    }
    public class BookController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }

		//GET: List
		/*		[HttpGet]
				public ActionResult List(string keyword,int pagesize=10,int pageindex = 1 )
				{
					return View();
				}
*/
		public ActionResult Modify(int id)
		{
            Book book = new Book(){ Id=1, BookNO="12312312312133", BookName="Javascript", BookImg="image/", BookDesc="一本好su"};

			return View(book);
		}
		/*
		/// <summary>
		/// 提交（添加&修改）
		/// </summary>
		/// <param name="Active"></param>
		/// <param name="UserGroup"></param>
		/// <returns></returns>
		[HttpGet]
		public ActionResult Modify(string Active,int id)
		{
			if(Active.Equals("add", StringComparison.StringComparison.OrdinalIgnoreCases))
			{

			}
			else
			{

			}
			return View(Channel);
		}*/
		/// <summary>
		/// 提交（添加&修改）
		/// </summary>
		/// <param name="Active"></param>
		/// <param name="book"></param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult Submit(string active, Book book)
		{
            //BLL.Book bllBook = new BLL.Book();
            //Book bllBook = new BLL.Book();
            return Json(new Result(){ code="200", content="成功调用",data=book});
		}
               
    	/// <summary>
    	/// 已经失效的列表
    	/// </summary>
    	/// <param name="QM"></param>
    	/// <returns></returns>
    	[HttpPost]
    	public ActionResult Delete(int id)
    	{
    		return View();
    	}
		


	}
}
