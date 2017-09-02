using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*=================================
 * 字符串处理专用类类 
 * 2012-03-06  create by zhijia
 =================================*/
namespace DLLibrary
{
    class StringHandler
    {
        #region ===替换字符串===
        /// <summary>
        /// 替换字符串
        /// </summary>
        /// <param name="oldstr">原字符串</param>
        /// <param name="replacestr">要处理掉的字符串</param>
        /// <param name="newstr">替换的新字符串 默认为空</param>
        public static string replacestr(string oldstr,string replacestr,string newstr="")
        {
            return oldstr.Replace(replacestr, newstr);
        }
        #endregion
    }
}
