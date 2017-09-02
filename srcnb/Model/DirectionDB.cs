using System;
using System.ComponentModel.DataAnnotations;
namespace Model
{
	/// <summary>
	/// DirectionDB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DirectionDB
	{
		public DirectionDB()
		{}
		#region Model
		private int _id;
		private string _direname;
        private string _addate;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
        [Required]
		/// <summary>
		/// 方向名称
		/// </summary>
		public string direname
		{
			set{ _direname=value;}
			get{return _direname;}
		}
        /// <summary>
        /// 添加日期
        /// </summary>
        public string addate
        {
            set { _addate = value; }
            get { return _addate; }
        }
		#endregion Model

	}
}

