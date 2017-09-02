using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.user
{
    public partial class delete : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            			if (!Page.IsPostBack)
			{
				Maticsoft.BLL.user bll=new Maticsoft.BLL.user();
				#warning 代码生成提示：删除页面,请检查确认传递过来的参数是否正确
				// bll.Delete();
			}

        }
    }
}