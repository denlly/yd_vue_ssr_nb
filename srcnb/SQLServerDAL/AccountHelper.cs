using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace SQLServerDAL
{
    /// <summary>
    /// 数据访问类:Account
    /// </summary>
    public partial class AccountHelper : IAccount
    {
        public AccountHelper()
        { }

        #region ===测试增加一条数据===
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Account model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Account(");
            strSql.Append("UserName,Password)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@Password)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar),
					new SqlParameter("@Password", SqlDbType.NVarChar)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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

        #region ===得到数据库总计路数===
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Account ");
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

        #region ===分页获取数据列表===
        /// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
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
			parameters[0].Value = "Account";
			parameters[1].Value = "AccountID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPage", parameters, "ds");
		}
        #endregion

        #region 【查询用户是否存在】
        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void UserExist(Model.Account model,out Model.Account accmodel) 
        {
            Model.Account outmodel = new Model.Account();//返回集体数据专用项
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Password", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = DLLibrary.Common.Encrypt(model.Password);
            SqlDataReader sdr = DbHelperSQL.RunProcedure("UserExit", parameters);
            if (sdr.Read())
            {
                outmodel.AccountID = Convert.ToInt32(sdr["AccountID"].ToString());
                outmodel.UserName = sdr["UserName"].ToString();
                outmodel.UseRole = Convert.ToInt32(sdr["UseRole"].ToString()); ;
                outmodel.ooderclass = sdr["ooderclass"].ToString()==null?"":sdr["ooderclass"].ToString();//所属班次
                outmodel.ownerclass = sdr["ownerclass"].ToString()==null?"":sdr["ownerclass"].ToString();//所属班
                //outmodel.ownergroup = sdr["ownergroup"].ToString();//所属组
                accmodel = outmodel;
            }
            else
            {
                outmodel.AccountID = 0;
                outmodel.UserName = "无";
                outmodel.UseRole = -1 ;
                accmodel = outmodel;
            }
        }
        #endregion

        #region 【得到一个对象的实体】
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Account GetModel(int AccountID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AccountID,UserName,Password,UseRole,ownerclass,ownergroup,ooderclass from Account ");
            strSql.Append(" where AccountID=@AccountID");
            SqlParameter[] parameters = {
					new SqlParameter("@AccountID", SqlDbType.Int,4)
			};
            parameters[0].Value = AccountID;

            Model.Account model = new Model.Account();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AccountID"] != null && ds.Tables[0].Rows[0]["AccountID"].ToString() != "")
                {
                    model.AccountID = int.Parse(ds.Tables[0].Rows[0]["AccountID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null && ds.Tables[0].Rows[0]["UserName"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Password"] != null && ds.Tables[0].Rows[0]["Password"].ToString() != "")
                {
                    model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UseRole"] != null && ds.Tables[0].Rows[0]["UseRole"].ToString() != "")
                {
                    model.UseRole = int.Parse(ds.Tables[0].Rows[0]["UseRole"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ownerclass"] != null && ds.Tables[0].Rows[0]["ownerclass"].ToString() != "")
                {
                    model.ownerclass = ds.Tables[0].Rows[0]["ownerclass"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ownergroup"] != null && ds.Tables[0].Rows[0]["ownergroup"].ToString() != "")
                {
                    model.ownergroup = ds.Tables[0].Rows[0]["ownergroup"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ooderclass"] != null && ds.Tables[0].Rows[0]["ooderclass"].ToString() != "")
                {
                    model.ooderclass = ds.Tables[0].Rows[0]["ooderclass"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 【批量删除用户】
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string AccountIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Account ");
            strSql.Append(" where AccountID in (" + AccountIDlist + ")  ");
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

        
    }
}