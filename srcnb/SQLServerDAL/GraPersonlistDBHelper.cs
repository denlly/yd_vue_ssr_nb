﻿using System;
using System.Text;
using IDAL;
using DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace SQLServerDAL
{
    public partial class GraPersonlistDBHelper : IGraPersonlist
    {
        #region 【得到数据库总记录数】
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM GraPersonlistDB ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        #endregion

        #region 【分页获取数据列表】
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
            parameters[0].Value = "GraPersonlistDB";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPage", parameters, "ds");
        }
        #endregion

        #region 【批量删除】
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from GraPersonlistDB ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 【获得对象实体】
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.GraPersonlistDB GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,printbatch,gname,granum from GraPersonlistDB ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

           Model.GraPersonlistDB model = new Model.GraPersonlistDB();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["printbatch"] != null && ds.Tables[0].Rows[0]["printbatch"].ToString() != "")
                {
                    model.printbatch = ds.Tables[0].Rows[0]["printbatch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["gname"] != null && ds.Tables[0].Rows[0]["gname"].ToString() != "")
                {
                    model.gname = ds.Tables[0].Rows[0]["gname"].ToString();
                }
                if (ds.Tables[0].Rows[0]["granum"] != null && ds.Tables[0].Rows[0]["granum"].ToString() != "")
                {
                    model.granum = ds.Tables[0].Rows[0]["granum"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 【根据条件获得班级数据】
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,classname,addate ");
            strSql.Append(" FROM ClassDB ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion
    }
}
