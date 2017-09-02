using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DALFactory;
using IDAL;
using System.Data;
using Model;

namespace BLL
{
    public partial class GraPersonlistDBll
    {
        private readonly IGraPersonlist dal = DataAccess.CreateGraPersonlist();
        public GraPersonlistDBll()
        { }

        #region ===获取数据库总记录数===
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere = "")
        {
            return dal.GetRecordCount(strWhere);
        }
        #endregion

        #region ===获的对象List集合===

        #region ===展示给用户的调用方法===
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GraPersonlistDB> GetModelList(int PageSize, int PageIndex, string strWhere = "")
        {
            DataSet ds = GetList(PageSize, PageIndex, strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region ===dataset转换成list ===
        /// <summary>
        /// dataset转换成list 
        /// </summary>
        public List<Model.GraPersonlistDB> DataTableToList(DataTable dt)
        {
            List<Model.GraPersonlistDB> modelList = new List<Model.GraPersonlistDB>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.GraPersonlistDB model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.GraPersonlistDB();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["printbatch"] != null && dt.Rows[n]["printbatch"].ToString() != "")
                    {
                        model.printbatch = dt.Rows[n]["printbatch"].ToString();
                    }
                    if (dt.Rows[n]["gname"] != null && dt.Rows[n]["gname"].ToString() != "")
                    {
                        model.gname = dt.Rows[n]["gname"].ToString();
                    }
                    if (dt.Rows[n]["granum"] != null && dt.Rows[n]["granum"].ToString() != "")
                    {
                        model.granum = dt.Rows[n]["granum"].ToString();
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

        #region 【批量删除数据】
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string AccountIDlist)
        {
            return dal.DeleteList(AccountIDlist);
        }
        #endregion

        #region 【得到一个对象实体】
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.GraPersonlistDB GetModel(int id)
        {
            return dal.GetModel(id);
        }
        #endregion

        #region 【获得dropdownlist列表】
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GraPersonlistDB> GetDropDownList(string strWhere = "")
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion
    }
}
