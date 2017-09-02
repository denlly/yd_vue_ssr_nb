#region

using System.Data;
using System;

#endregion

namespace DLLibrary
{
    /// <summary>
    ///   yuanzj 2012-02-15
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        ///   string型转换为int型
        /// </summary>
        /// <param name = "strValue">要转换的字符串</param>
        /// <param name = "defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int ToInt(this string strValue, int defValue)
        {
            if (string.IsNullOrEmpty(strValue))
            {
                return defValue;
            }

            int value;
            if (int.TryParse(strValue, out value))
            {
                return value;
            }

            return defValue;
        }

        /// <summary>
        /// string型转换为decimal型
        /// </summary>
        /// <param name = "strValue">要转换的字符串</param>
        /// <param name = "defValue">缺省值</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string strValue, decimal defValue)
        {
            if (string.IsNullOrEmpty(strValue))
            {
                return defValue;
            }

            decimal value;
            if (decimal.TryParse(strValue, out value))
            {
                return value;
            }

            return defValue;
        }

        /// <summary>
        /// string型转换为decimal型
        /// </summary>
        /// <param name = "strValue">要转换的字符串</param>
        /// <param name = "defValue">缺省值</param>
        /// <returns></returns>
        public static double ToDouble(this string strValue, double defValue)
        {
            if (string.IsNullOrEmpty(strValue))
            {
                return defValue;
            }

            double value;
            if (double.TryParse(strValue, out value))
            {
                return value;
            }

            return defValue;
        }

        /// <summary>
        /// string型转换为decimal型
        /// </summary>
        /// <param name = "strValue">要转换的字符串</param>
        /// <param name = "defValue">缺省值</param>
        /// <returns></returns>
        public static float ToFloat(this string strValue, float defValue)
        {
            if (string.IsNullOrEmpty(strValue))
            {
                return defValue;
            }

            float value;
            if (float.TryParse(strValue, out value))
            {
                return value;
            }

            return defValue;
        }

        /// <summary>
        /// DateTime型转换为ToDateTime型
        /// </summary>
        /// <param name = "strValue">要转换的字符串</param>
        /// <param name = "defValue">缺省值</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string strValue, DateTime defValue)
        {
            if (string.IsNullOrEmpty(strValue))
            {
                return defValue;
            }

            DateTime value;            
            if (DateTime.TryParse(strValue, out value))
            {
                return value;
            }

            return defValue;
        }
        /// <summary>
        /// 向指定字符串追加 指定字符串
        /// </summary>
        /// <param name="val"></param>
        /// <param name="Adds"></param>
        public static void AddTo(this string val,ref string Adds)
        {
            Adds += val;
        }
    }
}