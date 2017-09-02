using System;
using System.Text;
using IDAL;
using DBUtility;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace SQLServerDAL
{
    public partial class EnrollmentDBHelper : IEnrollmentDB
    {
        #region 【得到数据库总记录数】
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM EnrollmentDB ");
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
            parameters[0].Value = "EnrollmentDB";
            parameters[1].Value = "Totalscore";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 1;
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
            strSql.Append("delete from EnrollmentDB ");
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
        public EnrollmentDB GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,CandNum,stuname,sex,age,Datebirth,Hometown,Ethnic,Marstatus,Wage,positions,Titles,workunit,MobileNum,Unmaiadd,Zipcode,commadd,Whenerework,Whenerejpart,Degree,Graduatesch,Schoolsystem,Professname,GraduationYear,Politheoryscore,Journalscore,Englishscore,Eqscores,Totalscore,imgurl,ownerclass,ownergroup,oorderclass,ownerdirection,owneraccount from EnrollmentDB ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			EnrollmentDB model=new EnrollmentDB();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CandNum"]!=null && ds.Tables[0].Rows[0]["CandNum"].ToString()!="")
				{
					model.CandNum=ds.Tables[0].Rows[0]["CandNum"].ToString();
				}
				if(ds.Tables[0].Rows[0]["stuname"]!=null && ds.Tables[0].Rows[0]["stuname"].ToString()!="")
				{
					model.stuname=ds.Tables[0].Rows[0]["stuname"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sex"]!=null && ds.Tables[0].Rows[0]["sex"].ToString()!="")
				{
					model.sex=ds.Tables[0].Rows[0]["sex"].ToString();
				}
				if(ds.Tables[0].Rows[0]["age"]!=null && ds.Tables[0].Rows[0]["age"].ToString()!="")
				{
					model.age=int.Parse(ds.Tables[0].Rows[0]["age"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Datebirth"]!=null && ds.Tables[0].Rows[0]["Datebirth"].ToString()!="")
				{
					model.Datebirth=ds.Tables[0].Rows[0]["Datebirth"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Hometown"]!=null && ds.Tables[0].Rows[0]["Hometown"].ToString()!="")
				{
					model.Hometown=ds.Tables[0].Rows[0]["Hometown"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Ethnic"]!=null && ds.Tables[0].Rows[0]["Ethnic"].ToString()!="")
				{
					model.Ethnic=ds.Tables[0].Rows[0]["Ethnic"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Marstatus"]!=null && ds.Tables[0].Rows[0]["Marstatus"].ToString()!="")
				{
					model.Marstatus=ds.Tables[0].Rows[0]["Marstatus"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Wage"]!=null && ds.Tables[0].Rows[0]["Wage"].ToString()!="")
				{
					model.Wage=float.Parse(ds.Tables[0].Rows[0]["Wage"].ToString());
				}
				if(ds.Tables[0].Rows[0]["positions"]!=null && ds.Tables[0].Rows[0]["positions"].ToString()!="")
				{
					model.positions=ds.Tables[0].Rows[0]["positions"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Titles"]!=null && ds.Tables[0].Rows[0]["Titles"].ToString()!="")
				{
					model.Titles=ds.Tables[0].Rows[0]["Titles"].ToString();
				}
				if(ds.Tables[0].Rows[0]["workunit"]!=null && ds.Tables[0].Rows[0]["workunit"].ToString()!="")
				{
					model.workunit=ds.Tables[0].Rows[0]["workunit"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MobileNum"]!=null && ds.Tables[0].Rows[0]["MobileNum"].ToString()!="")
				{
					model.MobileNum=ds.Tables[0].Rows[0]["MobileNum"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Unmaiadd"]!=null && ds.Tables[0].Rows[0]["Unmaiadd"].ToString()!="")
				{
					model.Unmaiadd=ds.Tables[0].Rows[0]["Unmaiadd"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Zipcode"]!=null && ds.Tables[0].Rows[0]["Zipcode"].ToString()!="")
				{
					model.Zipcode=ds.Tables[0].Rows[0]["Zipcode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["commadd"]!=null && ds.Tables[0].Rows[0]["commadd"].ToString()!="")
				{
					model.commadd=ds.Tables[0].Rows[0]["commadd"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Whenerework"]!=null && ds.Tables[0].Rows[0]["Whenerework"].ToString()!="")
				{
					model.Whenerework=ds.Tables[0].Rows[0]["Whenerework"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Whenerejpart"]!=null && ds.Tables[0].Rows[0]["Whenerejpart"].ToString()!="")
				{
					model.Whenerejpart=ds.Tables[0].Rows[0]["Whenerejpart"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Degree"]!=null && ds.Tables[0].Rows[0]["Degree"].ToString()!="")
				{
					model.Degree=ds.Tables[0].Rows[0]["Degree"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Graduatesch"]!=null && ds.Tables[0].Rows[0]["Graduatesch"].ToString()!="")
				{
					model.Graduatesch=ds.Tables[0].Rows[0]["Graduatesch"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Schoolsystem"]!=null && ds.Tables[0].Rows[0]["Schoolsystem"].ToString()!="")
				{
					model.Schoolsystem=ds.Tables[0].Rows[0]["Schoolsystem"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Professname"]!=null && ds.Tables[0].Rows[0]["Professname"].ToString()!="")
				{
					model.Professname=ds.Tables[0].Rows[0]["Professname"].ToString();
				}
				if(ds.Tables[0].Rows[0]["GraduationYear"]!=null && ds.Tables[0].Rows[0]["GraduationYear"].ToString()!="")
				{
					model.GraduationYear=ds.Tables[0].Rows[0]["GraduationYear"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Politheoryscore"]!=null && ds.Tables[0].Rows[0]["Politheoryscore"].ToString()!="")
				{
					model.Politheoryscore=float.Parse(ds.Tables[0].Rows[0]["Politheoryscore"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Journalscore"]!=null && ds.Tables[0].Rows[0]["Journalscore"].ToString()!="")
				{
					model.Journalscore=float.Parse(ds.Tables[0].Rows[0]["Journalscore"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Englishscore"]!=null && ds.Tables[0].Rows[0]["Englishscore"].ToString()!="")
				{
					model.Englishscore=float.Parse(ds.Tables[0].Rows[0]["Englishscore"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Eqscores"]!=null && ds.Tables[0].Rows[0]["Eqscores"].ToString()!="")
				{
					model.Eqscores=float.Parse(ds.Tables[0].Rows[0]["Eqscores"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Totalscore"]!=null && ds.Tables[0].Rows[0]["Totalscore"].ToString()!="")
				{
					model.Totalscore=float.Parse(ds.Tables[0].Rows[0]["Totalscore"].ToString());
				}
				if(ds.Tables[0].Rows[0]["imgurl"]!=null && ds.Tables[0].Rows[0]["imgurl"].ToString()!="")
				{
					model.imgurl=ds.Tables[0].Rows[0]["imgurl"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ownerclass"]!=null && ds.Tables[0].Rows[0]["ownerclass"].ToString()!="")
				{
					model.ownerclass=ds.Tables[0].Rows[0]["ownerclass"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ownergroup"]!=null && ds.Tables[0].Rows[0]["ownergroup"].ToString()!="")
				{
					model.ownergroup=ds.Tables[0].Rows[0]["ownergroup"].ToString();
				}
				if(ds.Tables[0].Rows[0]["oorderclass"]!=null && ds.Tables[0].Rows[0]["oorderclass"].ToString()!="")
				{
					model.oorderclass=ds.Tables[0].Rows[0]["oorderclass"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ownerdirection"]!=null && ds.Tables[0].Rows[0]["ownerdirection"].ToString()!="")
				{
					model.ownerdirection=ds.Tables[0].Rows[0]["ownerdirection"].ToString();
				}
				if(ds.Tables[0].Rows[0]["owneraccount"]!=null && ds.Tables[0].Rows[0]["owneraccount"].ToString()!="")
				{
					model.owneraccount=ds.Tables[0].Rows[0]["owneraccount"].ToString();
				}
				return model;
			}
			else
			{
				return null;
			}
		}

        #endregion

        #region 【修改一条数据数据】
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EnrollmentDB model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update EnrollmentDB set ");
            strSql.Append("CandNum=@CandNum,");
            strSql.Append("stuname=@stuname,");
            strSql.Append("sex=@sex,");
            strSql.Append("age=@age,");
            strSql.Append("Datebirth=@Datebirth,");
            strSql.Append("Hometown=@Hometown,");
            strSql.Append("Ethnic=@Ethnic,");
            strSql.Append("Marstatus=@Marstatus,");
            strSql.Append("Wage=@Wage,");
            strSql.Append("positions=@positions,");
            strSql.Append("Titles=@Titles,");
            strSql.Append("workunit=@workunit,");
            strSql.Append("MobileNum=@MobileNum,");
            strSql.Append("Unmaiadd=@Unmaiadd,");
            strSql.Append("Zipcode=@Zipcode,");
            strSql.Append("commadd=@commadd,");
            strSql.Append("Whenerework=@Whenerework,");
            strSql.Append("Whenerejpart=@Whenerejpart,");
            strSql.Append("Degree=@Degree,");
            strSql.Append("Graduatesch=@Graduatesch,");
            strSql.Append("Schoolsystem=@Schoolsystem,");
            strSql.Append("Professname=@Professname,");
            strSql.Append("GraduationYear=@GraduationYear,");
            strSql.Append("Politheoryscore=@Politheoryscore,");
            strSql.Append("Journalscore=@Journalscore,");
            strSql.Append("Englishscore=@Englishscore,");
            strSql.Append("Eqscores=@Eqscores,");
            strSql.Append("Totalscore=@Totalscore,");
            strSql.Append("imgurl=@imgurl,");
            strSql.Append("ownerclass=@ownerclass,");
            strSql.Append("ownergroup=@ownergroup,");
            strSql.Append("oorderclass=@oorderclass,");
            strSql.Append("ownerdirection=@ownerdirection,");
            strSql.Append("owneraccount=@owneraccount");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@CandNum", SqlDbType.VarChar,100),
					new SqlParameter("@stuname", SqlDbType.NVarChar,50),
					new SqlParameter("@sex", SqlDbType.NVarChar,2),
					new SqlParameter("@age", SqlDbType.Int,4),
					new SqlParameter("@Datebirth", SqlDbType.NVarChar,10),
					new SqlParameter("@Hometown", SqlDbType.NVarChar,100),
					new SqlParameter("@Ethnic", SqlDbType.NVarChar,50),
					new SqlParameter("@Marstatus", SqlDbType.NVarChar,2),
					new SqlParameter("@Wage", SqlDbType.Float,8),
					new SqlParameter("@positions", SqlDbType.NVarChar,50),
					new SqlParameter("@Titles", SqlDbType.NVarChar,50),
					new SqlParameter("@workunit", SqlDbType.NVarChar,100),
					new SqlParameter("@MobileNum", SqlDbType.VarChar,50),
					new SqlParameter("@Unmaiadd", SqlDbType.NVarChar,100),
					new SqlParameter("@Zipcode", SqlDbType.VarChar,50),
					new SqlParameter("@commadd", SqlDbType.NVarChar,500),
					new SqlParameter("@Whenerework", SqlDbType.NVarChar,1000),
					new SqlParameter("@Whenerejpart", SqlDbType.NVarChar,1000),
					new SqlParameter("@Degree", SqlDbType.NVarChar,50),
					new SqlParameter("@Graduatesch", SqlDbType.NVarChar,200),
					new SqlParameter("@Schoolsystem", SqlDbType.NVarChar,50),
					new SqlParameter("@Professname", SqlDbType.NVarChar,50),
					new SqlParameter("@GraduationYear", SqlDbType.NVarChar,50),
					new SqlParameter("@Politheoryscore", SqlDbType.Float,8),
					new SqlParameter("@Journalscore", SqlDbType.Float,8),
					new SqlParameter("@Englishscore", SqlDbType.Float,8),
					new SqlParameter("@Eqscores", SqlDbType.Float,8),
					new SqlParameter("@Totalscore", SqlDbType.Float,8),
					new SqlParameter("@imgurl", SqlDbType.VarChar,50),
					new SqlParameter("@ownerclass", SqlDbType.NVarChar,50),
					new SqlParameter("@ownergroup", SqlDbType.NVarChar,50),
					new SqlParameter("@oorderclass", SqlDbType.NVarChar,50),
					new SqlParameter("@ownerdirection", SqlDbType.NVarChar,50),
					new SqlParameter("@owneraccount", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.CandNum;
            parameters[1].Value = model.stuname;
            parameters[2].Value = model.sex;
            parameters[3].Value = model.age;
            parameters[4].Value = model.Datebirth;
            parameters[5].Value = model.Hometown;
            parameters[6].Value = model.Ethnic;
            parameters[7].Value = model.Marstatus;
            parameters[8].Value = model.Wage;
            parameters[9].Value = model.positions;
            parameters[10].Value = model.Titles;
            parameters[11].Value = model.workunit;
            parameters[12].Value = model.MobileNum;
            parameters[13].Value = model.Unmaiadd;
            parameters[14].Value = model.Zipcode;
            parameters[15].Value = model.commadd;
            parameters[16].Value = model.Whenerework;
            parameters[17].Value = model.Whenerejpart;
            parameters[18].Value = model.Degree;
            parameters[19].Value = model.Graduatesch;
            parameters[20].Value = model.Schoolsystem;
            parameters[21].Value = model.Professname;
            parameters[22].Value = model.GraduationYear;
            parameters[23].Value = model.Politheoryscore;
            parameters[24].Value = model.Journalscore;
            parameters[25].Value = model.Englishscore;
            parameters[26].Value = model.Eqscores;
            parameters[27].Value = model.Totalscore;
            parameters[28].Value = model.imgurl;
            parameters[29].Value = model.ownerclass;
            parameters[30].Value = model.ownergroup;
            parameters[31].Value = model.oorderclass;
            parameters[32].Value = model.ownerdirection;
            parameters[33].Value = model.owneraccount;
            parameters[34].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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

        #region 【删除一条数据】
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from EnrollmentDB ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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

        #region 【获取数据库全部数据】
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,CandNum,stuname,sex,age,Datebirth,Hometown,Ethnic,Marstatus,Wage,positions,Titles,workunit,MobileNum,Unmaiadd,Zipcode,commadd,Whenerework,Whenerejpart,Degree,Graduatesch,Schoolsystem,Professname,GraduationYear,Politheoryscore,Journalscore,Englishscore,Eqscores,Totalscore,imgurl,ownerclass,ownergroup,oorderclass,ownerdirection,owneraccount ");
            strSql.Append(" FROM EnrollmentDB ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion
    }
}
