using System;
using System.Text;
using IDAL;
using DBUtility;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace SQLServerDAL
{
    public partial class StuenrollDBHelper : IStuenrollDB
    {
        #region 【得到数据库总记录数】
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM StuenrollDB ");
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
            parameters[0].Value = "StuenrollDB";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 1;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPage", parameters, "ds");
        }
        #endregion

        #region 【根据条件获得数据库记录】
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,stuname,sex,Datebirth,Hometown,Ethnic,Education,Whenwork,Whenjpart,Gradschprofe,Workunitpos,StuPhone,OrgPhone,WorkExpertra,imgurl,ownerclass,ownergroup,oorderclass,ownerdirection,owneraccount,RoomNo,Roomtelephone,Gradcernum ");
            strSql.Append(" FROM StuenrollDB ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 【批量删除】
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StuenrollDB ");
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
        public StuenrollDB GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,stuname,sex,Datebirth,Hometown,Ethnic,Education,Whenwork,Whenjpart,Gradschprofe,Workunitpos,StuPhone,OrgPhone,WorkExpertra,imgurl,ownerclass,ownergroup,oorderclass,ownerdirection,owneraccount,RoomNo,Roomtelephone,Gradcernum from StuenrollDB ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            StuenrollDB model = new StuenrollDB();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["stuname"] != null && ds.Tables[0].Rows[0]["stuname"].ToString() != "")
                {
                    model.stuname = ds.Tables[0].Rows[0]["stuname"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sex"] != null && ds.Tables[0].Rows[0]["sex"].ToString() != "")
                {
                    model.sex = ds.Tables[0].Rows[0]["sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Datebirth"] != null && ds.Tables[0].Rows[0]["Datebirth"].ToString() != "")
                {
                    model.Datebirth = ds.Tables[0].Rows[0]["Datebirth"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Hometown"] != null && ds.Tables[0].Rows[0]["Hometown"].ToString() != "")
                {
                    model.Hometown = ds.Tables[0].Rows[0]["Hometown"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Ethnic"] != null && ds.Tables[0].Rows[0]["Ethnic"].ToString() != "")
                {
                    model.Ethnic = ds.Tables[0].Rows[0]["Ethnic"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Education"] != null && ds.Tables[0].Rows[0]["Education"].ToString() != "")
                {
                    model.Education = ds.Tables[0].Rows[0]["Education"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Whenwork"] != null && ds.Tables[0].Rows[0]["Whenwork"].ToString() != "")
                {
                    model.Whenwork = ds.Tables[0].Rows[0]["Whenwork"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Whenjpart"] != null && ds.Tables[0].Rows[0]["Whenjpart"].ToString() != "")
                {
                    model.Whenjpart = ds.Tables[0].Rows[0]["Whenjpart"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Gradschprofe"] != null && ds.Tables[0].Rows[0]["Gradschprofe"].ToString() != "")
                {
                    model.Gradschprofe = ds.Tables[0].Rows[0]["Gradschprofe"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Workunitpos"] != null && ds.Tables[0].Rows[0]["Workunitpos"].ToString() != "")
                {
                    model.Workunitpos = ds.Tables[0].Rows[0]["Workunitpos"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StuPhone"] != null && ds.Tables[0].Rows[0]["StuPhone"].ToString() != "")
                {
                    model.StuPhone = ds.Tables[0].Rows[0]["StuPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrgPhone"] != null && ds.Tables[0].Rows[0]["OrgPhone"].ToString() != "")
                {
                    model.OrgPhone = ds.Tables[0].Rows[0]["OrgPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["WorkExpertra"] != null && ds.Tables[0].Rows[0]["WorkExpertra"].ToString() != "")
                {
                    model.WorkExpertra = ds.Tables[0].Rows[0]["WorkExpertra"].ToString();
                }
                if (ds.Tables[0].Rows[0]["imgurl"] != null && ds.Tables[0].Rows[0]["imgurl"].ToString() != "")
                {
                    model.imgurl = ds.Tables[0].Rows[0]["imgurl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ownerclass"] != null && ds.Tables[0].Rows[0]["ownerclass"].ToString() != "")
                {
                    model.ownerclass = ds.Tables[0].Rows[0]["ownerclass"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ownergroup"] != null && ds.Tables[0].Rows[0]["ownergroup"].ToString() != "")
                {
                    model.ownergroup = ds.Tables[0].Rows[0]["ownergroup"].ToString();
                }
                if (ds.Tables[0].Rows[0]["oorderclass"] != null && ds.Tables[0].Rows[0]["oorderclass"].ToString() != "")
                {
                    model.oorderclass = ds.Tables[0].Rows[0]["oorderclass"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ownerdirection"] != null && ds.Tables[0].Rows[0]["ownerdirection"].ToString() != "")
                {
                    model.ownerdirection = ds.Tables[0].Rows[0]["ownerdirection"].ToString();
                }
                if (ds.Tables[0].Rows[0]["owneraccount"] != null && ds.Tables[0].Rows[0]["owneraccount"].ToString() != "")
                {
                    model.owneraccount = ds.Tables[0].Rows[0]["owneraccount"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RoomNo"] != null && ds.Tables[0].Rows[0]["RoomNo"].ToString() != "")
                {
                    model.RoomNo = ds.Tables[0].Rows[0]["RoomNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Roomtelephone"] != null && ds.Tables[0].Rows[0]["Roomtelephone"].ToString() != "")
                {
                    model.Roomtelephone = ds.Tables[0].Rows[0]["Roomtelephone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Gradcernum"] != null && ds.Tables[0].Rows[0]["Gradcernum"].ToString() != "")
                {
                    model.Gradcernum = ds.Tables[0].Rows[0]["Gradcernum"].ToString();
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
        public bool Update(Model.StuenrollDB model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StuenrollDB set ");
            strSql.Append("stuname=@stuname,");
            strSql.Append("sex=@sex,");
            strSql.Append("Datebirth=@Datebirth,");
            strSql.Append("Hometown=@Hometown,");
            strSql.Append("Ethnic=@Ethnic,");
            strSql.Append("Education=@Education,");
            strSql.Append("Whenwork=@Whenwork,");
            strSql.Append("Whenjpart=@Whenjpart,");
            strSql.Append("Gradschprofe=@Gradschprofe,");
            strSql.Append("Workunitpos=@Workunitpos,");
            strSql.Append("StuPhone=@StuPhone,");
            strSql.Append("OrgPhone=@OrgPhone,");
            strSql.Append("WorkExpertra=@WorkExpertra,");
            strSql.Append("imgurl=@imgurl,");
            strSql.Append("ownerclass=@ownerclass,");
            strSql.Append("ownergroup=@ownergroup,");
            strSql.Append("oorderclass=@oorderclass,");
            strSql.Append("ownerdirection=@ownerdirection,");
            strSql.Append("owneraccount=@owneraccount,");
            strSql.Append("RoomNo=@RoomNo,");
            strSql.Append("Roomtelephone=@Roomtelephone,");
            strSql.Append("Gradcernum=@Gradcernum");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@stuname", SqlDbType.NVarChar,20),
					new SqlParameter("@sex", SqlDbType.NVarChar,4),
					new SqlParameter("@Datebirth", SqlDbType.NVarChar,50),
					new SqlParameter("@Hometown", SqlDbType.NVarChar,50),
					new SqlParameter("@Ethnic", SqlDbType.NVarChar,50),
					new SqlParameter("@Education", SqlDbType.NVarChar,20),
					new SqlParameter("@Whenwork", SqlDbType.NVarChar,50),
					new SqlParameter("@Whenjpart", SqlDbType.NVarChar,50),
					new SqlParameter("@Gradschprofe", SqlDbType.NVarChar,100),
					new SqlParameter("@Workunitpos", SqlDbType.NVarChar,100),
					new SqlParameter("@StuPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@OrgPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkExpertra", SqlDbType.NVarChar),
					new SqlParameter("@imgurl", SqlDbType.VarChar,50),
					new SqlParameter("@ownerclass", SqlDbType.NVarChar,50),
					new SqlParameter("@ownergroup", SqlDbType.NVarChar,50),
					new SqlParameter("@oorderclass", SqlDbType.NVarChar,50),
					new SqlParameter("@ownerdirection", SqlDbType.NVarChar,50),
					new SqlParameter("@owneraccount", SqlDbType.NVarChar,50),
					new SqlParameter("@RoomNo", SqlDbType.NVarChar,50),
					new SqlParameter("@Roomtelephone", SqlDbType.NVarChar,50),
					new SqlParameter("@Gradcernum", SqlDbType.VarChar,100),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.stuname;
            parameters[1].Value = model.sex;
            parameters[2].Value = model.Datebirth;
            parameters[3].Value = model.Hometown;
            parameters[4].Value = model.Ethnic;
            parameters[5].Value = model.Education;
            parameters[6].Value = model.Whenwork;
            parameters[7].Value = model.Whenjpart;
            parameters[8].Value = model.Gradschprofe;
            parameters[9].Value = model.Workunitpos;
            parameters[10].Value = model.StuPhone;
            parameters[11].Value = model.OrgPhone;
            parameters[12].Value = model.WorkExpertra;
            parameters[13].Value = model.imgurl;
            parameters[14].Value = model.ownerclass;
            parameters[15].Value = model.ownergroup;
            parameters[16].Value = model.oorderclass;
            parameters[17].Value = model.ownerdirection;
            parameters[18].Value = model.owneraccount;
            parameters[19].Value = model.RoomNo;
            parameters[20].Value = model.Roomtelephone;
            parameters[21].Value = model.Gradcernum;
            parameters[22].Value = model.id;

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

        #region 【根据自定义条件修改】
        /// <summary>
        /// 自定义条件更改数据
        /// </summary>
        public bool Update(string idlist,string setvalue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StuenrollDB set ");
            strSql.Append(setvalue);
            strSql.Append(" where id in("+idlist+")");
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

        #region 【删除一条数据】
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StuenrollDB ");
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

        #region 【保存一条数据】
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.StuenrollDB model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StuenrollDB(");
            strSql.Append("stuname,sex,Datebirth,Hometown,Ethnic,Education,Whenwork,Whenjpart,Gradschprofe,Workunitpos,StuPhone,OrgPhone,WorkExpertra,imgurl,ownerclass,ownergroup,oorderclass,ownerdirection,owneraccount,RoomNo,Roomtelephone,Gradcernum)");
            strSql.Append(" values (");
            strSql.Append("@stuname,@sex,@Datebirth,@Hometown,@Ethnic,@Education,@Whenwork,@Whenjpart,@Gradschprofe,@Workunitpos,@StuPhone,@OrgPhone,@WorkExpertra,@imgurl,@ownerclass,@ownergroup,@oorderclass,@ownerdirection,@owneraccount,@RoomNo,@Roomtelephone,@Gradcernum)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@stuname", SqlDbType.NVarChar,20),
					new SqlParameter("@sex", SqlDbType.NVarChar,4),
					new SqlParameter("@Datebirth", SqlDbType.NVarChar,50),
					new SqlParameter("@Hometown", SqlDbType.NVarChar,50),
					new SqlParameter("@Ethnic", SqlDbType.NVarChar,50),
					new SqlParameter("@Education", SqlDbType.NVarChar,20),
					new SqlParameter("@Whenwork", SqlDbType.NVarChar,50),
					new SqlParameter("@Whenjpart", SqlDbType.NVarChar,50),
					new SqlParameter("@Gradschprofe", SqlDbType.NVarChar,100),
					new SqlParameter("@Workunitpos", SqlDbType.NVarChar,100),
					new SqlParameter("@StuPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@OrgPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkExpertra", SqlDbType.NVarChar),
					new SqlParameter("@imgurl", SqlDbType.VarChar,50),
					new SqlParameter("@ownerclass", SqlDbType.NVarChar,50),
					new SqlParameter("@ownergroup", SqlDbType.NVarChar,50),
					new SqlParameter("@oorderclass", SqlDbType.NVarChar,50),
					new SqlParameter("@ownerdirection", SqlDbType.NVarChar,50),
					new SqlParameter("@owneraccount", SqlDbType.NVarChar,50),
					new SqlParameter("@RoomNo", SqlDbType.NVarChar,50),
					new SqlParameter("@Roomtelephone", SqlDbType.NVarChar,50),
					new SqlParameter("@Gradcernum", SqlDbType.VarChar,100)};
            parameters[0].Value = model.stuname;
            parameters[1].Value = model.sex;
            parameters[2].Value = model.Datebirth;
            parameters[3].Value = model.Hometown;
            parameters[4].Value = model.Ethnic;
            parameters[5].Value = model.Education;
            parameters[6].Value = model.Whenwork;
            parameters[7].Value = model.Whenjpart;
            parameters[8].Value = model.Gradschprofe;
            parameters[9].Value = model.Workunitpos;
            parameters[10].Value = model.StuPhone;
            parameters[11].Value = model.OrgPhone;
            parameters[12].Value = model.WorkExpertra;
            parameters[13].Value = model.imgurl;
            parameters[14].Value = model.ownerclass;
            parameters[15].Value = model.ownergroup;
            parameters[16].Value = model.oorderclass;
            parameters[17].Value = model.ownerdirection;
            parameters[18].Value = model.owneraccount;
            parameters[19].Value = model.RoomNo;
            parameters[20].Value = model.Roomtelephone;
            parameters[21].Value = model.Gradcernum;

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

        #region 【根据自定义条件获取数据】
        public DataSet GetList(string clumname, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  " + clumname + "");
            strSql.Append(" FROM StuenrollDB ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion 
    }
}
