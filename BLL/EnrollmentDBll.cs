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
    public partial class EnrollmentDBll
    {
        private readonly IEnrollmentDB dal = DataAccess.CreateEnrollmentDB();
        public EnrollmentDBll()
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
        public List<EnrollmentDB> GetModelList(int PageSize, int PageIndex, string strWhere = "")
        {
            DataSet ds = GetList(PageSize, PageIndex, strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region ===dataset转换成list ===
        /// <summary>
        /// dataset转换成list 
        /// </summary>
        public List<EnrollmentDB> DataTableToList(DataTable dt)
        {
            List<EnrollmentDB> modelList = new List<EnrollmentDB>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EnrollmentDB model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new EnrollmentDB();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["CandNum"] != null && dt.Rows[n]["CandNum"].ToString() != "")
                    {
                        model.CandNum = dt.Rows[n]["CandNum"].ToString();
                    }
                    if (dt.Rows[n]["stuname"] != null && dt.Rows[n]["stuname"].ToString() != "")
                    {
                        model.stuname = dt.Rows[n]["stuname"].ToString();
                    }
                    if (dt.Rows[n]["sex"] != null && dt.Rows[n]["sex"].ToString() != "")
                    {
                        model.sex = dt.Rows[n]["sex"].ToString();
                    }
                    if (dt.Rows[n]["age"] != null && dt.Rows[n]["age"].ToString() != "")
                    {
                        model.age = int.Parse(dt.Rows[n]["age"].ToString());
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
                    if (dt.Rows[n]["Marstatus"] != null && dt.Rows[n]["Marstatus"].ToString() != "")
                    {
                        model.Marstatus = dt.Rows[n]["Marstatus"].ToString();
                    }
                    if (dt.Rows[n]["Wage"] != null && dt.Rows[n]["Wage"].ToString() != "")
                    {
                        model.Wage = float.Parse(dt.Rows[n]["Wage"].ToString());
                    }
                    if (dt.Rows[n]["positions"] != null && dt.Rows[n]["positions"].ToString() != "")
                    {
                        model.positions = dt.Rows[n]["positions"].ToString();
                    }
                    if (dt.Rows[n]["Titles"] != null && dt.Rows[n]["Titles"].ToString() != "")
                    {
                        model.Titles = dt.Rows[n]["Titles"].ToString();
                    }
                    if (dt.Rows[n]["workunit"] != null && dt.Rows[n]["workunit"].ToString() != "")
                    {
                        model.workunit = dt.Rows[n]["workunit"].ToString();
                    }
                    if (dt.Rows[n]["MobileNum"] != null && dt.Rows[n]["MobileNum"].ToString() != "")
                    {
                        model.MobileNum = dt.Rows[n]["MobileNum"].ToString();
                    }
                    if (dt.Rows[n]["Unmaiadd"] != null && dt.Rows[n]["Unmaiadd"].ToString() != "")
                    {
                        model.Unmaiadd = dt.Rows[n]["Unmaiadd"].ToString();
                    }
                    if (dt.Rows[n]["Zipcode"] != null && dt.Rows[n]["Zipcode"].ToString() != "")
                    {
                        model.Zipcode = dt.Rows[n]["Zipcode"].ToString();
                    }
                    if (dt.Rows[n]["commadd"] != null && dt.Rows[n]["commadd"].ToString() != "")
                    {
                        model.commadd = dt.Rows[n]["commadd"].ToString();
                    }
                    if (dt.Rows[n]["Whenerework"] != null && dt.Rows[n]["Whenerework"].ToString() != "")
                    {
                        model.Whenerework = dt.Rows[n]["Whenerework"].ToString();
                    }
                    if (dt.Rows[n]["Whenerejpart"] != null && dt.Rows[n]["Whenerejpart"].ToString() != "")
                    {
                        model.Whenerejpart = dt.Rows[n]["Whenerejpart"].ToString();
                    }
                    if (dt.Rows[n]["Degree"] != null && dt.Rows[n]["Degree"].ToString() != "")
                    {
                        model.Degree = dt.Rows[n]["Degree"].ToString();
                    }
                    if (dt.Rows[n]["Graduatesch"] != null && dt.Rows[n]["Graduatesch"].ToString() != "")
                    {
                        model.Graduatesch = dt.Rows[n]["Graduatesch"].ToString();
                    }
                    if (dt.Rows[n]["Schoolsystem"] != null && dt.Rows[n]["Schoolsystem"].ToString() != "")
                    {
                        model.Schoolsystem = dt.Rows[n]["Schoolsystem"].ToString();
                    }
                    if (dt.Rows[n]["Professname"] != null && dt.Rows[n]["Professname"].ToString() != "")
                    {
                        model.Professname = dt.Rows[n]["Professname"].ToString();
                    }
                    if (dt.Rows[n]["GraduationYear"] != null && dt.Rows[n]["GraduationYear"].ToString() != "")
                    {
                        model.GraduationYear = dt.Rows[n]["GraduationYear"].ToString();
                    }
                    if (dt.Rows[n]["Politheoryscore"] != null && dt.Rows[n]["Politheoryscore"].ToString() != "")
                    {
                        model.Politheoryscore = float.Parse(dt.Rows[n]["Politheoryscore"].ToString());
                    }
                    if (dt.Rows[n]["Journalscore"] != null && dt.Rows[n]["Journalscore"].ToString() != "")
                    {
                        model.Journalscore = float.Parse(dt.Rows[n]["Journalscore"].ToString());
                    }
                    if (dt.Rows[n]["Englishscore"] != null && dt.Rows[n]["Englishscore"].ToString() != "")
                    {
                        model.Englishscore = float.Parse(dt.Rows[n]["Englishscore"].ToString());
                    }
                    if (dt.Rows[n]["Eqscores"] != null && dt.Rows[n]["Eqscores"].ToString() != "")
                    {
                        model.Eqscores = float.Parse(dt.Rows[n]["Eqscores"].ToString());
                    }
                    if (dt.Rows[n]["Totalscore"] != null && dt.Rows[n]["Totalscore"].ToString() != "")
                    {
                        model.Totalscore = float.Parse(dt.Rows[n]["Totalscore"].ToString());
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
        public Model.EnrollmentDB GetModel(int id)
        {

            return dal.GetModel(id);
        }
        #endregion

        #region 【修改一条数据】
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.EnrollmentDB model)
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

        #region 【导出研究生数据】
        public List<EnrollmentDB> ExportExcel(string strWhere = "")
        { 
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion
    }
}
