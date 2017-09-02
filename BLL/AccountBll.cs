using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using DALFactory;
using System.Data;
using DataCache;
using Model;

namespace BLL
{
    public partial class AccountBll
    {
        private readonly IAccount dal = DataAccess.CreateAccount();
        public AccountBll()
        { }

        #region ===增加一条数据===
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Account model)
        {
            return dal.Add(model);
        }
        #endregion

        #region ===调用存储过程 最终生成的方法===

        #region ====给前台最终生成的方法===
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Account> GetModelList(int PageSize, int PageIndex, string strWhere="")
        {
            DataSet ds = GetList(PageSize, PageIndex, strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region ===对dataset数据列表转换===
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Account> DataTableToList(DataTable dt)
        {
            List<Account> modelList = new List<Account>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Account model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Account();
                    if (dt.Rows[n]["AccountID"] != null && dt.Rows[n]["AccountID"].ToString() != "")
                    {
                        model.AccountID = int.Parse(dt.Rows[n]["AccountID"].ToString());
                    }
                    if (dt.Rows[n]["UserName"] != null && dt.Rows[n]["UserName"].ToString() != "")
                    {
                        model.UserName = dt.Rows[n]["UserName"].ToString();
                    }
                    if (dt.Rows[n]["Password"] != null && dt.Rows[n]["Password"].ToString() != "")
                    {
                        model.Password = dt.Rows[n]["Password"].ToString();
                    }
                    if (dt.Rows[n]["UseRole"] != null && dt.Rows[n]["UseRole"].ToString() != "")
                    {
                        model.UseRole = int.Parse(dt.Rows[n]["UseRole"].ToString());
                    }
                    if (dt.Rows[n]["ownerclass"] != null && dt.Rows[n]["ownerclass"].ToString() != "")
                    {
                        model.ownerclass = dt.Rows[n]["ownerclass"].ToString();
                    }
                    if (dt.Rows[n]["ownergroup"] != null && dt.Rows[n]["ownergroup"].ToString() != "")
                    {
                        model.ownergroup = dt.Rows[n]["ownergroup"].ToString();
                    }
                    if (dt.Rows[n]["ooderclass"] != null && dt.Rows[n]["ooderclass"].ToString() != "")
                    {
                        model.ooderclass = dt.Rows[n]["ooderclass"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        #region ===调用存储过程 获得数据列表===
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            return dal.GetList(PageSize, PageIndex, strWhere);
        }
        #endregion

        #endregion

        #region ===获取数据库总记录数===
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere="")
        {
            #region 【缓存拿到数据库总记录数】
            //object objRecord = GeneralCache.GetCache("AccountRecord");
            //if (objRecord == null)
            //{
            //    try
            //    {
            //        objRecord = dal.GetRecordCount(strWhere);
            //        if (objRecord != null)
            //        {
            //            DateTime dt = DateTime.Now.AddMinutes(2); //当前时间
            //            TimeSpan ts = TimeSpan.Zero;
            //            GeneralCache.SetCache("AccountRecord", objRecord, dt, ts);
            //        }
            //    }
            //    catch { }
            //}
            //return Convert.ToInt32(objRecord);
            #endregion
            return dal.GetRecordCount(strWhere);
        }
        #endregion

        #region 【查询用户是否存在】
        public void UserExist(Model.Account model, out Model.Account accmodel) 
        {
            dal.UserExist(model,out accmodel);
        }
        #endregion

        #region 【得到一个对象实体】
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Account GetModel(int AccountID)
        {
            return dal.GetModel(AccountID);
        }
        #endregion

        #region 【批量删除用户】
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string AccountIDlist)
        {
            return dal.DeleteList(AccountIDlist);
        }
        #endregion

        
    }
}
