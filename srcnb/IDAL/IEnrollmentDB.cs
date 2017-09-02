using System.Data;

namespace IDAL
{
    public interface IEnrollmentDB
    {
        #region 【获得数据库总记录数】
        /// <summary>
        /// 获得数据库总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        int GetRecordCount(string strWhere);
        #endregion

        #region 【获的对象List集合】
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        DataSet GetList(int PageSize, int PageIndex, string strWhere);
        #endregion

        #region 【数据删除】
        bool Delete(int id);
        bool DeleteList(string AccountIDlist);
        #endregion

        #region 【得到一个对象实体】
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Model.EnrollmentDB GetModel(int id);
        #endregion

        #region 【修改一条数据】
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Model.EnrollmentDB model);
        #endregion
    }
}
