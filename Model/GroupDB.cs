using System;
using System.ComponentModel.DataAnnotations;
namespace Model
{
	/// <summary>
	/// GroupDB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class GroupDB
	{
		public GroupDB()
		{}
		#region Model
		private int _id;
		private string _grouname;
		private string _addate;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
        [Required]
		/// <summary>
		/// 
		/// </summary>
		public string grouname
		{
			set{ _grouname=value;}
			get{return _grouname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string addate
		{
			set{ _addate=value;}
			get{return _addate;}
		}
		#endregion Model

	}
}

