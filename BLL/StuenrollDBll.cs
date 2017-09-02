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
    public partial class StuenrollDBll
    {
        private readonly IStuenrollDB dal = DataAccess.CreateStuenrollDB();
        public StuenrollDBll()
        { }

        #region 【根据自定条件获取数据列表】
        public DataSet GetList(string clumname, string strWhere)
        {
            return dal.GetList(clumname, strWhere);
        }
        #endregion

        #region 【获取数据库总记录数】
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere = "")
        {
            return dal.GetRecordCount(strWhere);
        }
        #endregion

        #region 【获的对象List集合】

        #region ===展示给用户的调用方法===
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<StuenrollDB> GetModelList(int PageSize, int PageIndex, string strWhere = "")
        {
            DataSet ds = GetList(PageSize, PageIndex, strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region ===dataset转换成list ===
        /// <summary>
        /// dataset转换成list 
        /// </summary>
        public List<StuenrollDB> DataTableToList(DataTable dt)
        {
            List<StuenrollDB> modelList = new List<StuenrollDB>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                StuenrollDB model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new StuenrollDB();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["stuname"] != null && dt.Rows[n]["stuname"].ToString() != "")
                    {
                        model.stuname = dt.Rows[n]["stuname"].ToString();
                    }
                    if (dt.Rows[n]["sex"] != null && dt.Rows[n]["sex"].ToString() != "")
                    {
                        model.sex = dt.Rows[n]["sex"].ToString();
                    }
                    if (dt.Rows[n]["Datebirth"] != null && dt.Rows[n]["Datebirth"].ToString() != "")
                    {
                        model.Datebirth = dt.Rows[n]["Datebirth"].ToString();
                    }
                    if (dt.Rows[n]["Hometown"] != null && dt.Rows[n]["Hometown"].ToString() != "")
                    {
                        model.Hometown = dt.Rows[n]["Hometown"].ToString();
                    }
                    if (dt.Rows[n]["Ethnic"] != null && dt.Rows[n]["Ethnic"].ToString() != "")
                    {
                        model.Ethnic = dt.Rows[n]["Ethnic"].ToString();
                    }
                    if (dt.Rows[n]["Education"] != null && dt.Rows[n]["Education"].ToString() != "")
                    {
                        model.Education = dt.Rows[n]["Education"].ToString();
                    }
                    if (dt.Rows[n]["Whenwork"] != null && dt.Rows[n]["Whenwork"].ToString() != "")
                    {
                        model.Whenwork = dt.Rows[n]["Whenwork"].ToString();
                    }
                    if (dt.Rows[n]["Whenjpart"] != null && dt.Rows[n]["Whenjpart"].ToString() != "")
                    {
                        model.Whenjpart = dt.Rows[n]["Whenjpart"].ToString();
                    }
                    if (dt.Rows[n]["Gradschprofe"] != null && dt.Rows[n]["Gradschprofe"].ToString() != "")
                    {
                        model.Gradschprofe = dt.Rows[n]["Gradschprofe"].ToString();
                    }
                    if (dt.Rows[n]["Workunitpos"] != null && dt.Rows[n]["Workunitpos"].ToString() != "")
                    {
                        model.Workunitpos = dt.Rows[n]["Workunitpos"].ToString();
                    }
                    if (dt.Rows[n]["StuPhone"] != null && dt.Rows[n]["StuPhone"].ToString() != "")
                    {
                        model.StuPhone = dt.Rows[n]["StuPhone"].ToString();
                    }
                    if (dt.Rows[n]["OrgPhone"] != null && dt.Rows[n]["OrgPhone"].ToString() != "")
                    {
                        model.OrgPhone = dt.Rows[n]["OrgPhone"].ToString();
                    }
                    if (dt.Rows[n]["WorkExpertra"] != null && dt.Rows[n]["WorkExpertra"].ToString() != "")
                    {
                        model.WorkExpertra = dt.Rows[n]["WorkExpertra"].ToString();
                    }
                    if (dt.Rows[n]["imgurl"] != null && dt.Rows[n]["imgurl"].ToString() != "")
                    {
                        model.imgurl = dt.Rows[n]["imgurl"].ToString();
                    }
                    if (dt.Rows[n]["ownerclass"] != null && dt.Rows[n]["ownerclass"].ToString() != "")
                    {
                        model.ownerclass = dt.Rows[n]["ownerclass"].ToString();
                    }
                    if (dt.Rows[n]["ownergroup"] != null && dt.Rows[n]["ownergroup"].ToString() != "")
                    {
                        model.ownergroup = dt.Rows[n]["ownergroup"].ToString();
                    }
                    if (dt.Rows[n]["oorderclass"] != null && dt.Rows[n]["oorderclass"].ToString() != "")
                    {
                        model.oorderclass = dt.Rows[n]["oorderclass"].ToString();
                    }
                    if (dt.Rows[n]["ownerdirection"] != null && dt.Rows[n]["ownerdirection"].ToString() != "")
                    {
                        model.ownerdirection = dt.Rows[n]["ownerdirection"].ToString();
                    }
                    if (dt.Rows[n]["owneraccount"] != null && dt.Rows[n]["owneraccount"].ToString() != "")
                    {
                        model.owneraccount = dt.Rows[n]["owneraccount"].ToString();
                    }
                    if (dt.Rows[n]["RoomNo"] != null && dt.Rows[n]["RoomNo"].ToString() != "")
                    {
                        model.RoomNo = dt.Rows[n]["RoomNo"].ToString();
                    }
                    if (dt.Rows[n]["Roomtelephone"] != null && dt.Rows[n]["Roomtelephone"].ToString() != "")
                    {
                        model.Roomtelephone = dt.Rows[n]["Roomtelephone"].ToString();
                    }
                    if (dt.Rows[n]["Gradcernum"] != null && dt.Rows[n]["Gradcernum"].ToString() != "")
                    {
                        model.Gradcernum = dt.Rows[n]["Gradcernum"].ToString();
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
        public StuenrollDB GetModel(int id)
        {
            return dal.GetModel(id);
        }
        #endregion

        #region 【修改一条数据】
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(StuenrollDB model)
        {
            return dal.Update(model);
        }
        #endregion

        #region 【删除一条数据】
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }
        #endregion

        #region 【添加一个学员】
        /// <summary>
        /// 增加一个学员
        /// </summary>
        public int Add(StuenrollDB model)
        {
            return dal.Add(model);
        }
        #endregion

        #region 【自定义修改数据】
        public bool Update(string idlist, string setvalue)
        {
            return dal.Update(idlist, setvalue);
        }
        #endregion

        #region 【导出学员EXCEL信息】
        public List<StuenrollDB> ExportExcel(string strWhere = "")
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion
    }
}
