using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;

namespace DALFactory
{
    /// <summary>
    /// Abstract Factory pattern to create the DAL。
    /// 如果在这里创建对象报错，请检查web.config里是否修改了<add key="DAL" value="Maticsoft.SQLServerDAL" />。
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        public DataAccess()
        { }

        #region CreateObject 将接口映射类写入缓存

        //不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch//(System.Exception ex)
            {
                //string str=ex.Message;// 记录错误日志
                return null;
            }

        }
        //使用缓存
        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            object objType = DataCache.GetCache(classNamespace);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                    DataCache.SetCache(classNamespace, objType);// 写入缓存
                }
                catch//(System.Exception ex)
                {
                    //string str=ex.Message;// 记录错误日志
                }
            }
            return objType;
        }
        #endregion

        #region ===创建account数据层接口===
        /// <summary>
        /// 创建用户数据层数据层接口。
        /// </summary>
        public static IDAL.IAccount CreateAccount()
        {
            string ClassNamespace = AssemblyPath + ".AccountHelper";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDAL.IAccount)objType;
        }
        #endregion

        #region ===创建orderclass数据接口===
        /// <summary>
        /// 创建班次数据层数据层接口。
        /// </summary>
        public static IDAL.IOrderclass CreateOrderclass()
        {
            string ClassNamespace = AssemblyPath + ".OrderclassHelper";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDAL.IOrderclass)objType;
        }
        #endregion

        #region ===创建class数据接口===
        /// <summary>
        /// 创建班级数据层数据层接口。
        /// </summary>
        public static IDAL.IClassDB CreateClassDB()
        {
            string ClassNamespace = AssemblyPath + ".ClassDBHelper";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDAL.IClassDB)objType;
        }
        #endregion

        #region ===创建CroupDB数据接口===
        /// <summary>
        /// 创建小组数据层数据层接口。
        /// </summary>
        public static IDAL.IGroupDB CreateCroupDB()
        {
            string ClassNamespace = AssemblyPath + ".GroupDBHelper";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDAL.IGroupDB)objType;
        }
        #endregion

        #region ===创建DirectionDB数据接口===
        /// <summary>
        /// 创建方向数据层数据层接口。
        /// </summary>
        public static IDAL.IDirectionDB CreateDirectionDB()
        {
            string ClassNamespace = AssemblyPath + ".DirectionDBHelper";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDAL.IDirectionDB)objType;
        }
        #endregion

        #region ===创建EnrollmentDB数据接口===
        /// <summary>
        /// 创建研究生数据层数据层接口。
        /// </summary>
        public static IDAL.IEnrollmentDB CreateEnrollmentDB()
        {
            string ClassNamespace = AssemblyPath + ".EnrollmentDBHelper";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDAL.IEnrollmentDB)objType;
        }
        #endregion

        #region ===创建StuenrollDB数据接口===
        /// <summary>
        /// 创建学员数据层数据层接口。
        /// </summary>
        public static IDAL.IStuenrollDB CreateStuenrollDB()
        {
            string ClassNamespace = AssemblyPath + ".StuenrollDBHelper";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDAL.IStuenrollDB)objType;
        }
        #endregion

        #region ===创建StuenrollDB数据接口===
        /// <summary>
        /// 创建学员数结业证数据层数据层接口。
        /// </summary>
        public static IDAL.IGraPersonlist CreateGraPersonlist()
        {
            string ClassNamespace = AssemblyPath + ".GraPersonlistDBHelper";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IDAL.IGraPersonlist)objType;
        }
        #endregion
    }
}
