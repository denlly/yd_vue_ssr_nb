using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DaiChaoMvcPager;

namespace DLLibrary
{
    public class MvcHelper
    {
        #region ===生成分页html代码===
        /// <summary>
        /// 生成分页的html代码
        /// </summary>
        /// <param name="currentpage">当前页面</param>
        /// <param name="recordcount">总记录数</param>
        /// <param name="pagesize">页码</param>
        /// <param name="ajaxurl">请求的URL</param>
        /// <param name="ajax">是否是ajax分页</param>
        /// <returns>返回值</returns>
        /// pager.LoadDomId 
        
        #region ===全部参数列表(若要修改样式 可具体参考)===
        ///LoadDomId Ajax加载Url数据后填充所需要的容器Dom ID  Default：requestAjaxText 

        ///FormatLinkUrl 格式

        ///CurrentPage 当前页面  Default：1

        ///PageSize页大小  Default：15

        ///RecordCount 总记录数  Default：0

        ///NumericButtonCount 每页显示数字按钮的个数  Default：10

        ///FirstPageText 页码导航中第一页的文本  Default：首页

        ///PrevPageText页码导航中上一页的文本  Default：上一页

        /// NextPageText页码导航中下一页的文本  Default：下一页

        ///LastPageText 页码导航中末页的文本  Default：末页

        /// MorePrevPageText页码导航中上一组(更多页)的文本  Default：&lt;img src="Content/images/pager/MoreNumericButton.gif" border="0" align="absmiddle"/&gt;

        ///MoreNextPageText 页码导航中下一组(更多页)的文本  Default：&lt;img src="Content/images/pager/MoreNumericButton.gif" border="0" align="absmiddle"/&gt;

        ///SubmitButtonText 转到第几页中的按钮的值  Default：GO

        ///SubmitButton_CssName 转到第几页中的按钮的样式名称  Default：button_go

        ///TextBox_CssName 转到第几页中文本框的样式名称  Default：textbox_pageIndex

        ///NumericButton_Cssname_One 导航按钮(普通)的样式名称  Default：page_a_NumericButton

        ///NumericButton_Cssname_Two 导航按钮(当前页按钮)的样式名称  Default：page_a_current

        ///NumericButton_Cssname_Three 导航按钮(不能访问的，如：如果已经是第一页那么上一页和首页将不能被访问)的样式名称  Default：page_a_disabled

        ///NumericButton_Cssname_Four 跳转文本框前后的文本样式名称(如转到{0}页中的“转到第”和“页”的样式名称!)  Default：page_span_text

        ///Statistics_Div_Cssname 分页统计信息区域外框DIV的样式表名称  Default：Statistics

        ///Statistics_Div_Numeric_Cssname 分页统计信息区域中的数字样式表名称  Default：StatisticsNumeric

        ///NavigationArea_Div_Cssname 分页页码外框DIV的样式表名称  Default：NavigationArea
        #endregion

        public static string MvcPagerHtml(int currentpage, int recordcount, int pagesize = 1,
            string posturl = "/Home/Index/{0}", bool ajax = true) 
        {         
            DCMvcPager pager = new DCMvcPager();
            pager.RecordCount = recordcount;
            pager.PageSize = pagesize;
            pager.FormatLinkUrl = posturl;
            pager.CurrentPage = currentpage;
            pager.MoreNextPageText = "...";
            pager.MorePrevPageText = "...";
            pager.SubmitButtonText = "转到";
            string disstr="<!--戴超Asp.Net MVC框架通用分页组件 Copyright © HuBeiXuanEn DaiChao 2010   Version:1.0-->";
            //垃圾字符串 T.T插件广告 有空自己写个
            string pagerhtml = "";
            if(ajax) 
            {
                pagerhtml=StringHandler.replacestr( pager.MvcAjaxPager(),disstr);
            }else{
                pagerhtml=StringHandler.replacestr( pager.MvcPager(),disstr);
            }
            return pagerhtml;
        }
        #endregion

    }
}
