using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace IDAL
{
    public interface IAccount
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Model.Account model);

        #region 【获得数据库总记录数】
        /// <summary>
        /// 获得数据库总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        int GetRecordCount(string strWhere);
        #endregion

        #region 【判断用户是否存在】
        void UserExist(Model.Account model, out Model.Account accmodel);
        #endregion

        #region 【根据分页获得数据列表】
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        DataSet GetList(int PageSize, int PageIndex, string strWhere);
        #endregion

        #region 【得到一个对象实体】
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Model.Account GetModel(int AccountID);
        #endregion

        #region 【批量删除用户数据】
        bool DeleteList(string AccountIDlist);
        #endregion
    }
}
